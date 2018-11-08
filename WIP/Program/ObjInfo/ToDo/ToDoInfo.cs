using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.ToDo
{
    public class ToDoInfo
    {
        public int Stt { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
        public decimal Code { get; set; }
        public string Code_Name { get; set; }
        public string Content { get; set; }
        public string Request_By { get; set; }
        public DateTime Request_Date { get; set; }
        public string Processor_By { get; set; }
        public DateTime Processor_Date { get; set; }
        public string Extime { get; set; }
        public int Status { get; set; }
        public string Status_Display { get; set; }
    }
}
