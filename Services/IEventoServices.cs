using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services {

    public interface IEventoServices {

        Evento NewEvento(EventoRequest evento_data);
        List<Evento> ListEventos();
        Evento GetEvento(int id_evento);
        Evento DeleteEvento(int id_evento);
        Evento ModifyEvento(int id_evento, EventoRequest data_evento);
        List<EventoDates> GetEventoDate(IQueryCollection queryParams);
    }
}