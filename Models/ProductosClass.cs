using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXFIN.Models
{
    public class ProductosClass
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public int Id_proveedor { get; set; }
        public String Estado { get; set; }
    }
}