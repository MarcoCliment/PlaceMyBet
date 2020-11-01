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
        public IEnumerable<ApuestasDTO> Get()
        {
            var repo = new apuestasRepository();
            //List<Apuestas> apuestas = repo.Retrieve();
            List<ApuestasDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return null;
        }

        // POST: api/Apuestas
        public bool Post() {
            userApuesta u = new userApuesta("cem201409@gmail.com", 4, "Over", 150);
            var repo = new apuestasRepository();
            return repo.HacerApuesta(u);            
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
