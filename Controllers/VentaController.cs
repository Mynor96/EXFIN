using EXFIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EXFIN.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        

            public ActionResult Index()
            {
                IEnumerable<VENTA> alobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeapi = hc.GetAsync("VentaApi");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<VENTA>>();
                    displaydata.Wait();
                    alobj = displaydata.Result;
                }
                return View(alobj);

            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(VENTA al)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var insertCli = hc.PostAsJsonAsync<VENTA>("VentaApi", al);
                insertCli.Wait();

                var savedata = insertCli.Result;
                if (savedata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Create");
            }

            public ActionResult Details(int id)
            {
                VentasClass objal = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeAPI = hc.GetAsync("CompraApi?id=" + id.ToString());
                consumeAPI.Wait();

                var readdata = consumeAPI.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayCliDetatails = readdata.Content.ReadAsAsync<VentasClass>();
                    displayCliDetatails.Wait();
                    objal = displayCliDetatails.Result;
                }
                return View(objal);
            }
            public ActionResult Edit(int id)
            {
                VentasClass objcli = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeAPI = hc.GetAsync("VentaApi?id=" + id.ToString());
                consumeAPI.Wait();

                var readdata = consumeAPI.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayCliDetatails = readdata.Content.ReadAsAsync<VentasClass>();
                    displayCliDetatails.Wait();
                    objcli = displayCliDetatails.Result;
                }
                return View(objcli);
            }

            [HttpPost]
            public ActionResult Edit(VentasClass al)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/VentaApi");

                var updateal = hc.PutAsJsonAsync<VentasClass>("VentaaApi", al);
                updateal.Wait();

                var savedata = updateal.Result;
                if (savedata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(al);
            }

            public ActionResult Delete(int id)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/CompraApi");

                var deleteal = hc.DeleteAsync("VentaaApi/" + id.ToString());
                deleteal.Wait();

                var savedata = deleteal.Result;
                if (savedata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Index");

            }
        
        }
}