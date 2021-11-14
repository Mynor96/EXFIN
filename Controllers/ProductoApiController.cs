using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProductoApiController : ApiController
    {
       
            EXAMEN_FINALEntities bd = new EXAMEN_FINALEntities();
            public IHttpActionResult getProducto()
            {
                var result = bd.SP_PRODUCTO(0, "",0,0,0,"", "Get").ToList();
                return Ok(result);
            }


            public IHttpActionResult InsertProducto(PRODUCTO pr)
            {
                var insertCli = bd.SP_PRODUCTO(0, pr.NOMBRE, pr.CANTIDAD,pr.STOCK,pr.ID_PROVEEDOR,pr.ESTADO, "Insert").ToList();
                return Ok(insertCli);
            }

            public IHttpActionResult getProductoId(int id)
            {
                var aldetail = bd.SP_PRODUCTO(id, "",0,0,0, "", "GetId").Select(z => new ProductosClass()
                {
                    Id = z.ID,
                    Nombre = z.NOMBRE,
                    Cantidad = Convert.ToInt32(z.CANTIDAD),
                    Stock = Convert.ToInt32(z.STOCK),
                    Id_proveedor= Convert.ToInt32(z.ID_PROVEEDOR),
                    Estado=z.ESTADO

                }).FirstOrDefault<ProductosClass>();
                return Ok(aldetail);
            }

            public IHttpActionResult Put(ProductosClass al)
            {
                var updateal = bd.SP_PRODUCTO(al.Id, al.Nombre,al.Cantidad,al.Stock,al.Id_proveedor, al.Estado, "Update").ToList();
                return Ok(updateal);
            }
            public IHttpActionResult Delete(int id)
            {
                var deletetemp = bd.SP_PRODUCTO(id, "", 0, 0, 0, "", "Delete").Select(z => new ProductosClass()
                {
                    Id = z.ID,
                    Nombre = z.NOMBRE,
                    Cantidad = Convert.ToInt32(z.CANTIDAD),
                    Stock = Convert.ToInt32(z.STOCK),
                    Id_proveedor = Convert.ToInt32(z.ID_PROVEEDOR),
                    Estado = z.ESTADO
                }).FirstOrDefault<ProductosClass>();

                bd.SaveChanges();
                return Ok();

            }
        
    }
}
