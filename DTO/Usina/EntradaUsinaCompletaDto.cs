namespace DTO.Usina
{
    public class EntradaUsinaCompletaDto : EntradaUsinaDto
    {
        public int IdEntradaUsina { get; set; }

        public string? NomeFornecedor { get; set; }

        public string? NomeMaterial { get; set; }

        public string? PlacaVeiculo { get; set; }

        public string? Transportadora { get; set; }

        public DateTime DataEntrada { get; set; }
    }
}
