using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProveedorController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<PROVEEDOR> alobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeapi = hc.GetAsync("ProveedorApi");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<PROVEEDOR>>();
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
        public ActionResult Create(PROVEEDOR al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var insertCli = hc.PostAsJsonAsync<PROVEEDOR>("ProveedorApi", al);
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
            ProveedoresClass objal = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("ProveedorApi?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<ProveedoresClass>();
                displayCliDetatails.Wait();
                objal = displayCliDetatails.Result;
            }
            return View(objal);
        }
        public ActionResult Edit(int id)
        {
            ProveedoresClass objcli = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("ProveedorApi?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<ProveedoresClass>();
                displayCliDetatails.Wait();
                objcli = displayCliDetatails.Result;
            }
            return View(objcli);
        }

        [HttpPost]
        public ActionResult Edit(ProveedoresClass al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/ProveedorApi");

            var updateal = hc.PutAsJsonAsync<ProveedoresClass>("ProveedorApi", al);
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
            hc.BaseAddress = new Uri("https://localhost:44338/api/ProveedorApi");

            var deleteal = hc.DeleteAsync("ProveedorApi/" + id.ToString());
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