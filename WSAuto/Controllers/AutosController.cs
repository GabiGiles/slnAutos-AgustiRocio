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

        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            return context.Autos.Find(id);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto auto = context.Autos.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            context.Autos.Remove(auto);
            context.SaveChanges();
            return auto;
        }

        [HttpGet("GetByModelAndBrand/{model}/{brand}")]
        public IEnumerable<Auto> GetByModelAndBrand(string model, string brand)
        {
            var profesores = (from a in context.Autos
                              where a.Modelo == model
                              && a.Marca == brand
                              select a).ToList();
            return profesores;
        }

        [HttpGet("GetByColor/{color}")]
        public IEnumerable<Auto> GetByColor(string color)
        {
            var profesores = (from a in context.Autos
                              where a.Color == color
                              select a).ToList();
            return profesores;
        }
    }
}
