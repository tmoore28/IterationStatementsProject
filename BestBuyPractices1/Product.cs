﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices1
{
    public class Product
    {
        public Product()
        {

        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
