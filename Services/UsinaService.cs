using DTO.Usina;
using Repository;

namespace Services
{
    public class UsinaService : IUsinaService
    {
        private readonly IUsinaRepository _usinaRepository;
        public UsinaService(IUsinaRepository usinaRepository)
        {
            _usinaRepository = usinaRepository;
        }

        public async Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario) => await _usinaRepository.RegistrarEntradaUsina(entradaUsina, usuario);
        
        public async Task AlterarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario) => await _usinaRepository.AlterarEntradaUsina(entradaUsina, usuario);

        public async Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(int idUsina, DateTime dataMovimento)
        {
            DateTime apenasData = dataMovimento.Date;

            DateTime dataEntradaFim = apenasData.AddDays(1).AddTicks(-1);

            return await _usinaRepository.ListarEntradaUsina(idUsina, apenasData, dataEntradaFim);
        }

        public async Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario) => await _usinaRepository.RegistrarSaidaUsina(saidaUsina, usuario);

        public async Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario) => await _usinaRepository.RegistrarEstoqueCap(estoqueCap, usuario);

        public async Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(int idUsina, DateTime dataMovimento)
        {
            DateTime apenasData = dataMovimento.Date;

            DateTime dataEntradaFim = apenasData.AddDays(1).AddTicks(-1);

            return await _usinaRepository.ListarSaidaUsina(idUsina, apenasData, dataEntradaFim);
        }
    }
}
