using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProductoActivoController : Controller
    {
        // GET: ProductoActivo
       
            public ActionResult Index()
            {
                IEnumerable<ProductosActivosClass> conobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/ProductoActivoApi");

                var consumeapi = hc.GetAsync("ProductoActivoApi");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<ProductosActivosClass>>();
                    displaydata.Wait();
                    conobj = displaydata.Result;
                }
                return View(conobj);
            }
        
    }
}