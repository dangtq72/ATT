using System;
using System.Collections.Generic;
using NaviCommon;
using ObjInfo.ModuleBaseData;
using DataAccessLayer.ModuleBaseDataDA;
namespace BusinessFacadeLayer.ModuleBaseDataBL
{
    public class ProductBL
    {
        public static List<Product_Info> Product_GetAll()
        {
            var p_List = new List<Product_Info>();
            try
            {
                p_List = CBO<Product_Info>.FillCollectionFromDataSet(ProductDA.Product_Getall());
                
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_List;
        }

        public static Product_Info Product_GetByID(decimal _productId)
        {
            var p_object = new Product_Info();
            try
            {
                p_object  = (Product_Info)CBO.FillObjectFromDataSet(ProductDA.Product_GetById(_productId), typeof(Product_Info));
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_object;
        }

        public static List<Product_Info> Product_Getpage(
            string _productText,
            int _start,
            int _end,
            string _orderBy,
            string _orderType,
            ref int _totalRecord)
        {
            var p_lst = new List<Product_Info>();
            try
            {
                p_lst = CBO<Product_Info>.FillCollectionFromDataSet(ProductDA.Product_GetPage(_productText,_start,_end,_orderBy,_orderType,ref _totalRecord));
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return p_lst;
        }

        public static int Product_Delete(decimal _productId)
        {
            try
            {
                return ProductDA.Product_Delete(_productId);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public static decimal Product_Insert(Product_Info _obj)
        {
            try
            {
                return ProductDA.Product_Insert(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

        public static int Product_Update(Product_Info _obj)
        {
            try
            {
                return ProductDA.Product_Update(_obj);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }

    }
}
