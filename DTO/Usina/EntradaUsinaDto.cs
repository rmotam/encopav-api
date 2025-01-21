namespace DTO.Usina
{
    public class EntradaUsinaDto
    {
        public int? IdEntradaUsina { get; set; }

        public int? IdUsina { get; set; }

        public string? NumeroNotaFiscal {  get; set; }

        public int IdFornecedor { get; set; }

        public int IdMaterial {  get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public int IdVeiculo { get; set; }

        public string? PostoRetirado { get; set; }

        public string? TicketBalanca { get; set; }

        public DateTime? DataEntrada { get; set; }

    }
}
