using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Common.DES;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Handler.Client
{
    /// <summary>
    /// OperationManage 的摘要说明
    /// </summary>
    public class OperationManage : IHttpHandler
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
                    case "BuyGlobe": BuyGlobe(context); break;
                    case "BuyGlobe_Group": BuyGlobe_Group(context); break;

                    case "DebtGroup": DebtGroup(context); break;

                    case "GetOperation": GetOperation(context); break;
                    case "GetUserMoney": GetUserMoney(context); break;
                    default:
                        jsonModel = new JsonModel()
                        {
                            errNum = 5,
                            errMsg = "没有此方法",
                            retData = ""
                        };
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

        #region 下注

        public void BuyGlobe(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UserID = RequestHelper.string_transfer(request, "UserID");
                int AwardCode = RequestHelper.int_transfer(request, "AwardCode");
                int ClueCode = RequestHelper.int_transfer(request, "ClueCode");


                string Buy_Content = RequestHelper.string_transfer(request, "Buy_Content");
                string Buy_Content2 = RequestHelper.string_transfer(request, "Buy_Content2");
                string BuyPayReturn = RequestHelper.string_transfer(request, "BuyPayReturn");
                string BuyPayReturn2 = RequestHelper.string_transfer(request, "BuyPayReturn2");
                int UnitPrice = RequestHelper.int_transfer(request, "UnitPrice");
                decimal Using_Money = RequestHelper.decimal_transfer(request, "Using_Money");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//下注
                if (result)
                {
                    jsonModel = BuyGlobe_Helper(UserID, AwardCode, ClueCode, Buy_Content, Buy_Content2, UnitPrice, Using_Money, BuyPayReturn, BuyPayReturn2);
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
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

        public static JsonModel BuyGlobe_Helper(string UserID, int AwardCode, int ClueCode, string Buy_Content, string Buy_Content2,
            int UnitPrice, decimal Using_Money, string BuyPayReturn, string BuyPayReturn2)
        {
            JsonModel jsm = null;
            try
            {
                List<Operation_Record> Operation_Record_List = Constant.Operation_Record_List;
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                UserInfo userInfo = UserInfo_List.FirstOrDefault(user => user.LoginName == Convert.ToString(UserID));
                if (userInfo != null)
                {
                    string pass = DESEncrypt.Decrypt(userInfo.Password, userInfo.Salt);

                    if (userInfo.Money >= Using_Money)
                    {
                        Operation_Record Operation_Record = new Operation_Record()
                        {
                            Buy_Content = Buy_Content,
                            Buy_Content2 = Buy_Content2,
                            CreateUID = userInfo.LoginName,
                            UnitPrice = UnitPrice,
                            AwardCode = AwardCode,
                            ClueCode = ClueCode,
                            BuyPayReturn = BuyPayReturn,
                            BuyPayReturn2 = BuyPayReturn2,
                            UserID = UserID,
                            Using_Money = Using_Money,
                            Type = (int)DebtType.Single,

                            Operation_Time = DateTime.Now,
                            CreateTime = DateTime.Now,
                            Get_Money = 0,
                            MaxPayReturn = 0,
                            MinPayReturn = 0,
                            Araw_ReturnMoney = 0,
                            Return_Money = 0,
                            EditUID = "",
                            IsDelete = 0,
                            IsEnable = (int)IsEnable.Enable,
                            IsWin = (int)IsWinType.未开奖,
                            PayUID = "",
                        };
                        JsonModel jsmo = Constant.Operation_Record_S.Add(Operation_Record);
                        if (jsmo.errNum == 0)
                        {
                            Operation_Record.Id = Convert.ToInt32(jsmo.retData);

                            UserInfo userInfo_Clone = Constant.Clone<UserInfo>(userInfo);
                            userInfo_Clone.Money -= Using_Money;
                            jsm = Constant.UserInfo_S.Update(userInfo_Clone);
                            if (jsm.errNum == 0)
                            {
                                userInfo.Money -= Using_Money;

                                Constant.Operation_Record_List.Add(Operation_Record);
                                //支出支入
                                Constant.MoneyAnsys(Operation_Record, Using_Money, userInfo, MoneyType.下注, "");

                            }
                            else
                            {
                                jsm = JsonModel.GetJsonModel(500, "下注失败");
                            }
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(500, "下注失败");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(400, "您当前的余额不足");
                    }
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

        #region 下注【组合】

        public void BuyGlobe_Group(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UserID = RequestHelper.string_transfer(request, "UserID");
                int AwardCode = RequestHelper.int_transfer(request, "AwardCode");
                int ClueCode = RequestHelper.int_transfer(request, "ClueCode");
                int Count = RequestHelper.int_transfer(request, "Count");

                string Buy_Content = RequestHelper.string_transfer(request, "Buy_Content");
                string Buy_Content2 = string.Empty;

                int UnitPrice = RequestHelper.int_transfer(request, "UnitPrice");
                decimal Using_Money = RequestHelper.decimal_transfer(request, "Using_Money");

                string BuyPayReturn = RequestHelper.string_transfer(request, "BuyPayReturn");
                string BuyPayReturn2 = string.Empty;

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//下注
                if (result)
                {
                    string[] codeArray = Split_Hepler.str_to_stringss(Buy_Content);
                    List<string> codeList = codeArray.Count() > 0 ? codeArray.ToList() : new List<string>();
                    List<string> bu_contents = GroupHelper(codeList, Count);
                    //序列化表单详情列表
                    List<string> BuyPayReturnList = JsonConvert.DeserializeObject<List<string>>(BuyPayReturn);

                    int length = 0;
                    foreach (var item in bu_contents)
                    {
                        float MinPayReturn = 0;
                        float MaxPayReturn = 0;
                        List<Globe_S> globes = Globe_S.GetBase(item, Constant.Globe_List, BuyPayReturnList[length]);
                        foreach (var code in globes)
                        {
                            if (MinPayReturn == 0 || MinPayReturn > code.PayReturn)
                            {
                                MinPayReturn = code.PayReturn;
                            }
                            if (MaxPayReturn == 0 || MaxPayReturn < code.PayReturn)
                            {
                                MaxPayReturn = code.PayReturn;
                            }
                        }
                        MinPayReturn = MinPayReturn > 0 ? (float)Math.Round(MinPayReturn, 2) : 0;
                        MaxPayReturn = MaxPayReturn > 0 ? (float)Math.Round(MaxPayReturn, 2) : 0;

                        jsonModel = BuyGlobe_Group_Helper(UserID, AwardCode, ClueCode, item, Buy_Content2, UnitPrice, UnitPrice, BuyPayReturnList[length], BuyPayReturn2, MinPayReturn, MaxPayReturn);
                        length++;
                    }
                }
                else
                {
                    jsonModel = JsonModel.GetJsonModel(300, "未经授权");
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

        public static JsonModel BuyGlobe_Group_Helper(string UserID, int AwardCode, int ClueCode, string Buy_Content, string Buy_Content2,
            int UnitPrice, decimal Using_Money, string BuyPayReturn, string BuyPayReturn2, float MinPayReturn, float MaxPayReturn)
        {
            JsonModel jsm = null;
            try
            {
                List<Operation_Record> Operation_Record_List = Constant.Operation_Record_List;
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                UserInfo userInfo = UserInfo_List.FirstOrDefault(user => user.LoginName == Convert.ToString(UserID));
                if (userInfo != null)
                {
                    string pass = DESEncrypt.Decrypt(userInfo.Password, userInfo.Salt);

                    if (userInfo.Money >= Using_Money)
                    {
                        Operation_Record Operation_Record = new Operation_Record()
                        {
                            Buy_Content = Buy_Content,
                            Buy_Content2 = Buy_Content2,
                            CreateUID = userInfo.LoginName,
                            UnitPrice = UnitPrice,
                            AwardCode = AwardCode,
                            ClueCode = ClueCode,
                            BuyPayReturn = BuyPayReturn,
                            BuyPayReturn2 = BuyPayReturn2,
                            UserID = UserID,
                            Using_Money = Using_Money,
                            MinPayReturn = (decimal)MinPayReturn,
                            MaxPayReturn = (decimal)MaxPayReturn,
                            Type = (int)DebtType.Group,
                            Operation_Time = DateTime.Now,
                            CreateTime = DateTime.Now,
                            Get_Money = 0,

                            Araw_ReturnMoney = 0,
                            Return_Money = 0,
                            EditUID = "",
                            IsDelete = 0,
                            IsEnable = (int)IsEnable.Enable,
                            IsWin = (int)IsWinType.未开奖,
                            PayUID = "",

                        };
                        JsonModel jsmo = Constant.Operation_Record_S.Add(Operation_Record);
                        if (jsmo.errNum == 0)
                        {
                            Operation_Record.Id = Convert.ToInt32(jsmo.retData);

                            UserInfo userInfo_Clone = Constant.Clone<UserInfo>(userInfo);
                            userInfo_Clone.Money -= Using_Money;
                            jsm = Constant.UserInfo_S.Update(userInfo_Clone);
                            if (jsm.errNum == 0)
                            {
                                userInfo.Money -= Using_Money;
                                Constant.Operation_Record_List.Add(Operation_Record);

                                //支出支入
                                //支出支入
                                Constant.MoneyAnsys(Operation_Record, Using_Money, userInfo, MoneyType.下注, "");
                            }
                            else
                            {
                                jsm = JsonModel.GetJsonModel(500, "下注失败");
                            }
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(500, "下注失败");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(400, "您当前的余额不足");
                    }
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

        #region 获取下注记录

        public void GetOperation(HttpContext context)
        {
            JsonModelNum_Total jsonModelNum = null;
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                string Key = RequestHelper.string_transfer(request, "Key");

                string Year = RequestHelper.string_transfer(request, "Year");
                string Section = RequestHelper.string_transfer(request, "Section");
                string LoginName = RequestHelper.string_transfer(request, "LoginName");

                //当期奖项
                bool Current = RequestHelper.bool_transfer(request, "Current");
                bool IsHistory = RequestHelper.bool_transfer(request, "IsHistory");

                int PageIndex = RequestHelper.int_transfer(request, "PageIndex");
                int PageSize = RequestHelper.int_transfer(request, "PageSize");

                bool result = Constant.Check_Login_DIP(UID, dsp);
                if (result)
                {
                    jsonModelNum = GetOperation_Helper(PageIndex, PageSize, Key, Current, IsHistory, Year, Section, LoginName);
                }
                else
                {
                    jsonModelNum = JsonModelNum_Total.GetJsonModel(1000, "已超时");
                }
            }
            catch (Exception ex)
            {
                jsonModelNum = JsonModelNum_Total.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModelNum) + "}");
            }
        }



        public static JsonModelNum_Total GetOperation_Helper(int pageIndex, int PageSize, string Key, bool Current, bool IsHistory, string Year, string Section, string LoginName)
        {
            JsonModelNum_Total jsm = null;
            try
            {
                List<Operation_Record> Operation_Record_List = Constant.Operation_Record_List;
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                List<Globe_Clue> Globe_Clue_List = Constant.Globe_Clue_List;
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                List<Globe> Globe_List = Constant.Globe_List;

                List<Operation_Record_S> recordList = Get_Operation_Record_S(Operation_Record_List, Award_Public_List, Globe_Clue_List, UserInfo_List, Globe_List);
                List<Operation_Record_S> recordList_real = new List<Operation_Record_S>();


                if (!string.IsNullOrEmpty(LoginName))
                {
                    recordList_real = (from record in recordList where record.UserID == LoginName select record).ToList();
                }
                else
                {
                    if (Current)
                    {
                        List<Award_Public> price_list = Award_Public_List.Where(item => DateTime.Now < item.CloseTime && item.StartTime < DateTime.Now).ToList();
                        if (price_list.Count > 0)
                        {
                            var prize = price_list[0];
                            recordList_real = (from record in recordList where record.AwardCode == prize.Code select record).ToList();
                        }
                    }
                    else if (IsHistory)
                    {
                        List<int> codes = (from award in Award_Public_List where DateTime.Now > award.CloseTime select (int)award.Code).ToList();
                        if (codes.Count > 0)
                        {
                            recordList_real = (from record in recordList where codes.Contains((int)record.AwardCode) select record).ToList();
                        }
                    }
                    else
                    {
                        recordList_real = recordList;
                    }
                }


                if (!string.IsNullOrEmpty(Year))
                {
                    List<int> codes = (from award in Award_Public_List where Convert.ToString(award.Year) == Year select (int)award.Code).Distinct().ToList();
                    recordList_real = (from record in recordList_real where codes.Contains((int)record.AwardCode) select record).ToList();
                }
                if (!string.IsNullOrEmpty(Section))
                {
                    List<int> codes = (from award in Award_Public_List where Convert.ToString(award.Name) == Section select (int)award.Code).Distinct().ToList();
                    recordList_real = (from record in recordList_real where codes.Contains((int)record.AwardCode) select record).ToList();
                }



                decimal Araw_ReturnMoneyTotal = 0;
                decimal Get_MoneyTotal = 0;
                decimal Return_MoneyTotal = 0;
                decimal Using_MoneyTotal = 0;
                decimal Win_MoneyTotal = 0;
                foreach (var item in recordList_real)
                {
                    Araw_ReturnMoneyTotal += (decimal)item.Araw_ReturnMoney;
                    Get_MoneyTotal += (decimal)item.Get_Money;
                    Return_MoneyTotal += (decimal)item.Return_Money;
                    Using_MoneyTotal += (decimal)item.Using_Money;
                    Win_MoneyTotal += (decimal)(item.Get_Money + item.Araw_ReturnMoney + item.Return_Money - item.Using_Money);
                }

                List<Operation_Record_S> recordList_get = recordList_real.Skip((pageIndex - 1) * PageSize).Take(PageSize).OrderByDescending(i => i.CreateTime).ToList();
                SetContent(recordList_get, Globe_Clue_List);

                jsm = JsonModelNum_Total.GetJsonModel(0, "success", recordList_get);
                jsm.Araw_ReturnMoneyTotal = Araw_ReturnMoneyTotal;
                jsm.Get_MoneyTotal = Get_MoneyTotal;
                jsm.Return_MoneyTotal = Return_MoneyTotal;
                jsm.Using_MoneyTotal = Using_MoneyTotal;
                jsm.Win_MoneyTotal = Win_MoneyTotal;

                jsm.PageIndex = pageIndex;
                jsm.PageSize = PageSize;
                jsm.PageCount = (recordList_real.Count + PageSize - 1) / PageSize; ;
                jsm.RowCount = recordList_real.Count;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        public static List<Operation_Record_S> Get_Operation_Record_S(List<Operation_Record> Operation_Record_List, List<Award_Public> Award_Public_List, List<Globe_Clue> Globe_Clue_List, List<UserInfo> UserInfo_List, List<Globe> Globe_List)
        {
            List<Operation_Record_S> list = new List<Operation_Record_S>();
            try
            {
                list = (from record in Operation_Record_List
                        join award in Award_Public_List on record.AwardCode equals award.Code
                        join clue in Globe_Clue_List on record.ClueCode equals clue.Code
                        join user in UserInfo_List on record.UserID equals user.LoginName
                        orderby record.CreateTime
                        select new Operation_Record_S()
                        {
                            Id = (int)record.Id,
                            AwardCode = (int)record.AwardCode,
                            ClueCode = (int)record.ClueCode,
                            Buy_Content = record.Buy_Content,
                            Buy_Content2 = record.Buy_Content2,
                            BuyPayReturn = record.BuyPayReturn,
                            BuyPayReturn2 = record.BuyPayReturn2,
                            UnitPrice = (int)record.UnitPrice,
                           

                            CreateTime = (DateTime)record.CreateTime,
                            Operation_Time = (DateTime)record.Operation_Time,
                            IsWin = (int)record.IsWin,
                            UserID = record.UserID,
                            Get_Money = (decimal)record.Get_Money,
                            Araw_ReturnMoney = (decimal)record.Araw_ReturnMoney,
                            Araw_RetrunContent = record.Araw_RetrunContent,
                            Using_Money = (decimal)record.Using_Money,
                            Return_Money = (decimal)record.Return_Money,

                            Win_Money = (decimal)(record.Get_Money + record.Araw_ReturnMoney + record.Return_Money - record.Using_Money),
                            Year = award.Year,
                            award_Name = award.Name,
                            PrizeContent = award.PrizeContent,

                            First_Name = clue.First_Name,
                            Second_Name = clue.Second_Name,
                            user_Name = user.Name,

                            GlobeList = Globe_S.GetBase(award.PrizeContent, Globe_List),
                            IsShowMin = clue.IsEnable == 2 ? true : false,
                            MinPayReturn = (decimal)record.MinPayReturn,

                        }).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return list;
        }


        public static Operation_Record_S Get_Operation_Record_S(Operation_Record record, Award_Public award, Globe_Clue clue, UserInfo user, List<Globe> Globe_List)
        {
            Operation_Record_S Operation_Record_S = new Operation_Record_S();
            try
            {
                Operation_Record_S = new Operation_Record_S()
                         {
                             Id = (int)record.Id,
                             AwardCode = (int)record.AwardCode,
                             ClueCode = (int)record.ClueCode,
                             Buy_Content = record.Buy_Content,
                             Buy_Content2 = record.Buy_Content2,
                             BuyPayReturn = record.BuyPayReturn,
                             BuyPayReturn2 = record.BuyPayReturn2,
                             UnitPrice = (int)record.UnitPrice,

                             CreateTime = (DateTime)record.CreateTime,
                             Operation_Time = (DateTime)record.Operation_Time,
                             IsWin = (int)record.IsWin,
                             UserID = record.UserID,
                             Get_Money = (decimal)record.Get_Money,
                             Araw_ReturnMoney = (decimal)record.Araw_ReturnMoney,
                             Araw_RetrunContent = record.Araw_RetrunContent,
                             Using_Money = (decimal)record.Using_Money,
                             Return_Money = (decimal)record.Return_Money,

                             Win_Money = (decimal)(record.Get_Money + record.Araw_ReturnMoney + record.Return_Money - record.Using_Money),
                             Year = award.Year,
                             award_Name = award.Name,
                             PrizeContent = award.PrizeContent,

                             First_Name = clue.First_Name,
                             Second_Name = clue.Second_Name,
                             user_Name = user.Name,

                             GlobeList = Globe_S.GetBase(award.PrizeContent, Globe_List),
                         };
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return Operation_Record_S;
        }

        public static void SetContent(List<Operation_Record_S> recordList_get, List<Globe_Clue> Globe_Clue_List)
        {
            try
            {
                foreach (var item in recordList_get)
                {
                    Globe_Clue clue = Globe_Clue_List.FirstOrDefault(i => i.Code == item.ClueCode);
                    if (clue != null)
                    {
                        SetContent(clue, item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        public static void SetContent(Globe_Clue clue, Operation_Record_S item)
        {
            try
            {
                GlobeClueType GlobeClueType = (GlobeClueType)clue.First_Type;
                switch (GlobeClueType)
                {
                    case GlobeClueType.Special:
                        item.BuyDisplay = Globe_S.GetBase_Str(item.Buy_Content, Constant.Globe_List);
                        item.FirstGlobeList = Globe_S.GetBase(item.Buy_Content, Constant.Globe_List);
                        item.FirstIsGloble = true;
                        item.BuyDisplay2 = Size_S.GetBase_Str(item.Buy_Content2, Constant.Size_Special_List);
                        break;
                    case GlobeClueType.Normal:
                        item.BuyDisplay = Globe_S.GetBase_Str(item.Buy_Content, Constant.Globe_List);
                        item.FirstGlobeList = Globe_S.GetBase(item.Buy_Content, Constant.Globe_List);
                        item.FirstIsGloble = true;
                        break;
                    case GlobeClueType.SpecialNormal:
                        item.BuyDisplay = Globe_S.GetBase_Str(item.Buy_Content, Constant.Globe_List);
                        item.FirstGlobeList = Globe_S.GetBase(item.Buy_Content, Constant.Globe_List);
                        item.FirstIsGloble = true;
                        item.BuyDisplay2 = Size_NormalS.GetBase_Str(item.Buy_Content2, Constant.Size_SpecialNormal_List);
                        break;
                    case GlobeClueType.NormalSix:
                        item.BuyDisplay = Size_Six_S.GetBase_Str(item.Buy_Content, Constant.Size_Six_List);
                        break;
                    case GlobeClueType.Line:
                        item.BuyDisplay = Globe_S.GetBase_Str(item.Buy_Content, Constant.Globe_List);
                        item.FirstGlobeList = Globe_S.GetBase(item.Buy_Content, Constant.Globe_List);
                        item.FirstIsGloble = true;
                        break;
                    case GlobeClueType.Wave:
                        item.BuyDisplay = Wave_S.GetBase_Str(item.Buy_Content, Constant.Wave_List);
                        break;
                    case GlobeClueType.Detail:
                        item.BuyDisplay = Animal_Info_S.GetBase_Str(item.Buy_Content, Constant.Animal_Info_List);
                        item.BuyDisplay2 = Detail_S.GetBase_Str(item.Buy_Content2, Constant.Detail_List);
                        break;
                    case GlobeClueType.SpecialAnimal:
                        item.BuyDisplay = Animal_Info_S.GetBase_Str(item.Buy_Content, Constant.Animal_Info_List);
                        break;
                    case GlobeClueType.CombineAnimal:
                        item.BuyDisplay = Animal_Info_S.GetBase_Str(item.Buy_Content, Constant.Animal_Info_List);
                        break;
                    case GlobeClueType.LineAnimal:
                        item.BuyDisplay = Animal_Info_S.GetBase_Str(item.Buy_Content, Constant.Animal_Info_List);
                        break;
                    case GlobeClueType.LineDetail:
                        item.BuyDisplay = Detail_S.GetBase_Str(item.Buy_Content, Constant.Detail_List);
                        break;
                    case GlobeClueType.NotAll:
                        item.BuyDisplay = Globe_S.GetBase_Str(item.Buy_Content, Constant.Globe_List);
                        item.FirstGlobeList = Globe_S.GetBase(item.Buy_Content, Constant.Globe_List);
                        item.FirstIsGloble = true;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        #endregion

        #region 获取当前人金额

        public void GetUserMoney(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string LoginName = RequestHelper.string_transfer(request, "LoginName");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//获取当前人金额
                if (result)
                {
                    jsonModel = GetUserMoney_Helper(LoginName);
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

        public static JsonModel GetUserMoney_Helper(string LoginName)
        {
            JsonModel jsm = null;
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                UserInfo user = UserInfo_List.FirstOrDefault(u => u.LoginName == LoginName);
                if (user != null)
                {
                    jsm = JsonModel.GetJsonModel(0, "susscecd", user.Money);
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

        #region 获取组合


        public void DebtGroup(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string Codes = RequestHelper.string_transfer(request, "Codes");
                string[] codeArray = Split_Hepler.str_to_stringss(Codes);
                List<string> codeList = codeArray.Count() > 0 ? codeArray.ToList() : new List<string>();
                int Count = RequestHelper.int_transfer(request, "Count");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//获取当前人金额
                if (result)
                {
                    var list = GroupHelper(codeList, Count);
                    jsonModel = JsonModel.GetJsonModel(0, "获取成功", list);
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

        public static List<string> GroupHelper(List<string> lst, int count)
        {
            List<string> result = new List<string>();
            try
            {
                foreach (var comb in Combinations(lst, 0, lst.Count(), count))
                {
                    var r = comb.Take(count).ToArray();
                    result.Add(string.Join(",", r));
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return result;
        }

        public static IEnumerable<List<string>> Combinations(List<string> sq, int i0, int n, int c)
        {
            if (c == 0) yield return sq;
            else
            {
                for (int i = 0; i < n; i++)
                {
                    foreach (var perm in Combinations
                        (sq, i0 + 1, n - 1 - i, c - 1))
                        yield return perm;
                    RL(sq, i0, n);
                }
            }
        }

        private static void RL(List<string> sq, int i0, int n)
        {
            string tmp = sq[i0];
            sq.RemoveAt(i0);
            sq.Insert(i0 + n - 1, tmp);
        }

        #endregion


    }
}