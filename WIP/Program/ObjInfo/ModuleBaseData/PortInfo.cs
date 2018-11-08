using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.ModuleBaseData
{
    public class PortInfo
    {
        public decimal STT { get; set; }
        public decimal Id { get; set; }
        public string Port_Code { get; set; }
        public string Port_Name { get; set; }
        public decimal Type { get; set; }
        public string Notes { get; set; }
        public int Deleted { get; set; }
    }
}
