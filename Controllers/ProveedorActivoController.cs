using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProveedorActivoController : Controller
    {
        // GET: ProveedorActivo
       
            public ActionResult Index()
            {
                IEnumerable<ProveedoresActivosClass> conobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/ProveedorActivoApi");

                var consumeapi = hc.GetAsync("ProveedorActivoApi");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<ProveedoresActivosClass>>();
                    displaydata.Wait();
                    conobj = displaydata.Result;
                }
                return View(conobj);
            }
        
    }
}