using System;
namespace ObjInfo.ModuleBaseData
{
    public class CustomerInfo
    {
        public decimal STT { get; set; }
        public decimal ID { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_Name { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_date { get; set; }
        public string modify_by { get; set; }
        public DateTime modify_date { get; set; }
        public decimal Delete { get; set; }
    }
}
