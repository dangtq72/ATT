using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.ModuleOrders
{
    public class DeliveryInfo
    {
        public decimal STT { get; set; }
        public decimal ID { get; set; }
        /// <summary>
        /// 1: Bán hàng tại cảng
        /// 2: Kéo về kho
        /// </summary>
        public decimal Delivery_Type { get; set; }
        public string Delivery_Type_Display { get; set; }
        public string Order_Code { get; set; }
        /// <summary>
        /// Danh sách container được chọn, cách nhau bằng dấu ,
        /// </summary>
        public string LST_CONT { get; set; }
        /// <summary>
        /// 0:chờ kéo
        /// 1:Đã kéo
        /// </summary>
        public decimal Status { get; set; }
        public string Status_Display { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Deleted { get; set; }
    }
}
