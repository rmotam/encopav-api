using Microsoft.AspNetCore.Mvc;

namespace encopav_api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Teste()
        {
            return Ok("Rodando...");
        }
    }
}
