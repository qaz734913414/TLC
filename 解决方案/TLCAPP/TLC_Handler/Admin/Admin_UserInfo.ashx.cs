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
    /// Admin_UserInfo 的摘要说明
    /// </summary>
    public partial class Admin : IHttpHandler
    {

        static string defaltPassword = "123456";

        #region 添加用户

        public void AddUser(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string CreateUID = RequestHelper.string_transfer(request, "CreateUID");
                CreateUID = string.IsNullOrEmpty(CreateUID) ? "admin" : CreateUID;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");
                string Password = RequestHelper.string_transfer(request, "Password");
                Password = string.IsNullOrEmpty(Password) ? defaltPassword : Password;
                string Name = RequestHelper.string_transfer(request, "Name");
                //decimal Money = RequestHelper.decimal_transfer(request, "Money");
                DateTime EnableTime = RequestHelper.DateTime_transfer(request, "EnableTime");
                int Role = RequestHelper.int_transfer(request, "Role");
                string Remarks = RequestHelper.string_transfer(request, "Remarks");

                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = AddUser_Helper(CreateUID, LoginName, Password, Name, EnableTime, Role, Remarks);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel AddUser_Helper(string CreateUID, string LoginName, string Password,
            string Name, DateTime EnableTime, int Role, string Remarks)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;

                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.LoginName == LoginName);
                if (userinfo == null)
                {
                    UserInfo userInfo = new TLC_Model.UserInfo()
                    {
                        CreateUID = CreateUID,
                        LoginName = LoginName,
                        Name = Name,
                        Money = 0,//初始化金额为0
                        EnableTime = EnableTime,
                        Role = Role,//0 为管理员  1为代理
                        Remarks = Remarks,
                        CreateTime = DateTime.Now,
                        IsDelete = 0,
                        IsEnable = (int)IsEnable.Enable,
                    };
                    userInfo.Salt = Utils.GetCheckCode(6);
                    userInfo.Password = DESEncrypt.Encrypt(Password, userInfo.Salt);

                    jsm = Constant.UserInfo_S.Add(userInfo);
                    if (jsm.errNum == 0)
                    {
                        userInfo.Id = Convert.ToInt32(jsm.retData);
                        UserInfo_List.Add(userInfo);
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户名已存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }


        #endregion

        #region 获取用户信息

        public void GetUserInfo(HttpContext context)
        {
            JsonModelUser_Total jsonModelNum = null;
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                string Key = RequestHelper.string_transfer(request, "Key");
                bool IsLast = RequestHelper.bool_transfer(request, "IsLast");

                int PageIndex = RequestHelper.int_transfer(request, "PageIndex");
                int PageSize = RequestHelper.int_transfer(request, "PageSize");

                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModelNum = GetUserInfo_Helper(PageIndex, PageSize, Key, IsLast);
                }
                else
                {
                    jsonModelNum = JsonModelUser_Total.GetJsonModel(1000, "已超时");
                }

            }
            catch (Exception ex)
            {
                jsonModelNum = JsonModelUser_Total.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModelNum) + "}");
            }
        }

        public static JsonModelUser_Total GetUserInfo_Helper(int pageIndex, int PageSize, string Key, bool IsLast)
        {
            JsonModelUser_Total jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                List<MoneyLog> MoneyLog_List = Constant.MoneyLog_List;
                var userList = (from user in UserInfo_List
                                where user.Role != 1 && user.Name.Contains(Key)
                                orderby user.CreateTime descending
                                select new
                                {
                                    user.Id,
                                    user.Name,
                                    user.Money,
                                    user.IsEnable,
                                    user.LoginName,
                                    user.CreateTime,
                                    user.EnableTime,

                                }).ToList();

                if (IsLast)
                {
                    userList = (from user in userList where user.CreateTime >= DateTime.Now.AddDays(-7) select user).ToList();
                }

                var userListt_get = userList.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                jsm = JsonModelUser_Total.GetJsonModel(0, "success", userListt_get);
                jsm.PageIndex = pageIndex;
                jsm.PageSize = PageSize;
                jsm.PageCount = (userList.Count + PageSize - 1) / PageSize; ;

                jsm.PersonCount = userList.Count;

                decimal allMoney = 0;
                decimal allCash = 0;
                foreach (var item in userListt_get)
                {
                    allMoney += (decimal)item.Money;

                    List<MoneyLog> mons = MoneyLog_List.Where(i => i.UserID == item.LoginName && i.OperationType == (int)MoneyType.提现).ToList();
                    foreach (var mon in mons)
                    {
                        allCash += (decimal)mon.O_Money;
                    }
                }
                jsm.AllMoney = allMoney;
                jsm.CashMoney = allCash;

                jsm.RowCount = userList.Count;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 获取指定用户信息

        public void GetUser(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = GetUser_Helper(Id);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel GetUser_Helper(int Id)
        {
            JsonModel jsm = null;
            try
            {
                var UserInfo_List = (from user in Constant.UserInfo_List
                                     select new
                                     {
                                         user.Id,
                                         user.Name,
                                         user.LoginName,
                                         user.Remarks,
                                         user.Money,
                                         user.EnableTime
                                     }).ToList();
                var userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    jsm = JsonModel.GetJsonModel(0, "sucessed", userinfo);
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 编辑用户

        public void EditUser(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");
                string EditUID = RequestHelper.string_transfer(request, "EditUID");
                EditUID = string.IsNullOrEmpty(EditUID) ? "admin" : EditUID;
                string Name = RequestHelper.string_transfer(request, "Name");
                //decimal Money = RequestHelper.decimal_transfer(request, "Money");
                DateTime EnableTime = RequestHelper.DateTime_transfer(request, "EnableTime");
                string Remarks = RequestHelper.string_transfer(request, "Remarks");
                string LoginName = RequestHelper.string_transfer(request, "LoginName");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = EditUser_Helper(Id, Name, EnableTime, Remarks);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel EditUser_Helper(int Id,
              string Name, DateTime EnableTime, string Remarks)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    userinfo.Name = Name;
                    userinfo.EnableTime = EnableTime;
                    userinfo.Remarks = Remarks;
                    jsm = Constant.UserInfo_S.Update(userinfo);
                    if (jsm.errNum == 0)
                    {
                        jsm = JsonModel.GetJsonModel(0, "sucessed");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 启用、禁用用户

        public void EnableUser(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");
                int IsEnable = RequestHelper.int_transfer(request, "IsEnable");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = EnableUser_Helper(Id, IsEnable);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel EnableUser_Helper(int Id, int IsEnable)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;

                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    userinfo.IsEnable = (byte)IsEnable;
                    jsm = Constant.UserInfo_S.Update(userinfo);
                    if (jsm.errNum == 0)
                    {
                        jsm = JsonModel.GetJsonModel(0, "sucessed");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 重置密码

        public void ResetPassword(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = ResetPassword_Helper(Id);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel ResetPassword_Helper(int Id)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;

                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    UserInfo _usInfo = Constant.Clone<UserInfo>(userinfo);

                    _usInfo.Salt = Utils.GetCheckCode(6);
                    _usInfo.Password = DESEncrypt.Encrypt(defaltPassword, _usInfo.Salt);
                    jsm = Constant.UserInfo_S.Update(_usInfo);
                    if (jsm.errNum == 0)
                    {
                        userinfo.Salt = _usInfo.Salt;
                        userinfo.Password = _usInfo.Password;
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "更改密码失败");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 修改密码

        public void UpdatePassword(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");
                string oldPassword = RequestHelper.string_transfer(request, "oldPassword");
                string newPassword = RequestHelper.string_transfer(request, "newPassword");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//修改密码
                if (result)
                {
                    jsonModel = UpdatePassword_Helper(LoginName, oldPassword, newPassword);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel UpdatePassword_Helper(string LoginName, string oldPassword, string newPassword)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                UserInfo userInfo = UserInfo_List.FirstOrDefault(user => user.LoginName == LoginName);
                if (userInfo != null)
                {
                    string pass = DESEncrypt.Decrypt(userInfo.Password, userInfo.Salt);
                    if (oldPassword == pass)
                    {
                        UserInfo _usInfo = Constant.Clone<UserInfo>(userInfo);
                        _usInfo.Salt = Utils.GetCheckCode(6);
                        _usInfo.Password = DESEncrypt.Encrypt(newPassword, _usInfo.Salt);
                        jsm = Constant.UserInfo_S.Update(_usInfo);
                        if (jsm.errNum == 0)
                        {
                            userInfo.Salt = _usInfo.Salt;
                            userInfo.Password = _usInfo.Password;
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(300, "更改密码失败");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "密码错误");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "该用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 充值金额

        public void AddUserMoney(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");
                decimal Money = RequestHelper.decimal_transfer(request, "Money");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = AddUserMoney_Helper(Id, Money);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel AddUserMoney_Helper(int Id, decimal Money)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;

                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    UserInfo userClone = Constant.Clone<UserInfo>(userinfo);
                    userClone.Money += Money;
                    jsm = Constant.UserInfo_S.Update(userClone);
                    if (jsm.errNum == 0)
                    {
                        userinfo.Money += Money;

                        Constant.MoneyAnsys(null, Money, userinfo, TLC_Model.Enums.MoneyType.充值, "");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 提取现金

        public void ReduceUserMoney(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                int Id = RequestHelper.int_transfer(request, "Id");
                decimal Money = RequestHelper.decimal_transfer(request, "Money");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = ReduceUserMoney_Helper(Id, Money);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel ReduceUserMoney_Helper(int Id, decimal Money)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;

                UserInfo userinfo = UserInfo_List.FirstOrDefault(user => user.Id == Id);
                if (userinfo != null)
                {
                    if (userinfo.Money > Money)
                    {
                        UserInfo userClone = Constant.Clone<UserInfo>(userinfo);
                        userClone.Money -= Money;
                        jsm = Constant.UserInfo_S.Update(userClone);
                        if (jsm.errNum == 0)
                        {
                            userinfo.Money -= Money;

                            Constant.MoneyAnsys(null, Money, userinfo, TLC_Model.Enums.MoneyType.提现, "");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "余额不足,提取失败");
                    }

                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "用户不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 代理总金额

        public void GetAllClientMoney(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP(UID, dsp);
                if (result)
                {
                    jsonModel = GetAllClientMoney_Helper();
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel GetAllClientMoney_Helper()
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                if (UserInfo_List.Count > 0)
                {
                    var moneys = (from user in UserInfo_List where user.Role == (int)RoleType.Agent select user.Money);

                    decimal AllMoney = 0;
                    foreach (var item in moneys)
                    {
                        AllMoney += (decimal)item;
                    }

                    jsm = JsonModel.GetJsonModel(0, "操作成功", AllMoney);
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "没有数据");
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion


        #region 提取总金额

        public void GetAllClientCash(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP(UID, dsp);
                if (result)
                {
                    jsonModel = GetAllClientCash_Helper();
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModel GetAllClientCash_Helper()
        {
            JsonModel jsm = null;
            try
            {
                List<MoneyLog> MoneyLog_List = Constant.MoneyLog_List;
                if (MoneyLog_List.Count > 0)
                {
                    var moneys = (from money in MoneyLog_List where money.OperationType == (int)MoneyType.提现 select money.O_Money);

                    decimal AllMoney = 0;
                    foreach (var item in moneys)
                    {
                        AllMoney += (decimal)item;
                    }

                    jsm = JsonModel.GetJsonModel(0, "操作成功", AllMoney);
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "没有数据");
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 获取支出、支出记录

        public void GetMoneyLog(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");

                int PageIndex = RequestHelper.int_transfer(request, "PageIndex");
                int PageSize = RequestHelper.int_transfer(request, "PageSize");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = GetMoneyLog_Helper(LoginName, PageIndex, PageSize);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
                }

            }
            catch (Exception ex)
            {
                jsonModel = JsonModel.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModel) + "}");
            }
        }

        public static JsonModelNum GetMoneyLog_Helper(string LoginName, int pageIndex, int PageSize)
        {
            JsonModelNum jsm = null;
            try
            {
                List<MoneyLog> MoneyLog_List = Constant.MoneyLog_List;

                MoneyLog_List = (from m in MoneyLog_List where m.UserID == LoginName orderby m.CreateTime descending select m).ToList();
                if (MoneyLog_List.Count > 0)
                {
                    var userListt_get = MoneyLog_List.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                    jsm = JsonModelNum.GetJsonModel(0, "success", userListt_get);
                    jsm.PageIndex = pageIndex;
                    jsm.PageSize = PageSize;
                    jsm.PageCount = (MoneyLog_List.Count + PageSize - 1) / PageSize; ;


                    jsm.RowCount = MoneyLog_List.Count;
                }
                else
                {
                    jsm = JsonModelNum.GetJsonModel(300, "暂无数据");
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