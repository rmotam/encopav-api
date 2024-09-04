using Configurations;
using MySql.Data.MySqlClient;
using Dapper;
using DTO;
using System.Data;

namespace Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly ConfiguracaoBanco _configuracao;

        public CadastroRepository(ConfiguracaoBanco configuracao)
        {
            _configuracao = configuracao;
        }

        public async Task<string> Teste()
        {
            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync("Show Databases");

            return "Rodando";
        }

        #region Unidade Medida

        public async Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida()
        {
            string sql = "SELECT id_unidade as id, descricao FROM encopav_unidade_medida;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<UnidadeMedidaDto>(sql);
        }

        public async Task AlterarUnidadeMedida(UnidadeMedidaDto unidade)
        {
            string sql = "UPDATE encopav_unidade_medida SET descricao = @Descricao WHERE id_unidade = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Descricao", unidade.Descricao, DbType.String);
            parametros.Add("@Id", unidade.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirUnidadeMedida(UnidadeMedidaDto unidadeMedida)
        {
            string sql = "INSERT INTO encopav_unidade_medida (descricao) VALUES (@Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@Descricao", unidadeMedida.Descricao, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Fornecedor

        public async Task<IEnumerable<FornecedorDto>> ListarFornecedor()
        {
            string sql = "SELECT id_fornecedor as id, nome, cpf_cnpj as CpfCnpj FROM encopav_fornecedor;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<FornecedorDto>(sql);
        }

        public async Task AlterarFornecedor(FornecedorDto fornecedor)
        {
            string sql = "UPDATE encopav_fornecedor SET nome = @Nome, cpf_cnpj = @CpfCnpj WHERE id_fornecedor = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", fornecedor.Nome, DbType.String);
            parametros.Add("@CpfCnpj", fornecedor.CpfCnpj, DbType.String);
            parametros.Add("@Id", fornecedor.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirFornecedor(FornecedorDto fornecedor)
        {
            string sql = "INSERT INTO encopav_fornecedor (nome, cpf_cnpj) VALUES (@Nome, @CpfCnpj);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", fornecedor.Nome, DbType.String);
            parametros.Add("@CpfCnpj", fornecedor.CpfCnpj, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Transportadora

        public async Task<IEnumerable<TransportadoraDto>> ListarTransportadora()
        {
            string sql = "SELECT id_fornecedor as id, nome, cpf_cnpj as CpfCnpj FROM encopav_transportadora;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TransportadoraDto>(sql);
        }

        public async Task AlterarTransportadora(TransportadoraDto transportadora)
        {
            string sql = "UPDATE encopav_transportadora SET nome = @Nome, cpf_cnpj = @CpfCnpj WHERE id_fornecedor = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", transportadora.Nome, DbType.String);
            parametros.Add("@CpfCnpj", transportadora.CpfCnpj, DbType.String);
            parametros.Add("@Id", transportadora.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirTransportadora(TransportadoraDto transportadora)
        {
            string sql = "INSERT INTO encopav_transportadora (nome, cpf_cnpj) VALUES (@Nome, @CpfCnpj);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", transportadora.Nome, DbType.String);
            parametros.Add("@CpfCnpj", transportadora.CpfCnpj, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion
    }
}
