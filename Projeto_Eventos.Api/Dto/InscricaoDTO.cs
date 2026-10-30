using System;

namespace Projeto_Eventos.Api.Dto
{
    public class InscricaoDTO
    {
        public int IdInscricao { get; set; }
        public string? Convidado { get; set; }
        public double Preco { get; set; }
        public DateTime DataInscricao { get; set; }
        public string? Evento { get; set; }
    }
}