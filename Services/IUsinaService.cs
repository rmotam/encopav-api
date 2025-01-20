using DTO.Usina;

namespace Services
{
    public interface IUsinaService
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task AlterarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataMovimento);

        Task RegistrarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario);        

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime dataMovimento);
    }
}
