using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Models
{
    public class libros
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public string pais { get; set; }
        public string autor { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public string editorial { get; set; }
    }
}