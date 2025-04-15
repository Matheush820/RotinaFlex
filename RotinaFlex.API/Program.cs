using MediatR;
using System.Reflection;
using RotinaFlex.Infra.Interfaces;
using RotinaFlex.Infra.Repositories.UsuarioRepositories;
using RotinaFlex.Infra.Repositories.RecompensaRepository;
using RotinaFlex.Infra.Repositories.RelatorioRepository;
using RotinaFlex.Infra.Repositories.TarefasRepositories;
using RotinaFlex.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using RotinaFlex.Application.CommandValidator.UsuarioCommandValidator;
using FluentValidation;
using RotinaFlex.Application.Behaviors;
using RotinaFlex.Application.QueryValidator.UsuarioQuery;
using RotinaFlex.Application.CommandValidator.TarefaCommandValidator;
using RotinaFlex.Application.QueryValidator.RelatorioQuery;
using RotinaFlex.Application.CommandValidator.RecompensaCommandValidator;
using RotinaFlex.Application.QueryValidator.RecompensaQuery.RecompensaQuery;
using RotinaFlex.Application.QueryValidator.TarefasQuery;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper - Registra todos os profiles da camada Application
builder.Services.AddAutoMapper(Assembly.Load("RotinaFlex.Application"));

// Repositórios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRecompensaRepository, RecompensaRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefasRepository>();

// Validator automático Usuario
builder.Services.AddValidatorsFromAssemblyContaining<CriarUsuarioCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarUsuarioCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeletarUsuarioCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ListarUsuarioIdQueryValidator>();

// Validator automático Tarefas
builder.Services.AddValidatorsFromAssemblyContaining<CriarTarefaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarTarefaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeletarTarefaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BuscarTarefaPorIdAsyncValidator>();

// Validator automático Relatório
builder.Services.AddValidatorsFromAssemblyContaining<GerarRelatorioQueryValidator>();

// Validator automático Recompensa
builder.Services.AddValidatorsFromAssemblyContaining<CriarRecompensaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ResgatarRecompensaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeletarRecompensaCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ListarRecompensaPorUsuarioIdQueryValidator>();

// Pipeline de validação
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("RotinaFlex.Application")));

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers (com serialização configurada corretamente)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
