using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.cs.DTO
{
    class ImportExport
    {
        public int CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string IE { get; set; }
        public string CustomerID { get; set; }
    }
}
