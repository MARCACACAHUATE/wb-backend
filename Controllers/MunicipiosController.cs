using Microsoft.AspNetCore.Mvc;
using wb_backend.Services;
using wb_backend.Tools.Request;
using wb_backend.Tools.Response;

namespace wb_backend.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MunicipiosController: ControllerBase {

    private readonly IMunicipioServices _municipioService;

    public MunicipiosController(IMunicipioServices municipioServices){
        _municipioService = municipioServices;
    }

    [HttpPost]
    public IActionResult CreateMunicipio(MunicipioRequest request){
        Response response = new Response();
        try{
            response.data = _municipioService.NewMunicipio(request);
            response.Message = "Municipio Creado con exito";
            response.Estado = 1;
            return Ok(response);
        }catch(Exception error){
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public IActionResult GetMunicipios(){
        Response response = new Response();
        try{
            response.data = _municipioService.GetMunicipiosList();
            response.Message = "Operacion exitosa";
            response.Estado = 1;
            return Ok(response);
        }catch(Exception error){
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetMunicipio(int id){
        Response response = new Response();
        try{
            response.data = _municipioService.GetMunicipioById(id);
            response.Message = "Operacion exitosa";
            response.Estado = 1;
            return Ok(response);
        }catch(Exception error){
            return BadRequest(error.Message);
        }
    }
}