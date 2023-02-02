using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_ORM_
{
    public class Product
    {
        public Product()
        {

        }

        public string Name { get; set; }
       
        public double Price { get; set; }

        public int CategoryID { get; set; }
        public int StockLevel { get; set; }
        public int ProductID { get; set; }


    }
}
