using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Common.DES;
using TLC_Model.Enums;

namespace TLC_Handler.Admin
{
    /// <summary>
    /// Admin_Login 的摘要说明
    /// </summary>
    public partial class Admin : IHttpHandler
    {
        #region 约定俗成

        public static string Valied_Admin = "sll^^^9wefew]loloorerferf";

        public static string Valied = "s*--234regrregoloorerferf";

        #endregion

        #region 登录

        public void Login(HttpContext context)
        {
            try
            {
                Constant.SyncTimer();

                HttpRequest request = context.Request;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");
                string Password = RequestHelper.string_transfer(request, "Password");
                jsonModel = Login_Helper(LoginName, Password);
            }
            catch (Exception ex)
            {
                jsonModel = new JsonModel()
                {
                    errNum = 400,
                    errMsg = ex.Message,
                    retData = ""
                };
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel Login_Helper(string LoginName, string Password)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                UserInfo userInfo = UserInfo_List.FirstOrDefault(user => user.LoginName == LoginName);
                if (userInfo != null)
                {
                    string pass = DESEncrypt.Decrypt(userInfo.Password, userInfo.Salt);
                    if (Password == pass)
                    {
                        if (userInfo.IsEnable == (int)IsEnable.Enable || userInfo.Role == (int)RoleType.Admin)
                        {
                            if (userInfo.EnableTime > DateTime.Now || userInfo.Role == (int)RoleType.Admin)
                            {
                                var dsp = DESEncrypt.Encrypt(userInfo.LoginName, userInfo.Salt);
                                if (userInfo.Role == (int)RoleType.Admin)
                                {
                                    var user = new { dsp = dsp,userInfo.Name, userInfo.LoginName, userInfo.Role, Valied = Valied_Admin };
                                    Constant.Set_Login_DIP(LoginName, dsp);
                                    jsm = JsonModel.GetJsonModel(0, "登录成功", user);
                                }
                                else if (userInfo.Role == (int)RoleType.Agent)
                                {
                                    var user = new { dsp = dsp, userInfo.Name, userInfo.LoginName, userInfo.Role, Valied = Valied };
                                    Constant.Set_Login_DIP(LoginName, dsp);
                                    jsm = JsonModel.GetJsonModel(0, "登录成功", user);
                                }
                            }
                            else
                            {
                                jsm = JsonModel.GetJsonModel(300, "该账户已到期,请联系管理员");
                            }
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(300, "该账户已被禁用,请联系管理员");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "用户名密码错误");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户名密码错误");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 登出

        public void LoginOut(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//登出
                if (result)
                {
                    jsonModel = LoginOut_Helper(LoginName);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModel = new JsonModel()
                {
                    errNum = 400,
                    errMsg = ex.Message,
                    retData = ""
                };
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel LoginOut_Helper(string LoginName)
        {
            JsonModel jsm = null;
            try
            {
                bool result = Constant.Remove_Login_DIP(LoginName);
                if (result)
                {
                    jsm = JsonModel.GetJsonModel(0, "登出成功");
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion
    }
}


