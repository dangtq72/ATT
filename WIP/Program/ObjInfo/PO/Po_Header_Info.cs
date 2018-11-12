using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.PO
{
    public class Po_Header_Info
    {
        public decimal Id { get; set; }
        public string Po_Code { get; set; }
        public string Pr_Code { get; set; }
        public string Po_No { get; set; }
        public string Supplier_Code { get; set; }
        public DateTime Po_Date { get; set; }
        public string Price_Type { get; set; }
        public string Port_Out { get; set; }
        public string Payment_Type { get; set; }
        public DateTime Lsd { get; set; }
        public decimal Cont_Type { get; set; }
        public decimal Pack_Type { get; set; }
        public string Packing_Detail { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Status { get; set; }
        public string Reject_Reason { get; set; }
        public string Notes { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modify_Date { get; set; }
        public decimal Deleted { get; set; }
    }
}
