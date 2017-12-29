using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_Globe_Line;
using TLC_Globe_LineAnimal;
using TLC_Globe_LineDetail;
using TLC_Globe_Normal;
using TLC_Globe_NotAll;
using TLC_Globe_Special;
using TLC_Globe_SpecialAnimal;
using TLC_Globe_SpecialNormal;
using TLC_Globe_Wave;
using TLC_Handler.Client;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Common.DES;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Handler.Admin
{
    /// <summary>
    /// Admin_Login 的摘要说明
    /// </summary>
    public partial class Admin : IHttpHandler
    {
        #region 获取历史奖项

        public void GetAward(HttpContext context)
        {
            JsonModelNum jsonModelNum = null;
            try
            {
                HttpRequest request = context.Request;

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                string Key = RequestHelper.string_transfer(request, "Key");
                int Id = RequestHelper.int_transfer(request, "Id");
                bool Current = RequestHelper.bool_transfer(request, "Current");
                bool IsLast = RequestHelper.bool_transfer(request, "IsLast");
                int PageIndex = RequestHelper.int_transfer(request, "PageIndex");
                int PageSize = RequestHelper.int_transfer(request, "PageSize");

                if (IsLast || Current || Id > 0)
                {
                    //bool result = Constant.Check_Login_DIP(UID, dsp);
                    //if (result)
                    //{
                    jsonModelNum = GetAward_Helper(PageIndex, PageSize, Key, Current, IsLast, Id);
                    //}
                    //else
                    //{
                    //    jsonModelNum = JsonModelNum.GetJsonModel(1000, "已超时");
                    //}
                }
                else
                {
                    bool result = Constant.Check_Login_DIP(UID, dsp);
                    if (result)
                    {
                        jsonModelNum = GetAward_Helper(PageIndex, PageSize, Key, Current, IsLast, Id);
                    }
                    else
                    {
                        jsonModelNum = JsonModelNum.GetJsonModel(1000, "已超时");
                    }
                }


            }
            catch (Exception ex)
            {
                jsonModelNum = JsonModelNum.GetJsonModel(400, ex.Message);
                LogHelper.Error(ex);
            }
            finally
            {
                //无论后端出现什么问题，都要给前端有个通知【为防止jsonModel 为空 ,全局字段 jsonModel 特意声明之后进行初始化】
                context.Response.Write("{\"result\":" + Constant.jss.Serialize(jsonModelNum) + "}");
            }
        }

        public static JsonModelNum GetAward_Helper(int pageIndex, int PageSize, string Key, bool Current, bool IsLast, int Id)
        {
            JsonModelNum jsm = null;
            try
            {
                List<Award_Public> Prize_Public_List = Constant.Award_Public_List;
                List<Globe> Globe_List = Constant.Globe_List;

                List<PrizeModel> price_list = (from prize in Prize_Public_List
                                               where Convert.ToString(prize.Name).Contains(Key)
                                               orderby prize.Id
                                               select new PrizeModel()
                                               {
                                                   Id = prize.Id,
                                                   Code = prize.Code,
                                                   Name = prize.Name,
                                                   StartTime = prize.StartTime,
                                                   CloseTime = prize.CloseTime,
                                                   EndTime = prize.EndTime,
                                                   Year = prize.Year,
                                                   IsEnable = prize.IsEnable,
                                                   GlobeList = Globe_S.GetBase(prize.PrizeContent, Globe_List),
                                                   PrizeContent = prize.PrizeContent,
                                                   IsCompleate = prize.IsCompleate,                                                   
                                               }).ToList();
                if (Id > 0)
                {
                    price_list = (from prize in price_list where prize.Id == Id select prize).ToList();
                    if (price_list.Count > 0)
                    {
                        var prize = price_list[0];
                        jsm = JsonModelNum.GetJsonModel(0, "获取成功", prize);
                    }
                    else
                    {
                        jsm = JsonModelNum.GetJsonModel(300, "无数据");
                    }
                }
                else if (Current)
                {
                    price_list = price_list.Where(item => DateTime.Now < item.CloseTime && item.StartTime < DateTime.Now).ToList();
                    if (price_list.Count > 0)
                    {
                        var prize = price_list[0];
                        DateTimeS DateTimeS = TimeTransfer((DateTime)prize.CloseTime, DateTime.Now);

                        prize.Leave_Day = DateTimeS.days;
                        prize.Leave_Hour = DateTimeS.hours;
                        prize.Leave_Minuite = DateTimeS.minutes;
                        prize.Leave_Second = DateTimeS.seconds;

                        jsm = JsonModelNum.GetJsonModel(0, "获取成功", prize);
                    }
                    else
                    {
                        jsm = JsonModelNum.GetJsonModel(300, "无数据");
                    }
                }
                else
                {
                    if (IsLast)
                    {
                        var prize_lis = price_list.Where(item => DateTime.Now > item.CloseTime).OrderByDescending(i => i.CloseTime).ToList();

                        if (prize_lis.Count > 0)
                        {
                            jsm = JsonModelNum.GetJsonModel(0, "获取成功", prize_lis[0]);
                        }
                        else
                        {
                            jsm = JsonModelNum.GetJsonModel(300, "无数据");
                        }
                    }
                    else
                    {
                        //where DateTime.Now >= prize.CloseTime || DateTime.Now <= prize.StartTime
                        price_list = (from prize in price_list select prize).OrderByDescending(i => i.CloseTime).ToList();

                        var price_list_get = price_list.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                        foreach (var item in price_list_get)
                        {
                           if(item.StartTime > DateTime.Now)
                           {
                               item.State = 1;
                           }
                            else if(item.CloseTime < DateTime.Now)
                           {
                               item.State = 3;
                           }
                           else if (item.CloseTime > DateTime.Now && item.StartTime <DateTime.Now)
                           {
                               item.State = 2;
                           }
                        }

                        if (price_list.Count > 0)
                        {
                            jsm = JsonModelNum.GetJsonModel(0, "获取成功", price_list_get);
                            jsm.PageIndex = pageIndex;
                            jsm.PageSize = PageSize;

                            jsm.PageCount = (price_list.Count + PageSize - 1) / PageSize; ; ;

                            jsm.RowCount = price_list.Count;
                        }
                        else
                        {
                            jsm = JsonModelNum.GetJsonModel(300, "无数据");
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        public static DateTimeS TimeTransfer(DateTime startDate, DateTime endDate)
        {
            DateTimeS DateTimeS = new Admin.DateTimeS();
            try
            {
                DateTime oldTime = new DateTime(1970, 1, 1);
                double diff = startDate.Subtract(endDate).TotalMilliseconds;//时间差的毫秒数  

                //计算出相差天数  
                DateTimeS.days = (int)Math.Floor(diff / (24 * 3600 * 1000));

                //计算出小时数  
                double leave1 = diff % (24 * 3600 * 1000);    //计算天数后剩余的毫秒数  
                DateTimeS.hours = (int)Math.Floor(leave1 / (3600 * 1000));
                //计算相差分钟数  
                double leave2 = leave1 % (3600 * 1000);        //计算小时数后剩余的毫秒数  
                DateTimeS.minutes = (int)Math.Floor(leave2 / (60 * 1000));

                //计算相差秒数  
                double leave3 = leave2 % (60 * 1000);      //计算分钟数后剩余的毫秒数  
                DateTimeS.seconds = (int)Math.Floor(leave3 / 1000);

                //var returnStr = seconds + "秒";
                //if (minutes > 0)
                //{
                //    returnStr = minutes + "分" + returnStr;
                //}
                //if (DateTimeS.hours > 0)
                //{
                //    returnStr = hours + "小时" + returnStr;
                //}
                //if (days > 0)
                //{
                //    returnStr = days + "天" + returnStr;
                //}
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return DateTimeS;
        }

        public class DateTimeS
        {

            public static int days { get; set; }

            public static int hours { get; set; }

            public static int seconds { get; set; }

            public static int minutes { get; set; }
        }


        #endregion

        #region 添加奖项

        public void AddAward(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;

                string CreateUID = RequestHelper.string_transfer(request, "CreateUID");
                CreateUID = string.IsNullOrEmpty(CreateUID) ? "admin" : CreateUID;
                int Year = RequestHelper.int_transfer(request, "Year");
                int Name = RequestHelper.int_transfer(request, "Name");

                DateTime StartTime = RequestHelper.DateTime_transfer(request, "StartTime");

                DateTime CloseTime = RequestHelper.DateTime_transfer(request, "CloseTime");
                DateTime EndTime = RequestHelper.DateTime_transfer(request, "EndTime");//使用默认的派奖时间 3000 -01-01
                string PrizeContent = RequestHelper.string_transfer(request, "PrizeContent");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = AddAward_Helper(CreateUID, Year, Name, PrizeContent, StartTime, EndTime, CloseTime);
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

        public static JsonModel AddAward_Helper(string CreateUID, int Year, int Name,
            string PrizeContent, DateTime StartTime, DateTime EndTime, DateTime CloseTime)
        {
            JsonModel jsm = null;
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                int prize_lastCode = Award_Public_List.Count > 0 ? Award_Public_List.Max(p => (int)p.Code) : 1;


                Award_Public award_Public = Award_Public_List.FirstOrDefault(p => p.Year == Year && p.Name == Name);
                if (award_Public == null)
                {
                    bool hasAcross = false;
                    foreach (Award_Public regu in Award_Public_List)
                    {
                        //if (StartTime <= regu.StartTime && EndTime >= regu.CloseTime)
                        //{
                        //    hasAcross = true;
                        //    break;
                        //}
                        if (StartTime >= regu.StartTime && StartTime <= regu.CloseTime)
                        {
                            hasAcross = true;
                            break;
                        }
                        //if (EndTime >= regu.StartTime && EndTime <= regu.CloseTime)
                        //{
                        //    hasAcross = true;
                        //    break;
                        //}
                    }
                    if (!hasAcross)
                    {
                        Award_Public award_Public_new = new TLC_Model.Award_Public()
                        {
                            CreateUID = CreateUID,
                            Year = Year,
                            Name = Name,
                            PrizeContent = PrizeContent,
                            Code = prize_lastCode + 1,
                            EndTime = EndTime,
                            StartTime = StartTime,
                            CloseTime = CloseTime,
                            IsCompleate = (int)IsCompleate.No,
                            CreateTime = DateTime.Now,
                            IsEnable = (int)IsEnable.Enable,
                            IsDelete = 0,


                        };
                        jsm = Constant.Award_Public_S.Add(award_Public_new);
                        if (jsm.errNum == 0)
                        {
                            award_Public_new.Id = Convert.ToInt32(jsm.retData);
                            Constant.Award_Public_List.Add(award_Public_new);
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(300, "操作失败");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "和已知的奖项时间交叉");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "该期已存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 编辑奖项

        public void EditAward(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;

                string EditUID = RequestHelper.string_transfer(request, "EditUID");
                EditUID = string.IsNullOrEmpty(EditUID) ? "admin" : EditUID;

                int Id = RequestHelper.int_transfer(request, "Id");
                int Year = RequestHelper.int_transfer(request, "Year");
                int Name = RequestHelper.int_transfer(request, "Name");

                DateTime StartTime = RequestHelper.DateTime_transfer(request, "StartTime");
                DateTime EndTime = RequestHelper.DateTime_transfer(request, "EndTime");
                DateTime CloseTime = RequestHelper.DateTime_transfer(request, "CloseTime");
                string PrizeContent = RequestHelper.string_transfer(request, "PrizeContent");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = EditAward_Helper(Id, EditUID, Year, Name, PrizeContent, StartTime, EndTime, CloseTime);
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

        public static JsonModel EditAward_Helper(int Id, string EditUID, int Year, int Name,
            string PrizeContent, DateTime StartTime, DateTime EndTime, DateTime CloseTime)
        {
            JsonModel jsm = null;
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                Award_Public award_Edit = Award_Public_List.FirstOrDefault(award => award.Id == Id);
                if (award_Edit != null)
                {
                    Award_Public award_Public = Award_Public_List.FirstOrDefault(p => p.Year == Year && p.Name == Name && p.Id != Id);
                    if (award_Public == null)
                    {
                        var Eva_Regular_Lists = (from award in Award_Public_List where award.Id != Id select award).ToList();
                        bool hasAcross = false;
                        foreach (Award_Public regu in Eva_Regular_Lists)
                        {
                            //if (StartTime <= regu.StartTime && EndTime >= regu.CloseTime)
                            //{
                            //    hasAcross = true;
                            //    break;
                            //}
                            if (StartTime >= regu.StartTime && StartTime <= regu.CloseTime)
                            {
                                hasAcross = true;
                                break;
                            }
                            //if (EndTime >= regu.StartTime && EndTime <= regu.CloseTime)
                            //{
                            //    hasAcross = true;
                            //    break;
                            //}
                        }
                        if (!hasAcross)
                        {
                            Award_Public award_Edit_clone = Constant.Clone<Award_Public>(award_Edit);
                            award_Edit_clone.EditUID = EditUID;
                            award_Edit_clone.Year = Year;
                            award_Edit_clone.Name = Name;
                            award_Edit_clone.PrizeContent = PrizeContent;
                            award_Edit_clone.EndTime = EndTime;
                            award_Edit_clone.StartTime = StartTime;
                            award_Edit_clone.CloseTime = CloseTime;
                            jsm = Constant.Award_Public_S.Update(award_Edit_clone);
                            if (jsm.errNum == 0)
                            {
                                award_Edit.EditUID = EditUID;
                                award_Edit.Year = Year;
                                award_Edit.Name = Name;
                                award_Edit.PrizeContent = PrizeContent;
                                award_Edit.EndTime = EndTime;
                                award_Edit.StartTime = StartTime;
                                award_Edit.CloseTime = CloseTime;
                                jsm = JsonModel.GetJsonModel(0, "操作成功");
                            }
                            else
                            {
                                jsm = JsonModel.GetJsonModel(300, "操作失败");
                            }
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(300, "和已知的奖项时间交叉");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "该期已存在");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "该奖项不存在");
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 派奖

        public void PayAward(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string PayUID = RequestHelper.string_transfer(request, "PayUID");
                int Code = RequestHelper.int_transfer(request, "Code");
                string PrizeContent = RequestHelper.string_transfer(request, "PrizeContent");
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = PayAward_Helper(Code, PayUID, PrizeContent);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AwardCode"></param>
        /// <param name="PayUID"></param>
        /// <returns></returns>
        public static JsonModel PayAward_Helper(int Code, string PayUID, string PrizeContent)
        {
            JsonModel jsm = null;
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                List<Operation_Record> Operation_Record_List = Constant.Operation_Record_List;
                Award_Public award_Public = Award_Public_List.FirstOrDefault(p => p.Code == Code);
                if (award_Public != null)
                {
                    List<Operation_Record> recordList = (from op in Operation_Record_List where op.AwardCode == Code select op).ToList();
                    if (award_Public.IsCompleate == (int)IsCompleate.No)
                    {
                        foreach (var record in recordList)
                        {
                            AwardDealWidth(award_Public, record, PrizeContent);
                        }
                    }
                    jsm = JsonModel.GetJsonModel(0, "派奖成功");


                    Award_Public award_Edit_clone = Constant.Clone<Award_Public>(award_Public);
                    award_Edit_clone.PrizeContent = PrizeContent;
                    award_Edit_clone.EndTime = DateTime.Now;
                    award_Edit_clone.IsCompleate = (int)IsCompleate.Yes;
                    jsm = Constant.Award_Public_S.Update(award_Edit_clone);
                    if (jsm.errNum == 0)
                    {
                        award_Public.PrizeContent = PrizeContent;
                        award_Public.EndTime = DateTime.Now;
                        award_Public.IsCompleate = (int)IsCompleate.Yes;
                        jsm = JsonModel.GetJsonModel(0, "操作成功");
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "操作失败");
                    }



                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "该期不存在");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        /// <summary>
        /// 结果处理
        /// </summary>
        /// <param name="Award_Public"></param>
        /// <param name="record"></param>
        public static void AwardDealWidth(Award_Public Award_Public, Operation_Record record, string PrizeContent)
        {
            try
            {
                List<UserInfo> UserInfo_List = Constant.UserInfo_List;
                Globe_Clue clue = Constant.Globe_Clue_List.FirstOrDefault(i => i.Code == record.ClueCode);
                decimal getMoney = 0;
                List<Araw_Return_S> Araw_Return_Ss = new List<Araw_Return_S>();
                List<string> NoAwardList = new List<string>();
                List<string> AwardList = new List<string>();

                int paytype = 0;
                if (!string.IsNullOrEmpty(PrizeContent))
                {

                    if (clue != null)
                    {
                        switch ((GlobeClueType)clue.First_Type)
                        {
                            case GlobeClueType.Special:
                                getMoney = SpecialModel.GetAward(PrizeContent, record, Constant.Globe_List, Constant.Size_Special_List, ref Araw_Return_Ss, ref NoAwardList, ref AwardList, ref paytype);
                                break;
                            case GlobeClueType.Normal:
                                getMoney = NormalModel.GetAward(PrizeContent, record, Constant.Globe_List, ref AwardList);
                                break;
                            case GlobeClueType.SpecialNormal:
                                getMoney = SpecialNormalModel.GetAward(clue, PrizeContent, record, Constant.Globe_List, Constant.Size_SpecialNormal_List, ref Araw_Return_Ss, ref NoAwardList, ref AwardList, ref paytype);
                                break;
                            case GlobeClueType.NormalSix:
                                getMoney = NormalSixModel.GetAward(PrizeContent, record, Constant.Size_Six_List, ref Araw_Return_Ss, ref NoAwardList, ref AwardList);
                                break;
                            case GlobeClueType.Line:
                                getMoney = LineModel.GetAward(clue, PrizeContent, record, ref AwardList);
                                break;
                            case GlobeClueType.Wave:
                                getMoney = WaveModel.GetAward(PrizeContent, record, Constant.Wave_List, ref Araw_Return_Ss, ref NoAwardList, ref AwardList);
                                break;
                            case GlobeClueType.Detail:
                                getMoney = Globe_ClueDetail.GetAward(PrizeContent, record, Constant.Animal_Info_List, Constant.Detail_List, ref AwardList);
                                break;
                            case GlobeClueType.SpecialAnimal:
                                getMoney = SpecialAnimalModel.GetAward(PrizeContent, record, Constant.Animal_Info_List, ref AwardList);
                                break;
                            case GlobeClueType.CombineAnimal:
                                getMoney = Globe_ClueCombineAnimal.GetAward(PrizeContent, record, Constant.Animal_Info_List, ref Araw_Return_Ss, ref NoAwardList, ref AwardList);
                                break;
                            case GlobeClueType.LineAnimal:
                                getMoney = LineAnimalModel.GetAward(clue, PrizeContent, record, Constant.Animal_Info_List, ref AwardList);
                                break;
                            case GlobeClueType.LineDetail:
                                getMoney = LineDetaillModel.GetAward(clue, PrizeContent, record, Constant.Detail_List, ref AwardList);
                                break;
                            case GlobeClueType.NotAll:
                                getMoney = NotAllModel.GetAward(PrizeContent, record);
                                break;
                            default:
                                break;
                        }
                    }
                }
                //最终完成【结束】
                Operation_Record record_Clone = Constant.Clone<Operation_Record>(record);

                if (paytype ==1)
                {
                    //返率的钱
                    record_Clone.Return_Money = (decimal)(clue.Return_Pay2 * record_Clone.Using_Money);
                }
                else
                {
                    //返率的钱
                    record_Clone.Return_Money = (decimal)(clue.Return_Pay * record_Clone.Using_Money);
                }
             
                //获奖的钱
                record_Clone.Get_Money = (decimal)getMoney;

                if (Araw_Return_Ss.Count > 0)
                {
                    #region 有和局的情况下
                    
                    //record_Clone.IsWin = (int)IsWinType.综合;
                    //record_Clone.Araw_ReturnMoney = 0;
                    //record_Clone.Araw_RetrunContent = "和局：(";
                    //for (int i = 0; i < Araw_Return_Ss.Count ; i++)
                    //{
                    //    //和局返的钱
                    //    record_Clone.Araw_ReturnMoney += Araw_Return_Ss[i].Araw_Money;
                    //    if (i != Araw_Return_Ss.Count - 1)
                    //    {
                    //        record_Clone.Araw_RetrunContent += Araw_Return_Ss[i].Name += ",";
                    //    }
                    //    else
                    //    {
                    //        record_Clone.Araw_RetrunContent += Araw_Return_Ss[i].Name += ")";
                    //    }

                    //}          
                    //if (NoAwardList.Count > 0)
                    //{
                    //    record_Clone.Araw_RetrunContent += "、不中奖：(";
                    //    for (int i = 0; i < NoAwardList.Count; i++)
                    //    {
                    //        if (i != NoAwardList.Count - 1)
                    //        {
                    //            record_Clone.Araw_RetrunContent += NoAwardList[i] += ",";
                    //        }
                    //        else
                    //        {
                    //            record_Clone.Araw_RetrunContent += NoAwardList[i] += ")";
                    //        }

                    //    }
                    //}

                    //if (AwardList.Count > 0)
                    //{
                    //    record_Clone.Araw_RetrunContent += "、中奖：(";
                    //    for (int i = 0; i < AwardList.Count; i++)
                    //    {
                    //        if (i != AwardList.Count - 1)
                    //        {
                    //            record_Clone.Araw_RetrunContent += AwardList[i] += ",";
                    //        }
                    //        else
                    //        {
                    //            record_Clone.Araw_RetrunContent += AwardList[i] += ")";
                    //        }

                    //    }
                    //}

                    #endregion
                }
                else if (record_Clone.Get_Money > 0)
                {
                    record_Clone.IsWin = (int)IsWinType.获奖;

                    if (AwardList.Count > 0)
                    {
                        record_Clone.Araw_RetrunContent += "中奖：(";
                        for (int i = 0; i < AwardList.Count; i++)
                        {
                            if (i != AwardList.Count - 1)
                            {
                                record_Clone.Araw_RetrunContent += AwardList[i] += ",";
                            }
                            else
                            {
                                record_Clone.Araw_RetrunContent += AwardList[i] += ")";
                            }

                        }
                    }
                }
                else
                {
                    record_Clone.IsWin = (int)IsWinType.未获奖;
                }

                var jsm = Constant.Operation_Record_S.Update(record_Clone);
                if (jsm.errNum == 0)
                {
                    record.Get_Money = record_Clone.Get_Money;
                    record.Return_Money = record_Clone.Return_Money;
                    record.Araw_ReturnMoney = record_Clone.Araw_ReturnMoney;
                    record.Araw_RetrunContent = record_Clone.Araw_RetrunContent;
                    record.IsWin = record_Clone.IsWin;

                    UserInfo user = UserInfo_List.FirstOrDefault(u => u.LoginName == record.UserID);
                    if (user != null)
                    {
                        UserInfo userinfo_Clone = Constant.Clone<UserInfo>(user);
                        userinfo_Clone.Money += record_Clone.Get_Money;
                        userinfo_Clone.Money += record.Araw_ReturnMoney;
                        userinfo_Clone.Money += record.Return_Money;
                        var jsm2 = Constant.UserInfo_S.Update(userinfo_Clone);
                        if (jsm2.errNum == 0)
                        {
                            user.Money += record_Clone.Get_Money;
                            user.Money += record.Araw_ReturnMoney;
                            user.Money += record.Return_Money;

                            if (record.Get_Money > 0)
                            {
                                //支出支入
                                Constant.MoneyAnsys(record, (decimal)record.Get_Money, user, MoneyType.中奖, record.Araw_RetrunContent);
                            }
                            if (record.Araw_ReturnMoney > 0)
                            {
                                //支出支入
                                //Constant.MoneyAnsys(record, (decimal)record.Araw_ReturnMoney, user, MoneyType.综合, record.Araw_RetrunContent);
                            }
                            if (record.Return_Money > 0)
                            {
                                //支出支入
                                Constant.MoneyAnsys(record, (decimal)record.Return_Money, user, MoneyType.返还奖金, "");
                            }
                        }
                        else
                        {
                            jsm = JsonModel.GetJsonModel(300, "操作失败");
                        }
                    }
                    else
                    {
                        jsm = JsonModel.GetJsonModel(300, "操作失败");
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "操作失败");
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        #endregion

        #region 获取年号

        public void GetAwardYear(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP(UID, dsp);
                if (result)
                {
                    jsonModel = GetAwardYear_Helper();
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

        public static JsonModel GetAwardYear_Helper()
        {
            JsonModel jsm = null;
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                if (Award_Public_List.Count > 0)
                {
                    var years = (from award in Award_Public_List select new { award.Year }).Distinct();
                    jsm = JsonModel.GetJsonModel(0, "操作成功", years);
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

        #region 获取期号

        public void GetAwardSection(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");


                bool result = Constant.Check_Login_DIP(UID, dsp);
                if (result)
                {
                    jsonModel = GetAwardSection_Helper();
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

        public static JsonModel GetAwardSection_Helper()
        {
            JsonModel jsm = null;
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                if (Award_Public_List.Count > 0)
                {
                    var sections = (from award in Award_Public_List select new { award.Name, award.Year }).Distinct();
                    jsm = JsonModel.GetJsonModel(0, "操作成功", sections);
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
    }
}


