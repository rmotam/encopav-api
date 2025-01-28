using DTO.Usina;

namespace Repository
{
    public interface IUsinaRepository
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(int idUsina, DateTime dataEntradaInicio, DateTime dataEntradaFim);

        Task AlterarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina, string usuario);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(int idUsina, DateTime DataSaidaInicio, DateTime DataSaidaFim);

        Task AlterarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario);


    }
}
