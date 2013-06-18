using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    public class Book
    {
       // public int BookID { get; set; }
        public string ISBNBook { get; set; }
        public string BookName { get; set; }
        public int PublisherID { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
    }
}
