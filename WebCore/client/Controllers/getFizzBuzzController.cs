using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace client.Controllers
{
    [Route("[controller]")]
    public class GetFizzBuzzController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string html = string.Empty;
            string url = "https://localhost:44394/fizzbuzz/" + id;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
            html = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            return html;
        }
    }
}
