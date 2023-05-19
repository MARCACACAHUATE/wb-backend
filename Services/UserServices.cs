using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services;

public class UserServices : IUserServices {

    private readonly WujuDbContext _dbContext;
    private readonly string _secretKey;

    public UserServices(WujuDbContext dbContext){
        _dbContext = dbContext;
        _secretKey = Environment.GetEnvironmentVariable("SECRETKEY");
    }

    public User NewUser(UserRequest request){

        EstadoCurso? estado = _dbContext.EstadoCursos.Find(1);
        TipoUser tipoUser;
        try{
            tipoUser = _dbContext.TipoUsers.
                                Single(tipo => tipo.TypeUser == "Cliente");
        }catch(Exception){
            tipoUser = new TipoUser{ TypeUser="Cliente"};
            _dbContext.TipoUsers.Add(tipoUser);
            _dbContext.SaveChanges();
        }

        User new_user = new User{
            First_name = request.First_name,
            Last_name = request.Last_name,
            Email = request.Email,
            Password = request.Password,
            Telefono = Int32.Parse(request.Telefono),
            Calle = request.Calle,
            Numero = request.Numero,
            Municipio = request.Municipio
        };

        estado.Users.Add(new_user);
        tipoUser.Users.Add(new_user);

        _dbContext.Users.Add(new_user);
        _dbContext.SaveChanges();

        return new_user; 
    }

    public List<User> GetUserList(){
        return _dbContext.Users.ToList();
    }

    public User GetUserById(int id){
        User? user = _dbContext.Users.Find(id);
        if(user == null){
            throw new ValidationException($"Usuario con id {id} no encontrado");
        }
        return user;     
    }

    public string AuthUser(string email, string password){
        // buscar al usuario mediante el email
        User user;
        try{
            user = _dbContext.Users.Single(user => user.Email == email);
        }catch(Exception){
            throw new Exception("Usuario no existe");
        }
        // desencriptar la password
        string passwordUncrypted = user.Password;

        if(email == user.Email && passwordUncrypted == password){
            var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
            ClaimsIdentity claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor{
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;

        }else{
            // Datos invalidos 
            throw new Exception("Datos del usuario incorrectos");;
        }
    }
}