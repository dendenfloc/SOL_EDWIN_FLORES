using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SOL_EDWIN_FLORES.Clases
{
    public class reportes
    {
       
        [Display(Name = "ID Préstamo")]
        public int id_prestamo { get; set; }
        [Display(Name = "ID libro")]
        public int id_libro { get; set; }
        [Display(Name = "Nombre Libro")]
        public string nombre_libro { get; set; }
        [Display(Name = "Fecha prestamo")]
        public DateTime fecha_prestamo { get; set; }
        [Display(Name = "DNI Usuario")]
        public string dni_usuario { get; set; }
        [Display(Name = "Nombre Usuario")]
        public string nombre_usuario { get; set; }
        [Display(Name = "Apellido Usuario")]
        public string apellido_usuario { get; set; }
        [Display(Name = "Tipo Usuario")]
        public string tipo_usuario { get; set; }
        [Display(Name = "Tipo Lectura")]
        public string tipo_lectura { get; set; }
        [Display(Name = "Fecha Devolución")]
        public DateTime? fecha_devolucion { get; set; }

        public string tipo_usuario_view => (tipo_usuario == "DOC") ? "Docente" : "Alumno";

    }
}