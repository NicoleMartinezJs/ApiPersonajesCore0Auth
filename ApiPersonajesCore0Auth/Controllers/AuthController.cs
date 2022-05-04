using ApiPersonajesCore0Auth.Models;
using ApiPersonajesCore0Auth.Repositories;
using ApiPersonajesCore0Auth.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Controllers
{
    //www.apiempleados/Auth
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryPersonajes repo;
        HelperToken helper;

        public AuthController(RepositoryPersonajes repo
            , IConfiguration configuration)
        {
            this.helper = new HelperToken(configuration);
            this.repo = repo;
        }

        //NECESITAMOS UN PUNTO DE ENTRADA (ENDPOINT) PARA QUE EL 
        //USUARIO NOS ENVIE LOS DATOS DE SU VALIDACION
        //LOS ENDPOINT AUTH SON POST
        //LO QUE RECIBIREMOS SERA UserName y Password
        //QUE NOSOTROS LO HEMOS INCLUIDO CON LoginModel
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            USUARIOSAZURE empleado =
                this.repo.ExisteUsuario(model.UserName
                , model.Password);
            if (empleado != null)
            {
                //NECESITAMOS CREARNOS UN TOKEN
                //EL TOKEN LLEVARA INFORMACION DE TIPO ISSUER
                //, TIEMPO DE DURACION
                //, CREDENCIALES DEL USUARIO
                //, PODEMOS ALMACENAR INFO EXTRA DENTRO DEL TOKEN.
                //VAMOS A ALMACENAR A NUESTRO EMPLEADO
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(empleado))
                };

                JwtSecurityToken token = new JwtSecurityToken
                    (
                     issuer: helper.Issuer
                     , audience: helper.Audience
                     , claims: claims
                     , expires: DateTime.UtcNow.AddMinutes(10)
                     , notBefore: DateTime.UtcNow
                     , signingCredentials:
                     new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256)
                    );
                //DEVOLVEMOS UNA RESPUESTA AFIRMATIVA
                //CON SU TOKEN
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}



