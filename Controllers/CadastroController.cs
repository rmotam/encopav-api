using encopav_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace encopav_api.Controllers
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
    }
}
