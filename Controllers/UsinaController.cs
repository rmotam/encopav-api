using DTO;
using DTO.Usina;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsinaController : Controller
    {
        private readonly IUsinaService _usinaService;
        private const string PERFIL_SALA_TECNICA = "sala_tecnica";
        private const string PERFIL_OPERACAO_USINA = "operacao_usina";
        public UsinaController(IUsinaService usinaService)
        {
            _usinaService = usinaService;
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> RegistrarEntradaUsina([FromBody] EntradaUsinaDto entradaUsina)
        {
            try
            {
                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_SALA_TECNICA)) &&
                    !perfil.Any(x => x.Nome.Contains(PERFIL_OPERACAO_USINA)))
                {
                    return Forbid();
                }

                var usuario = User.Identity?.Name;

                await _usinaService.RegistrarEntradaUsina(entradaUsina, usuario);

                return Ok("Entrada registrada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarEntradaUsina([FromBody] EntradaUsinaDto entradaUsina)
        {
            try
            {
                var cadastradoHoje = entradaUsina.DataEntrada.Value.Date == DateTime.Today;

                var permissao = User.Claims.FirstOrDefault(x => x.Type == "perfil");

                var perfil = ObterPerfil(permissao.Value);
                
                var usuario = User.Identity?.Name;

                if (!perfil.Any(x => x.Nome.Contains(PERFIL_SALA_TECNICA)) && 
                    !(perfil.Any(x => x.Nome.Contains(PERFIL_OPERACAO_USINA)) && cadastradoHoje && usuario == entradaUsina.UserName))
                {
                    return Forbid();
                }

                await _usinaService.AlterarEntradaUsina(entradaUsina, usuario);

                return Ok("Entrada alterada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<EntradaUsinaCompletaDto>>> ListarEntradaUsina(int idUsina, DateTime dataMovimento)
        {
            var retorno = await _usinaService.ListarEntradaUsina(idUsina, dataMovimento);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> RegistrarSaidaUsina([FromBody] SaidaUsinaDto saidaUsina)
        {
            try
            {
                var usuario = User.Identity?.Name;

                await _usinaService.RegistrarSaidaUsina(saidaUsina, usuario);

                return Ok("Saída registrada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> RegistrarEstoqueCap([FromBody] EstoqueCapDto estoqueCap)
        {
            try
            {
                var usuario = User.Identity?.Name;

                await _usinaService.RegistrarEstoqueCap(estoqueCap, usuario);

                return Ok("Estoque CAP registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<SaidaUsinaCompletaDto>>> ListarSaidaUsina(int idUsina, DateTime dataMovimento)
        {
            var retorno = await _usinaService.ListarSaidaUsina(idUsina, dataMovimento);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        private IEnumerable<PerfilUsuarioDto> ObterPerfil(string perfilJson) => JsonConvert.DeserializeObject<IEnumerable<PerfilUsuarioDto>>(perfilJson);
    }
}
