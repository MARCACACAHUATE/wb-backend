using System.Text;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using wb_backend.Models;
using wb_backend.Services;
using wb_backend.Tools.Authorization;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

// Add services to the container.
var myCors = "myCors";
builder.Services.AddCors(options => {
    options.AddPolicy(name: myCors,
    policy => {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// jwt
string secretKey = Environment.GetEnvironmentVariable("SECRETKEY");
var keyBytes = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string connection = builder.Configuration["ConnectionString"]; 

// ******Inject custom services******
builder.Services.AddTransient<IServiceExample, ServiceExample>();

//Inyeccion del servicio de la tabla de separaciones de los cursos
builder.Services.AddTransient<ICursoSeparacionService, CursoSeparacionService>();
builder.Services.AddTransient<ICursoService, CursoService>();
builder.Services.AddTransient<IEventoServices, EventoServices>();
builder.Services.AddTransient<IEventoSeparacionsServices, EventoSeparacionsServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IMunicipioServices, MunicipioServices>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddDbContext<WujuDbContext>(options =>{


    string connection = builder.Configuration["ConnectionString"]; 
    string pg_connection = connection != null ? connection : Environment.GetEnvironmentVariable("PGCONNECTION");
    options.UseNpgsql(pg_connection);
    //options.UseNpgsql(builder.Configuration.GetConnectionString("WujuDB"))
});
builder.Services.AddControllers().AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddControllers().AddJsonOptions(option => {
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


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

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseCors(myCors);

app.Run();  

