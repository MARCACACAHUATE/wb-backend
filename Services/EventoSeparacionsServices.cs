using System.Linq;
using System.Globalization;
using wb_backend.Models;
using wb_backend .Tools;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;
using System.ComponentModel.DataAnnotations;

namespace wb_backend.Services {

    public class EventoSeparacionsServices : IEventoSeparacionsServices {

        private readonly WujuDbContext _dbContext;
        private readonly IEventoServices _eventoServices;
        private readonly string _dateFormat = "dd-MM-yyyy";

        public EventoSeparacionsServices(WujuDbContext dbConetxt, IEventoServices eventoServices) {
            _dbContext = dbConetxt;
            _eventoServices = eventoServices;
        }

        public EventoSeparacion NewEventoSeparacions(EventoSeparacionsRequest eventoSeparacions_data){
            // TODO: parsear la fecha de evento_data y utilizarla en el objeto
            EventoValidation validator = new EventoValidation();

            if(!validator.ValidateDateFormat(eventoSeparacions_data.Fecha)){
                throw new ValidationException("Formato de la fecha invalido");
            }

            validator.ValidateHoraEventoGreaterHoraMontaje(eventoSeparacions_data.HoraMontaje, eventoSeparacions_data.HoraEvento);
            
            
            CultureInfo cult = new CultureInfo("es-MX", false);
            DateTime fechaformat = DateTime.ParseExact(eventoSeparacions_data.Fecha, _dateFormat, cult);

            EventoSeparacion eventoSeparacions_nuevo = new EventoSeparacion{
                FirstName = eventoSeparacions_data.FirstName,
                LastName = eventoSeparacions_data.LastName,
                Telefono = eventoSeparacions_data.Telefono,
                Email = eventoSeparacions_data.Email,
                HoraEvento = eventoSeparacions_data.HoraEvento,
                HoraMontaje = eventoSeparacions_data.HoraMontaje,
                Fecha = fechaformat.ToUniversalTime(),
                Calle = eventoSeparacions_data.Calle,
                Numero = eventoSeparacions_data.Numero,
                Colonia = eventoSeparacions_data.Colonia,
                //Id_Evento = eventoSeparacions_data.Id_Evento,
            };

            // buscar si existe el evento sino crearlo
            Evento evento;
            evento = _dbContext.Eventos.Find(eventoSeparacions_data.Id_Evento);

            if(evento == null){
                evento = _eventoServices.NewEvento(new EventoRequest {
                    NombrePaquete = "Paquete Default",
                    Ocasion = "Ocasion Default",
                    Servicios = "Servicio Default",
                    Mobiliario = "Default",
                    ColorGlobos = "Default",
                    CostoEnvioMaterial = 1,
                    Costo_reservacion = 1,
                    Costo_total = 1,
                    Estado = "Estado Default",
                    Id_Municipio = 1
                });
                eventoSeparacions_nuevo.Evento = evento;
            }else {
                eventoSeparacions_nuevo.Evento = evento;
            }

            _dbContext.EventoSeparacions.Add(eventoSeparacions_nuevo);
            _dbContext.SaveChanges();
            return eventoSeparacions_nuevo;
        }

        public List<EventoSeparacion> ListEventosSeparacions(){
            List<EventoSeparacion> list_eventosSeparacions = _dbContext.EventoSeparacions.ToList();
            return list_eventosSeparacions;
        }

        public EventoSeparacion GetEventoSeparacions(int id_eventoSeparacions){
            EventoSeparacion eventoSeparacions = _dbContext.EventoSeparacions.Single(obj => obj.Id == id_eventoSeparacions);
            return eventoSeparacions;
        }

        public EventoSeparacion DeleteEventoSeparacions(int id_eventoSeparacions){
            EventoSeparacion eventoSeparacions = GetEventoSeparacions(id_eventoSeparacions);
            _dbContext.EventoSeparacions.Remove(eventoSeparacions);
            _dbContext.SaveChanges();
            return eventoSeparacions;
        }

        public EventoSeparacion ModifyEventoSeparacions(int id_eventoSeparacions, EventoSeparacionsRequest data_eventoSeparacions){
            // TODO: parsear la fecha de evento_data y utilizarla en el objeto
            EventoValidation validator = new EventoValidation();
            if(!validator.ValidateDateFormat(data_eventoSeparacions.Fecha)){
                //throw new ValidationException();
                return null;
            }

            CultureInfo cult = new CultureInfo("es-MX", false);
            DateTime fechaformat = DateTime.ParseExact(data_eventoSeparacions.Fecha, _dateFormat, cult);
            
            EventoSeparacion eventoSeparacions = GetEventoSeparacions(id_eventoSeparacions);

            eventoSeparacions.FirstName = data_eventoSeparacions.FirstName;
            eventoSeparacions.LastName = data_eventoSeparacions.LastName;
            eventoSeparacions.Telefono = data_eventoSeparacions.Telefono;
            eventoSeparacions.Email = data_eventoSeparacions.Email;
            eventoSeparacions.HoraEvento = data_eventoSeparacions.HoraEvento;
            eventoSeparacions.HoraMontaje = data_eventoSeparacions.HoraMontaje;
            eventoSeparacions.Fecha = fechaformat.ToUniversalTime();
            eventoSeparacions.Calle = data_eventoSeparacions.Calle;
            eventoSeparacions.Numero = data_eventoSeparacions.Numero;
            eventoSeparacions.Colonia = data_eventoSeparacions.Colonia;
            eventoSeparacions.Id_Evento = data_eventoSeparacions.Id_Evento;

            _dbContext.Entry(eventoSeparacions).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return eventoSeparacions;
        }
    }
}