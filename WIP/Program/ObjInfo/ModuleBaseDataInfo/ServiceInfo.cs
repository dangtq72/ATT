using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.ModuleBaseDataInfo
{
    public class ServiceInfo
    {
        public decimal Service_Id { get; set; }
        public string Service_Name { get; set; }
        public string Description { get; set; }
        public decimal Type { get; set; } 
        public string Avartar { get; set; }
        public decimal AddOnOrder { get; set; }
        public decimal Price { get; set; }
        public decimal Course_Id { get; set; }
        public decimal Deleted { get; set; }
        public DateTime CreatedDate { get; set;}
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
