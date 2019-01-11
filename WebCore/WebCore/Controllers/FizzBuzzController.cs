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

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
