using System.Linq;
using System.Globalization;
using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services {

    public class EventoServices : IEventoServices {

        private readonly WujuDbContext _dbContext;
        private readonly string _dateFormat = "dd-MM-yyyy";

        private enum Months {
            enero = 1,
            febrero = 2,
            marzo = 3,
            abril = 4,
            mayo = 5,
            junio = 6,
            julio = 7,
            agosto = 8,
            septiembre = 9,
            octubre = 10,
            noviembre = 11,
            diciembre = 12
        }

        public EventoServices(WujuDbContext dbConetxt) {
            _dbContext = dbConetxt;
        }

        public Evento NewEvento(EventoRequest evento_data){
            // TODO: parsear la fecha de evento_data y utilizarla en el objeto
            CultureInfo cult = new CultureInfo("es-MX", false);
            DateTime fecha = DateTime.ParseExact(evento_data.Fecha, _dateFormat, cult);
            Evento evento_nuevo = new Evento{
                Nombre = evento_data.Nombre,
                Tematica = evento_data.Tematica,
                Direccion = evento_data.Direccion,
                Fecha = fecha.ToUniversalTime(),
                Costo_reservacion = evento_data.Costo_reservacion,
                Costo_total = evento_data.Costo_total
            };

            _dbContext.Eventos.Add(evento_nuevo);
            _dbContext.SaveChanges();
            return evento_nuevo;
        }

        public List<Evento> ListEventos(){
            List<Evento> list_eventos = _dbContext.Eventos.ToList();
            return list_eventos;
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
            DateTime fecha = DateTime.ParseExact(data_evento.Fecha, "dd-MM-yyyy", null);

            Evento evento = GetEvento(id_evento);
            evento.Nombre = data_evento.Nombre; 
            evento.Tematica = data_evento.Tematica;
            evento.Direccion = data_evento.Direccion;
            evento.Fecha = fecha.ToUniversalTime();
            evento.Costo_total = data_evento.Costo_total;
            evento.Costo_reservacion = data_evento.Costo_reservacion;

            _dbContext.Entry(evento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return evento;
        }

        public List<EventoDates> GetEventoDate(IQueryCollection queryParams){

            List<Evento> eventos_list;
            List<EventoDates> eventosDates = new List<EventoDates>(); 

            // ------ validar que estan los query params ------

            // default values
            CultureInfo ci = new CultureInfo("es-MX");
            DateTime fecha_test = DateTime.UtcNow;
            string mes_formateado = fecha_test.ToString("MMMM", ci);
            string año_formateado = fecha_test.ToString("yyyy", ci);
            // default values

            int year;
            string? month_param = queryParams["month"];
            string monthName;
            string monthKey = "1";

            // validate values
            // year
            if(!Int32.TryParse(queryParams["year"], out year)){
                year = Int32.Parse(año_formateado);
            }

            // month
            if(String.IsNullOrEmpty(month_param)){
                monthName = mes_formateado;
            }else {
                monthName = month_param;
            }

            if(Enum.IsDefined(typeof(Months), monthName)){
                foreach(string _monthName in Enum.GetNames(typeof(Months))){
                    if(monthName == _monthName){
                        monthKey = ((int)Enum.Parse(typeof(Months), monthName)).ToString(); 
                        monthKey = monthKey.Length != 2 ? "0" + monthKey : monthKey;
                        Console.WriteLine(monthKey);
                        break;
                    }
                }
            }

            // ------ codigo de validacion ------
            string rango_inicio = $"01-{monthKey}-{year}";
            string rango_final = $"31-{monthKey}-{year}";

            var fecha_inicial = DateTime.ParseExact(rango_inicio, _dateFormat, null);
            var fecha_final = DateTime.ParseExact(rango_final, _dateFormat, null);

            eventos_list = (from evento in _dbContext.Eventos.ToList()
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
                    eventodate.id_eventos.Add(evento.Id);
                }
                eventosDates.Add(eventodate);
            }

            return eventosDates; 
        }

    }
}