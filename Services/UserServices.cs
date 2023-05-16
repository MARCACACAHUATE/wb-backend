using System.ComponentModel.DataAnnotations;
using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services;

public class UserServices : IUserServices {

    private readonly WujuDbContext _dbContext;

    public UserServices(WujuDbContext dbContext){
        _dbContext = dbContext;
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
}