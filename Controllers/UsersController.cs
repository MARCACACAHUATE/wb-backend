using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using wb_backend.Services;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: ControllerBase {

    private readonly IUserServices _userServices;

    public UsersController(IUserServices userServices){
        _userServices = userServices;
    }

    [HttpPost]
    public IActionResult CreateUser(UserRequest request){
        Response response = new Response();
        try{
            response.data = _userServices.NewUser(request);
            response.Message = "Usuario Creado";
            response.Estado = 1;
            return Ok(response);
        }catch(ValidationException){
            return BadRequest();
        }
    }

    [HttpGet]
    public IActionResult GetUsers(){
        Response response = new Response();
        try{
            response.data = _userServices.GetUserList();
            response.Message = "Operacion Existosa";
            response.Estado = 1;
            return Ok(response);
        }catch(Exception error){
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id){
        Response response = new Response();
        try{
            response.data = _userServices.GetUserById(id);
            response.Message = "Operacion Existosa";
            response.Estado = 1;
            return Ok(response);
        }catch(Exception error){
            return BadRequest(error.Message);
        }
    }

}