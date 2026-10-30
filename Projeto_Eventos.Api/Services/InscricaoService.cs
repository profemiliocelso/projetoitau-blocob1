using System;
using Projeto_Eventos.Api.Context;
using Projeto_Eventos.Api.Dao;
using Projeto_Eventos.Api.Dto;
using Projeto_Eventos.Api.Entities;

namespace Projeto_Eventos.Api.Services;

public class InscricaoService
{
    private GenericDao<Inscricao> InscricaoDao { get; set; }
    private EventoContext Context {get; set;}

    public InscricaoService(EventoContext context)
    {
        this.InscricaoDao = new GenericDao<Inscricao>(context);
        this.Context = context;
    }
    public void Incluir(Inscricao inscricao)
    {
        InscricaoDao.Adicionar(inscricao);
    }

    public IEnumerable<InscricaoDTO> ListarInscricoes() {
        var lista = from e in Context.Eventos
                    join ins in Context.Inscricoes on e.Id equals ins.EventoId
                    join c in Context.Convidados on ins.ConvidadoId equals c.Id
                    select new InscricaoDTO
                    {
                        IdInscricao = ins.Id,
                        Evento = e.Descricao,
                        Convidado = c.Nome,
                        Preco = ins.Preco,
                        DataInscricao = ins.DataInscricao
                    };
        return lista.ToList();

    }
}
