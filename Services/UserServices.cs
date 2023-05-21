using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using wb_backend.Models;
using wb_backend.Tools;
using wb_backend.Tools.Authorization;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services;

public class UserServices : IUserServices {

    private readonly WujuDbContext _dbContext;
    private readonly string _secretKey = Environment.GetEnvironmentVariable("SECRETKEY");
    private readonly IJwtUtils _jwtUtils;

    public UserServices(WujuDbContext dbContext, IJwtUtils jwtUtils){
        _dbContext = dbContext;
        _jwtUtils = jwtUtils;
    }

    public User NewUser(UserRequest request){

        EstadoCurso? estado = _dbContext.EstadoCursos.Find(1);
        TipoUser tipoUser;
        try{
            tipoUser = _dbContext.TipoUsers.
                                Single(tipo => tipo.TypeUser == Role.Cliente.ToString());
        }catch(Exception){
            Enum tipoCliente = Role.Cliente;
            tipoUser = new TipoUser{ TypeUser=tipoCliente.ToString()};
            _dbContext.TipoUsers.Add(tipoUser);
            _dbContext.SaveChanges();
        }

        if(request.Password != request.ConfirmPassword){
            throw new Exception("Las contraseñas no son iguales");
        }
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        User new_user = new User{
            First_name = request.First_name,
            Last_name = request.Last_name,
            Email = request.Email,
            Password = passwordHash,
            Telefono = request.Telefono,
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
        User? user = _dbContext.Users.Include(user => user.TipoUser)
                                     .SingleOrDefault(user => user.Id == id);
        if(user == null){
            throw new ValidationException($"Usuario con id {id} no encontrado");
        }
        return user;     
    }

    public User ModifyUser(int id, UserModifyRequest request){
        User user = GetUserById(id);
        user.First_name = request.First_name;
        user.Last_name = request.Last_name;
        user.Email = request.Email;
        user.Telefono = request.Telefono;
        user.Calle = request.Calle;
        user.Numero = request.Numero;

        _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _dbContext.SaveChanges();
        return user;
    }

    public User DeleteUser(int id){
        User user = GetUserById(id);
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
        return user;
    }

    public AuthenticateResponse AuthUser(string email, string password){
        User? user = _dbContext.Users.Include(user => user.TipoUser).SingleOrDefault(user => user.Email == email);

        if(user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password)){
            throw new Exception($"Datos del usuario invaildos");
        }
        
        var jwtToken = _jwtUtils.GenerateJwtToken(user); 

        return new AuthenticateResponse(user, jwtToken);
    }
}