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
    [RoutePrefix("Especialidad")]
    public class EspecialidadsController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        // GET: api/Especialidads
        [HttpGet]
        [Route("")]
        public IQueryable<Especialidad> GetEspecialidad()
        {
            return db.Especialidad;
        }
        [Route("{id}")]
        // GET: api/Especialidads/5
        [ResponseType(typeof(Especialidad))]
        public IHttpActionResult GetEspecialidad(int id)
        {
            Especialidad Especialidad = db.Especialidad.Find(id);
            if (Especialidad == null)
            {
                return NotFound();
            }

            return Ok(Especialidad);
        }

        [Route("{id}")]
        // PUT: api/Especialidads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspecialidad(int id, Especialidad Especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Constantes.MensajeError);
            }

            if (id != Especialidad.idEspecialidad)
            {
                return BadRequest(Constantes.MensajeError);
            }

            db.Entry(Especialidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(id))
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
        // POST: api/Especialidads
        [ResponseType(typeof(Especialidad))]
        public IHttpActionResult PostEspecialidad(Especialidad Especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Especialidad.Add(Especialidad);
            db.SaveChanges();

            return Ok(new MensajesWeb(Constantes.MensajeExitoPost));
        }
        [Route("{id}")]
        // DELETE: api/Especialidads/5
        [ResponseType(typeof(Especialidad))]
        public IHttpActionResult DeleteEspecialidad(int id)
        {
            Especialidad Especialidad = db.Especialidad.Find(id);
            if (Especialidad == null)
            {
                return NotFound();
            }

            db.Especialidad.Remove(Especialidad);
            db.SaveChanges();

            return Ok(new MensajesWeb(Constantes.MensajeExitoDelete));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspecialidadExists(int id)
        {
            return db.Especialidad.Count(e => e.idEspecialidad == id) > 0;
        }
    }
}