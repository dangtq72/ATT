using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo
{
    public class UserInfo
    {
        public decimal STT { get; set; }
        public decimal User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public decimal User_Type { get; set; }
        public decimal Group_Id { get; set; }
        public decimal Deleted { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modify_Date { get; set; }
    }
}
