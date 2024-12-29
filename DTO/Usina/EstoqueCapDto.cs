namespace DTO.Usina
{
    public class EstoqueCapDto
    {
        public int IdUnidadeIndustrial {  get; set; }

        public DateTime DataDescarga { get; set; }

        public string NumeroNotaFiscal { get; set; }

        public bool PagoPor {  get; set; }

        public int IdFornecedor { get; set; }

        public string Quantidade { get; set; }

        public int IdTipoCap { get; set; }

        public decimal ValorPago { get; set; }

        public decimal ConsumoTanque { get; set; }

        public decimal SaldoEstoque { get; set; }

        public decimal ProducaoUsina { get; set; }

        public decimal TeorConsumo { get; set; }

        public string HorimetroInicial {  get; set; }

        public string HorimetroFinal { get; set; }

        public string Observacao { get; set; }
    }
}
