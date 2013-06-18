using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    public class IEDetail
    {
        public int CheckNo { get; set; }
        public string ISBNBook { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Value { get; set; }
    }
}
