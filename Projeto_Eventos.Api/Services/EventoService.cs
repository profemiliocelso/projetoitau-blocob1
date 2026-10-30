using Projeto_Eventos.Api.Context;
using Projeto_Eventos.Api.Dao;
using Projeto_Eventos.Api.Entities;
using Projeto_Eventos.Api.Exceptions;

namespace Projeto_Eventos.Api.Services
{
    public class EventoService
    {
        private GenericDao<Evento> EventoDao {  get; set; }
        public EventoService(EventoContext context)
        {
            this.EventoDao = new GenericDao<Evento>(context);
        }

        public IEnumerable<Evento> Listar()
        {
            return EventoDao.Listar();
        }
        public void Incluir(Evento evento)
        {
            EventoDao.Adicionar(evento);
        }
        public void Alterar(int id, Evento evento)
        {
            bool existe = VerificarEvento(id);
            if (!existe)
            {
                throw new RecursoNaoEncontradoException($"Nenhum evento localizado com o id {id}");
            }
            evento.Id = id;
            EventoDao.Alterar(evento);
        }
        public void Remover(Evento evento)
        {
            EventoDao.Remover(evento);
        }
        public Evento? Buscar(int id)
        {
            return EventoDao.Buscar(id);
        }

        private bool VerificarEvento(int id)
        {
            return EventoDao.Context.Eventos.Any(e => e.Id == id);
        }
    }
}
