using LagersystemMVC.DataAccessLayer;
using LagersystemMVC.Models;
using LagersystemMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LagersystemMVC.Controllers
{
    public class ItemController : Controller
    {

        private ItemRepository repo;

        public ItemController()
        {
            this.repo = new ItemRepository();
        }
        
        // GET: all items
        public ActionResult Index(string searchTerm="")
        {
            if(searchTerm == "")
                return View(repo.GetAllItems());
            if (searchTerm == "@Price")
                return View(repo.SortItemsByPrice());
            if (searchTerm == "@Shelf")
                return View(repo.SortItemsByShelf());
            if (searchTerm == "@Description")
                return View(repo.SortItemsByDecription());
            else
                return View(repo.SearchItemByName(searchTerm));
        }

        //Skapa ett items och lägg till i databasen
        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                repo.CreateItem(stockItem);
                return RedirectToAction("Index");
            }
            return View(stockItem);
        }

        //Redigera ett items och lägg till i databasen
        public ActionResult Edit(int? id)
        {
            return View(repo.FindItem(id));       
        }

        [HttpPost]       
        public ActionResult Edit([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                repo.EditItem(stockItem);
                return RedirectToAction("Index");
            }
            return View(stockItem);
        }

        //Ta bort ett items från databasen
        public ActionResult Delete(int id = 0)
        {                      
            return View(repo.FindItem(id));
        }

        [HttpPost, ActionName("Delete")]      
        public ActionResult DeleteConfirmed(int id)
        {
            repo.RemoveItem(id);
            return RedirectToAction("Index");
        }
        

        //Se detaljer från ett items från databasen
        public ActionResult Details(int id = 0)
        {
            return View(repo.GetItemById(id));
        }


        public ActionResult Test(int id = 2)
        {
            StoreContext Ctx = new StoreContext();
            return View(Ctx.Items.FirstOrDefault(i => i.ItemID == id));
        }



    }
}