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
        public IEnumerable<Mercados> Get()
        {
            var repo = new mercadosRepository();
            List<Mercados> mercados = repo.Retrieve();
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
