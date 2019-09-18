using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiSupport.Controllers
{
    [Route("sample")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok($"This works too on {DateTime.Now.ToShortDateString()}");
        }

        // GET api/values/5
        [HttpGet("{param}")]
        public ActionResult<string> Get(string param)
        {
            return Ok($"This works too {param}");
        }
    }
}
