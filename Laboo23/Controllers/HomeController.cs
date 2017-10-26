using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboo23.Models;

namespace Laboo23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            GroceriesEntities ORM = new GroceriesEntities();
            List<Item> listofItems = ORM.Items.ToList(); //select * from customers
            ViewBag.Message = "Your application description page.";
            ViewBag.Clist = listofItems;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NewItem(Item Newitems)
        {
            GroceriesEntities GroceriesDB = new GroceriesEntities(); //este metodo es para mostrar en el view que se llama new employye para que display los datos del new employee
            GroceriesDB.Items.Add(Newitems);// saves the new employee to the list 

            GroceriesDB.SaveChanges(); //saves the new employee to the db

            return RedirectToAction("About");
        }

        public ActionResult AddingNewItem()
        {
            return View();
        }

        public ActionResult DeleteItem(string itemID)
        {
            GroceriesEntities GroceriesDB = new GroceriesEntities();
            Item e = GroceriesDB.Items.Find(itemID);

            GroceriesDB.Items.Remove(e);
            GroceriesDB.SaveChanges();

            return RedirectToAction("About"); 


        }
    }
} 