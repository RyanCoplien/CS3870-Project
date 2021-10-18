using CS3870_APS.NET_Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS3870_APS.NET_Assignment_2.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Hours()
        {
            return View();
        }
        public ActionResult Store()
        {
            var items = from s in storeList
            orderby s.ID
            select s;
            return View(items);
            //return View();
        }
        public ActionResult News()
        {
            return View();
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Store item)
        {
            try
            {
                /*Store item = new Store();
                item.Product = collection["Product"];
                string cost = collection["Cost"];
                item.Cost = Int32.Parse(cost);
                storeList.Add(item);*/
                storeList.Add(item);
                return RedirectToAction("Store");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            List<Store> storeList = GetStoreList();
            var item = storeList.Single(m => m.ID == id);
            return View(item);
            //return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var item = storeList.Single(m => m.ID == id);
                if (TryUpdateModel(item))
                {
                    return RedirectToAction("Store");
                }
                return View(item);
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            var item = storeList.Single(m => m.ID == id);
            return View(item);
            //return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var item = storeList.Single(m => m.ID == id);
                storeList.Remove(item);
                return RedirectToAction("Store");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Store> GetStoreList()
        {
            return new List<Store>{
              new Store{
                 ID = 1,
                 Product = "Wizard Wand",
                 Cost = 30
              },

              new Store{
                 ID = 2,
                 Product = "Wizard Hat",
                 Cost = 20
              },

              new Store{
                 ID = 3,
                 Product = "Pet Owl",
                 Cost = 100
              },
           };
        }

        public static List<Store> storeList = new List<Store>{
            new Store{
                    ID = 1,
                    Product = "Wizard Wand",
                    Cost = 30
            },

            new Store{
                ID = 2,
                Product = "Wizard Hat",
                Cost = 20
            },

            new Store{
                ID = 3,
                Product = "Pet Owl",
                Cost = 100
            },

        };
    }
}