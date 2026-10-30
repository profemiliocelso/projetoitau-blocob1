using System;
using Projeto_Eventos.Api.Context;
using Projeto_Eventos.Api.Dao;
using Projeto_Eventos.Api.Entities;


namespace Projeto_Eventos.Api.Services;

public class ConvidadoService
{
    private GenericDao<Convidado> ConvidadoDao { get; set; }
    public ConvidadoService(EventoContext context)
    {
        this.ConvidadoDao = new GenericDao<Convidado>(context);
    }

    public void Incluir(Convidado convidado)
    {
        ConvidadoDao.Adicionar(convidado);
    }    
}
