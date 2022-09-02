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
    [RoutePrefix("Doctores")]
    public class DoctorsController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpGet]
        [Route("")]
        public IQueryable<Doctor> GetDoctor()
        {
            return db.Doctor;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult GetDoctor(int id)
        {
            Doctor Doctor = db.Doctor.Find(id);
            if (Doctor == null)
            {
                return NotFound();
            }

            return Ok(Doctor);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctor(int id, Doctor Doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Doctor.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(Doctor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult PostDoctor(Doctor Doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doctor.Add(Doctor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DoctorExists(Doctor.idUsuario))
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
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult DeleteDoctor(int id)
        {
            Doctor Doctor = db.Doctor.Find(id);
            if (Doctor == null)
            {
                return NotFound();
            }

            db.Doctor.Remove(Doctor);
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

        private bool DoctorExists(int id)
        {
            return db.Doctor.Count(e => e.idUsuario == id) > 0;
        }
    }
}