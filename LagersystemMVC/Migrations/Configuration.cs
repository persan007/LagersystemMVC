namespace LagersystemMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LagersystemMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LagersystemMVC.DataAccessLayer.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LagersystemMVC.DataAccessLayer.StoreContext context)
        {
           
           context.Items.AddOrUpdate(
            
               new StockItem { ItemID = 1, Name = "Potatis", Price = 9.90m, Shelf = "nedre", Description = "Rotfrukt" },
               new StockItem { ItemID = 2, Name = "Hallon", Price = 19.90m, Shelf = "mellan", Description = "Bär" },
               new StockItem { ItemID = 3, Name = "Persika", Price = 15.90m, Shelf = "nedre", Description = "Frukt" },
               new StockItem { ItemID = 4, Name = "Kalkon", Price = 79.90m, Shelf = "övre", Description = "Fågel" },
               new StockItem { ItemID = 5, Name = "Gris", Price = 49.90m, Shelf = "övre", Description = "Fläsk" }                     
             );
           
        }
    }
}
