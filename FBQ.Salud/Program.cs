using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Commands;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<FbqSaludDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Repository
builder.Services.AddTransient<IMedicoRepository, MedicoRepository>();
builder.Services.AddTransient<IMedicoServices, MedicoServices>();
builder.Services.AddTransient<IEnfermeraRepository, EnfermeraRepository>();
builder.Services.AddTransient<IEnfermeraServices, EnfermeraServices>();
builder.Services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddTransient<IEmpleadoServices, EmpleadoServices>();
builder.Services.AddTransient<ITipoEmpleadoRepository, TipoEmpleadoRepository>();
builder.Services.AddTransient<ITipoEmpleadoServices, TipoEmpleadoServices>();
builder.Services.AddTransient<IHorarioTrabajoRepository, HorarioTrabajoRepository>();
builder.Services.AddTransient<IHorarioTrabajoServices, HorarioTrabajoServices>();
builder.Services.AddTransient<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddTransient<IEspecialidadServices, EspecialidadServices>();
//Cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options
                                                .AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
