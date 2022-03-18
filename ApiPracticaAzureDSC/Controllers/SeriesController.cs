using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPracticaAzureDSC.Repositories;
using ApiPracticaAzureDSC.Models;

namespace ApiPracticaAzureDSC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repo.GetSeries();
        }
        [HttpPost]
        public ActionResult InsertarSeries(Serie serie)
        {
            this.repo.InsertarSerie(serie.Nombre, serie.Imagen, (float)serie.Puntuacion, serie.Anyo);
            return Ok();
        }
        [HttpPut]
        public ActionResult EditarSerie(Serie serie)
        {
            this.repo.EditarSerie(serie.IdSerie, serie.Nombre, serie.Imagen, (float)serie.Puntuacion, serie.Anyo);
            return Ok();
        }

        [HttpGet("{idserie}")]
        public ActionResult<Serie> FindSerie(int idserie)
        {
            return this.repo.FindSerie(idserie);
        }
        [HttpDelete("idserie")]
        public ActionResult DeleteSerie(int idserie)
        {
            this.repo.DeleteSerie(idserie);
            return Ok();
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie)
        {
           return this.repo.GetPersonajesSerie(idserie);
           
        }
    }
}
