using DataAccessLayer.ModuleOrder;
using NaviCommon;
using ObjInfo.ModuleOrders;
using System;
using System.Collections.Generic;

namespace BusinessFacadeLayer.ModuleOrders
{
    public class DeliveryBL
    {
        public List<DeliveryInfo> GetAll_Delivery()
        {
            DeliveryDA Obj_da = new DeliveryDA();
            List<DeliveryInfo> List_Obj = new List<DeliveryInfo>();
            try
            {
                var ds = Obj_da.GetAll_Delivery();
                List_Obj = CBO<DeliveryInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;




        }
        public DeliveryInfo GetDeliveryByID(decimal delivery_id)
        {
            DeliveryDA Obj_da = new DeliveryDA();
            DeliveryInfo Obj_Info = new DeliveryInfo();
            try
            {
                var ds = Obj_da.GetDeliveryByID(delivery_id);
                Obj_Info = CBO<DeliveryInfo>.FillObject_From_DataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return Obj_Info;
        }
        public List<DeliveryInfo> GetDeliveryByOrder(string Order_code)
        {
            DeliveryDA Obj_da = new DeliveryDA();
            List<DeliveryInfo> List_Obj = new List<DeliveryInfo>();
            try
            {
                var ds = Obj_da.GetDeliveryByOrder(Order_code);
                List_Obj = CBO<DeliveryInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;
        }
        public decimal Inser_Delivery(DeliveryInfo Obj_Info)
        {
            DeliveryDA Obj_da = new DeliveryDA();
            try
            {
                return Obj_da.InsertDelivery(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Update_Delivery(DeliveryInfo Obj_Info)
        {
            DeliveryDA Obj_da = new DeliveryDA();
            try
            {
                return Obj_da.UpdateDelivery(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Delete_Delivery(decimal delivery_id)
        {
            DeliveryDA Obj_da = new DeliveryDA();
            try
            {
                return Obj_da.DeleteDelivery(delivery_id);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
