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
        public decimal Price { get; set; }
        public string Bravo_Code { get; set; }
        public string Product_Name { get; set; }
        public string Country_Name { get; set; }
        public string Firm { get; set; }
        public decimal Total_Price { get; set; }
        public int Co_Free_Tax { get; set; }

    }
}
