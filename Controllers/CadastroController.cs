using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Newtonsoft;
using Newtonsoft.Json;

namespace Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CadastroController : Controller
    {
        private readonly ICadastroService _cadastroService;
        private const string PERFIL_CADASTRO = "cadastro";

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpGet]
        public IActionResult Teste()
        {
            return Ok(Task.Run(() => _cadastroService.Teste()).Result);
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<GrupoDto>>> ListarGrupo()
        {
            var retorno = await _cadastroService.ListarGrupo();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        #region Unidade Medida

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaDto>>> ListarUnidadesMedida()
        {
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

            var retorno = await _cadastroService.ListarObra();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult<int>> IncluirObra([FromBody] ObraDto obra)
        {
            
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

                return await _cadastroService.IncluirObra(obra);
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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

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
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

            var retorno = await _cadastroService.ListarMaterial();

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

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
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

                await _cadastroService.AlterarMaterial(material);

                return Ok("Material alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Tipo Servico

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<TipoServicoDto>>> ListarTipoServico()
        {
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

            var retorno = await _cadastroService.ListarTipoServico();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpGet("{IdGrupo}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<TipoServicoDto>>> ListarTipoServico(int IdGrupo)
        {
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

            var retorno = await _cadastroService.ListarTipoServico(IdGrupo);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirTipoServico([FromBody] TipoServicoDto tipoServico)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

                await _cadastroService.IncluirTipoServico(tipoServico);

                return Ok("Tipo serviço incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarTipoServico([FromBody] TipoServicoDto tipoServico)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

                await _cadastroService.AlterarTipoServico(tipoServico);

                return Ok("Tipo serviço alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idTipoServico}/{ativo}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> AtivarDesativarTipoServico(int idTipoServico, bool ativo)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

                await _cadastroService.AtivarDesativarTipoServico(idTipoServico, ativo);

                string situacao = ativo ? "ativado" : "desativado";

                return Ok($"Tipo serviço {situacao} com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Trecho

        [HttpGet("{idObra}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<TrechoDto>>> ListarTrecho(int idObra)
        {
            var retorno = await _cadastroService.ListarTrecho(idObra);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirTrecho([FromBody] TrechoDto trecho)
        {
            try
            {
                await _cadastroService.IncluirTrecho(trecho);

                return Ok("Trecho incluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarTrecho([FromBody] TrechoDto trecho)
        {
            try
            {
                await _cadastroService.AlterarTrecho(trecho);

                return Ok("Trecho alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idTrecho}")]
        [Authorize("Bearer")]
        public async Task<ActionResult> ExcluirTrecho(int idTrecho)
        {
            try
            {
                await _cadastroService.ExcluirTrecho(idTrecho);

                return Ok("Trecho excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region Usina

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<UsinaDto>>> ListarUsina()
        {
            var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

            var perfil = ObterPerfil(permissao.Value);

            if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO)))
            {
                return Forbid();
            }

            var retorno = await _cadastroService.ListarUsina();

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> IncluirUsina([FromBody] UsinaDto usina)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Incluir))
                {
                    return Forbid();
                }

                var usuario = User.Identity?.Name;

                await _cadastroService.IncluirUsina(usina, usuario);

                return Ok("Usina incluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarUsina([FromBody] UsinaDto usina)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_CADASTRO) && x.Alterar))
                {
                    return Forbid();
                }

                await _cadastroService.AlterarUsina(usina);

                return Ok("Usina alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        private IEnumerable<PerfilUsuarioDto> ObterPerfil(string perfilJson) => JsonConvert.DeserializeObject<IEnumerable<PerfilUsuarioDto>>(perfilJson);

    }
}
