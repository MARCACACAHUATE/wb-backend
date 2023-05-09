using wb_backend.Models;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Services {

    public interface IEventoSeparacionsServices {

        EventoSeparacion NewEventoSeparacions(EventoSeparacionsRequest eventoSeparacions_data);
        List<EventoSeparacion> ListEventosSeparacions();
        EventoSeparacion GetEventoSeparacions(int id_eventoSeparacions);
        EventoSeparacion DeleteEventoSeparacions(int id_eventoSeparacions);
        EventoSeparacion ModifyEventoSeparacions(int id_eventoSeparacions, EventoSeparacionsRequest eventoSeparacions_data);
    }
}