using DTO;

namespace Repository
{
    public interface ICadastroRepository
    {
        Task<string> Teste();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida);

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

        Task<IEnumerable<ObraDto>> ListarObras();

        Task AlterarObra(ObraDto obra);

        Task IncluirObra(ObraDto obra);

        Task<IEnumerable<FaixaCbuqDto>> ListarFaixaCbuq();

        Task AlterarFaixaCbuq(FaixaCbuqDto faixaCbuq);

        Task IncluirFaixaCbuq(FaixaCbuqDto faixaCbuq);

        Task<IEnumerable<TipoCapDto>> ListarTipoCap();

        Task AlterarTipoCap(TipoCapDto tipoCap);

        Task IncluirTipoCap(TipoCapDto tipoCap);

        Task<IEnumerable<MaterialDto>> ListarMaterial();

        Task AlterarMaterial(MaterialDto material);

        Task IncluirMaterial(MaterialDto material);

        Task<IEnumerable<GrupoDto>> ListarGrupo();
    }
}
