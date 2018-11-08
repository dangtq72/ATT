namespace NVS_Common
{
    public class CommonStruct
    {
        /// <summary>
        /// Xuất kho phụ kiện: Hình thức xuất kho, gồm:
        /// Xuất bán, Xuất bảo hành (Icare), Xuất khác
        /// </summary>
        public struct ExportEquipmentForm
        {
            public const int FOR_SELL = 1;

            public const int FOR_ICARE = 2;

            public const int FOR_OTHER = 3;
        }

        /// <summary>
        /// Khách hàng: { 1: Đại lý, 2: Showroom, 3: Dự án, 4: Nội bộ, 5: Cá nhân }
        /// </summary>
        public struct ExportCustomerType
        {
            public const int DAILY = 1;

            public const int SHOWROOM = 2;

            public const int DUAN = 3;

            public const int NOIBO = 4;

            public const int CANHAN = 5;
        }

        /// <summary>
        /// Trạng thái kho
        /// 0 Ngừng hoạt động
        /// 1 Hoạt động
        /// Mặc định thêm mới cái hoạt động luôn, cho phép NSD chuyển sang ngưng hoạt động và ngược lại.
        /// </summary>
        public struct StoreStatus
        {
            public const int NOACTIVE = 0;

            public const int ACTIVE = 1;
        }

        public struct InventoryControlStatus
        {
            public const int WORKING = 1;

            public const int FINISHED = 2;
        }

        public struct ProductInInventoryStatus
        {
            public const int EMPTYINSTORE = 1;

            public const int EXCESSINSTORE = 2;

            public const int VALIDINSTORE = 3;
        }

        public struct ReImportStoreStatus
        {
            public const int WAITCHECKDEBT = 1;
            public const int WAITAPPROVAL = 2; 
            public const int WAITIMPORT = 3;
            public const int DONEIMPORT = 4;
            public const int REFUSEDCHECKDEB = 5;
            public const int REFUSEDAPPROVAL = 6;

            public static string GetConditionSearchTabNewCreated()
            {
                return $"{WAITCHECKDEBT},{WAITAPPROVAL},{WAITIMPORT},{DONEIMPORT},{REFUSEDCHECKDEB},{REFUSEDAPPROVAL}";
            }

            public static string GetConditionSearchTabImport()
            {
                return $"{WAITIMPORT}";
            }
        }
    }
}