using System.Globalization;
using wb_backend.Models;
using wb_backend.Tools.Request;

namespace wb_backend.Services {

    public class EventoServices : IEventoServices {

        private readonly WujuDbContext _dbContext;

        public EventoServices(WujuDbContext dbConetxt) {
            _dbContext = dbConetxt;
        }

        public Evento NewEvento(EventoRequest evento_data){
            // TODO: parsear la fecha de evento_data y utilizarla en el objeto
            CultureInfo cult = new CultureInfo("es-MX", false);
            DateTime fecha = DateTime.ParseExact(evento_data.Fecha, "dd-MM-yyyy", cult);
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
    }
}