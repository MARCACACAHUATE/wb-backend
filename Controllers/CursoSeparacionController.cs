using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wb_backend.Models;
using wb_backend.Services;

namespace wb_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoSeparacionController : ControllerBase
    {
        private readonly ICursoSeparacionService _cursoSeparacionService;

        public CursoSeparacionController(ICursoSeparacionService cursoSeparacionService)
        {
            _cursoSeparacionService = cursoSeparacionService;
        }

        // GET: api/CursoSeparacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoSeparacion>>> GetCursoSeparaciones()
        {
            var cursoSeparaciones = await _cursoSeparacionService.GetCursoSeparacionesAsync();
            return Ok(cursoSeparaciones);
        }

        // GET: api/CursoSeparacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoSeparacion>> GetCursoSeparacion(int id)
        {
            var cursoSeparacion = await _cursoSeparacionService.GetCursoSeparacionByIdAsync(id);

            if (cursoSeparacion == null)
            {
                return NotFound();
            }

            return Ok(cursoSeparacion);
        }

        // POST: api/CursoSeparacion
        [HttpPost]
        public async Task<ActionResult<CursoSeparacion>> PostCursoSeparacion(CursoSeparacion cursoSeparacion)
        {
            var createdCursoSeparacion = await _cursoSeparacionService.CreateCursoSeparacionAsync(cursoSeparacion);
            return CreatedAtAction(nameof(GetCursoSeparacion), new { id = createdCursoSeparacion.Id }, createdCursoSeparacion);
        }

        // PUT: api/CursoSeparacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoSeparacion(int id, CursoSeparacion cursoSeparacion)
        {
            if (id != cursoSeparacion.Id)
            {
                return BadRequest();
            }

            var updatedCursoSeparacion = await _cursoSeparacionService.UpdateCursoSeparacionAsync(id, cursoSeparacion);

            if (updatedCursoSeparacion == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CursoSeparacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoSeparacion(int id)
        {
            var cursoSeparacion = await _cursoSeparacionService.DeleteCursoSeparacionAsync(id);

            if (cursoSeparacion == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
