using DTO.Usina;

namespace Services
{
    public interface IUsinaService
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataMovimento);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime dataMovimento);
    }
}
