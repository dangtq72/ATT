using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.UserAndRole
{
    public class Au_GroupInfo
    {

        public decimal STT { get; set; }
        public decimal Group_Id { get; set; }
        public string Group_Name { get; set; }
        public string Description { get; set; }
        public decimal User_Type { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Modify_By { get; set; }
        public DateTime Modify_Date { get; set; }
        public decimal Deleted { get; set; }
    }
}
