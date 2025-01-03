namespace DTO.Usina
{
    public class EntradaUsinaDto
    {
        public string? NumeroNotaFiscal {  get; set; }

        public int IdFornecedor { get; set; }

        public int IdMaterial {  get; set; }

        public string? Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public int IdVeiculo { get; set; }

        public string? TipoTransporte { get; set; }
    }
}
