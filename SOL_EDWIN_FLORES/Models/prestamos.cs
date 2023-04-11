using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class prestamos
    {
        public int id { get; set; }
        public int id_libro { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_prestamo { get; set; }
        public DateTime fecha_devolucion { get; set; }
        public string tipo_prestamo { get; set; }
        public string tipo_lectura { get; set; }

    }
}