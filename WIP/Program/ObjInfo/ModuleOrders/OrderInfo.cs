using System;

namespace ObjInfo.ModuleOrders
{
    public class OrderInfo
    {
        public decimal STT { get; set; }
        public decimal ID { get; set; }
        /// <summary>
        /// định dạng ORDER + ddMMyyyy + Seq
        /// </summary>
        public string Order_Code { get; set; }
        /// <summary>
        /// 1: bán hàng tại cảng
        /// 2: Bán lẻ khác
        /// </summary>
        public decimal Order_Type { get; set; }
        public string Order_Type_Display { get; set; }
        public string Shipment_Code { get; set; }
        public string Customer_Code { get; set; }
        public string Address { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Delivery_From_Date { get; set; }
        public DateTime Delivery_To_Date { get; set; }
        public string Sale_Man { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total_Price { get; set; }
        /// <summary>
        /// Tình trạng đơn hàng
        /// 0: Mới tạo chờ duyệt
        /// 1:Đã duyệt giá
        /// 2:Đã thanh toán
        /// 3:Chờ kéo hàng
        /// 4:đã xong
        /// </summary>
        public decimal Status { get; set; }
        public string Status_Display { get; set; }
        /// <summary>
        /// Có giao hàng cho khách tại cảng hay không
        /// 1:có
        /// 0:không
        /// </summary>
        public decimal Is_Delivery_In_Port { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// Chỉ cho xóa khi trạng thái bằng 0
        /// </summary>
        public decimal Deleted { get; set; }
    }
}
