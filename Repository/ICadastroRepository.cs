using DTO;

namespace Repository
{
    public interface ICadastroRepository
    {
        Task<string> Teste();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidade);

        Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida();
    }
}
