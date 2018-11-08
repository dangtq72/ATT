using System;
using System.Collections.Generic;
using System.Linq;
using ObjInfo.ToDo;
using DataAccessLayer.Todo;
using NaviCommon;

namespace BusinessFacadeLayer.ToDo
{
    public class ToDoBL
    {
        public List<ToDoInfo> GetAll()
        {
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();
            var todoDa = new ToDoDA();
            try
            {
                var ds = todoDa.GetAll();
                lstToDo = CBO<ToDoInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return lstToDo;
        }

        public List<ToDoInfo> Search(int currentPage, ref decimal totalRecord, string keySearch = "")
        {
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();
            var todoDa = new ToDoDA();
            try
            {
                string p_name = "";
                string p_status = "";
                string p_type = "";
                var arrKeySearch = keySearch.Split('|');
                if (arrKeySearch.Length >= 3)
                { 
                    p_name = arrKeySearch[0];
                    p_status = arrKeySearch[1];
                    p_type = arrKeySearch[2];
                }
                string p_to = Common.RecordOnpage.ToString();
                string p_from = CommonFuc.Get_From_To_Page(currentPage, ref p_to);

                var ds = todoDa.Search(p_name, p_status, p_type, p_from, p_to, ref totalRecord);
                lstToDo = CBO<ToDoInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return lstToDo;
        }

        public List<ToDoInfo> GetByCode(decimal code, int type)
        {
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();
            var todoDa = new ToDoDA();
            try
            {
                var ds = todoDa.GetByCode(code, type);
                lstToDo = CBO<ToDoInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return lstToDo;
        }

        public decimal Insert(ToDoInfo todo)
        {
            var todoDa = new ToDoDA();
            decimal _result = -1;
            try
            {
                _result = todoDa.Insert(todo);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return _result;
        }

        public decimal Update(ToDoInfo todo)
        {
            var todoDa = new ToDoDA();
            decimal _result = -1;
            try
            {
                _result = todoDa.Update(todo);
            }
            catch (Exception ex)
            {
                Common.log.Error(ex.ToString());
            }
            return _result;
        }
    }
}
