using DTO.Usina;

namespace Services
{
    public interface IUsinaService
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task AlterarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(int idUsina, DateTime dataMovimento);

        Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);

        Task AlterarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);

        Task<IEnumerable<EstoqueCapCompletoDto>> ListarEstoqueCap(int idUsina, DateTime dataDescarga);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(int idUsina, DateTime dataMovimento);

        Task AlterarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario);
    }
}
