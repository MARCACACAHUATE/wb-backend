using wb_backend.Models;

namespace wb_backend.Tools.Response;

public class AuthenticateResponse {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(User user, string token){
        Id = user.Id;
        FirstName = user.First_name;
        LastName = user.Last_name;
        Email = user.Email;
        Role = user.TipoUser.TypeUser;
        Token = token;
    }
}