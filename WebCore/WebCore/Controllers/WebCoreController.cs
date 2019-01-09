using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebCoreController : ControllerBase
    {
        private readonly WebCoreContext _context;

        public WebCoreController(WebCoreContext context)
        {
            _context = context;

            if (_context.WebCoreItems.Count() == 0)
            {
                // Create a new ClassItem if collection is empty,
                // which means you can't delete all ClassItems.
                _context.WebCoreItems.Add(new WebCoreItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/WebCore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebCoreItem>>> GetWebCoreItem()
        {
            return await _context.WebCoreItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebCoreItem>> GetWebCoreItem(long id)
        {
            var webCoreItem = await _context.WebCoreItems.FindAsync(id);

            if (webCoreItem == null)
            {
                return NotFound();
            }

            return webCoreItem;
        }

        /*// GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        }*/
    }
}
