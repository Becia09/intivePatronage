using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApi.Controllers
{
    [Route("[controller]")]  //[Route("[controller]&number")]
    public class FizzBuzzController : Controller
    {
        private FizzBuzz fb = new FizzBuzz();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Podaj liczbę po ukośniku" };
        }

        // GET api/<controller>/5
        //[Route("&number=")]
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return fb.FizzOrBuzz(id);
        }
    }
}
