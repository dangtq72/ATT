using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NaviCommon;
using ObjInfo.ToDo;
using BusinessFacadeLayer.ToDo;
using ObjInfo.Catalogue;
using BusinessFacadeLayer.MemmoryBL;

namespace AnThanh.Areas.ToDo.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo/ToDo
        [HttpGet]
        public ActionResult ToDo_Display()
        {
            var todoBl = new ToDoBL();
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();

            try
            { 
                decimal totalRecord = 0;
                lstToDo = todoBl.Search(1, ref totalRecord);
                string htmlPaging = CommonFuc.Get_HtmlPaging<ToDoInfo>((int)totalRecord, 1, "công việc");
                ViewBag.Paging = htmlPaging;
                ViewBag.ListToDo = lstToDo;
                ViewBag.SumRecord = totalRecord;

            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ToDo/Views/ToDo/ToDo_Display.cshtml");
        }

        [HttpPost]
        public ActionResult ToDo_Search(string keySearch, int currentPage)
        {
            var todoBl = new ToDoBL();
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();

            try
            {
                decimal totalRecord = 0;
                lstToDo = todoBl.Search(currentPage, ref totalRecord, keySearch);
                string htmlPaging = CommonFuc.Get_HtmlPaging<ToDoInfo>((int)totalRecord, 1, "công việc");
                ViewBag.Paging = htmlPaging;
                ViewBag.ListToDo = lstToDo;
                ViewBag.SumRecord = totalRecord;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return PartialView("~/Areas/ToDo/Views/ToDo/_Partial_ToDo_List.cshtml");
        }

        [HttpGet]
        public ActionResult ToDo_Action(decimal code, int type)
        {
            var todoBl = new ToDoBL();
            List<ToDoInfo> lstToDo = new List<ToDoInfo>();
            int currStatus = 0;
            List<AllCodeInfo> lstStatus = new List<AllCodeInfo>();
            try
            {
                lstToDo = todoBl.GetByCode(code, type);
                //var actionToDo = ....(code);
                //currStatus = actionToDo.Status;
                //ViewBag.ListStatus = Memory_BL.GetAllCodeByCdType("");
                ViewBag.CurrentStatus = currStatus;
                ViewBag.ListToDo = lstToDo;
                ViewBag.ToDoType = type;
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View("~/Areas/ToDo/Views/ToDo/ToDo_Action.cshtml");
        }
    }
}