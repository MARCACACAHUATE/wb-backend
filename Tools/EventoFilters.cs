using System.Globalization;
using System.Collections;

namespace wb_backend.Tools {

    public class EventoFilters {

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

        public Hashtable FechasQueryParamsFilter(string month, string year){

            Hashtable data = new Hashtable();

            // ------ validar que estan los query params ------

            // default values
            CultureInfo ci = new CultureInfo("es-MX");
            DateTime fecha_test = DateTime.UtcNow;
            string mes_formateado = fecha_test.ToString("MMMM", ci);
            string año_formateado = fecha_test.ToString("yyyy", ci);
            // default values

            int yearSelected;
            string? month_param = month;
            string monthName;
            int monthNumber = 1;
            string monthKey = "1";

            // validate values
            // year
            if(!Int32.TryParse(year, out yearSelected)){
                yearSelected = Int32.Parse(año_formateado);
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
                        monthNumber = (int)Enum.Parse(typeof(Months), monthName);
                        break;
                    }
                }
            }
            int daysInMonth = DateTime.DaysInMonth(yearSelected, monthNumber);

            string rango_inicio = $"01-{monthKey}-{yearSelected}";
            string rango_final = $"{daysInMonth}-{monthKey}-{yearSelected}";


            data.Add("rango_inicio", rango_inicio);
            data.Add("rango_final", rango_final);

            return data;
        }
    }
}