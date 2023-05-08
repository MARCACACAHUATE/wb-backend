using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using wb_backend.Models;

namespace wb_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionCursosController : ControllerBase
    {
        private readonly WujuDbContext _context;

        public ReservacionCursosController(WujuDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservacionCursos
        [HttpGet]
       // public async Task<ActionResult> GetReservaciones()
       // {
           // var reservaciones = await _context.ReservacionCurso.ToListAsync();
            //return Ok(reservaciones);
     //   }

        // GET: api/ReservacionCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservacion(int id)
        {
            var reservacion = await _context.ReservacionCurso.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return Ok(reservacion);
        }

        // POST: api/ReservacionCursos
        [HttpPost]
        public async Task<ActionResult> CreateReservacion(ReservacionCurso reservacionCurso)
        {
            // Revisa si el curso existe
            var curso = await _context.Cursos.FindAsync(reservacionCurso.Id_curso);
            if (curso == null)
            {
                return BadRequest($"El curso con id {reservacionCurso.Id_curso} no existe.");
            }

            // Revisa si el usuario existe
            var user = await _context.Users.FindAsync(reservacionCurso.Id_user);
            if (user == null)
            {
                return BadRequest($"El usuario con id {reservacionCurso.Id_user} no existe.");
            }

            // Revisa si el usuario tiene ya una reservacion para el mismo curso
            var existingReservacion = await _context.ReservacionCurso
                .FirstOrDefaultAsync(rc => rc.Id_user == reservacionCurso.Id_user && rc.Id_curso == reservacionCurso.Id_curso);
            if (existingReservacion != null)
            {
                return BadRequest($"El usuario con id {reservacionCurso.Id_user} ya tiene una reserva para el curso con id {reservacionCurso.Id_curso}.");
            }

            // Revisa si hay espacio suficiente
            if (curso.Espacios_restantes <= 0)
            {
                return BadRequest($"No hay espacios disponibles para el curso con id {reservacionCurso.Id_curso}.");
            }

            // Actualiza el numero de espacios restantes
            curso.Espacios_restantes--;
            _context.Entry(curso).State = EntityState.Modified;

            // Create the reservation
            reservacionCurso.Estado = "Esperando pago";
            _context.ReservacionCurso.Add(reservacionCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservacion), new { id = reservacionCurso.Id }, reservacionCurso);
        }

        // PUT: api/ReservacionCursos/5
        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateReservacion(int id, ReservacionCurso reservacionCurso)
    {
        if (id != reservacionCurso.Id)
        {
            return BadRequest("El id de la reserva no coincide con el id de la URL.");
        }

        // Revisa si la reservacion existe
        var existingReservacion = await _context.ReservacionCurso
            .FirstOrDefaultAsync(rc => rc.Id == id);
        if (existingReservacion == null)
        {
            return NotFound("La reserva no existe.");
        }

        // Revisa si el usuario ya tiene una resevacion para el mismo curso
        var conflictingReservacion = await _context.ReservacionCurso
            .FirstOrDefaultAsync(rc => rc.Id_user == reservacionCurso.Id_user
                                    && rc.Id_curso == reservacionCurso.Id_curso
                                    && rc.Id != id);
        if (conflictingReservacion != null)
        {
            return Conflict("El usuario ya tiene una reserva para este curso.");
        }

        // Revisa si el curso tiene suficiente espacio para la reservacion
        var curso = await _context.Cursos
            .FirstOrDefaultAsync(c => c.Id == reservacionCurso.Id_curso);
        if (curso == null)
        {
            return NotFound("El curso de la reserva no existe.");
        }
        if (reservacionCurso.Estado == "Pagado" && reservacionCurso.Id != existingReservacion.Id)
        {
            curso.Espacios_restantes = curso.Espacios_restantes - 1;
        }

        _context.Entry(existingReservacion).CurrentValues.SetValues(reservacionCurso);
        await _context.SaveChangesAsync();

        return NoContent();
        }


    }
}

