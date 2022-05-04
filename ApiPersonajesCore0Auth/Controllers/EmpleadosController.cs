using ApiPersonajesCore0Auth.Models;
using ApiPersonajesCore0Auth.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        RepositoryPersonajes repo;

        public EmpleadosController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<List<USUARIOSAZURE>> GetEmpleados()
        {
            return this.repo.GetEmpleados();
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<USUARIOSAZURE> BuscarEmpleado(int id)
        {
            return this.repo.BuscarEmpleado(id);
        }
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<USUARIOSAZURE> PerfilEmpleado()
        {
     
            List<Claim> claims =
                HttpContext.User.Claims.ToList();
            
            String json =
                claims.SingleOrDefault(x => x.Type == "UserData").Value;
   
            USUARIOSAZURE emp =
                JsonConvert.DeserializeObject<USUARIOSAZURE>(json);
            return emp;
        }


    }
}

