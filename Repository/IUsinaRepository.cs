using DTO.Usina;

namespace Repository
{
    public interface IUsinaRepository
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina);

        Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap);
    }
}
