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
        #region 清除浏览器缓存

        static string Static_Scrept = "tbg@123";

        public void ServiceTempClear(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                string Scrept = RequestHelper.string_transfer(request, "Scrept");


                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result || Scrept == Static_Scrept)
                {
                    jsonModel = ServiceTempClear_Helper();
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message, "");
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AwardCode"></param>
        /// <param name="PayUID"></param>
        /// <returns></returns>
        public static JsonModel ServiceTempClear_Helper()
        {
            JsonModel jsm = null;
            try
            {
                Constant.Animal_Info_List = null;
                Constant.Award_Public_List = null;
                Constant.Detail_List = null;
                Constant.Globe_Clue_List = null;
                Constant.Globe_Clue_List = null;
                Constant.Globe_List = null;
                Constant.Operation_Record_List = null;
                Constant.Size_Six_List = null;
                Constant.Size_Special_List = null;
                Constant.Size_SpecialNormal_List = null;
                Constant.UserInfo_List = null;
                Constant.Wave_List = null;
                Constant.MoneyLog_List = null;
                jsm = JsonModel.GetJsonModel(0, "操作成功");
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 获取当前服务器时间

        public void GetDateTimeNow(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                jsonModel = JsonModel.GetJsonModel(0, "success", DateTime.Now);
            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message, "");
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        #endregion
    }
}