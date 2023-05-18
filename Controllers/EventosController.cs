using System;
using System.ComponentModel.DataAnnotations;
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
    public class EventosController : ControllerBase {

        private readonly IServiceExample _serviceExample;
        private readonly IEventoServices _eventoService;

        public EventosController(
            IServiceExample serviceExample,
            IEventoServices eventoServices
            )
        {
            _serviceExample = serviceExample;
            _eventoService = eventoServices;
        }

        [HttpGet("example")]
        public IActionResult EndpointExample(){
            string ejemplo = _serviceExample.ExposeExample();
            return Ok(ejemplo);
        }

        [HttpPost]
        public IActionResult CreateEvento(EventoRequest request){
            Response response = new Response();
            try{
                response.data = _eventoService.NewEvento(request);
                response.Message = "Evento creado con exito";
                response.Estado = 1;
                return Ok(response);
            }catch(ValidationException error){
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult GetEventosList(string? month, string? year){
            Response response = new Response();

            if(month == null && year == null){
                response.data = _eventoService.ListEventos();
            }else{

                response.data = _eventoService.ListEventosWithFilters(month, year);
            }
            response.Message = "Operacion exitosa";
            response.Estado = 1;
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventoById(int id) {
            Response response = new Response();
            try {
                response.data = _eventoService.GetEvento(id);
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
        public IActionResult ModifyEvento(int id, EventoRequest eventoRequest){
            Response response = new Response();
            try {
                response.data = _eventoService.ModifyEvento(id, eventoRequest);
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
        public IActionResult DeleteEvento(int id) {
            Response response = new Response();
            try{
                response.data = _eventoService.DeleteEvento(id);
                response.Message = "Evento eliminado exitosamente";
                response.Estado = 1;
            }catch(InvalidOperationException){
                response.Message = $"Elemento con id {id} no existe";
                response.Estado = 0;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("available")]
        public IActionResult AvailableDates(string? month, string? year){
            Response response = new Response();

            response.Estado = 1;
            response.Message = "Operacion realizada con exito";            
            response.data = _eventoService.GetEventoDate(month, year);

            return Ok(response);
        }

        [HttpGet]
        [Route("pagination")]
        public IActionResult GetEventosListPagination(int pagina=1, int registros_pagina=10){
        PaginacionResponse<Evento> response;
            try{
                response = _eventoService.ListEventosWithPaginacion(pagina, registros_pagina);
                return Ok(response);
            }catch(Exception error){
                return BadRequest(error.Message);
            }

        }
    }
}
