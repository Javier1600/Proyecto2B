using AgendamientoCitas.Models;
using AgendamientoCitas.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendamientoCitas.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {
        private HospitalDB db = new HospitalDB();

        [HttpPost]
        [Route("ValidarClave")]
        public IHttpActionResult ValidarClave(LoginRequest request)
        {
            var usuario = db.Usuario.FirstOrDefault(x => x.cedula == request.Usuario);
            if (usuario == null)
                return BadRequest("Datos Erroneos");
            if (usuario.password != request.Password)
                return BadRequest("Datos Erroneos");
            else { 
                Rol rol = db.Rol.FirstOrDefault(x => x.idRol == usuario.idRol);
                return Ok(new { Message = "Usuario autenticado", Usuario = usuario, Rol = rol });
            }

        }
    }
}
