using DTO;
using Repository;

namespace Services
{
    public class CadastroService : ICadastroService
    {
        private readonly ICadastroRepository _cadastroRepository;
        public CadastroService(ICadastroRepository cadastroRepository) 
        { 
            _cadastroRepository = cadastroRepository;
        }

        public async Task<string> Teste() => await _cadastroRepository.Teste();

        public async Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida() => await _cadastroRepository.ListarUnidadesMedida();

        public async Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida) => await _cadastroRepository.IncluirUnidadeMedida(unidadeMedida);

        public async Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida) => await _cadastroRepository.AlterarUnidadeMedida(unidadeMedida);

        public async Task<IEnumerable<FornecedorDto>> ListarFornecedor() => await _cadastroRepository.ListarFornecedor();

        public async Task IncluirFornecedor(FornecedorDto fornecedor) => await _cadastroRepository.IncluirFornecedor(fornecedor);

        public async Task AlterarFornecedor(FornecedorDto fornecedor) => await _cadastroRepository.AlterarFornecedor(fornecedor);

        public async Task<IEnumerable<TransportadoraDto>> ListarTransportadora() => await _cadastroRepository.ListarTransportadora();

        public async Task IncluirTransportadora(TransportadoraDto transportadora) => await _cadastroRepository.IncluirTransportadora(transportadora);

        public async Task AlterarTransportadora(TransportadoraDto transportadora) => await _cadastroRepository.AlterarTransportadora(transportadora);

        public async Task<IEnumerable<OrigemMaterialDto>> ListarOrigemMaterial() => await _cadastroRepository.ListarOrigemMaterial();

        public async Task IncluirOrigemMaterial(OrigemMaterialDto origemMaterial) => await _cadastroRepository.IncluirOrigemMaterial(origemMaterial);

        public async Task AlterarOrigemMaterial(OrigemMaterialDto origemMaterial) => await _cadastroRepository.AlterarOrigemMaterial(origemMaterial);

        public async Task<IEnumerable<VeiculoDto>> ListarVeiculo() => await _cadastroRepository.ListarVeiculo();

        public async Task IncluirVeiculo(VeiculoDto veiculo) => await _cadastroRepository.IncluirVeiculo(veiculo);

        public async Task AlterarVeiculo(VeiculoDto veiculo) => await _cadastroRepository.AlterarVeiculo(veiculo);

        public async Task<IEnumerable<ObraDto>> ListarObra() => await _cadastroRepository.ListarObras();

        public async Task IncluirObra(ObraDto obra) => await _cadastroRepository.IncluirObra(obra);

        public async Task AlterarObra(ObraDto obra) => await _cadastroRepository.AlterarObra(obra);
    }
}
