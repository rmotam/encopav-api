using DTO.Usina;

namespace Repository
{
    public interface IUsinaRepository
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina, string usuario);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime DataSaidaInicio, DateTime DataSaidaFim);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataEntradaInicio, DateTime dataEntradaFim);
    }
}
