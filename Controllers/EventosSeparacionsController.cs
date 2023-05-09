using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wb_backend.Services;
using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;
using System.Text.RegularExpressions;

namespace wb_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosSeparacionsController : ControllerBase {

        private readonly IServiceExample _serviceExample;
        private readonly IEventoSeparacionsServices _eventoSeparacionsService;

        public EventosSeparacionsController(
            IServiceExample serviceExample,
            IEventoSeparacionsServices eventoSeparacionsServices
            )
        {
            _serviceExample = serviceExample;
            _eventoSeparacionsService = eventoSeparacionsServices;
        }

        [HttpGet("example")]
        public IActionResult EndpointExample(){
            string ejemplo = _serviceExample.ExposeExample();
            return Ok(ejemplo);
        }

        [HttpPost]
        public IActionResult CreateEventoSeparacions(EventoSeparacionsRequest request){
            Response response = new Response();
            // Validaciones
            // formato de la fecha
            // var regex = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";
            // var format_validator = new Regex(regex);
            // if(format_validator.IsMatch(request.Fecha) != true){
            //    string message = "Error en el formato de la fecha. El formato debe ser -> dd/MM/yyyy";
            //    response.Message = message;
            //    response.Estado = 0;
            //    return Ok(response);
            // }

            response.data = _eventoSeparacionsService.NewEventoSeparacions(request);
            response.Message = "Evento creado con exito";
            response.Estado = 1;
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetEventosSeparacionsList(){
            Response response = new Response();
            response.data = _eventoSeparacionsService.ListEventosSeparacions();
            response.Message = "Operacion exitosa";
            response.Estado = 1;
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventoSeparacionsById(int id) {
            Response response = new Response();
            try {
                response.data = _eventoSeparacionsService.GetEventoSeparacions(id);
                response.Message = "Operacion exitosa";
                response.Estado = 1;
            }catch(InvalidOperationException){
                response.Message = $"Elemento con id {id} no existe";
                response.Estado = 0;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ModifyEventoSeparacions(int id, EventoSeparacionsRequest eventoSeparacionsRequest){
            Response response = new Response();
            try {
                response.data = _eventoSeparacionsService.ModifyEventoSeparacions(id, eventoSeparacionsRequest);
                response.Message = "Elemento modificado con exito";
                response.Estado = 1;
            }catch(Exception error){
                response.Message = $"Hubo un fallo en al operacion {error.Message}";
                response.Estado = 0;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEventoSeparacions(int id) {
            Response response = new Response();
            try{
                response.data = _eventoSeparacionsService.DeleteEventoSeparacions(id);
                response.Message = "Evento eliminado exitosamente";
                response.Estado = 1;
            }catch(InvalidOperationException){
                response.Message = $"Elemento con id {id} no existe";
                response.Estado = 0;
            }
            return Ok(response);
        }
    }
}
