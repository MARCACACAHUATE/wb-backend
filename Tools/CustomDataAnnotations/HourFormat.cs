using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.CustomDataAnnotations;

public class HourFormat : ValidationAttribute {

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext){
        string hora = value as string;
        bool isValid = TimeSpan.TryParse(hora, out var dummy);
        if(isValid){
            return ValidationResult.Success;
        }else{
            return new ValidationResult("Formato de hora invalido. El foramto debe ser HH:mm");
        }
    }
}