namespace DTO.Usina
{
    public class EntradaUsinaCompletaDto : EntradaUsinaDto
    {
        public string? NomeFornecedor { get; set; }

        public string? NomeMaterial { get; set; }

        public string? UnidadeMedida { get; set; }

        public string? PlacaVeiculo { get; set; }

        public string? Transportadora { get; set; }

        public decimal ValorTotal => Quantidade * ValorUnitario;

    }
}
