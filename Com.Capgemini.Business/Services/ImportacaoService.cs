using AutoMapper;
using Com.Capgemini.Business.Objetos;
using Com.Capgemini.Domain.Dtos;
using Com.Capgemini.Domain.Entidades;
using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Domain.Interfaces.Services;
using Com.Capgemini.Domain.Interfaces.UnitOfWork;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Capgemini.Business.Services
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly IImportacaoRepository _importacaoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public ImportacaoService(IImportacaoRepository importacaoRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _importacaoRepository = importacaoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<DtoErroImportacao>> Importar(MemoryStream memo)
        {
            var dados = ObterDadosExcel(memo);

            var erros = ObterErrosImportacao(dados);

            if (erros.Any())
                return erros;

            await IncluirDados(dados);

            return Enumerable.Empty<DtoErroImportacao>();

        }

        private IEnumerable<ProdutoExcel> ObterDadosExcel(MemoryStream memo)
        {
            var dados = new List<ProdutoExcel>();
            using (var package = new ExcelPackage(memo))
            {
                for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                {
                    var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                    for (int j = 2; j <= totalRows.Value; j++)
                    {
                        var leitura = new ProdutoExcel();
                        leitura.SetDtEntrada(package.Workbook.Worksheets[i].Cells[j, 1].Value);
                        leitura.SetNmProduto(package.Workbook.Worksheets[i].Cells[j, 2].Value);
                        leitura.SetQuantidade(package.Workbook.Worksheets[i].Cells[j, 3].Value);
                        leitura.SetVlUnitario(package.Workbook.Worksheets[i].Cells[j, 4].Value);

                        if (leitura.Validar())
                        {
                            dados.Add(leitura);
                        }
                    }
                }
            }
            return dados;


        }
        private List<DtoErroImportacao> ObterErrosImportacao(IEnumerable<ProdutoExcel> dados)
        {
            var listaErros = new List<DtoErroImportacao>();
            var linha = 1;
            foreach (var d in dados)
            {
                var validator = new ProdutoExcelValidator();
                var validacao = validator.Validate(d);
                if (!validacao.IsValid)
                {
                    listaErros.Add(new DtoErroImportacao
                    {
                        Linha = linha,
                        Columas = validacao.Errors.Select(x => x.ErrorMessage).ToList()
                    });
                }
                linha++;
            }
            return listaErros;
        }

        private async Task IncluirDados(IEnumerable<ProdutoExcel> dados)
        {
            var produtos = _mapper.Map<List<Produto>>(dados);
            var importacao = new Importacao
            {
                DtImportacao = DateTime.Now,
                Produtos = produtos,
            };
            _importacaoRepository.Inserir(importacao);
            await _uow.Commit();
        }
    }
}
