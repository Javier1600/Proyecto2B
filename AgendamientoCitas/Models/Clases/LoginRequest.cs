using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendamientoCitas.Models.Clases
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}