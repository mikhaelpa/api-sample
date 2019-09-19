using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSupport.Data;
using ApiSupport.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TAM.LogisticSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSupport.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly GetDataService getDataService;
        public ApiController(GetDataService getData)
        {
            this.getDataService = getData;
        }

        // GET api/values/5
        [HttpGet("number-string/{param}")]
        public ActionResult<string> Get(string param)
        {
            var result = new NumberToStringUtilityService(param);
            return Ok($"{result.ResultString}");
        }

        [HttpGet("get-bio")]
        public ActionResult GetSample()
        {
            var result = JsonConvert.SerializeObject(Profiles.Bio, Formatting.Indented);
            return Ok(result); 
        }

        [HttpGet("get-benefit")]
        public ActionResult GetBenefit()
        {
            var result = JsonConvert.SerializeObject(getDataService.GetBenefits().GetAwaiter().GetResult(), Formatting.Indented);
            return Ok(result);
        }
    }
}
