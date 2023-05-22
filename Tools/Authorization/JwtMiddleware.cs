using wb_backend.Services;

namespace wb_backend.Tools.Authorization;

public class JwtMiddleware {

    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserServices userServices, IJwtUtils jwtUtils){
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if(userId != null){
            context.Items["User"] = userServices.GetUserById(userId.Value);
        }

        await _next(context);
    }
}