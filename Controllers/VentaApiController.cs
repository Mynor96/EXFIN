using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class VentaApiController : ApiController
    {
        EXAMEN_FINALEntities bd = new EXAMEN_FINALEntities();
        public IHttpActionResult getVenta()
        {
            var result = bd.SP_VENTA(0, 0, 0, 0, 0, "Get").ToList();
            return Ok(result);
        }


        public IHttpActionResult InsertCompra(VENTA c)
        {
            var insertCli = bd.SP_VENTA(0, c.ID_PRODUCTO, c.ID_PROVEEDOR, c.PRECIO, c.CANTIDAD, "Insert").ToList();
            return Ok(insertCli);
        }

        public IHttpActionResult getVentaId(int id)
        {
            var aldetail = bd.SP_VENTA(id, 0, 0, 0, 0, "GetId").Select(z => new VentasClass()
            {
                Id = z.ID,
                Id_producto = Convert.ToInt32(z.ID_PRODUCTO),
                Id_proveedor = Convert.ToInt32(z.ID_PROVEEDOR),
                Precio = Convert.ToInt32(z.PRECIO),
                Cantidad = Convert.ToInt32(z.CANTIDAD)

            }).FirstOrDefault<VentasClass>();
            return Ok(aldetail);
        }

        public IHttpActionResult Put(VentasClass al)
        {
            var updateal = bd.SP_COMPRA(al.Id, al.Id_producto, al.Id_proveedor, al.Precio, al.Cantidad, "Update").ToList();
            return Ok(updateal);
        }
        public IHttpActionResult Delete(int id)
        {
            var deletetemp = bd.SP_COMPRA(id, 0, 0, 0, 0, "Delete").Select(z => new VentasClass()
            {
                Id = z.ID,
                Id_producto = Convert.ToInt32(z.ID_PRODUCTO),
                Id_proveedor = Convert.ToInt32(z.ID_PROVEEDOR),
                Precio = Convert.ToInt32(z.PRECIO),
                Cantidad = Convert.ToInt32(z.CANTIDAD)
            }).FirstOrDefault<VentasClass>();

            bd.SaveChanges();
            return Ok();

        }
    }
}
