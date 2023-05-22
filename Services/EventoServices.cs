using System.IO;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using wb_backend.Models;
using wb_backend.Tools;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;
using Microsoft.EntityFrameworkCore;

namespace wb_backend.Services {

    public class EventoServices : IEventoServices {

        private readonly WujuDbContext _dbContext;
        private readonly string _dateFormat = "dd-MM-yyyy";


        public EventoServices(WujuDbContext dbConetxt) {
            _dbContext = dbConetxt;
        }

        public Evento NewEvento(EventoRequest evento_data){
            // TODO: parsear la fecha de evento_data y utilizarla en el objeto
            //CultureInfo cult = new CultureInfo("es-MX", false);
            //DateTime fecha = DateTime.ParseExact(evento_data.Fecha, _dateFormat, cult);
            EventoValidation validator = new EventoValidation();

            // obtener el municipio
            Municipio? municipio  = _dbContext.Municipios.Find(evento_data.Id_Municipio);

            if(municipio == null){
                throw new ValidationException("El municipio dado no existe");
            }

            validator.ValidateReservacionIsLessThanTotal(evento_data.Costo_total, evento_data.Costo_reservacion);
            

            Evento evento_nuevo = new Evento{
                NombrePaquete = evento_data.NombrePaquete,
                Ocasion = evento_data.Ocasion,
                Servicios = evento_data.Servicios,
                Mobiliario = evento_data.Mobiliario,
                ColorGlobos = evento_data.ColorGlobos,
                CostoEnvioMaterial = evento_data.CostoEnvioMaterial,
                Estado = evento_data.Estado,
                Costo_reservacion = evento_data.Costo_reservacion,
                Costo_total = evento_data.Costo_total,
            };
            municipio.Eventos.Add(evento_nuevo);

            _dbContext.Eventos.Add(evento_nuevo);
            _dbContext.SaveChanges();
            return evento_nuevo;
        }

        public List<Evento> ListEventos(){
            List<Evento> list_eventos = _dbContext.Eventos
                                        .Include(evento => evento.Separacion)
                                        .ToList();
            return list_eventos;
        }

        public PaginacionResponse<Evento> ListEventosWithPaginacion(int pagina, int registrosPagina){
            List<Evento> eventos = ListEventos();
            string urlBase = "/api/eventos/pagination?";

            int totalRegistros = eventos.Count(); 

            eventos = eventos.Skip((pagina - 1) * registrosPagina)
                                            .Take(registrosPagina)
                                            .OrderByDescending(evento => evento.Separacion.Fecha)
                                            .ToList();
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPagina);

            PaginacionResponse<Evento> response = new PaginacionResponse<Evento>{
                RegistrosPorPagina = registrosPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaignaActual = pagina,
                Data = eventos
            }; 

            if(pagina >= 1 && pagina <= totalPaginas){
                if(pagina + 1 <= totalPaginas){
                    response.PaginaSiguiente = urlBase + $"pagina={pagina + 1}&registros_pagina={registrosPagina}";                
                }
                if(pagina - 1 > 0){
                    response.PaginaAnterior = urlBase + $"pagina={pagina - 1}&registros_pagina={registrosPagina}";                
                }
            }
            
            return response;
        }

        public List<Evento> ListEventosWithFilters(string? month, string? year){
            EventoFilters filters = new EventoFilters();
            List<Evento> eventos_list;
            Hashtable paramsFiltered = filters.FechasQueryParamsFilter(month, year);

            string rango_inicio = paramsFiltered["rango_inicio"].ToString();
            string rango_final = paramsFiltered["rango_final"].ToString();

            var fecha_inicial = DateTime.ParseExact(rango_inicio, _dateFormat, null);
            var fecha_final = DateTime.ParseExact(rango_final, _dateFormat, null);

            eventos_list = (from evento in _dbContext.EventoSeparacions
                            .Include(evento => evento.Evento)
                            .ToList()
                            where evento.Fecha >= fecha_inicial &&
                                  evento.Fecha <= fecha_final
                            select evento.Evento).ToList();
            return eventos_list;
        }

