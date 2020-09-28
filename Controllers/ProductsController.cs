using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBPOS.DataContext;
using JBPOS.Models;

namespace JBPOS.Controllers
{
    public class ProductsController
    {
        private JBPOS_DB_Context db = new JBPOS_DB_Context();

        // GetProducts - Find all instances of the model from the data source.
        public List<Product> GetProducts()
        {            
            return db.Products.ToList();
        }

        // GetProduct - Find one instance of the model from the data source given an id.
        public Product GetProduct(int id)
        {            
            return db.Products.Find(id);
        }
    }
}