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
    [RoutePrefix("Enfermeras")]
    public class EnfermerasController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpGet]
        [Route("")]
        public IQueryable<Enfermera> GetEnfermera()
        {
            return db.Enfermera;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Enfermera))]
        public IHttpActionResult GetEnfermera(int id)
        {
            Enfermera Enfermera = db.Enfermera.Find(id);
            if (Enfermera == null)
            {
                return NotFound();
            }

            return Ok(Enfermera);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnfermera(int id, Enfermera Enfermera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Enfermera.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(Enfermera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermeraExists(id))
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

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Enfermera))]
        public IHttpActionResult PostEnfermera(Enfermera Enfermera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enfermera.Add(Enfermera);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EnfermeraExists(Enfermera.idUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new MensajesWeb(Constantes.MensajeExitoPost));
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(Enfermera))]
        public IHttpActionResult DeleteEnfermera(int id)
        {
            Enfermera Enfermera = db.Enfermera.Find(id);
            if (Enfermera == null)
            {
                return NotFound();
            }

            db.Enfermera.Remove(Enfermera);
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

        private bool EnfermeraExists(int id)
        {
            return db.Enfermera.Count(e => e.idUsuario == id) > 0;
        }
    }
}