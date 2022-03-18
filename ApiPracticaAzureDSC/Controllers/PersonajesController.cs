using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPracticaAzureDSC.Models;
using ApiPracticaAzureDSC.Repositories;

namespace ApiPracticaAzureDSC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;
        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

      [HttpGet]
      public ActionResult<List<Personaje>> GetPersonajes()
        {
            
            return this.repo.GetPersonajes();
        }
        [HttpPost]
        public ActionResult InsertarPersonajes(Personaje personaje)
        {
            this.repo.InsertarPersonaje(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        public ActionResult EditarPersonaje(Personaje personaje)
        {
            this.repo.EditarPersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpGet("{idpersonaje}")]
        public ActionResult<Personaje> FindSerie(int idpersonaje)
        {
            return this.repo.FindPersonaje(idpersonaje);
        }

        [HttpDelete("idpersonaje")]
        public ActionResult DeleteSerie(int idpersonaje)
        {
            this.repo.DeletePersonaje(idpersonaje);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{idserie}/{idpersonaje}")]
        public ActionResult<Personaje> PersonajeSerie(int idserie, int idpersonaje)
        {
            return this.repo.GetPersonajeSerie(idserie, idpersonaje);
        }
    }
}
