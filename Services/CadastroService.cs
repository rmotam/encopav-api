using encopav_api.Repository;

namespace encopav_api.Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadastroRepository;
        public CadastroService(ICadastroRepository cadastroRepository) 
        { 
            _cadastroRepository = cadastroRepository;
        }

        public async Task<string> Teste() => await _cadastroRepository.Teste();
    }
}
