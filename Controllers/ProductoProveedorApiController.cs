using EXFIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EXFIN.Controllers
{
    public class ProductoProveedorApiController : ApiController
    {
         EXAMEN_FINALEntities bd = new EXAMEN_FINALEntities();

        public IHttpActionResult getConsultaActivo()
        {
            List<PROVEEDOR> lproveedor = bd.PROVEEDOR.ToList();
            List<PRODUCTO> laproducto = bd.PRODUCTO.ToList();



            var query = from c in lproveedor
                        join a in laproducto on c.ID equals a.ID_PROVEEDOR into t1
                        from a in t1.DefaultIfEmpty()

                        select new ProductoProveedoresClass { getproducto = a, getproveedor = c };
            return Ok(query);
        }
    }
}
