using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TaxNo { get; set; }
    }
}
