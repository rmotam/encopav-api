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

        public async Task<IEnumerable<GrupoDto>> ListarGrupo()
        {
            string sql = "SELECT id_grupo as id, nome FROM encopav_grupo;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<GrupoDto>(sql);
        }

        #region Unidade Medida

        public async Task<IEnumerable<UnidadeMedidaDto>> ListarUnidadesMedida()
        {
            string sql = "SELECT id_unidade_medida as id, descricao FROM encopav_unidade_medida;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<UnidadeMedidaDto>(sql);
        }

        public async Task AlterarUnidadeMedida(UnidadeMedidaDto unidadeMedida)
        {
            string sql = "UPDATE encopav_unidade_medida SET descricao = @Descricao WHERE id_unidade_medida = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Descricao", unidadeMedida.Descricao, DbType.String);
            parametros.Add("@Id", unidadeMedida.Id, DbType.Int32);

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
            string sql = "SELECT id_fornecedor as id, nome, cpf_cnpj as CpfCnpj, contato, endereco FROM encopav_fornecedor;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<FornecedorDto>(sql);
        }

        public async Task AlterarFornecedor(FornecedorDto fornecedor)
        {
            string sql = "UPDATE encopav_fornecedor SET nome = @Nome, cpf_cnpj = @CpfCnpj, contato = @Contato, endereco = @Endereco WHERE id_fornecedor = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", fornecedor.Nome, DbType.String);
            parametros.Add("@CpfCnpj", fornecedor.CpfCnpj, DbType.String);
            parametros.Add("@Contato", fornecedor.Contato, DbType.String);
            parametros.Add("@Endereco", fornecedor.Endereco, DbType.String);
            parametros.Add("@Id", fornecedor.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirFornecedor(FornecedorDto fornecedor)
        {
            string sql = "INSERT INTO encopav_fornecedor (nome, cpf_cnpj, contato, endereco) VALUES (@Nome, @CpfCnpj, @Contato, @Endereco);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", fornecedor.Nome, DbType.String);
            parametros.Add("@CpfCnpj", fornecedor.CpfCnpj, DbType.String);
            parametros.Add("@Contato", fornecedor.Contato, DbType.String);
            parametros.Add("@Endereco", fornecedor.Endereco, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Transportadora

        public async Task<IEnumerable<TransportadoraDto>> ListarTransportadora()
        {
            string sql = "SELECT id_transportadora as id, nome, cpf_cnpj as CpfCnpj FROM encopav_transportadora;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TransportadoraDto>(sql);
        }

        public async Task AlterarTransportadora(TransportadoraDto transportadora)
        {
            string sql = "UPDATE encopav_transportadora SET nome = @Nome, cpf_cnpj = @CpfCnpj WHERE id_transportadora = @Id;";

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

        #region Origem Material

        public async Task<IEnumerable<OrigemMaterialDto>> ListarOrigemMaterial()
        {
            string sql = "SELECT id_origem as id, nome, endereco, contato FROM encopav_origem;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<OrigemMaterialDto>(sql);
        }

        public async Task AlterarOrigemMaterial(OrigemMaterialDto origemMaterial)
        {
            string sql = "UPDATE encopav_origem SET nome = @Nome, endereco = @Endereco, contato = @Contato WHERE id_origem = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", origemMaterial.Nome, DbType.String);
            parametros.Add("@Endereco", origemMaterial.Endereco, DbType.String);
            parametros.Add("@Contato", origemMaterial.Contato, DbType.String);
            parametros.Add("@Id", origemMaterial.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirOrigemMaterial(OrigemMaterialDto origemMaterial)
        {
            string sql = "INSERT INTO encopav_origem (nome, endereco, contato) VALUES (@Nome, @Endereco, @Contato);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", origemMaterial.Nome, DbType.String);
            parametros.Add("@Endereco", origemMaterial.Endereco, DbType.String);
            parametros.Add("@Contato", origemMaterial.Contato, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Veiculo

        public async Task<IEnumerable<VeiculoDto>> ListarVeiculo()
        {
            string sql = @"SELECT a.id_veiculo as id, a.modelo, a.ano, a.placa, a.proprietario, a.id_fornecedor as IdFornecedor, b.nome as NomeFornecedor
                        FROM encopav_veiculo a
                        INNER JOIN encopav_fornecedor b
                        ON a.id_fornecedor = b.id_fornecedor;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<VeiculoDto>(sql);
        }

        public async Task AlterarVeiculo(VeiculoDto veiculo)
        {
            string sql = "UPDATE encopav_veiculo SET modelo = @Modelo, ano = @Ano, placa = @Placa, proprietario = @Proprietario WHERE id_veiculo = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Modelo", veiculo.Modelo, DbType.String);
            parametros.Add("@Ano", veiculo.Ano, DbType.String);
            parametros.Add("@Placa", veiculo.Placa, DbType.String);
            parametros.Add("@Proprietario", veiculo.Proprietario, DbType.String);
            parametros.Add("@Id", veiculo.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirVeiculo(VeiculoDto veiculo)
        {
            string sql = "INSERT INTO encopav_veiculo (id_fornecedor, modelo, ano, placa, proprietario) VALUES (@IdFornecedor, @Modelo, @Ano, @Placa, @Proprietario);";

            DynamicParameters parametros = new();
            parametros.Add("@IdFornecedor", veiculo.IdFornecedor, DbType.Int32);
            parametros.Add("@Modelo", veiculo.Modelo, DbType.String);
            parametros.Add("@Ano", veiculo.Ano, DbType.String);
            parametros.Add("@Placa", veiculo.Placa, DbType.String);
            parametros.Add("@Proprietario", veiculo.Proprietario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Obras

        public async Task<IEnumerable<ObraDto>> ListarObras()
        {
            string sql = "SELECT id_obra as id, numero, nome, endereco, data_inicio as DataInicio, data_termino as DataTermino, situacao FROM encopav_obra;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<ObraDto>(sql);
        }

        public async Task AlterarObra(ObraDto obra)
        {
            string sql = "UPDATE encopav_obra SET numero = @Numero, nome = @Nome, endereco = @Endereco, data_inicio = @DataInicio, data_termino = @DataTermino, situacao = @Situacao WHERE id_obra = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Numero", obra.Numero, DbType.String);
            parametros.Add("@Nome", obra.Nome, DbType.String);
            parametros.Add("@Endereco", obra.Endereco, DbType.String);
            parametros.Add("@DataInicio", obra.DataInicio, DbType.DateTime);
            parametros.Add("@DataTermino", obra.DataTermino, DbType.DateTime);
            parametros.Add("@Situacao", obra.Situacao, DbType.Boolean);
            parametros.Add("@Id", obra.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task<int> IncluirObra(ObraDto obra)
        {
            string sql = @"INSERT INTO encopav_obra (numero, nome, endereco, data_inicio, data_termino, situacao) VALUES (@Numero, @Nome, @Endereco, @DataInicio, @DataTermino, @Situacao); 
                        SELECT LAST_INSERT_ID();";

            DynamicParameters parametros = new();
            parametros.Add("@Numero", obra.Numero, DbType.String);
            parametros.Add("@Nome", obra.Nome, DbType.String);
            parametros.Add("@Endereco", obra.Endereco, DbType.String);
            parametros.Add("@DataInicio", obra.DataInicio, DbType.DateTime);
            parametros.Add("@DataTermino", obra.DataTermino, DbType.DateTime);
            parametros.Add("@Situacao", obra.Situacao, DbType.Boolean);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryFirstOrDefaultAsync<int>(sql, parametros);
        }

        #endregion

        #region Faixa CBUQ

        public async Task<IEnumerable<FaixaCbuqDto>> ListarFaixaCbuq()
        {
            string sql = "SELECT id_faixa_cbuq as id, nome, descricao FROM encopav_faixa_cbuq;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<FaixaCbuqDto>(sql);
        }

        public async Task AlterarFaixaCbuq(FaixaCbuqDto faixaCbuq)
        {
            string sql = "UPDATE encopav_faixa_cbuq SET nome = @Nome, descricao = @Descricao WHERE id_faixa_cbuq = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", faixaCbuq.Nome, DbType.String);
            parametros.Add("@Descricao", faixaCbuq.Descricao, DbType.String);
            parametros.Add("@Id", faixaCbuq.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirFaixaCbuq(FaixaCbuqDto faixaCbuq)
        {
            string sql = "INSERT INTO encopav_faixa_cbuq (nome, descricao) VALUES (@Nome, @Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", faixaCbuq.Nome, DbType.String);
            parametros.Add("@Descricao", faixaCbuq.Descricao, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Tipo CAP

        public async Task<IEnumerable<TipoCapDto>> ListarTipoCap()
        {
            string sql = "SELECT id_tipo_cap as id, nome, descricao FROM encopav_tipo_cap;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TipoCapDto>(sql);
        }

        public async Task AlterarTipoCap(TipoCapDto tipoCap)
        {
            string sql = "UPDATE encopav_tipo_cap SET nome = @Nome, descricao = @Descricao WHERE id_tipo_cap = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", tipoCap.Nome, DbType.String);
            parametros.Add("@Descricao", tipoCap.Descricao, DbType.String);
            parametros.Add("@Id", tipoCap.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirTipoCap(TipoCapDto tipoCap)
        {
            string sql = "INSERT INTO encopav_tipo_cap (nome, descricao) VALUES (@Nome, @Descricao);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", tipoCap.Nome, DbType.String);
            parametros.Add("@Descricao", tipoCap.Descricao, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Material

        public async Task<IEnumerable<MaterialDto>> ListarMaterial()
        {
            string sql = @"SELECT a.id_material as id, a.nome, a.descricao, a.id_unidade_medida as idUnidadeMedida, b.descricao as descricaoUnidadeMedida
                        FROM encopav_material a
                        INNER JOIN encopav_unidade_medida b
                        ON a.id_unidade_medida = b.id_unidade_medida;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<MaterialDto>(sql);
        }

        public async Task AlterarMaterial(MaterialDto material)
        {
            string sql = "UPDATE encopav_material SET nome = @Nome, descricao = @Descricao, id_unidade_medida = @IdUnidadeMedida WHERE id_material = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", material.Nome, DbType.String);
            parametros.Add("@Descricao", material.Descricao, DbType.String);
            parametros.Add("@IdUnidadeMedida", material.IdUnidadeMedida, DbType.Int32);
            parametros.Add("@Id", material.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirMaterial(MaterialDto material)
        {
            string sql = "INSERT INTO encopav_material (nome, descricao, id_unidade_medida) VALUES (@Nome, @Descricao, @IdUnidadeMedida);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", material.Nome, DbType.String);
            parametros.Add("@Descricao", material.Descricao, DbType.String);
            parametros.Add("@IdUnidadeMedida", material.IdUnidadeMedida, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Tipo Serviço

        public async Task<IEnumerable<TipoServicoDto>> ListarTipoServico()
        {
            string sql = @"SELECT id_tipo_servico as id, nome, descricao, id_grupo as IdGrupo, id_unidade_medida as IdUnidadeMedida, ativo 
                            FROM encopav_tipo_servico ORDER BY id_grupo;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TipoServicoDto>(sql);
        }

        public async Task<IEnumerable<TipoServicoDto>> ListarTipoServico(int IdGrupo)
        {
            string sql = @"SELECT a.id_tipo_servico as id, a.nome, a.descricao, a.id_grupo as IdGrupo, a.id_unidade_medida as IdUnidadeMedida, 
                                b.nome as Grupo, c.descricao as UnidadeMedida
                            FROM encopav_tipo_servico a
                            INNER JOIN encopav_grupo b
                                ON a.id_grupo = b.id_grupo
                            INNER JOIN encopav_unidade_medida c
                                ON a.id_unidade_medida = c.id_unidade_medida
                            WHERE a.id_grupo = @IdGrupo AND a.ativo = 1
                            ORDER BY a.nome;";

            DynamicParameters parametros = new();
            parametros.Add("@IdGrupo", IdGrupo, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TipoServicoDto>(sql, parametros);
        }

        public async Task AlterarTipoServico(TipoServicoDto tipoServico)
        {
            string sql = @"UPDATE encopav_tipo_servico SET nome = @Nome, descricao = @Descricao 
                            WHERE id_tipo_servico = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", tipoServico.Nome, DbType.String);
            parametros.Add("@Descricao", tipoServico.Descricao, DbType.String);
            parametros.Add("@IdGrupo", tipoServico.IdGrupo, DbType.Int32);
            parametros.Add("@IdUnidadeMedida", tipoServico.IdUnidadeMedida, DbType.Int32);
            parametros.Add("@Id", tipoServico.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task AtivarDesativarTipoServico(int idTipoServico, bool ativo)
        {
            string sql = @"UPDATE encopav_tipo_servico SET ativo = @Ativo
                            WHERE id_tipo_servico = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Ativo", ativo, DbType.Boolean);
            parametros.Add("@Id", idTipoServico, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirTipoServico(TipoServicoDto tipoServico)
        {
            string sql = @"INSERT INTO encopav_tipo_servico (id_grupo, id_unidade_medida, nome, descricao, ativo) 
                            VALUES (@IdGrupo, @IdUnidadeMedida, @Nome, @Descricao, 1);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", tipoServico.Nome, DbType.String);
            parametros.Add("@Descricao", tipoServico.Descricao, DbType.String);
            parametros.Add("@IdGrupo", tipoServico.IdGrupo, DbType.Int32);
            parametros.Add("@IdUnidadeMedida", tipoServico.IdUnidadeMedida, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Trecho

        public async Task<IEnumerable<TrechoDto>> ListarTrecho(int idObra)
        {
            string sql = "SELECT id_trecho as id, nome, descricao FROM encopav_trecho WHERE id_obra = @IdObra;";

            DynamicParameters parametros = new();
            parametros.Add("@IdObra", idObra, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<TrechoDto>(sql, parametros);
        }

        public async Task AlterarTrecho(TrechoDto trecho)
        {
            string sql = "UPDATE encopav_trecho SET nome = @Nome, descricao = @Descricao WHERE id_trecho = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", trecho.Nome, DbType.String);
            parametros.Add("@Descricao", trecho.Descricao, DbType.String);
            parametros.Add("@Id", trecho.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirTrecho(TrechoDto trecho)
        {
            string sql = "INSERT INTO encopav_trecho (nome, descricao, id_obra) VALUES (@Nome, @Descricao, @IdObra);";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", trecho.Nome, DbType.String);
            parametros.Add("@Descricao", trecho.Descricao, DbType.String);
            parametros.Add("@IdObra", trecho.IdObra, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task ExcluirTrecho(int idTrecho)
        {
            string sql = "DELETE FROM encopav_trecho WHERE id_trecho = @IdTrecho;";

            DynamicParameters parametros = new();
            parametros.Add("@IdTrecho", idTrecho, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion

        #region Usina

        public async Task<IEnumerable<UsinaDto>> ListarUsina()
        {
            string sql = "SELECT id_usina as id, nome FROM encopav_usina;";

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<UsinaDto>(sql);
        }

        public async Task AlterarUsina(UsinaDto usina)
        {
            string sql = "UPDATE encopav_usina SET nome = @Nome WHERE id_usina = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", usina.Nome, DbType.String);
            parametros.Add("@Id", usina.Id, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task IncluirUsina(UsinaDto usina, string usuario)
        {
            string sql = "INSERT INTO encopav_usina (nome, user_name, dthr) VALUES (@Nome, @Usuario, NOW());";

            DynamicParameters parametros = new();
            parametros.Add("@Nome", usina.Nome, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        #endregion
    }
}
