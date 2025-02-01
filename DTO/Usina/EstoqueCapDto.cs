namespace DTO.Usina
{
    public class EstoqueCapDto
    {
        public int IdEstoqueCap { get; set; }
        public int IdUsina { get; set; }

        public DateTime? DataDescarga { get; set; }

        public string? NumeroNotaFiscal { get; set; }

        public string? PagoPor { get; set; }

        public int IdFornecedor { get; set; }

        public int IdTransportadora { get; set; }

        public decimal Volume { get; set; }

        public int IdTipoCap { get; set; }

        public decimal Valor { get; set; }

        public decimal ConsumoTanque { get; set; }

        public decimal SaldoEstoque { get; set; }

        public decimal ProducaoCbuq { get; set; }

        public decimal TeorReal { get; set; }

        public string? Observacao { get; set; }

        public string? UserName { get; set; }
    }
}
