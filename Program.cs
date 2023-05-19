using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using wb_backend.Models;
using wb_backend.Services;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

// Add services to the container.

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

// Inject custom services
builder.Services.AddTransient<IServiceExample, ServiceExample>();
builder.Services.AddTransient<IEventoServices, EventoServices>();
builder.Services.AddTransient<IEventoSeparacionsServices, EventoSeparacionsServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IMunicipioServices, MunicipioServices>();
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
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Configuration.AddUserSecrets<Program>();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
