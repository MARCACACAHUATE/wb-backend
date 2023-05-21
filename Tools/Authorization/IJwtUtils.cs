using wb_backend.Models;

namespace wb_backend.Tools.Authorization;

public interface IJwtUtils {
    string GenerateJwtToken(User user);
    int? ValidateJwtToken(string token);
}