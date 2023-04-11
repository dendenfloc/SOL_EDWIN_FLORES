using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class USUARIOS
    {
        [Key]
        public int ID { get; set; }
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string TIPO_USUARIO { get; set; }
        public int ESTADO { get; set; }
    }
}