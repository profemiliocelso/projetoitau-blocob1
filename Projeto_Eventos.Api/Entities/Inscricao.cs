namespace Projeto_Eventos.Api.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public int ConvidadoId { get; set; }
        public double Preco { get; set; }
        public DateTime DataInscricao { get; set; }
        public Evento? Evento { get; set; }
        public Convidado? Convidado { get; set; }

    }
}
