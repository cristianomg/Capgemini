using AutoMapper;
using AutoMapper.QueryableExtensions;
using Com.Capgemini.Domain.Dtos;
using Com.Capgemini.Domain.Entidades;
using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Capgemini.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportacaoController : ControllerBase
    {
        private readonly IImportacaoService _importacaoService;
        private readonly IImportacaoRepository _importacaoRepository;

        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ImportacaoController(IImportacaoService importacaoService,
            IProdutoRepository produtoRepository,
            IImportacaoRepository importacaoRepository,
            IMapper mapper)
        {
            _importacaoService = importacaoService;
            _produtoRepository = produtoRepository;
            _importacaoRepository = importacaoRepository;
            _mapper = mapper;   
        }
        [Route("")]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var importacoes = _importacaoRepository.ObterTodos();
            return Ok(_mapper.ProjectTo<DtoImportacao>(importacoes));
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult ObterTodos(Guid id)
        {
            var dado =  _importacaoRepository.ObterPorId(id);
            var produtos = _produtoRepository.ObterTodos().Where(x => x.ImportacaoId == dado.Id);
            dado.Produtos = produtos.ToList();
            return Ok(_mapper.Map<DtoImportacao>(dado));
        }
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Importar(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                var errosImportacao = await _importacaoService.Importar(memoryStream);

                if (errosImportacao.Any())
                    return BadRequest(errosImportacao);
            }
            return Ok();
        }
    }
}
