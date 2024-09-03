using DTO;

namespace Services
{
    public interface ICadastroService
    {
        Task<string> Teste();

        Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida);
    }
}
