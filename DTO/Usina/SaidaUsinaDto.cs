namespace DTO.Usina
{
    public class SaidaUsinaDto
    {
        public int? IdSaidaUsina { get; set; }

        public int? IdUsina { get; set; }
        public string? NumeroNotaFiscal { get; set; }

        public int IdMaterial { get; set; }

        public int IdVeiculo { get; set; }

        public string? TicketBalanca { get; set; }

        public int PesoEntrada { get; set; }

        public int PesoBruto { get; set; }

        public int PesoLiquido { get; set; }

        public int IdObra { get; set; }

        public int IdTrecho { get; set; }

        public int IdFaixaCbuq { get; set; }

        public DateTime? DataSaida { get; set; }
    }
}
