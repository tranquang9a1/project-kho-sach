using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DTO
{
    class Book
    {
        public int ISBNBook { get; set; }
        public string BookName { get; set; }
        public int PublisherID { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }
    }
}
