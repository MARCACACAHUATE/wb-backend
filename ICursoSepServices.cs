using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services {

    public interface ICursoSepServices {

        CursoSeparacion NewCursoSeparacion(CursoSeparacionRequest cursoseparacion_data);
        CursoSeparacion GetCursoSeparacion(int idcurso_separacion);
        CursoSeparacion DeleteCursoSeparacion(int idcurso_separacion);
        CursoSeparacion ModifyCursoSeparacion(int idcurso_separacion, CursoSeparacionRequest data_cursoseparacion);
        
    }
}