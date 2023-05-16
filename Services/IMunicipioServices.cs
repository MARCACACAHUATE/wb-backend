using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services;

public interface IMunicipioServices {
    Municipio NewMunicipio(MunicipioRequest request);
    List<Municipio> GetMunicipiosList();
    Municipio GetMunicipioById(int id);
}