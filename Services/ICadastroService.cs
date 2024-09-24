using DTO;

namespace Services
{
    public interface ICadastroService
    {
        Task<string> Teste();

        Task<IEnumerable<GrupoDto>> ListarGrupo();

        Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida();

        Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida);

        Task<IEnumerable<FornecedorDto>> ListarFornecedor();

        Task IncluirFornecedor(FornecedorDto fornecedor);

        Task AlterarFornecedor(FornecedorDto fornecedor);

        Task<IEnumerable<TransportadoraDto>> ListarTransportadora();

        Task IncluirTransportadora(TransportadoraDto transportadora);

        Task AlterarTransportadora(TransportadoraDto transportadora);

        Task<IEnumerable<OrigemMaterialDto>> ListarOrigemMaterial();

        Task IncluirOrigemMaterial(OrigemMaterialDto origemMaterial);

        Task AlterarOrigemMaterial(OrigemMaterialDto origemMaterial);

        Task<IEnumerable<VeiculoDto>> ListarVeiculo();

        Task IncluirVeiculo(VeiculoDto veiculo);

        Task AlterarVeiculo(VeiculoDto veiculo);

        Task<IEnumerable<ObraDto>> ListarObra();

        Task IncluirObra(ObraDto obra);

        Task AlterarObra(ObraDto obra);

        Task<IEnumerable<FaixaCbuqDto>> ListarFaixaCbuq();

        Task IncluirFaixaCbuq(FaixaCbuqDto faixaCbuq);

        Task AlterarFaixaCbuq(FaixaCbuqDto faixaCbuq);

        Task<IEnumerable<TipoCapDto>> ListarTipoCap();

        Task IncluirTipoCap(TipoCapDto tipoCap);

        Task AlterarTipoCap(TipoCapDto tipoCap);

        Task<IEnumerable<MaterialDto>> ListarMaterial();

        Task IncluirMaterial(MaterialDto material);

        Task AlterarMaterial(MaterialDto material);

        Task<IEnumerable<TipoServicoDto>> ListarTipoServico();

        Task<IEnumerable<TipoServicoDto>> ListarTipoServico(int IdGrupo);

        Task IncluirTipoServico(TipoServicoDto tipoServico);

        Task AlterarTipoServico(TipoServicoDto tipoServico);
    }
}
