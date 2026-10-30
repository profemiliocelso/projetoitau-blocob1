namespace Projeto_Eventos.Api.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
