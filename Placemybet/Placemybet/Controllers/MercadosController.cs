﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Placemybet.Models;

namespace Placemybet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadosDTO> Get()
        {
            var repo = new mercadosRepository();
            //List<Mercados> mercados = repo.Retrieve();
            List<MercadosDTO> mercados = repo.RetrieveDTO();
            return mercados;
        }

        // GET: api/Mercados/5
        public string Get(int id)
        {
            return null;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
