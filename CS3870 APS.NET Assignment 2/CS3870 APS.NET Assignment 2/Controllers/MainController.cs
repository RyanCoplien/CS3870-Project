using CS3870_APS.NET_Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CS3870_APS.NET_Assignment_2.Controllers
{
    [RequireHttps]
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

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Registration userr)
        {
            //if (ModelState.IsValid)
            //{
            if (IsValid(userr.Email, userr.Password))
            {
                FormsAuthentication.SetAuthCookie(userr.Email, false);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userr);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Registration user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new RegistrationEntities())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
                        var encrypPass = crypto.Compute(user.Password);
                        var newUser = db.Registrations.Create();
                        newUser.Email = user.Email;
                        newUser.Password = encrypPass;
                        newUser.PasswordSalt = crypto.Salt;
                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;
                        newUser.UserType = "User";
                        newUser.CreatedDate = DateTime.Now;
                        newUser.IsActive = true;
                        newUser.IPAddress = "642 White Hague Avenue";
                        db.Registrations.Add(newUser);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new RegistrationEntities())
            {
                var user = db.Registrations.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }
    }
}