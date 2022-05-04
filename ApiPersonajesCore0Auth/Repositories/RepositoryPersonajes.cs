using ApiPersonajesCore0Auth.Data;
using ApiPersonajesCore0Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Repositories
{
    public class RepositoryPersonajes
    {
        PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public List<SERIES> GetSeries()
        {
            return this.context.Series.ToList();
        }

        public SERIES BuscarSerie(int idserie)
        {
            return this.context.Series
                .SingleOrDefault(x => x.IdSerie == idserie);
        }
        public List<PERSONAJES> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }
        public PERSONAJES BuscarPersonaje(int idpersonaje)
        {
            return this.context.Personajes
                .SingleOrDefault(x => x.IdPersonaje == idpersonaje);
        }
        public List<USUARIOSAZURE> GetEmpleados()
        {
            return this.context.UsuarioAzures.ToList();
        }

        public USUARIOSAZURE BuscarEmpleado(int idempleado)
        {
            return this.context.UsuarioAzures
                .SingleOrDefault(x => x.IdUsuario == idempleado);
        }

        public USUARIOSAZURE ExisteUsuario(string username, string password)
        {
            return this.context.UsuarioAzures.SingleOrDefault
                (x => x.Email == username && x.Password == password);
        }

        public List<PERSONAJES> GetPersonajes(int idserie)
        {
            var consulta = from datos in context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }
        public PERSONAJES AñadirPersonaje(PERSONAJES personaje)
        {
            int newId = GetPersonajes().Count() + 100;
            personaje.IdPersonaje = newId;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
            return personaje;
        }

        public PERSONAJES PersonajeChangeSerie(int idpersonaje, int idserie)
        {
            PERSONAJES personaje = this.context.Personajes.Find(idpersonaje);
            personaje.IdSerie = idserie;
            this.context.Personajes.Update(personaje);
            this.context.SaveChanges();
            return personaje;
        }
        public List<PERSONAJES> GetPersonajesSubordinados(int idserie)
        {
            var consulta = from datos in context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }
        public PERSONAJES UpdatePersonaje(PERSONAJES personaje)
        {
            var result = this.context.Personajes
                .FirstOrDefault(p => p.IdPersonaje == personaje.IdPersonaje);
            if (result != null)
            {
                //result.NombrePersonaje = personaje.NombrePersonaje;
                //result.Imagen = personaje.Imagen;
                result.IdSerie = personaje.IdSerie;
                //this.context.Update(personaje);
                this.context.SaveChanges();
                return result;
            }
            return null;
        }


    }
}

    

