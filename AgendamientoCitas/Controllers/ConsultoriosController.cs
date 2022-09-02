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
    [RoutePrefix("Consultorios")]
    public class ConsultoriosController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpGet]
        [Route("")]
        public IQueryable<Consultorio> GetConsultorio()
        {
            return db.Consultorio;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Consultorio))]
        public IHttpActionResult GetConsultorio(int id)
        {
            Consultorio Consultorio = db.Consultorio.Find(id);
            if (Consultorio == null)
            {
                return NotFound();
            }

            return Ok(Consultorio);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultorio(int id, Consultorio Consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Consultorio.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(Consultorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorioExists(id))
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
        [ResponseType(typeof(Consultorio))]
        public IHttpActionResult PostConsultorio(Consultorio Consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultorio.Add(Consultorio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConsultorioExists(Consultorio.idUsuario))
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
        [ResponseType(typeof(Consultorio))]
        public IHttpActionResult DeleteConsultorio(int id)
        {
            Consultorio Consultorio = db.Consultorio.Find(id);
            if (Consultorio == null)
            {
                return NotFound();
            }

            db.Consultorio.Remove(Consultorio);
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

        private bool ConsultorioExists(int id)
        {
            return db.Consultorio.Count(e => e.idUsuario == id) > 0;
        }
    }
}