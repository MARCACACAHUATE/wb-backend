using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wb_backend.Services;

namespace wb_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase {

        private readonly IServiceExample _serviceExample;

        public EventosController(IServiceExample serviceExample){
            _serviceExample = serviceExample;
        }

        [HttpGet]
        public IActionResult EndpointExample(){
            string ejemplo = _serviceExample.ExposeExample();
            return Ok(ejemplo);
        }
    }
}
