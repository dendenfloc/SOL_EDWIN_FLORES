using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class usuarios
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string tipo_usuario { get; set; }
        public int estado { get; set; }
    }
}