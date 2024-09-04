using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CadastroController : Controller
    {
        private readonly ICadastroService _cadastroService;
        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }


        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Teste()
        {
            return Ok(Task.Run(() => _cadastroService.Teste()).Result);
        }

        #region Unidade Medida

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaDto>>> ListarUnidadesMedida()
        {
            var retorno = await _cadastroService.ListarUnidadesMedida();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirUnidadeMedida([FromBody] UnidadeMedidaDto unidadeMedida)
        {
            try
            {
                await _cadastroService.IncluirUnidadeMedida(unidadeMedida);

                return Ok("Unidade medida incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarUnidadeMedida([FromBody] UnidadeMedidaDto unidadeMedida)
        {
            try
            {
                await _cadastroService.AlterarUnidadeMedida(unidadeMedida);

                return Ok("Unidade medida alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Fornecedor

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> ListarFornecedor()
        {
            var retorno = await _cadastroService.ListarFornecedor();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirFornecedor([FromBody] FornecedorDto fornecedor)
        {
            try
            {
                await _cadastroService.IncluirFornecedor(fornecedor);

                return Ok("Fornecedor incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarFornecedor([FromBody] FornecedorDto fornecedor)
        {
            try
            {
                await _cadastroService.AlterarFornecedor(fornecedor);

                return Ok("Fornecedor alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Transportadora

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<TransportadoraDto>>> ListarTransportadora()
        {
            var retorno = await _cadastroService.ListarFornecedor();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirTransportadora([FromBody] TransportadoraDto transportadora)
        {
            try
            {
                await _cadastroService.IncluirTransportadora(transportadora);

                return Ok("Transportadora incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarTransportadora([FromBody] TransportadoraDto transportadora)
        {
            try
            {
                await _cadastroService.AlterarTransportadora(transportadora);

                return Ok("Transportadora alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
