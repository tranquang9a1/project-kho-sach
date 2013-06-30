using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    public class Store
    {
        public string ISBNBook { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
