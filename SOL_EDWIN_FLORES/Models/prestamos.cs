using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class PRESTAMOS
    {
        [Key]
        public int ID { get; set; }
        public int ID_LIBRO { get; set; }
        public int ID_USUARIO { get; set; }
        public DateTime FECHA_PRESTAMO { get; set; }
        public DateTime? FECHA_DEVOLUCION { get; set; }
        public string TIPO_LECTURA { get; set; }
    }
}