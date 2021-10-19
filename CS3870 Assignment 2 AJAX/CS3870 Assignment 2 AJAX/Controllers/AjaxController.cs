using CS3870_Assignment_2_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS3870_Assignment_2_AJAX.Controllers
{
    public class AjaxController : Controller
    {
        public static List<Product> prodList = new List<Product>();
        // GET: Ajax
        public ActionResult Index()
        {
            //List<Product> prodList = new List<Product>();
            Product p1 = new Product { ProdCode = "P001", ProdName = "Wizard Wand", ProdQty = 75 };
            Product p2 = new Product { ProdCode = "P002", ProdName = "Wizard Hat", ProdQty = 125 };
            Product p3 = new Product { ProdCode = "P003", ProdName = "Pet Owl", ProdQty = 100 };
            prodList.Add(p1);
            prodList.Add(p2);
            prodList.Add(p3);
            return View();
        }

        public PartialViewResult ShowDetails()
        {
            System.Threading.Thread.Sleep(1000);
            string code = Request.Form["txtCode"];
            Product prod = new Product();
            foreach (Product p in prodList)
            {
                if (p.ProdCode == code)
                {
                    prod = p;
                    break;
                }
            }
            return PartialView("_ShowDetails", prod);
        }
    }
}