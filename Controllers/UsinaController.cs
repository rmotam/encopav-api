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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> RegistrarEntradaUsina([FromBody] EntradaUsinaDto entradaUsina)
        {
            try
            {
                await _usinaService.RegistrarEntradaUsina(entradaUsina);

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
                await _usinaService.RegistrarSaidaUsina(saidaUsina);

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
                await _usinaService.RegistrarEstoqueCap(estoqueCap);

                return Ok("Estoque CAP registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
