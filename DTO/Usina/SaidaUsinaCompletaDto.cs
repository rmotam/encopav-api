﻿namespace DTO.Usina
{
    public class SaidaUsinaCompletaDto : SaidaUsinaDto
    {
        public int IdSaidaUsina {  get; set; }

        public string? NomeMaterial {  get; set; }

        public string? PlacaVeiculo { get; set; }

        public string? NomeObra {  get; set; }

        public string? NomeTrecho { get; set; }

        public string? NomeFaixaCbuq { get; set; }
    }
}