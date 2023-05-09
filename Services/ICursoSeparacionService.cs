using System.Collections.Generic;
using System.Threading.Tasks;
using wb_backend.Models;

namespace wb_backend.Services
{
    public interface ICursoSeparacionService
    {
        Task<CursoSeparacion> CreateCursoSeparacionAsync(CursoSeparacion newCursoSeparacion);
        Task<CursoSeparacion> GetCursoSeparacionByIdAsync(int id);
        Task<IEnumerable<CursoSeparacion>> GetAllCursoSeparacionesAsync();
        Task<CursoSeparacion> UpdateCursoSeparacionAsync(int id, CursoSeparacion updatedCursoSeparacion);
        Task<bool> DeleteCursoSeparacionAsync(int id);
        Task<List<CursoSeparacion>> GetCursoSeparacionesAsync();

    }
}
