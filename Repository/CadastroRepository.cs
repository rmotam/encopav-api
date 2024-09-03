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
    }
}
