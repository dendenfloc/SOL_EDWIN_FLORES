using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class LIBROS
    {
        [Key]
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string CATEGORIA { get; set; }
        public string AUTOR { get; set; }
        public string PAIS { get; set; }
        public DateTime FECHA_PUBLICACION { get; set; }
        public string EDITORIAL { get; set; }
    }
}