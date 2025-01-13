using DTO;
using DTO.Usina;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsinaController : Controller
    {
        private readonly IUsinaService _usinaService;
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
                var usuario = User.Identity?.Name;

                await _usinaService.RegistrarEntradaUsina(entradaUsina, usuario);

                return Ok("Entrada registrada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<ActionResult<IEnumerable<EntradaUsinaCompletaDto>>> ListarEntradaUsina(DateTime dataMovimento)
        {
            var retorno = await _usinaService.ListarEntradaUsina(dataMovimento);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IEnumerable<SaidaUsinaCompletaDto>>> ListarSaidaUsina(DateTime dataMovimento)
        {
            var retorno = await _usinaService.ListarSaidaUsina(dataMovimento);

            if (retorno == null)
            {
                return NotFound();
            }

            return Ok(retorno);
        }
    }
}
