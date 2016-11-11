using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LagersystemMVC.DataAccessLayer;
using LagersystemMVC.Models;

namespace LagersystemMVC.Repositories
{
    public class ItemRepository
    {
        private StoreContext Ctx;
       
        public ItemRepository()
        {
            Ctx = new StoreContext();
        }

        //Hämtar alla item som sorteras i stigande ordning
        public List<StockItem> GetAllItems()
        {
            var model = from i in Ctx.Items
                        orderby i.Name
                        select i;

            return model.ToList();           
        }

        public StockItem GetItemById(int id)
        {
            return Ctx.Items.FirstOrDefault(i => i.ItemID == id);
        }

        public List<StockItem> SearchItemByName(string searchterm)
        {
            var model = from i in Ctx.Items
                        where searchterm == null || i.Name.StartsWith(searchterm)
                        select i;

            return model.ToList();
        }

        public StockItem FindItem(int? id)
        {
            StockItem stockItem = Ctx.Items.Find(id);          
            return stockItem;                      
        }

        public void CreateItem(StockItem stockItem)
        {          
            Ctx.Items.Add(stockItem);
            Ctx.SaveChanges();
        }
        
        public void EditItem(StockItem stockItem)
        {
            Ctx.Entry(stockItem).State = EntityState.Modified;
            Ctx.SaveChanges();
        }       
        
        
        public void RemoveItem(int? id)
        {
            StockItem stockItem = Ctx.Items.Find(id);
            Ctx.Items.Remove(stockItem);
            Ctx.SaveChanges();           
        }

        //Sorterar efter price
        public List<StockItem> SortItemsByPrice()
        {
            var model = from i in Ctx.Items
                        orderby i.Price
                        select i;

            return model.ToList();
        }

        //Sorterar efter shelf
        public List<StockItem> SortItemsByShelf()
        {
            var model = from i in Ctx.Items
                        orderby i.Shelf
                        select i;

            return model.ToList();
        }

        //Sorterar efter shelf
        public List<StockItem> SortItemsByDecription()
        {
            var model = from i in Ctx.Items
                        orderby i.Description
                        select i;

            return model.ToList();
        }
    }
}