using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wb_backend.Models;
using wb_backend.Services;

namespace wb_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cursos>>> GetCursos()
        {
            var cursos = await _cursoService.GetCursosAsync();
            return Ok(cursos);
        }

            [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCursoById(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<Cursos>> CreateCurso(Cursos curso)
        {
            var createdCurso = await _cursoService.CreateCursoAsync(curso);
            return CreatedAtAction(nameof(GetCursoById), new { id = createdCurso.IdCursos }, createdCurso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, Cursos curso)
        {
            var updatedCurso = await _cursoService.UpdateCursoAsync(id, curso);

            if (updatedCurso == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var result = await _cursoService.DeleteCursoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
                }
    }
}