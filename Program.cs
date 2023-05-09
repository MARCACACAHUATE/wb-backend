using Microsoft.EntityFrameworkCore;
using wb_backend.Models;
using wb_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//string connection = builder.Configuration["ConnectionString"]; 
DotNetEnv.Env.Load();

// Inject custom services
builder.Services.AddTransient<IServiceExample, ServiceExample>();
builder.Services.AddTransient<IEventoServices, EventoServices>();
builder.Services.AddTransient<IEventoSeparacionsServices, EventoSeparacionsServices>();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    builder.Configuration.AddUserSecrets<Program>();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
