using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.CustomDataAnnotations;

public class ThreeDaysAfterToday : ValidationAttribute {

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext){

        DateTime fechaEvento = DateTime.ParseExact(value as string, "dd-MM-yyyy", null);
        DateTime today = DateTime.Today.ToUniversalTime();

        TimeSpan diasDiferencia = fechaEvento - today;

        // Compare
        if(diasDiferencia.Days < 3){
            string message = "La fecha del evento tiene que ser 3 dias despues del dia de hoy";
            return new ValidationResult(message);
        }else{
            return ValidationResult.Success;
        }
    }
}