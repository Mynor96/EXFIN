using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProveedorActivoApiController : ApiController
    {
        EXAMEN_FINALEntities bd = new EXAMEN_FINALEntities();

        public IHttpActionResult getConsultaActivo()
        {
            List<PROVEEDOR> lproveedor = bd.PROVEEDOR.ToList();
            List<PRODUCTO> laproducto = bd.PRODUCTO.ToList();
          


            var query = from c in laproducto
                        join a in lproveedor on c.ID_PROVEEDOR equals a.ID into t1
                        from a in t1.Where(x => x.ESTADO.StartsWith("ACT"))
                       
                        select new ProveedoresActivosClass { getproducto = c, getproveedor = a };
            return Ok(query);
        }
    }
}
