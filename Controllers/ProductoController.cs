using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<PRODUCTO> alobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeapi = hc.GetAsync("ProductoApi");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<PRODUCTO>>();
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
        public ActionResult Create(PRODUCTO al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var insertCli = hc.PostAsJsonAsync<PRODUCTO>("ProductoApi", al);
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
            ProductosClass objal = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("ProductoApi?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<ProductosClass>();
                displayCliDetatails.Wait();
                objal = displayCliDetatails.Result;
            }
            return View(objal);
        }
        public ActionResult Edit(int id)
        {
            ProductosClass objcli = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("ProductoApi?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<ProductosClass>();
                displayCliDetatails.Wait();
                objcli = displayCliDetatails.Result;
            }
            return View(objcli);
        }

        [HttpPost]
        public ActionResult Edit(ProductosClass al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/ProductoApi");

            var updateal = hc.PutAsJsonAsync<ProductosClass>("ProductoApi", al);
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
            hc.BaseAddress = new Uri("https://localhost:44338/api/ProductoApi");

            var deleteal = hc.DeleteAsync("ProductoApi/" + id.ToString());
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