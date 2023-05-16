using System.Collections.Generic;
using System.Threading.Tasks;
using wb_backend.Models;

namespace wb_backend.Services
{
    public interface ICursoService
    {
        Task<List<Cursos>> GetCursosAsync();
        Task<Cursos> GetCursoByIdAsync(int id);
        Task<Cursos> CreateCursoAsync(Cursos curso);
        Task<Cursos> UpdateCursoAsync(int id, Cursos curso);
        Task<bool> DeleteCursoAsync(int id);
    }
}
