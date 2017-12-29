using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Common.DES;

namespace TLC_Handler.Admin
{
    /// <summary>
    /// Admin 的摘要说明
    /// </summary>
    public partial class Admin : IHttpHandler
    {
        #region 字段

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        JsonModel jsonModel = null;

        #endregion

        #region 中心入口点

        public void ProcessRequest(HttpContext context)
        {
            string func = context.Request["func"] ?? "";
            try
            {
              

                switch (func)
                {
                    case "Login": Login(context); break;
                    case "LoginOut": LoginOut(context); break;

                    case "AddUser": AddUser(context); break;
                    case "EditUser": EditUser(context); break;
                    case "GetUser": GetUser(context); break;
                    case "GetUserInfo": GetUserInfo(context); break;
                    case "EnableUser": EnableUser(context); break;
                    case "ResetPassword": ResetPassword(context); break;
                    case "UpdatePassword": UpdatePassword(context); break;

                    case "GetAward": GetAward(context); break;
                    case "AddAward": AddAward(context); break;
                    case "EditAward": EditAward(context); break;
                    case "PayAward": PayAward(context); break;

                    case "ServiceTempClear": ServiceTempClear(context); break;
                    case "GetAwardYear": GetAwardYear(context); break;
                    case "GetAwardSection": GetAwardSection(context); break;

                    case "GetMoneyLog": GetMoneyLog(context); break;
                    case "AddUserMoney": AddUserMoney(context); break;
                    case "ReduceUserMoney": ReduceUserMoney(context); break;
                    case "GetAllClientCash": GetAllClientCash(context); break;
                    case "GetAllClientMoney": GetAllClientMoney(context); break;
                    case "GetDateTimeNow": GetDateTimeNow(context); break; 
                        
                        
                    default:
                        jsonModel = JsonModel.GetJsonModel(5, "没有此方法", "");
                        context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                jsonModel = Constant.ErrorGetData(ex);
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        #endregion
    }
}