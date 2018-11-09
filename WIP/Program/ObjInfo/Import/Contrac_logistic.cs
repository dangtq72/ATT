using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.Import
{
    public class Contrac_logistic
    {
        public decimal ID { get; set; }
        public string Contract_code { get; set; }
        public string Product_code { get; set; }
        /// <summary>
        /// ATZ nhận chứng từ gốc
        /// </summary>
        public DateTime Atz_Recv_Cert_Date { get; set; }
        /// <summary>
        /// Ngày mở tờ khai
        /// </summary>
        public DateTime Decla_Open_Date { get; set; }
        /// <summary>
        /// Số tờ khai
        /// </summary>
        public string Decla_Number { get; set; }
        /// <summary>
        /// Ngày dự kiến thông quan
        /// </summary>
        public DateTime Clearance_Expec_Date { get; set; }
        /// <summary>
        /// Ngày thông quan
        /// </summary>
        public DateTime Clearance_Date { get; set; }
        /// <summary>
        /// Ngày hết hạn lưu kho
        /// </summary>
        public DateTime Exp_Storage_Cont_Date { get; set; }
        /// <summary>
        /// Ngày hết hạn lưu vỏ
        /// </summary>
        public DateTime Exp_Storage_Bark_Date { get; set; }
        /// <summary>
        /// Ngày hết hạn lưu bãi
        /// </summary>
        public DateTime Exp_Storage_Space_Date { get; set; }
        public string Notes { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
