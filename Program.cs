using Microsoft.EntityFrameworkCore;
using Npgsql;
using wb_backend.Models;
using wb_backend.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string connection = builder.Configuration["ConnectionString"]; 
DotNetEnv.Env.Load();

// ******Inject custom services******
builder.Services.AddTransient<IServiceExample, ServiceExample>();

//Inyeccion del servicio de la tabla de separaciones de los cursos
builder.Services.AddTransient<ICursoSeparacionService, CursoSeparacionService>();


builder.Services.AddDbContext<WujuDbContext>(options =>{
    string connection = builder.Configuration["ConnectionString"]; 
    string pg_connection = connection != null ? connection : Environment.GetEnvironmentVariable("PGCONNECTION");
    options.UseNpgsql(pg_connection);
    //options.UseNpgsql(builder.Configuration.GetConnectionString("WujuDB"))
});
builder.Services.AddControllers().AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var app = builder.Build();


// Probando la conexion a la base de datos
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<WujuDbContext>();
    using var connection = context.Database.GetDbConnection();
    connection.Open();
    Console.WriteLine($"Connected to {connection.Database} on {connection.DataSource}");
}
catch (NpgsqlException ex)
{
    Console.WriteLine($"Error connecting to database: {ex.Message}");
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Configuration.AddUserSecrets<Program>();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();

app.UseStaticFiles();

app.Run();  

