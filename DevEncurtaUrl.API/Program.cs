using DevEncurtaUrl.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy => {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

// Para conectar com o Banco de Dados SQL
// GetConnectionString configurado no appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DevEncurtaUrl");

//builder.Services.AddSingleton<DevEncurtaUrlDbContext>();

// Para usar Em Memória Interna
builder.Services.AddDbContext<DevEncurtaUrlDbContext>(a => 
    a.UseInMemoryDatabase("DevEncurtaDb"));

// Para usar o SQL Server por exemplo:
builder.Services.AddDbContext<DevEncurtaUrlDbContext>(a => 
    a.UseSqlServer("connectionString"));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "DevEncurtaUrl.API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact{
            Name = "Fernando Di Nardo",
            Email = "dinardo.lazarin@gmail.com"
        }
    });

    var xmlFile = "DevEncurtaUrl.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
