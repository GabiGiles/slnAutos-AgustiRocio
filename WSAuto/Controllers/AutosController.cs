using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WSAuto.Data;
using WSAuto.Models;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly DbSWAutoContext context;
        public AutosController(DbSWAutoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Autos.ToList();
        }

        [HttpGet("GetByModel/{model}")]
        public IEnumerable<Auto> GetByModel(string model)
        {
            var profesores = (from a in context.Autos
                              where a.Modelo == model
                              select a).ToList();
            return profesores;
        }

        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            context.Autos.Add(auto);
            context.SaveChanges();
            return Ok();
        }
    }
}
