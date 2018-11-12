using System;

namespace ObjInfo.PurchaseRequest
{
    public class PR_Info
    {
        public decimal STT { get; set; }
        public decimal ID { get; set; }
        /// <summary>
        /// Mã Pr_Code
        /// </summary>
        public string Pr_Code { get; set; }
        /// <summary>
        /// SỐ PR
        /// </summary>
        public string Pr_No { get; set; }
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        public string Supplier_Code { get; set; }
        public string Supplier_Name { get; set; }
        /// <summary>
        /// Ngày tạo PR
        /// </summary>
        public DateTime Pr_Date { get; set; }
        /// <summary>
        /// Loại Giá
        /// CIF,CFR,EXW,FOB
        /// </summary>
        public Decimal Price_Type { get; set; }
        /// <summary>
        /// Cảng xuất
        /// </summary>
        public string Port_Out { get; set; }
        /// <summary>
        /// ĐK thanh toán
        /// CIA,DPAS100%, LCAS, LC30,...
        /// </summary>
        public string Payment_type { get; set; }
        /// <summary>
        /// Last ship date
        /// </summary>
        public DateTime LSD { get; set; }
        /// <summary>
        /// Loại container
        /// </summary>
        public decimal Cont_Type { get; set; }
        public string Cont_Type_Dispay { get; set; }
        /// <summary>
        /// Quy cách đóng hàng
        /// </summary>
        public decimal Pack_Type { get; set; }
        public string Pack_Type_Dispay { get; set; }
        /// <summary>
        /// Mô tả quy cách đóng hàng
        /// </summary>
        public string Packing_Detail { get; set; }
        /// <summary>
        /// Tổng tiền theo PR_Detail
        /// </summary>
        public decimal Total_Amount { get; set; }
        /// <summary>
        /// Trạng thái hợp đồng
        /// 1:chờ duyệt, 2:Đã duyệt, 3:Từ chối, 4:Hủy
        /// </summary>
        public decimal Status { get; set; }
        /// <summary>
        /// Trạng thái duyệt
        /// A:GĐ mua hàng + B:GĐ bán hàng + C:GĐ tài chính
        /// 0:chưa duyệt, 1:đã duyệt,2:từ chối
        /// </summary>
        public string Status_Apporve { get; set; }
        /// <summary>
        /// Nội dung từ chối
        /// </summary>
        public string Reject_Reason { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public decimal Deleted { get; set; }
    }
}
