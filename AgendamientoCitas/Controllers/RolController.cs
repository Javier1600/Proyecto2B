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
    [RoutePrefix("Roles")]
    public class RolController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [Route("")]
        public IQueryable<Rol> GetRol()
        {
            return db.Rol;
        }

        [Route("{id}")]
        [ResponseType(typeof(Rol))]
        public IHttpActionResult GetRol(int id)
        {
            Rol Rol = db.Rol.Find(id);
            if (Rol == null)
            {
                return NotFound();
            }

            return Ok(Rol);
        }

        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRol(int id, Rol Rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Rol.idRol)
            {
                return BadRequest();
            }

            db.Entry(Rol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new MensajesWeb(Constantes.MensajeExitoPut));
        }

        [Route("")]
        [ResponseType(typeof(Rol))]
        public IHttpActionResult PostRol(Rol Rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rol.Add(Rol);
            db.SaveChanges();

            return Ok(new MensajesWeb(Constantes.MensajeExitoPost));
        }

        [Route("{id}")]
        [ResponseType(typeof(Rol))]
        public IHttpActionResult DeleteRol(int id)
        {
            Rol Rol = db.Rol.Find(id);
            if (Rol == null)
            {
                return NotFound();
            }

            db.Rol.Remove(Rol);
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

        private bool RolExists(int id)
        {
            return db.Rol.Count(e => e.idRol == id) > 0;
        }
    }
}