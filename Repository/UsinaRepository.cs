﻿using Configurations;
using Dapper;
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

        public async Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario)
        {
            string sql = @"INSERT INTO encopav_entrada_usina (id_usina, data_entrada, numero_nota_fiscal, id_fornecedor, id_material, quantidade, valor_unitario, id_veiculo, posto_retirado, ticket_balanca, user_name, dthr) 
                            VALUES (@IdUsina, NOW(), @NumeroNotaFiscal, @IdFornecedor, @IdMaterial, @Quantidade, @ValorUnitario, @IdVeiculo, @PostoRetirado, @TicketBalanca, @Usuario, NOW());";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", entradaUsina.IdUsina, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@IdFornecedor", entradaUsina.IdFornecedor, DbType.Int32);
            parametros.Add("@IdMaterial", entradaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@Quantidade", entradaUsina.Quantidade, DbType.Decimal);
            parametros.Add("@ValorUnitario", entradaUsina.ValorUnitario, DbType.Decimal);
            parametros.Add("@IdVeiculo", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@PostoRetirado", entradaUsina.PostoRetirado, DbType.String);
            parametros.Add("@TicketBalanca", entradaUsina.TicketBalanca, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(int idUsina, DateTime dataEntradaInicio, DateTime dataEntradaFim)
        {
            string sql = @"SELECT a.id_entrada_usina as IdEntradaUsina, a.data_entrada as DataEntrada, a.numero_nota_fiscal as NumeroNotaFiscal, a.id_fornecedor as IdFornecedor, 
                                b.nome as NomeFornecedor, a.id_material as IdMaterial, c.nome as NomeMaterial, a.quantidade as Quantidade, a.valor_unitario as ValorUnitario, 
                                a.id_veiculo as IdVeiculo, d.placa as PlacaVeiculo, e.nome as Transportadora, a.posto_retirado as PostoRetirado, f.descricao as UnidadeMedida,
                                a.ticket_balanca as TicketBalanca, a.user_name as UserName
                            FROM encopav_entrada_usina a
                            LEFT JOIN encopav_fornecedor b
                            ON a.id_fornecedor = b.id_fornecedor
                            LEFT JOIN encopav_material c
                            ON a.id_material = c.id_material
                            LEFT JOIN encopav_veiculo d
                            ON a.id_veiculo = d.id_veiculo
                            LEFT JOIN encopav_fornecedor e
                            ON d.id_fornecedor = e.id_fornecedor
                            LEFT JOIN encopav_unidade_medida f
                            ON c.id_unidade_medida = f.id_unidade_medida
                            WHERE a.id_usina = @IdUsina
                            AND a.data_entrada BETWEEN @DataEntradaInicio AND @DataEntradaFim";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", idUsina, DbType.Int32);
            parametros.Add("@DataEntradaInicio", dataEntradaInicio, DbType.DateTime);
            parametros.Add("@DataEntradaFim", dataEntradaFim, DbType.DateTime);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<EntradaUsinaCompletaDto>(sql, parametros);
        }

        public async Task AlterarEntradaUsina(EntradaUsinaDto entradaUsina, string usuario)
        {
            string sqlHist = @"INSERT INTO encopav_entrada_usina_hist (id_entrada_usina, id_usina, data_entrada, numero_nota_fiscal, id_fornecedor, id_material, quantidade, valor_unitario, id_veiculo, posto_retirado, ticket_balanca, user_name, dthr) 
                            SELECT id_entrada_usina, id_usina, data_entrada, numero_nota_fiscal, id_fornecedor, id_material, quantidade, valor_unitario, id_veiculo, posto_retirado, ticket_balanca, user_name, dthr 
                            FROM encopav_entrada_usina
                            WHERE id_entrada_usina = @Id;";

            DynamicParameters parametrosHist = new();
            parametrosHist.Add("@Id", entradaUsina.IdEntradaUsina, DbType.Int32);

            string sql = @"UPDATE encopav_entrada_usina SET numero_nota_fiscal = @NumeroNotaFiscal, id_fornecedor = @IdFornecedor, id_material = @IdMaterial, 
                                quantidade = @Quantidade, valor_unitario = @ValorUnitario, id_veiculo = @IdVeiculo, posto_retirado = @PostoRetirado, 
                                ticket_balanca = @TicketBalanca, user_name = @Usuario, dthr = NOW()
                            WHERE id_entrada_usina = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Id", entradaUsina.IdEntradaUsina, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@IdFornecedor", entradaUsina.IdFornecedor, DbType.Int32);
            parametros.Add("@IdMaterial", entradaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@Quantidade", entradaUsina.Quantidade, DbType.Decimal);
            parametros.Add("@ValorUnitario", entradaUsina.ValorUnitario, DbType.Decimal);
            parametros.Add("@IdVeiculo", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@PostoRetirado", entradaUsina.PostoRetirado, DbType.String);
            parametros.Add("@TicketBalanca", entradaUsina.TicketBalanca, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sqlHist, parametrosHist);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina, string usuario)
        {
            string sql = @"INSERT INTO encopav_saida_usina (id_usina, data_saida, id_material, id_veiculo, numero_nota_fiscal, ticket_balanca, peso_entrada, peso_bruto, peso_liquido, id_obra, id_trecho, id_faixa_cbuq, user_name, dthr) 
                            VALUES (@IdUsina, NOW(), @IdMaterial, @IdVeiculo, @NumeroNotaFiscal, @TicketBalanca, @PesoEntrada, @PesoBruto, @PesoLiquido, @IdObra, @IdTrecho, @IdFaixaCbuq, @Usuario, NOW());";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", entradaUsina.IdUsina, DbType.Int32);
            parametros.Add("@IdMaterial", entradaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@IdVeiculo", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@TicketBalanca", entradaUsina.TicketBalanca, DbType.String);
            parametros.Add("@PesoEntrada", entradaUsina.PesoEntrada, DbType.Decimal);
            parametros.Add("@PesoBruto", entradaUsina.PesoBruto, DbType.Decimal);
            parametros.Add("@PesoLiquido", entradaUsina.PesoLiquido, DbType.Decimal);
            parametros.Add("@IdObra", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@IdTrecho", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@IdFaixaCbuq", entradaUsina.IdFaixaCbuq, DbType.Int32);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap, string usuario)
        {
            string sql = @"INSERT INTO encopav_estoque_cap (id_usina, data_descarga, numero_nota_fiscal, pago_por, id_fornecedor, id_transportadora, volume, id_tipo_cap, valor, consumo_tanque, saldo_estoque, producao_cbuq, teor_real, observacao, user_name, dthr)
                            VALUES (@IdUsina, NOW(), @NumeroNotaFiscal, @PagoPor, @IdFornecedor, @IdTransportadora, @Volume, @IdTipoCap, @Valor, @ConsumoTanque, @SaldoEstoque, @ProducaoCbuq, @TeorReal, @Observacao, @Usuario, NOW());";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", estoqueCap.IdUsina, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", estoqueCap.NumeroNotaFiscal, DbType.String);
            parametros.Add("@PagoPor", estoqueCap.PagoPor, DbType.String);
            parametros.Add("@IdFornecedor", estoqueCap.IdFornecedor, DbType.Int32);
            parametros.Add("@IdTransportadora", estoqueCap.IdTransportadora, DbType.Int32);
            parametros.Add("@Volume", estoqueCap.Volume, DbType.Decimal);
            parametros.Add("@IdTipoCap", estoqueCap.IdTipoCap, DbType.Int32);
            parametros.Add("@Valor", estoqueCap.Valor, DbType.Decimal);
            parametros.Add("@ConsumoTanque", estoqueCap.ConsumoTanque, DbType.Decimal);
            parametros.Add("@SaldoEstoque", estoqueCap.SaldoEstoque, DbType.Decimal);
            parametros.Add("@ProducaoCbuq", estoqueCap.ProducaoCbuq, DbType.Decimal);
            parametros.Add("@TeorReal", estoqueCap.TeorReal, DbType.Decimal);
            parametros.Add("@Observacao", estoqueCap.Observacao, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task AlterarEstoqueCap(EstoqueCapDto estoqueCap, string usuario)
        {
            string sqlHist = @"INSERT INTO encopav_estoque_cap_hist (id_usina, data_descarga, numero_nota_fiscal, pago_por, id_fornecedor, volume, id_tipo_cap, valor, consumo_tanque, saldo_estoque, producao_cbuq, teor_real, observacao, user_name, dthr) 
                            SELECT id_usina, data_descarga, numero_nota_fiscal, pago_por, id_fornecedor, volume, id_tipo_cap, valor, consumo_tanque, saldo_estoque, producao_cbuq, teor_real, observacao, user_name, dthr 
                            FROM encopav_estoque_cap
                            WHERE id_estoque_cap = @Id;";

            DynamicParameters parametrosHist = new();
            parametrosHist.Add("@Id", estoqueCap.IdEstoqueCap, DbType.Int32);

            string sql = @"UPDATE encopav_estoque_cap SET numero_nota_fiscal = @NumeroNotaFiscal, id_fornecedor = @IdFornecedor, id_transportadora = @IdTransportadora, pago_por = @PagoPor, 
                                volume = @Volume, valor = @Valor, id_tipo_cap = @IdTipoCap, consumo_tanque = @ConsumoTanque, saldo_estoque = @SaldoEstoque,
                                producao_cbuq = @ProducaoCbuq, teor_real = @TeorReal, observacao = @Observacao, user_name = @Usuario, dthr = NOW()
                            WHERE id_estoque_cap = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Id", estoqueCap.IdEstoqueCap, DbType.Int32);
            parametros.Add("@IdUsina", estoqueCap.IdUsina, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", estoqueCap.NumeroNotaFiscal, DbType.String);
            parametros.Add("@PagoPor", estoqueCap.PagoPor, DbType.String);
            parametros.Add("@IdFornecedor", estoqueCap.IdFornecedor, DbType.Int32);
            parametros.Add("@IdTransportadora", estoqueCap.IdTransportadora, DbType.Int32);
            parametros.Add("@Volume", estoqueCap.Volume, DbType.Decimal);
            parametros.Add("@IdTipoCap", estoqueCap.IdTipoCap, DbType.Int32);
            parametros.Add("@Valor", estoqueCap.Valor, DbType.Decimal);
            parametros.Add("@ConsumoTanque", estoqueCap.ConsumoTanque, DbType.Decimal);
            parametros.Add("@SaldoEstoque", estoqueCap.SaldoEstoque, DbType.Decimal);
            parametros.Add("@ProducaoCbuq", estoqueCap.ProducaoCbuq, DbType.Decimal);
            parametros.Add("@TeorReal", estoqueCap.TeorReal, DbType.Decimal);
            parametros.Add("@Observacao", estoqueCap.Observacao, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sqlHist, parametrosHist);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task<IEnumerable<EstoqueCapCompletoDto>> ListarEstoqueCap(int idUsina, DateTime DataDescargaInicio, DateTime DataDescargaFim)
        {
            string sql = @"SELECT a.id_estoque_cap as IdEstoqueCap, a.data_descarga as DataDescarga, a.numero_nota_fiscal as NumeroNotaFiscal, a.pago_por as PagoPor, 
                            a.id_fornecedor as IdFornecedor, b.nome as NomeFornecedor, a.id_transportadora as IdTransportadora, c.nome as NomeTransportadora, a.volume, a.valor, 
                            a.id_tipo_cap as IdTipoCap, d.nome as NomeTipoCap, a.consumo_tanque as ConsumoTanque, a.saldo_estoque as SaldoEstoque, a.producao_cbuq as ProducaoCbuq, 
                            a.teor_real as TeorReal, a.observacao, a.user_name as UserName
                            FROM encopav_estoque_cap a
                            LEFT JOIN encopav_fornecedor b
                            ON a.id_fornecedor = b.id_fornecedor
                            LEFT JOIN encopav_fornecedor c
                            ON a.id_transportadora = c.id_fornecedor
                            LEFT JOIN encopav_tipo_cap d
                            ON a.id_tipo_cap = d.id_tipo_cap
                            WHERE a.id_usina = @IdUsina
                            AND a.data_descarga BETWEEN @DataDescargaInicio AND @DataDescargaFim";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", idUsina, DbType.Int32);
            parametros.Add("@DataDescargaInicio", DataDescargaInicio, DbType.DateTime);
            parametros.Add("@DataDescargaFim", DataDescargaFim, DbType.DateTime);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<EstoqueCapCompletoDto>(sql, parametros);
        }

        public async Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(int idUsina, DateTime DataSaidaInicio, DateTime DataSaidaFim)
        {
            string sql = @"SELECT a.id_saida_usina as IdSaidaUsina, a.id_usina as IdUsina, a.data_saida as DataSaida, a.numero_nota_fiscal as NumeroNotaFiscal, a.id_material as IdMaterial, 
                                c.nome as NomeMaterial, a.id_veiculo as IdVeiculo, d.placa as PlacaVeiculo, e.nome as Transportadora, a.ticket_balanca as TicketBalanca, 
                                a.peso_entrada as PesoEntrada, a.peso_bruto as PesoBruto, a.peso_liquido as PesoLiquido, a.id_obra as IdObra, f.nome as NomeObra, 
                                a.id_trecho as IdTrecho, g.nome as NomeTrecho, a.id_faixa_cbuq as IdFaixaCbuq, h.nome as NomeFaixaCbuq, a.user_name as UserName
                            FROM encopav_saida_usina a
                            LEFT JOIN encopav_material c
                            ON a.id_material = c.id_material
                            LEFT JOIN encopav_veiculo d
                            ON a.id_veiculo = d.id_veiculo
                            LEFT JOIN encopav_fornecedor e
                            ON d.id_fornecedor = e.id_fornecedor
                            LEFT JOIN encopav_obra f
                            ON a.id_obra = f.id_obra
                            LEFT JOIN encopav_trecho g
                            ON a.id_trecho = g.id_trecho
                            LEFT JOIN encopav_faixa_cbuq h
                            ON a.id_faixa_cbuq = h.id_faixa_cbuq
                            WHERE a.id_usina = @IdUsina
                            AND a.data_saida BETWEEN @DataSaidaInicio AND @DataSaidaFim";

            DynamicParameters parametros = new();
            parametros.Add("@IdUsina", idUsina, DbType.Int32);
            parametros.Add("@DataSaidaInicio", DataSaidaInicio, DbType.DateTime);
            parametros.Add("@DataSaidaFim", DataSaidaFim, DbType.DateTime);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<SaidaUsinaCompletaDto>(sql, parametros);
        }

        public async Task AlterarSaidaUsina(SaidaUsinaDto saidaUsina, string usuario)
        {
            string sqlHist = @"INSERT INTO encopav_saida_usina_hist (id_saida_usina, id_usina, id_obra, id_trecho, id_faixa_cbuq, id_material, id_veiculo, data_saida, numero_nota_fiscal, ticket_balanca, peso_entrada, peso_bruto, peso_liquido, user_name, dthr)
                            SELECT id_saida_usina, id_usina, id_obra, id_trecho, id_faixa_cbuq, id_material, id_veiculo, data_saida, numero_nota_fiscal, ticket_balanca, peso_entrada, peso_bruto, peso_liquido, user_name, dthr
                            FROM encopav_saida_usina
                            WHERE id_saida_usina = @Id;";

            DynamicParameters parametrosHist = new();
            parametrosHist.Add("@Id", saidaUsina.IdSaidaUsina, DbType.Int32);

            string sql = @"UPDATE encopav_saida_usina SET numero_nota_fiscal = @NumeroNotaFiscal, id_obra = @IdObra, id_trecho = @IdTrecho, 
                                id_faixa_cbuq = @IdFaixaCbuq, id_material = @IdMaterial, id_veiculo = @IdVeiculo,
                                peso_entrada = @PesoEntrada, peso_bruto = @PesoBruto, peso_liquido = @PesoLiquido, 
                                ticket_balanca = @TicketBalanca, user_name = @Usuario, dthr = NOW()
                            WHERE id_saida_usina = @Id;";

            DynamicParameters parametros = new();
            parametros.Add("@Id", saidaUsina.IdSaidaUsina, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", saidaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@IdObra", saidaUsina.IdObra, DbType.Int32);
            parametros.Add("@IdTrecho", saidaUsina.IdTrecho, DbType.Int32);
            parametros.Add("@IdFaixaCbuq", saidaUsina.IdFaixaCbuq, DbType.Int32);
            parametros.Add("@IdMaterial", saidaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@IdVeiculo", saidaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@PesoEntrada", saidaUsina.PesoEntrada, DbType.Decimal);
            parametros.Add("@PesoBruto", saidaUsina.PesoBruto, DbType.Decimal);
            parametros.Add("@PesoLiquido", saidaUsina.PesoLiquido, DbType.Decimal);
            parametros.Add("@TicketBalanca", saidaUsina.TicketBalanca, DbType.String);
            parametros.Add("@Usuario", usuario, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sqlHist, parametrosHist);
            await conexao.ExecuteAsync(sql, parametros);
        }

    }
}
