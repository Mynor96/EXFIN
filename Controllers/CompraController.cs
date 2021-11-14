using EXFIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EXFIN.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
       
            public ActionResult Index()
            {
                IEnumerable<COMPRA> alobj = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeapi = hc.GetAsync("CompraApi");
                consumeapi.Wait();

                var readdata = consumeapi.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displaydata = readdata.Content.ReadAsAsync<IList<COMPRA>>();
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
            public ActionResult Create(COMPRA al)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var insertCli = hc.PostAsJsonAsync<COMPRA>("CompraApi", al);
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
                ComprasClass objal = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeAPI = hc.GetAsync("CompraApi?id=" + id.ToString());
                consumeAPI.Wait();

                var readdata = consumeAPI.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayCliDetatails = readdata.Content.ReadAsAsync<ComprasClass>();
                    displayCliDetatails.Wait();
                    objal = displayCliDetatails.Result;
                }
                return View(objal);
            }
            public ActionResult Edit(int id)
            {
                ComprasClass objcli = null;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/");

                var consumeAPI = hc.GetAsync("CompraApi?id=" + id.ToString());
                consumeAPI.Wait();

                var readdata = consumeAPI.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var displayCliDetatails = readdata.Content.ReadAsAsync<ComprasClass>();
                    displayCliDetatails.Wait();
                    objcli = displayCliDetatails.Result;
                }
                return View(objcli);
            }

            [HttpPost]
            public ActionResult Edit(ComprasClass al)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44338/api/CompraApi");

                var updateal = hc.PutAsJsonAsync<ComprasClass>("CompraApi", al);
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

                var deleteal = hc.DeleteAsync("CompraApi/" + id.ToString());
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