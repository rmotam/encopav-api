namespace DTO
{
    public class TipoServicoDto
    {
        public int Id { get; set; }

        public int IdGrupo { get; set; }

        public string? Grupo { get; set; }

        public int IdUnidadeMedida { get; set; }

        public string? UnidadeMedida { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public bool Ativo {  get; set; }
    }
}
