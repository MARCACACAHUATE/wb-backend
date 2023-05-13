using System.Text.RegularExpressions;
using wb_backend.Tools.Request;

namespace wb_backend.Tools {

    public class EventoValidation {

        /// <summary>
        /// Funcion para validar que el costo de reservacion y el costo total
        /// al crear un evento no sean igual a 0.
        /// </summary>
        /// <returns>
        /// Retorna False si el valor de reservacion o de total
        /// son igual a 0, de lo contrario retorna True.
        /// </returns>
        /// <param name="evento_request">Objeto request de eventos.</param>
        public bool ValidateReservacionAndTotalNotZero(EventoRequest evento_request){
            if(evento_request.Costo_reservacion <= 0 || evento_request.Costo_total <= 0){
                //string message = "El Costo de reservacion o de total no pueden ser 0";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Función para validar que la fecha recibida tenga el formato dd-MM-yyyy 
        /// </summary>
        /// <returns>
        /// Retorna False si la fecha no cumple con el formato requerido, de lo contrario
        /// retorna True.
        /// </returns>
        /// <param name="fecha">Fecha que será validada</param>
        public bool ValidateDateFormat(string fecha){
            var regex = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";
            var format_validator = new Regex(regex);
            if(format_validator.IsMatch(fecha) != true){
                //string message = "Error en el formato de la fecha. El formato debe ser -> dd/MM/yyyy";
                return false;
            }
            return true;
        }
    }
}