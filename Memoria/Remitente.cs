using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memoria
{
    public class Remitente
    {
        string email = "die-leo@hotmail.com";
        string contraseña = "momnom";

        public string Email { get => email; set => email = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}