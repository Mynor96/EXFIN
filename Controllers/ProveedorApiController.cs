using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProveedorApiController : ApiController
    {
        EXAMEN_FINALEntities bd = new EXAMEN_FINALEntities();
        public IHttpActionResult getProveedor()
        {
            var result = bd.SP_PROVEEDOR(0,"","","Get").ToList();
            return Ok(result);
        }


        public IHttpActionResult InsertProveedor(PROVEEDOR p)
        {
            var insertCli = bd.SP_PROVEEDOR(0,p.NOMBRE,p.ESTADO, "Insert").ToList();
            return Ok(insertCli);
        }

        public IHttpActionResult getProveedorId(int id)
        {
            var aldetail = bd.SP_PROVEEDOR(id,"","","GetId").Select(x => new ProveedoresClass()
            {
                Id = x.ID,
                Nombre = x.NOMBRE,
                Estado = x.ESTADO
            }).FirstOrDefault<ProveedoresClass>();
            return Ok(aldetail);
        }

        public IHttpActionResult Put(ProveedoresClass al)
        {
            var updateal = bd.SP_PROVEEDOR(al.Id, al.Nombre,  al.Estado, "Update").ToList();
            return Ok(updateal);
        }
        public IHttpActionResult Delete(int id)
        {
            var deletetemp = bd.SP_PROVEEDOR(id, "","","Delete").Select(x => new ProveedoresClass()
            {
                Id = x.ID,
                Nombre = x.NOMBRE,
                Estado = x.ESTADO
            }).FirstOrDefault<ProveedoresClass>();

            bd.SaveChanges();
            return Ok();

        }
    }
}

