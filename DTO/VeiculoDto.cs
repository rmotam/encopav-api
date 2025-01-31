﻿namespace DTO
{
    public class VeiculoDto
    {
        public int Id { get; set; }

        public int IdFornecedor { get; set; }

        public string? NomeFornecedor { get; set; }

        public string? Modelo { get; set; }

        public string? Ano {  get; set; }

        public string Placa { get; set; }

        public string? Proprietario { get; set; }

        public string? Codigo { get; set; }
    }
}
