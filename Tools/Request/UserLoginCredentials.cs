using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.Request;

public class UserLoginCredentials {
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}