using ApiPersonajesCore0Auth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Data
{
    public class PersonajesContext: DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) :
        base(options)
        { }
        public DbSet<SERIES> Series { get; set; }
        public DbSet<PERSONAJES> Personajes { get; set; }
        public DbSet<USUARIOSAZURE> UsuarioAzures { get; set; }

    }
}
