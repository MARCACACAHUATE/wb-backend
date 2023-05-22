using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wb_backend.Models;

namespace wb_backend.Services
{
    public class CursoService : ICursoService
    {
        private readonly WujuDbContext _context;

        public CursoService(WujuDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cursos>> GetCursosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Cursos> GetCursoByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<Cursos> CreateCursoAsync(Cursos curso)
        {
            // Convertir las fechas a UTC
            curso.FechaInicio = DateTime.SpecifyKind(curso.FechaInicio, DateTimeKind.Utc);
            curso.FechaFin = DateTime.SpecifyKind(curso.FechaFin, DateTimeKind.Utc);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Cursos> UpdateCursoAsync(int id, Cursos curso)
        {
            var existingCurso = await _context.Cursos.FindAsync(id);

            if (existingCurso == null)
            {
                return null;
            }

            // Update the properties of existingCurso with the properties of the updated curso
            existingCurso.Nombre = curso.Nombre;
            existingCurso.Tematica = curso.Tematica;
            existingCurso.Detalle = curso.Detalle;
            existingCurso.FechaInicio = curso.FechaInicio;
            existingCurso.FechaFin = curso.FechaFin;
            existingCurso.CostoReservacion = curso.CostoReservacion;
            existingCurso.CostoTotal = curso.CostoTotal;
            existingCurso.Calle = curso.Calle;
            existingCurso.Numero = curso.Numero;
            existingCurso.Municipio = curso.Municipio;
            existingCurso.EstadoCursoName = curso.EstadoCursoName;

            await _context.SaveChangesAsync();

            return existingCurso;
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return false;
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
