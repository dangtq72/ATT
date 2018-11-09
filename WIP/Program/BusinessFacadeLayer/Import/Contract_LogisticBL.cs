using DataAccessLayer.Import;
using NaviCommon;
using ObjInfo.Import;
using System;
using System.Collections.Generic;

namespace BusinessFacadeLayer.Import
{
    public class Contract_LogisticBL
    {
        public List<Contrac_logistic> GetByContract(string Contract_name)
        {
            Contrac_LogisticDA Obj_da = new Contrac_LogisticDA();
            List<Contrac_logistic> List_Obj = new List<Contrac_logistic>();
            try
            {
                var ds = Obj_da.GetByContrac(Contract_name);
                List_Obj = CBO<Contrac_logistic>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return List_Obj;
        }
        public decimal Inser_Contract_Logistic(Contrac_logistic Obj_Info)
        {
            Contrac_LogisticDA Obj_da = new Contrac_LogisticDA();
            try
            {
                return Obj_da.InsertContract_Logistic(Obj_Info);
            }
            catch(Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
        public decimal Update_Contract_Logistic(Contrac_logistic Obj_Info)
        {
            Contrac_LogisticDA Obj_da = new Contrac_LogisticDA();
            try
            {
                return Obj_da.UpdateContract_Logistic(Obj_Info);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
