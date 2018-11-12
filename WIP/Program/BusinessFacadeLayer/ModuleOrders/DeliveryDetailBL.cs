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
    public class DeliveryDetailBL
    {
        public List<Delivery_Detail_Info> GetDeliveryDetailByDelivery (decimal delivery_id)
        {
            Delivery_DetailDA Obj_da = new Delivery_DetailDA();
            List<Delivery_Detail_Info> List_Obj = new List<Delivery_Detail_Info>();
            try
            {
                var ds = Obj_da.GetDetailByDelivery(delivery_id);
                List_Obj = CBO<Delivery_Detail_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;
        }
        public decimal InsertDeliveryDetail(Delivery_Detail_Info Obj_Info)
        {
            Delivery_DetailDA Obj_da = new Delivery_DetailDA();
            try
            {
                return Obj_da.InsertDeliveryDetail(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal UpdateDeliveryDetail(Delivery_Detail_Info Obj_Info)
        {
            Delivery_DetailDA Obj_da = new Delivery_DetailDA();
            try
            {
                return Obj_da.UpdateDeliveryDetail(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
