using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.PO
{
    public class Po_Detail_Info
    {
        public decimal Id { get; set; }
        public string Po_Code { get; set; }
        public string Product_Code { get; set; }
        public DateTime Due_On { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Per { get; set; }
        public decimal Amount { get; set; }
        public string Packaging { get; set; }
    }
}
