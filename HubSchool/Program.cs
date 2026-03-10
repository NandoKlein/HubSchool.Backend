using HubSchool.Configurations;
using HubSchool.Repositories;
using HubSchool.Repositories.Impl;
using HubSchool.Services;
using HubSchool.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddRouteConfig();

builder.Services.AddCorsConfiguration(builder.Configuration);

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IAlunoServices, AlunoServicesImpl>();
builder.Services.AddScoped<IProfessorServices, ProfessorServicesImpl>();
builder.Services.AddScoped<ITurmaServices, TurmaServicesImpl>();
builder.Services.AddScoped<IAulaServices, AulaServicesImpl>();
builder.Services.AddScoped<IHomeworkServices, HomeworkServicesImpl>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IAuteticadorRepository<>), typeof(AuteticadorRepository<>));
builder.Services.AddScoped<ITurmaAlunosRepository, TurmaAlunosRepository>();
builder.Services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
builder.Services.AddScoped<IHomeworkRepository, HomeworkRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseAuthorization();
app.UseCorsConfiguration(builder.Configuration);

app.MapControllers();

app.UseSwaggerSpecification();
app.UseScalarConfiguration();

app.Run();
