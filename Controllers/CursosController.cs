using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wb_backend.Models;

namespace wb_backend.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase {

        private readonly WujuDbContext _context;

        public CursosController(WujuDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos() {
            return await _context.Cursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id) {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null) {
                return NotFound();
            }

            return curso;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCurso(int id, Curso curso) {
            if (id != curso.Id) {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CursoExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> AddCourse(Curso curso) {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCurso(int id) {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null) {
                return NotFound();
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id) {
            return _context.Cursos.Any(c => c.Id == id);
        }
    }
}
