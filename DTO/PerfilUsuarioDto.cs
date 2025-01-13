namespace DTO
{
    public class PerfilUsuarioDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public bool Listar { get; set; }
        public bool Incluir { get; set; }
        public bool Alterar { get; set; }
        public bool Excluir { get; set; }
    }
}
