using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using wb_backend.Models;

namespace wb_backend.Tools.Authorization;

public class AuthorizeAttribute: Attribute, IAuthorizationFilter {

    private readonly IList<Role> _roles;

    public AuthorizeAttribute(params Role[] roles){
        _roles = roles ?? new Role[] {};
    }

    public void OnAuthorization(AuthorizationFilterContext context){
        // Salta la autorizacion si el controller es decorado con el atributo [AllowAnonymous]
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if(allowAnonymous)
            return;

        // Authorizacion
        var user = (User)context.HttpContext.Items["User"];
        if(user == null || (_roles.Any() && !_roles.Contains((Role)Enum.Parse(typeof(Role), user.TipoUser.TypeUser)))){
            // No logeado o rol sin autorizacion
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}