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

        public async Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina)
        {
            string sql = @"INSERT INTO encopav_entrada_usina (data_entrada, numero_nota_fiscal, id_fornecedor, id_material, quantidade, valor_unitario, id_veiculo, tipo_transporte) 
                            VALUES (CURDATE(), @NumeroNotaFiscal, @IdFornecedor, @IdMaterial, @Quantidade, @ValorUnitario, @IdVeiculo, @TipoTransporte);";

            DynamicParameters parametros = new();
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@IdFornecedor", entradaUsina.IdFornecedor, DbType.Int32);
            parametros.Add("@IdMaterial", entradaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@Quantidade", entradaUsina.Quantidade, DbType.String);
            parametros.Add("@ValorUnitario", entradaUsina.ValorUnitario, DbType.Decimal);
            parametros.Add("@IdVeiculo", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@TipoTransporte", entradaUsina.TipoTransporte, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina)
        {
            string sql = @"INSERT INTO encopav_saida_usina (data_saida, id_material, id_veiculo, numero_nota_fiscal, ticket_balanca, peso_entrada, peso_bruto, peso_liquido, id_obra, id_trecho, id_faixa_cbuq) 
                            VALUES (CURDATE(), @IdMaterial, @IdVeiculo, @NumeroNotaFiscal, @TicketBalanca, @PesoEntrada, @PesoBruto, @PesoLiquido, @IdObra, @IdTrecho, @IdFaixaCbuq);";

            DynamicParameters parametros = new();
            parametros.Add("@IdMaterial", entradaUsina.IdMaterial, DbType.Int32);
            parametros.Add("@IdVeiculo", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", entradaUsina.NumeroNotaFiscal, DbType.String);
            parametros.Add("@TicketBalanca", entradaUsina.TicketBalanca, DbType.String);
            parametros.Add("@PesoEntrada", entradaUsina.PesoEntrada, DbType.Decimal);
            parametros.Add("@PesoBruto", entradaUsina.PesoBruto, DbType.Decimal);
            parametros.Add("@PesoLiquido", entradaUsina.PesoLiquido, DbType.Decimal);
            parametros.Add("@IdObra", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@IdTrecho", entradaUsina.IdVeiculo, DbType.Int32);
            parametros.Add("@IdFaixaCbuq", entradaUsina.IdVeiculo, DbType.Int32);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap)
        {
            string sql = @"INSERT INTO encopav_estoque_cap (id_unidade_industrial, data_descarga, numero_nota_fiscal, pago_por, id_fornecedor, quantidade, id_tipo_cap, valor_pago, consumo_tanque, saldo_estoque, producao_usina, teor_consumo, horimetro_inicial, horimetro_final, observacao)
                            VALUES (@IdUnidadeInsdustrial, CURDATE(), @NumeroNotaFiscal, @PagoPor, @IdFornecedor, @Quantidade, @IdTipoCap, @ValorPago, @ConsumoTanque, @SaldoEstoque, @ProducaoUsina, @TeorConsumo, @HorimetroInicial, @HorimetroFinal, @Observacao);";

            DynamicParameters parametros = new();
            parametros.Add("@IdUnidadeInsdustrial", estoqueCap.IdUnidadeIndustrial, DbType.Int32);
            parametros.Add("@NumeroNotaFiscal", estoqueCap.NumeroNotaFiscal, DbType.String);
            parametros.Add("@PagoPor", estoqueCap.PagoPor, DbType.String);
            parametros.Add("@IdFornecedor", estoqueCap.IdFornecedor, DbType.Int32);
            parametros.Add("@Quantidade", estoqueCap.Quantidade, DbType.String);
            parametros.Add("@IdTipoCap", estoqueCap.IdTipoCap, DbType.Int32);
            parametros.Add("@ValorPago", estoqueCap.ValorPago, DbType.Decimal);
            parametros.Add("@ConsumoTanque", estoqueCap.ConsumoTanque, DbType.Decimal);
            parametros.Add("@SaldoEstoque", estoqueCap.SaldoEstoque, DbType.Decimal);
            parametros.Add("@ProducaoUsina", estoqueCap.ProducaoUsina, DbType.Decimal);
            parametros.Add("@TeorConsumo", estoqueCap.TeorConsumo, DbType.Decimal);
            parametros.Add("@HorimetroInicial", estoqueCap.HorimetroInicial, DbType.String);
            parametros.Add("@HorimetroFinal", estoqueCap.HorimetroFinal, DbType.String);
            parametros.Add("@Observacao", estoqueCap.Observacao, DbType.String);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            await conexao.ExecuteAsync(sql, parametros);
        }

        public async Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime dataMovimento)
        {
            string sql = @"SELECT a.id_saida_usina as IdSaidaUsina, a.data_saida as DataSaida, a.numero_nota_fiscal as NumeroNotaFiscal, a.id_material as IdMaterial, 
                                c.nome as NomeMaterial, a.id_veiculo as IdVeiculo, d.placa as PlacaVeiculo, e.nome as Transportadora, a.ticket_balanca as TicketBalanca, 
                                a.peso_entrada as PesoEntrada, a.peso_bruto as PesoBruto, a.peso_liquido as PesoLiquido, a.id_obra as IdObra, f.nome as NomeObra, 
                                a.id_trecho as IdTrecho, h.nome as NomeTrecho, a.id_faixa_cbuq as IdFaixaCbuq, h.nome as NomeFaixaCbuq
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
                            WHERE a.data_saida = @DataSaida";

            DynamicParameters parametros = new();
            parametros.Add("@Data", dataMovimento, DbType.DateTime);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<SaidaUsinaCompletaDto>(sql, parametros);
        }

        public async Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataMovimento)
        {
            string sql = @"SELECT a.id_entrada_usina as IdEntradaUsina, a.data_entrada as DataEntrada, a.numero_nota_fiscal as NumeroNotaFiscal, a.id_fornecedor as IdFornecedor, 
                                b.nome as NomeFornecedor, a.id_material as IdMaterial, c.nome as NomeMaterial, a.quantidade as Quantidade, a.valor_unitario as ValorUnitario, 
                                a.id_veiculo as IdVeiculo, d.placa as PlacaVeiculo, e.nome as Transportadora, a.tipo_transporte as TipoTransporte
                            FROM encopav_entrada_usina a
                            LEFT JOIN encopav_fornecedor b
                            ON a.id_fornecedor = b.id_fornecedor
                            LEFT JOIN encopav_material c
                            ON a.id_material = c.id_material
                            LEFT JOIN encopav_veiculo d
                            ON a.id_veiculo = d.id_veiculo
                            LEFT JOIN encopav_fornecedor e
                            ON d.id_fornecedor = e.id_fornecedor
                            WHERE a.data_entrada = @DataEntrada";

            DynamicParameters parametros = new();
            parametros.Add("@DataEntrada", dataMovimento, DbType.DateTime);

            using MySqlConnection conexao = new(_configuracao.MySQLConnectionString);
            return await conexao.QueryAsync<EntradaUsinaCompletaDto>(sql, parametros);
        }
    }
}