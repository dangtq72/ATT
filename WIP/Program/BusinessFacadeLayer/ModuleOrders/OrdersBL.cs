using DataAccessLayer.ModuleOrder;
using NaviCommon;
using ObjInfo.ModuleOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacadeLayer.ModuleOrders
{
    public class OrdersBL
    {
        public List<OrderInfo> GetAll_Order()
        {
            OrdersDA Obj_da = new OrdersDA();
            List<OrderInfo> List_Obj = new List<OrderInfo>();
            try
            {
                var ds = Obj_da.GetAll_Order();
                List_Obj = CBO<OrderInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;
        }
        public List<OrderInfo> Order_Search(string p_keySearch, string p_from, string p_to, ref decimal p_total_record)
        {
            OrdersDA Obj_da = new OrdersDA();
            List<OrderInfo> List_Obj = new List<OrderInfo>();
            try
            {
                var ds = Obj_da.Order_Search(p_keySearch, p_from, p_to,ref p_total_record);
                List_Obj = CBO<OrderInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;
        }
        public OrderInfo GetOrderById(decimal Order_Id)
        {
            OrdersDA Obj_da = new OrdersDA();
            OrderInfo Obj_Info = new OrderInfo();
            try
            {
                var ds = Obj_da.GetOrderByID(Order_Id);
                Obj_Info = CBO<OrderInfo>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Obj_Info;
        }
        public decimal Inser_Order(OrderInfo Obj_Info)
        {
            OrdersDA Obj_da = new OrdersDA();
            try
            {
                return Obj_da.InsertOrder(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Update_Order(OrderInfo Obj_Info)
        {
            OrdersDA Obj_da = new OrdersDA();
            try
            {
                return Obj_da.UpdateOrder(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Delete_Order(decimal order_id)
        {
            OrdersDA Obj_da = new OrdersDA();
            try
            {
                return Obj_da.DeleteOrder(order_id);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
