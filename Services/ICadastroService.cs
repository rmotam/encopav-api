using DTO;

namespace Services
{
    public interface ICadastroService
    {
        Task<string> Teste();

        Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task<IEnumerable<FornecedorDto>> ListarFornecedor();

        Task IncluirFornecedor(FornecedorDto fornecedor);

        Task AlterarFornecedor(FornecedorDto fornecedor);

        Task<IEnumerable<TransportadoraDto>> ListarTransportadora();

        Task IncluirTransportadora(TransportadoraDto transportadora);

        Task AlterarTransportadora(TransportadoraDto transportadora);
    }
}
