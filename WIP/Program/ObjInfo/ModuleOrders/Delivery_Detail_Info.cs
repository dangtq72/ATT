using System;
namespace ObjInfo.ModuleOrders
{
    public class Delivery_Detail_Info
    {
        public decimal STT { get; set; }
        public decimal ID { get; set; }
        public decimal Delivery_DetailID { get; set; }
        public decimal Status { get; set; }
        public string Status_Display { get; set; }
        public string Url { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Deleted { get; set; }
    }
}
