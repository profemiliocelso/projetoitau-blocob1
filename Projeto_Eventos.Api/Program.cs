using Microsoft.EntityFrameworkCore;
using Projeto_Eventos.Api.Context;
using Projeto_Eventos.Api.Context.Startup;
using Projeto_Eventos.Api.Handlers;
using Projeto_Eventos.Api.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
ConfigurationManager config = builder.Configuration;

builder.Services.AddDbContext<EventoContext>(options => options.UseSqlServer(config.GetConnectionString("EventosConnection")));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<ConvidadoService>();
builder.Services.AddScoped<InscricaoService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "API para Gestão de Eventos",
            Description = "Nesta API é possível gerenciar eventos, convidados e inscrições"
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();
app.UseExceptionHandler();

// sincronizando com o banco de dados
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EventoContext>();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "API para Gestão de Eventos"));

}

//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
