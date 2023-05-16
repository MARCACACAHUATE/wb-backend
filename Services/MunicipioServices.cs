using System.ComponentModel.DataAnnotations;
using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services;

public class MunicipioServices: IMunicipioServices {

    private readonly WujuDbContext _dbContext;

    public MunicipioServices(WujuDbContext dbContext){
        _dbContext = dbContext;
    }

    public Municipio NewMunicipio(MunicipioRequest request){
        Municipio newMunicipio = new Municipio{NombreMunicipio = request.NombreMunicipio};
        _dbContext.Municipios.Add(newMunicipio);
        _dbContext.SaveChanges();
        return newMunicipio;
    }

    public List<Municipio> GetMunicipiosList(){
        return _dbContext.Municipios.ToList();
    }

    public Municipio GetMunicipioById(int id){
        Municipio? municipio = _dbContext.Municipios.Find(id);
        if(municipio == null){
            throw new ValidationException($"Municipio con el id {id} no encontrado");
        }
        return municipio;
    }
}