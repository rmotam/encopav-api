using DTO;

namespace Repository
{
    public interface ICadastroRepository
    {
        Task<string> Teste();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidade);

        Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida();

        Task<IEnumerable<FornecedorDto>> ListarFornecedor();

        Task AlterarFornecedor(FornecedorDto fornecedor);

        Task IncluirFornecedor(FornecedorDto fornecedor);

        Task<IEnumerable<TransportadoraDto>> ListarTransportadora();

        Task AlterarTransportadora(TransportadoraDto transportadora);

        Task IncluirTransportadora(TransportadoraDto transportadora);

        Task<IEnumerable<OrigemMaterialDto>> ListarOrigemMaterial();

        Task AlterarOrigemMaterial(OrigemMaterialDto origemMaterial);

        Task IncluirOrigemMaterial(OrigemMaterialDto origemMaterial);

        Task<IEnumerable<VeiculoDto>> ListarVeiculo();

        Task AlterarVeiculo(VeiculoDto veiculo);

        Task IncluirVeiculo(VeiculoDto veiculo);
    }
}
