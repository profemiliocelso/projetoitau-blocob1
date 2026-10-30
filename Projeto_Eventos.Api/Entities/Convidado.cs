namespace Projeto_Eventos.Api.Entities
{
    public class Convidado
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
