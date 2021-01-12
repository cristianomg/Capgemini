using Com.Capgemini.Domain.Interfaces.Repositories;
using Com.Capgemini.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IProdutoRepository _produtoRepository;
        public ImportacaoController(IImportacaoService importacaoService,
            IProdutoRepository produtoRepository)
        {
            _importacaoService = importacaoService;
            _produtoRepository = produtoRepository;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var dados = await _produtoRepository.ObterTodos();
            return Ok(dados);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos(Guid id)
        {
            var dado = await _produtoRepository.ObterPorId(id);
            return  Ok(dado);
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
