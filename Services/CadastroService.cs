using DTO;
using Repository;

namespace Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadastroRepository;
        public CadastroService(ICadastroRepository cadastroRepository) 
        { 
            _cadastroRepository = cadastroRepository;
        }

        public async Task<string> Teste() => await _cadastroRepository.Teste();

        public async Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida() => await _cadastroRepository.ListarUnidadesMedida();

        public async Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida) => await _cadastroRepository.IncluirUnidadeMedida(unidadeMedida);

        public async Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida) => await _cadastroRepository.AlterarUnidadeMedida(unidadeMedida);
    }
}
