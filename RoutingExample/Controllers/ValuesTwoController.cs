using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingExample.Model;

namespace RoutingExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesTwoController : ControllerBase
    {
        private const string FROM_FORM_ROUTING = "user-from-form";
        
        [HttpGet]
        [Route("Retrieve")]
        public string Get()
        {
            return $"GET: Controller => ValuesTwo; Action => Get.";
        }

        [HttpGet("Primary")]
        public string Index()
        {
            return $"GET: Controller => ValuesTwo; Action => Index.";
        }

        [HttpGet]
        [Route("test/data/{value:int}")]
        public string Index(int value)
        {
            return $"GET: Controller => ValuesTwo; Action => Index; Value = {value}";
        }

        [HttpGet]
        [Route("test/data/{value:bool}")]
        public string Index(bool value)
        {
            return $"GET: Controller => ValuesTwo; Action => Index; Value = {value}";
        }

        [HttpPost("user-from-body")]
        public string Index([FromBody] User user)
        {
            return user.ToString();
        }

        [HttpGet("[action]")]
        public string IndexQuery([FromQuery] User user)
        {
            return user.ToString();
        }

        [HttpPost]
        [Route(FROM_FORM_ROUTING)]
        public string IndexForm([FromForm] User user)
        {
            return user.ToString();
        }

        [HttpPost]
        [Route("file/upload")]
        public string HandlePostFile(IFormFile file)
        {
            return file.Length.ToString();
        }

        [HttpPut]
        public IActionResult IndexBodyPut([FromBody] User user)
        {
            return Accepted(user.ToString());
        }

        [HttpDelete]
        public IActionResult IndexBodyDelete([FromBody] User user)
        {
            return NoContent();
        }
    }
}
