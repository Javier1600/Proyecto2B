using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgendamientoCitas.Models;
using AgendamientoCitas.Models.Clases;

namespace AgendamientoCitas.Controllers
{
    [RoutePrefix("Usuarios")]
    public class UsuariosController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpGet]
        [Route("")]
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }

        [Route("{id}")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario Usuario = db.Usuario.Find(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }

        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Usuario.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(Usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Constantes.MensajeExitoPut);
        }

        [Route("")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario.Add(Usuario);
            db.SaveChanges();

            return Ok(Constantes.MensajeExitoPost);
        }

        [Route("{id}")]
        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario Usuario = db.Usuario.Find(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(Usuario);
            db.SaveChanges();

            return Ok(Constantes.MensajeExitoDelete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.idUsuario == id) > 0;
        }
    }
}