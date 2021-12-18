using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingExample.Model;

namespace RoutingExample.Controllers
{
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return $"GET: Controller => Values; Action => Get.";
        }

        [HttpGet]
        public string Index()
        {
            return $"GET: Controller => Values; Action => Index.";
        }

        [HttpGet]
        [ActionName("WithInt")]
        public string Index(int value)
        {
            return $"GET: Controller => Values; Action => WithInt; Value = {value}"; 
        }

        [HttpGet]
        [ActionName("WithBoolean")]
        public string Index(bool value)
        {
            return $"GET: Controller => Values; Action => WithBoolean; Value = {value}";
        }

        [HttpPost]
        [ActionName("UserFromBody")]
        public string Index([FromBody] User user)
        {
            return user.ToString();
        }

        [HttpGet]
        [ActionName("UserFromQuery")]
        public string IndexQuery([FromQuery] User user)
        {
            return user.ToString();
        }

        [HttpPost]
        [ActionName("UserFromForm")]
        public string IndexForm([FromForm] User user)
        {
            return user.ToString();
        }

        [HttpPost]
        public string HandlePostFile(IFormFile file)
        {
            return file.Length.ToString();
        }

        [HttpPut]
        [ActionName("UserFromBodyPut")]
        public IActionResult IndexBodyPut([FromBody] User user)
        {
            return Accepted(user.ToString());
        }

        [HttpDelete]
        [ActionName("UserFromBodyDelete")]
        public IActionResult IndexBodyDelete([FromBody] User user)
        {
            return NoContent();
        }
    }
}
