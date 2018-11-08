using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.Import
{ 
    public class Contract
    {
        public decimal Stt { get; set; }
        public decimal Id { get; set; }
        public string Contract_Code { get; set; }
        public string Contract_Name { get; set; }
        public DateTime Contract_Date { get; set; }
        public string Request_By { get; set; }
        public int Import_Object { get; set; }
        public string Import_Object_Display { get; set; }
        public int Status { get; set; }
        public string Status_Display{ get; set; }
        public int Payment_Type { get; set; }
        public string Payment_Type_Display { get; set; }
        public int Payment_Status { get; set; }
        public string Payment_Status_Display { get; set; }
        public string Notes { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Modified_By { get; set; }
        public DateTime Modified_Date{ get; set; }
        public int Deleted { get; set; }
    }
}
