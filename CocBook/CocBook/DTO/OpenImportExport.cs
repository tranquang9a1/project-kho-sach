using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocBook.DTO
{
    public class OpenImportExport
    {
        public int CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string ImEx { get; set; }
        public string CustomerName { get; set; }
    }
}
