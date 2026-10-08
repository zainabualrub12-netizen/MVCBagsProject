using InputDataUsingHtmlHelper.Models;
using InputDataUsingHtmlHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InputDataUsingHtmlHelper.Controllers
{
    public class HomeController : Controller
    {
        BagsEntities2 db = new BagsEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LogIn model)
        {
            if (ModelState.IsValid)
            {
                if (model.BirthDate > DateTime.Today)
                {
                    ModelState.AddModelError("BirthDate", "Error: Invalid birth date (cannot be in the future).");
                    return View(model);
                }

                TempData["UserName"] = model.UserName;
                return RedirectToAction("Show");
            }

            return View(model);
        }
        public ActionResult Show()
        {
            return View(db.Bags.ToList());
        }
        public ActionResult add(int? id)
        {
            if (id == null)
            {
                return Content("Error, id is null");
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }

            return View(bag);
        }
        public ActionResult AddToCart(int id)
        {
            Bag selectedBag = db.Bags.Find(id);
            if (selectedBag == null)
            {
                return HttpNotFound();
            }

            List<Bag> cart = TempData["Cart"] as List<Bag> ?? new List<Bag>();

            cart.Add(selectedBag);

            TempData["Cart"] = cart;

            return RedirectToAction("Show");
        }
        public ActionResult Cart()
        {
            List<Bag> cart = TempData["Cart"] as List<Bag> ?? new List<Bag>();

            TempData.Keep("Cart");

            return View(cart);
        }
        public ActionResult Seed()
        {
            if (db.Bags.Any())
            {
                return Content("Database already seeded!");
            }

            db.Bags.AddRange(new List<Bag>
    {
        new Bag {Id=1, Name = "Celine Bag", Description = "Elegant design", Color = "Beige", Size = "Medium", Price = 35, ImagePath = "~/photo/c7c38ea6cd6633929389806d1d2b7ada.jpg" },
        new Bag {Id=2, Name = "Chanel Bag", Description = "Iconic style", Color = "Black", Size = "Medium", Price = 30, ImagePath = "~/photo/CHANEL Official Website_ Fashion, Fragrance, Beauty, Watches, Fine Jewelry _ CHANEL.jpg" },
        new Bag {Id=3, Name = "Prada Bag", Description = "Luxury Italian", Color = "Red", Size = "Large", Price = 20, ImagePath = "~/photo/download (1).jpg" },
        new Bag {Id=4, Name = "Coach Bag", Description = "Stylish everyday bag", Color = "Pink", Size = "Large", Price = 30, ImagePath = "~/photo/download (2).jpg" },
        new Bag {Id=5, Name = "Louis Vuitton Bag", Description = "Timeless design", Color = "Brown", Size = "Large", Price = 52, ImagePath = "~/photo/download.jpg" },
        new Bag { Id=6,Name = "Hermes Bag", Description = "World’s most exclusive", Color = "Orange", Size = "Medium", Price = 22, ImagePath = "~/photo/download4.jpg" },
        new Bag {Id=7, Name = "Balenciaga Bag", Description = "Bold fashion", Color = "White", Size = "Small", Price = 35, ImagePath = "~/photo/download5.jpg" },
        new Bag {Id=8, Name = "Miu Miu Bag", Description = "Cute and compact", Color = "Purple", Size = "Small", Price = 40, ImagePath = "~/photo/download6.jpg" },
        new Bag {Id=9, Name = "Jacquemus Bag", Description = "Trendy mini bag", Color = "White", Size = "Mini", Price = 30, ImagePath = "~/photo/Le Bambino leather shoulder bag in white - Jacquemus _ Mytheresa.jpg" },
        new Bag {Id=10, Name = "Dior Bag", Description = "Saddle bag style", Color = "Black", Size = "Medium", Price = 20, ImagePath = "~/photo/Saddle Bag with Strap Black Goatskin _ DIOR.jpg" },
        new Bag {Id=11, Name = "Versace Bag", Description = "Bold gold detailing", Color = "Gold", Size = "Medium", Price = 20, ImagePath = "~/photo/VERSACE US.jpg" },
        new Bag {Id=12, Name = "Prada Bag", Description = "Classic design", Color = "Black", Size = "Large", Price = 33, ImagePath = "~/photo/Women's Leather and Nylon Bags _ PRADA.jpg" }
    });

            db.SaveChanges();
            return Content("Database seeded with bags successfully! 🌟");
        }


        public ActionResult Detalis(int? id) {
           
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View();
        }

    }
}
       
        