using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.Import
{
    public class ContractDetail
    {
        public decimal Contract_Detail_Id { get; set; }
        public string Contract_Code { get; set; }
        public string Product_Code { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Supplier_Id { get; set; }
    }
}
