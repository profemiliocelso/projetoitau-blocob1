using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_Eventos.Api.Exceptions;

namespace Projeto_Eventos.Api.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {


            var (statusCode, titulo) = exception switch
            {
                RecursoNaoEncontradoException => (StatusCodes.Status404NotFound, "Recurso Não Localizado"),
                _ => (StatusCodes.Status500InternalServerError, $"Erro interno: {exception.Message}")
            };

            // Cria o payload de erro padronizado RFC 7807 (ProblemDetails)
            var resposta = new 
            {
                Status = statusCode,
                Descrição = exception.Message,
                Data = DateTime.Now.ToShortDateString(),
                //Instance = httpContext.Request.Path
            };

            //httpContext.Response.StatusCode = statusCode;

            // Escreve o JSON de retorno de forma assíncrona
            await httpContext.Response.WriteAsJsonAsync(resposta, cancellationToken);

            // Retorna 'true' para sinalizar que o erro já foi tratado e não deve subir na pipeline
            return true;
        }
    }
}
