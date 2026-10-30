namespace Projeto_Eventos.Api.Exceptions
{
    public class RecursoNaoEncontradoException: Exception
    {
        public RecursoNaoEncontradoException(): base() { }

        public RecursoNaoEncontradoException(string msg) : base(msg) { }
        public RecursoNaoEncontradoException(string msg, Exception inner) : base(msg, inner) { }

    }
}
