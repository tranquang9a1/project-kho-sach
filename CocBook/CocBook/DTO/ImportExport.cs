using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    public class ImportExport
    {
        public int CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string  ImEx { get; set; }
        public int CustomerID { get; set; }
    }
}
