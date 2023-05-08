/* de mientras en comentario en lo que se arregla
using System.Linq;
using System.Globalization;
using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services {

    public class CursoSepServices : ICursoSepServices {

        private readonly WujuDbContext _dbContext;


        public CursoSepServices(WujuDbContext dbConetxt) {
            _dbContext = dbConetxt;
        }

        public CursoSeparacion NewCursoSeparacion(CursoSeparacionRequest cursoseparacion_data){
            
            CultureInfo cult = new CultureInfo("es-MX", false);
            CursoSeparacion separacion_nueva = new CursoSeparacion{
                first_name = cursoseparacion_data.first_name,
                last_name = cursoseparacion_data.last_name,
                edad = cursoseparacion_data.edad,
                telefono = cursoseparacion_data.telefono,
                email = cursoseparacion_data.email,
                cantidad_personas_contratadas = cursoseparacion_data.cantidad_personas_contratadas,                
                Costo_reservacion = cursoseparacion_data.Costo_reservacion,
                Costo_total = cursoseparacion_data.Costo_total
            };

            _dbContext.Curso_Separacion.Add(separacion_nueva);
            _dbContext.SaveChanges();
            return separacion_nueva;
        }

        public CursoSeparacion GetCursoSeparacion(int idcurso_separacion){
            CursoSeparacion Separacion_Curso = _dbContext.Curso_Separacion.Single(obj => obj.Id == idcurso_separacion);
            return Separacion_Curso;
        } 

        public CursoSeparacion DeleteCursoSeparacion(int idcurso_separacion){
            CursoSeparacion Separacion_Curso = Get(idcurso_separacion);
            _dbContext.Curso_Separacion.Remove(Separacion_Curso);
            _dbContext.SaveChanges();
            return Separacion_Curso;
        }

        public CursoSeparacion ModifyCursoSeparacion(int idcurso_separacion, CursoSeparacionRequest data_cursoseparacion){
            

            CursoSeparacion Separacion_Curso = GetCursoSeparacion(idcurso_separacion);
            Separacion_Curso.first_name = data_cursoseparacion.first_name; 
            Separacion_Curso.last_name = data_cursoseparacion.last_name;
            Separacion_Curso.edad = data_cursoseparacion.edad;
            Separacion_Curso.telefono = data_cursoseparacion.telefono;
            Separacion_Curso.email = data_cursoseparacion.email;
            Separacion_Curso.cantidad_personas_contratadas = data_cursoseparacion.cantidad_personas_contratadas;
            Separacion_Curso.Costo_reservacion = data_cursoseparacion.Costo_reservacion;
            Separacion_Curso.Costo_total = data_cursoseparacion.Costo_total;

            _dbContext.Entry(Separacion_Curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return Separacion_Curso;
        }

        

    }
}
*/