        public Evento GetEvento(int id_evento){
            Evento evento = _dbContext.Eventos.Single(obj => obj.Id == id_evento);
            return evento;
        }

        public Evento DeleteEvento(int id_evento){
            Evento evento = GetEvento(id_evento);
            _dbContext.Eventos.Remove(evento);
            _dbContext.SaveChanges();
            return evento;
        }

        public Evento ModifyEvento(int id_evento, EventoRequest data_evento){
            //DateTime fecha = DateTime.ParseExact(data_evento.Fecha, "dd-MM-yyyy", null);

            Evento evento = GetEvento(id_evento);
            evento.NombrePaquete = data_evento.NombrePaquete;
            evento.Ocasion = data_evento.Ocasion;
            evento.Servicios = data_evento.Servicios;
            evento.Mobiliario = data_evento.Mobiliario;
            evento.ColorGlobos = data_evento.ColorGlobos;
            evento.CostoEnvioMaterial = data_evento.CostoEnvioMaterial;
            evento.Estado = data_evento.Estado;
            evento.Costo_reservacion = data_evento.Costo_reservacion;
            evento.Costo_total = data_evento.Costo_total;

            _dbContext.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return evento;
        }

        public List<EventoDates> GetEventoDate(string? month, string? year){

            EventoFilters filtros = new EventoFilters();
            List<EventoSeparacion> eventos_list;
            List<EventoDates> eventosDates = new List<EventoDates>(); 

            Hashtable paramsFiltered = filtros.FechasQueryParamsFilter(month, year);


            // ------ codigo de validacion ------
            string rango_inicio = paramsFiltered["rango_inicio"].ToString();
            string rango_final = paramsFiltered["rango_final"].ToString();

            var fecha_inicial = DateTime.ParseExact(rango_inicio, _dateFormat, null);
            var fecha_final = DateTime.ParseExact(rango_final, _dateFormat, null);

            eventos_list = (from evento in _dbContext.EventoSeparacions.ToList()
                            where evento.Fecha >= fecha_inicial &&
                                  evento.Fecha <= fecha_final
                            select evento).ToList();

            var eventosGroup = (from item in eventos_list
                                orderby item.Fecha ascending
                                group item by item.Fecha).ToList();

            foreach(var fecha in eventosGroup){
                EventoDates eventodate = new EventoDates();
                eventodate.Fecha = fecha.Key;
                foreach(var evento in fecha){
                    eventodate.id_eventos.Add(evento.Id_Evento);
                }
                eventosDates.Add(eventodate);
            }

            return eventosDates; 
        }

        public async Task<string> UploadImage(UploadImageRequest request){
            // verificar que exista la carpeta
            IFormFile file = request.File;
            string projectDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(projectDirectory, "Image");

            if(Directory.Exists(imagePath)){
                Console.WriteLine("El directorio existe");
            }else{
                Console.WriteLine("El directorio NO existe, pero en proceso de creacion...");
                // Creando el diretorio si no existe
                DirectoryInfo imageDir = Directory.CreateDirectory(imagePath);
                Console.WriteLine($"Directorio {imageDir.Name} Cerado con Exito");
                Console.WriteLine($"Path -> {imageDir.FullName}");
            }

            // Verificar que el archivo es valido
            string pathSave = "";
            if(file.Length > 0){
                // guardar el archivo en la carpeta
                Evento evento = GetEvento(request.Evento_id);
                string nombreArchivo = $"evento_{evento.Id}_{evento.Ocasion}_{evento.Servicios}.jpg";
                pathSave = Path.Combine(imagePath, nombreArchivo);
                Console.WriteLine(pathSave);

                using(var stream = new FileStream(pathSave, FileMode.Create)){
                    await file.CopyToAsync(stream);
                }

                Console.WriteLine($"En el Servicio -> {request.Evento_id}");
                // guardar el path en la base de datos
                evento.ImageUrl = pathSave;
                _dbContext.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("Archivo creado con exito");
            }

            return pathSave;
        }

    }
}