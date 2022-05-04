using ApiPersonajesCore0Auth.Models;
using ApiPersonajesCore0Auth.Repositories;
using ApiPersonajesCore0Auth.WiewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        //[Authorize]
        [HttpGet]
        public ActionResult<List<PERSONAJES>> GetPersonajes()
        {
            return this.repo.GetPersonajes();
        }

        [HttpGet("{id}")]
        public ActionResult<PERSONAJES> BuscarPersonaje(int id)
        {
            return this.repo.BuscarPersonaje(id);
        }
        [HttpGet("serie/{id2}")]
        public ActionResult<List<PERSONAJES>> PersonajesSubordinados(int id2)
        {
            return this.repo.GetPersonajesSubordinados(id2);
        }

        //[HttpPost]
        //public ActionResult<PERSONAJES> AñadirPersonaje(PERSONAJES personaje)
        //{
        //    return this.repo.AñadirPersonaje(personaje);
        //}
        [Authorize]
        [HttpPost]
        public ActionResult<PERSONAJES> CreateEmployee(PERSONAJES personaje)
        {
            try
            {
                if (personaje == null) 
                    return BadRequest();

                var create = this.repo.AñadirPersonaje(personaje);

                return CreatedAtAction(nameof(GetPersonajes),
                    new { id = create.IdPersonaje }, create);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }


            //[HttpPost("{idpersonaje}/{idserie}")]
            //public ActionResult<PERSONAJES> PersonajeChangeSerie(int idpersonaje, int idserie)
            //{
            //    return this.repo.PersonajeChangeSerie(idpersonaje, idserie);
            //}


        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<PERSONAJES> UpdatePersonaje(PERSONAJES pj)
        {
            return repo.UpdatePersonaje(pj);
        }

    }
}
