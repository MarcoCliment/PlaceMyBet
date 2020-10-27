using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Placemybet.Models;

namespace Placemybet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuestas> Get()
        {
            var repo = new apuestasRepository();
            List<Apuestas> apuestas = repo.Retrieve();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
