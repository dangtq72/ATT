using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.Import
{
    public class Shipment_Container
    {
        public decimal Stt { get; set; }
        public decimal Id { get; set; }
        public string Cont_Code { get; set; }
        public string Product_Code { get; set; }
        public string Contract_Code { get; set; }
        public int Status { get; set; }
        public string Status_Display { get; set; }
    }
}
