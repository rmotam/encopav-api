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
            var retorno = await _cadastroService.ListarTransportadora();

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

        #region Origem Material

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<OrigemMaterialDto>>> ListarOrigemMaterial()
        {
            var retorno = await _cadastroService.ListarOrigemMaterial();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirOrigemMaterial([FromBody] OrigemMaterialDto origemMaterial)
        {
            try
            {
                await _cadastroService.IncluirOrigemMaterial(origemMaterial);

                return Ok("Origem material incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarOrigemMaterial([FromBody] OrigemMaterialDto origemMaterial)
        {
            try
            {
                await _cadastroService.AlterarOrigemMaterial(origemMaterial);

                return Ok("Origem material alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Veiculo

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<VeiculoDto>>> ListarVeiculo()
        {
            var retorno = await _cadastroService.ListarVeiculo();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirVeiculo([FromBody] VeiculoDto veiculo)
        {
            try
            {
                await _cadastroService.IncluirVeiculo(veiculo);

                return Ok("Veículo incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarVeiculo([FromBody] VeiculoDto veiculo)
        {
            try
            {
                await _cadastroService.AlterarVeiculo(veiculo);

                return Ok("Veículo alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Obra

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<ObraDto>>> ListarObra()
        {
            var retorno = await _cadastroService.ListarObra();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirObra([FromBody] ObraDto obra)
        {
            try
            {
                await _cadastroService.IncluirObra(obra);

                return Ok("Obra incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarObra([FromBody] ObraDto obra)
        {
            try
            {
                await _cadastroService.AlterarObra(obra);

                return Ok("Obra alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Faixa CBUQ

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<FaixaCbuqDto>>> ListarFaixaCbuq()
        {
            var retorno = await _cadastroService.ListarFaixaCbuq();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirFaixaCbuq([FromBody] FaixaCbuqDto faixaCbuq)
        {
            try
            {
                await _cadastroService.IncluirFaixaCbuq(faixaCbuq);

                return Ok("Faixa CBUQ incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarFaixaCbuq([FromBody] FaixaCbuqDto faixaCbuq)
        {
            try
            {
                await _cadastroService.AlterarFaixaCbuq(faixaCbuq);

                return Ok("Faixa CBUQ alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Tipo CAP

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<TipoCapDto>>> ListarTipoCap()
        {
            var retorno = await _cadastroService.ListarTipoCap();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirTipoCap([FromBody] TipoCapDto tipoCap)
        {
            try
            {
                await _cadastroService.IncluirTipoCap(tipoCap);

                return Ok("Tipo CAP incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarTipoCap([FromBody] TipoCapDto tipoCap)
        {
            try
            {
                await _cadastroService.AlterarTipoCap(tipoCap);

                return Ok("Tipo CAP alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Material

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> ListarMaterial()
        {
            var retorno = await _cadastroService.ListarTipoCap();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirMaterial([FromBody] MaterialDto material)
        {
            try
            {
                await _cadastroService.IncluirMaterial(material);

                return Ok("Material incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarMaterial([FromBody] MaterialDto material)
        {
            try
            {
                await _cadastroService.AlterarMaterial(material);

                return Ok("Material alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
