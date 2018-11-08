using BusinessFacadeLayer;
using NaviCommon;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AnThanh.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserDisplay()
        {
            List<UserInfo> list = new List<UserInfo>();
            try
            {
                UserBL _bl = new UserBL();
                list = _bl.User_GetAll();
                string p_key = "ALL";
                decimal _total_record = 0;
                list = _bl.User_Search(p_key,ref _total_record);
                ViewBag.List = list;
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<UserInfo>((int)_total_record, 1, "Thành viên");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = list;
                ViewBag.SumRecord = _total_record;
            }
            catch(Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return View();
        }
        [HttpPost]
        public ActionResult User_Search(string p_keysearch, int p_CurrentPage)
        {
            try
            {
                decimal _total_record = 0;
                string p_to = "";
                string p_from = CommonFuc.Get_From_To_Page(p_CurrentPage, ref p_to);
                if (p_keysearch == "" || p_keysearch == null)
                {
                    p_keysearch = "ALL";
                }
                UserBL _bl = new UserBL();
                List<UserInfo> _lst = _bl.User_Search(p_keysearch, ref _total_record, p_from, p_to);
                string htmlPaging = NaviCommon.CommonFuc.Get_HtmlPaging<UserInfo>((int)_total_record, p_CurrentPage, "thành viên");
                ViewBag.Paging = htmlPaging;
                ViewBag.List = _lst;
                ViewBag.SumRecord = _total_record;
                return PartialView("/Views/User/_Partial_List_User.cshtml");
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("/Views/User/_Partial_List_User.cshtml");
            }
        }
        public ActionResult UserViewRegister()
        {
            return PartialView("~/Views/User/_Partial_Register_User.cshtml");
        }
        [HttpPost]
        public Decimal User_Insert(UserInfo Obj_Info)
        {
            decimal p_return = -1;
            UserBL Obj_BL = new UserBL();
            try
            {
                Obj_Info.Password = NaviCommon.CommonFuc.Encrypt(Obj_Info.User_Name.ToUpper() + "!@#$%" + Obj_Info.Password);
                Obj_Info.Created_Date = DateTime.Now;
                p_return = Obj_BL.User_Insert(Obj_Info);
                // Nếu inser thành công thì gửi email hoặc sms
                if (p_return > 0)
                {
                  
                    Commons.SendTTUser.Enqueue_Insert_User(Obj_BL.User_GetById(p_return));
                }
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
        }
        [HttpGet]
        public ActionResult GotoViewUpdate(decimal Id)
        {
            try
            {
                UserBL Obj_BL = new UserBL();
                UserInfo obj_info = new UserInfo();
                obj_info = Obj_BL.User_GetById(Id);
                return PartialView("~/Views/User/_PartialUser_Update.cshtml", obj_info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
                return PartialView("~/Views/User/_PartialUser_Update.cshtml");
            }
        }
        [HttpPost]
        public Decimal UserUpdate(UserInfo Obj_Info)
        {
            decimal p_return = -1;
            UserBL Obj_BL = new UserBL();
            try
            {
                Obj_Info.Modify_Date = DateTime.Now;
                Obj_Info.Password = NaviCommon.CommonFuc.Encrypt(Obj_Info.User_Name.ToUpper() + "!@#$%" + Obj_Info.Password);
                p_return = Obj_BL.User_Update(Obj_Info);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
        }
        [HttpPost]
        public Decimal User_Delete(decimal user_id)
        {
            decimal p_return = -1;
            UserBL Obj_BL = new UserBL();
            try
            {
                p_return = Obj_BL.Delete(user_id);
            }
            catch (Exception ex)
            {
                NaviCommon.Common.log.Error(ex.ToString());
            }
            return p_return;
        }
    }
}