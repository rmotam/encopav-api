using Configurations;
using Dapper;
using DTO;
using DTO.Usina;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repository
{
    public class UsinaRepository : IUsinaRepository
    {
        private readonly ConfiguracaoBanco _configuracao;

        public UsinaRepository(ConfiguracaoBanco configuracao)
        {
            _configuracao = configuracao;
        }

        public async Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina)
        {
            string sql = "INSERT INTO encopav_unidade_medida (descricao) VALUES (@Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina)
        {
            string sql = "INSERT INTO encopav_unidade_medida (descricao) VALUES (@Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap)
        {
            string sql = "INSERT INTO encopav_unidade_medida (descricao) VALUES (@Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@NumeroNotaFiscal", estoqueCap.NumeroNotaFiscal, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }
    }
}
