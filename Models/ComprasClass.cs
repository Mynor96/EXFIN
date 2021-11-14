using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EXFIN.Models;

namespace EXFIN.Models
{
    public class ComprasClass
    { 


    public int Id { get; set; }
    public int Id_producto { get; set; }
    public int Id_proveedor { get; set; }
    public int Precio { get; set; }
    public int Cantidad { get; set; }
  
}
}