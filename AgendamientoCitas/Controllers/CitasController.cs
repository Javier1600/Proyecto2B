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
    [RoutePrefix("Citas")]
    public class CitasController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpGet]
        [Route("")]
        public IQueryable<Cita> GetCita()
        {
            return db.Cita;
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCita(int id)
        {
            Cita Cita = db.Cita.Find(id);
            if (Cita == null)
            {
                return NotFound();
            }

            return Ok(Cita);
        }

        [HttpGet]
        [Route("Paciente/{idPaciente}")]
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCitasPaciente(int idPaciente)
        {
            var citas = db.Cita.Where(x => x.idPaciente==idPaciente).ToList();
            if (citas == null)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        [HttpGet]
        [Route("{idEspecialidad}/Fecha")]
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCitaFecha(int idEspecialidad)
        {
            var dateTime = Request.GetQueryNameValuePairs().Where(m => m.Key == "fecha" ).SingleOrDefault();
            DateTime dt = Convert.ToDateTime(dateTime.Value);
            var docs = db.Doctor.Where(x=> x.idEspecialidad == idEspecialidad).ToList();
            var citasFecha = db.Cita.Where(x => x.fecha == dt ).ToList();
            var citas = new List<Cita>();
            foreach(var c in citasFecha)
            {
                foreach(var d in docs)
                {
                    if (c.idDoctor == d.idUsuario)
                        citas.Add(c);
                }
            }
            
            if (citas == null)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCita(int id, Cita Cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Cita.idCita)
            {
                return BadRequest();
            }

            db.Entry(Cita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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
        [ResponseType(typeof(Cita))]
        public IHttpActionResult PostCita(Cita Cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cita.Add(Cita);
            db.SaveChanges();

            return Ok(new MensajesWeb(Constantes.MensajeExitoPost));
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(Cita))]
        public IHttpActionResult DeleteCita(int id)
        {
            Cita Cita = db.Cita.Find(id);
            if (Cita == null)
            {
                return NotFound();
            }

            db.Cita.Remove(Cita);
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

        private bool CitaExists(int id)
        {
            return db.Cita.Count(e => e.idCita == id) > 0;
        }
    }
}