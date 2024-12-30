using DTO.Usina;

namespace Services
{
    public interface IUsinaService
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina);

        Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataMovimento);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime dataMovimento);
    }
}
