using ApiPersonajesCore0Auth.Models;
using ApiPersonajesCore0Auth.Repositories;
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
    public class SeriesController : ControllerBase
    {
        RepositoryPersonajes repo;

        public SeriesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        //[Authorize]
        [HttpGet]
        public ActionResult<List<SERIES>> GetSeries()
        {
            return this.repo.GetSeries();
        }

        [HttpGet("{id}")]
        public ActionResult<SERIES> BuscarSerie(int id)
        {
            return this.repo.BuscarSerie(id);
        }
    }

}
