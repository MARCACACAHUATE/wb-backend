using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.Request;

public class UploadImageRequest {

    public IFormFile File { get; set; } = null!;
    [Required]
    public int Evento_id { get; set; }
}