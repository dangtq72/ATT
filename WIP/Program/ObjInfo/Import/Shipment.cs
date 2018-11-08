using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo.Import
{
    public class Shipment
    {
        public decimal Stt { get; set; }
        public decimal Id { get; set; }
        public string Shipment_Code { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string Contract_Code { get; set; }
        public string Contract_Name { get; set; }
        public DateTime Contract_Date { get; set; }
        public int Status { get; set; }
        public string Status_Display { get; set; }
        public string Billing_Number { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total_Price { get; set; }
        public int Cont_Type { get; set; }
        public int Cont_Numbers { get; set; }
        public decimal Cont_Volume { get; set; }
        public int Currency { get; set; }
        public string Currency_Display { get; set; }
        public decimal Currency_Rate { get; set; }
        public decimal Cost_Price { get; set; }
        public decimal Cost_Price_Usd { get; set; }
        public int Sale_Price_Type { get; set; }
        public decimal Sale_Price { get; set; }
        public decimal Sale_Price_Usd { get; set; }
        public decimal Other_Price { get; set; }
        public int Is_CO_Free_Tax { get; set; }
        public DateTime LSD { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public string Port_Code { get; set; }
        public string Port_Out { get; set; }
        public string Port_In { get; set; }
        public int Distance { get; set; }
        public string Distance_Display { get; set; }
        public int Pack_Type { get; set; }
        public string Pack_Type_Display { get; set; }
        public int Request_Object { get; set; }
        public string Request_Object_Display { get; set; }
        public int Import_Object { get; set; }
        public string Import_Object_Display { get; set; }
        public int Intent_Type { get; set; }
        public int Intent_Type_Display { get; set; }
    }
}
