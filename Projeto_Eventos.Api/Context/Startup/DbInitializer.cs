namespace Projeto_Eventos.Api.Context.Startup
{
    public class DbInitializer
    {
        public static void Initialize(EventoContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
