using NaviCommon;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnThanh.Commons
{
    public class SendTTUser
    {
        static MyQueue c_queue_user = new MyQueue();
        public static void Enqueue_Insert_User(UserInfo p_obj)
        {
            c_queue_user.Enqueue(p_obj);
        }
        public static UserInfo Get_Insert_User()
        {
            return (UserInfo)c_queue_user.Dequeue();
        }
    }
}