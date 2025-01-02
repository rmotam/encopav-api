using DTO.Usina;
using Org.BouncyCastle.Asn1.Esf;
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

        public async Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina) => await _usinaRepository.RegistrarEntradaUsina(entradaUsina);

        public async Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina) => await _usinaRepository.RegistrarSaidaUsina(saidaUsina);

        public async Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap) => await _usinaRepository.RegistrarEstoqueCap(estoqueCap);

        public async Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataMovimento)
        {
            DateTime apenasData = dataMovimento.Date;

            DateTime dataEntradaFim = apenasData.AddDays(1).AddTicks(-1);

            return await _usinaRepository.ListarEntradaUsina(apenasData, dataEntradaFim);
        }

        public async Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime dataMovimento) => await _usinaRepository.ListarSaidaUsina(dataMovimento);
    }
}
