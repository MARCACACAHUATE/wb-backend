using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using wb_backend.Models;

namespace wb_backend.Services
{
    public class CursoSeparacionService : ICursoSeparacionService
    {
        private readonly WujuDbContext _context;

        public CursoSeparacionService(WujuDbContext context)
        {
            _context = context;
        }

        public async Task<CursoSeparacion> CreateCursoSeparacionAsync(CursoSeparacion cursoSeparacion)
        {
            _context.CursoSeparacion.Add(cursoSeparacion);
            await _context.SaveChangesAsync();
            return cursoSeparacion;
        }

        public async Task<CursoSeparacion> GetCursoSeparacionByIdAsync(int id)
        {
           return await _context.CursoSeparacion.FindAsync(id);
        }



        public async Task<IEnumerable<CursoSeparacion>> GetAllCursoSeparacionesAsync()
        {
            return await _context.CursoSeparacion
            .ToListAsync();
        }

        public async Task<CursoSeparacion> UpdateCursoSeparacionAsync(int id, CursoSeparacion cursoSeparacion)
        {
            var existingCursoSeparacion = await _context.CursoSeparacion.FindAsync(id);

            if (existingCursoSeparacion == null)
            {
                return null;
            }

            existingCursoSeparacion.First_name = cursoSeparacion.First_name;
            existingCursoSeparacion.Last_name = cursoSeparacion.Last_name;
            existingCursoSeparacion.Edad = cursoSeparacion.Edad;
            existingCursoSeparacion.Telefono = cursoSeparacion.Telefono;
            existingCursoSeparacion.Email = cursoSeparacion.Email;
            existingCursoSeparacion.Cantidad_personas_contratadas = cursoSeparacion.Cantidad_personas_contratadas;
            existingCursoSeparacion.CursosIdCursos = cursoSeparacion.CursosIdCursos;

            await _context.SaveChangesAsync();

            return existingCursoSeparacion;
        }

        public async Task<bool> DeleteCursoSeparacionAsync(int id)
        {
            var existingCursoSeparacion = await _context.CursoSeparacion.FindAsync(id);

            if (existingCursoSeparacion == null)
            {
                return false;
            }

            _context.CursoSeparacion.Remove(existingCursoSeparacion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CursoSeparacion>> GetCursoSeparacionesAsync()
        {
        return await _context.CursoSeparacion.ToListAsync();
        }

        public async Task<List<CursoSeparacion>> GetSeparacionesByCursoIdAsync(int cursoId)
        {
            return await _context.CursoSeparacion
                .Where(cs => cs.CursosIdCursos == cursoId)
                .ToListAsync();
        }

    }
}
