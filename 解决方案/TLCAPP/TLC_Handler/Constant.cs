using TLC_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_BLL;

using System.Data;
using System.Web.Script.Serialization;
using System.Timers;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

using System.Configuration;
using TLC_Model.Common;
using System.Reflection;
using TLC_Model.Enums;
using TLC_Model.EntityOuter;
using TLC_Handler.Client;


namespace TLC_Handler
{
    public static class Constant
    {
        #region 字段

        /// <summary>
        /// 授权码
        /// </summary>
        public static Dictionary<string, string> dicLogin_dsp = new Dictionary<string, string>();

        /// <summary>
        /// 是否开启测试模式
        /// </summary>
        public static bool IsTestMode = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsTestMode"]);

        /// <summary>
        /// 批量导入时是否覆盖原有客户地址
        /// </summary>
        public static bool IsInput_CoverAddress = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsInput_CoverAddress"]);

        /// <summary>
        /// 分钟之内不能重复签到同一客户 以分钟为单位
        /// </summary>
        public static int SignLimitTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SignLimitTime"]);

         /// <summary>
        /// 时间差
        /// </summary>
        public static int TimerDistance = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TimerDistance"]);
        

        /// <summary>
        /// js辅助
        /// </summary>
        public static JavaScriptSerializer jss = new JavaScriptSerializer();

        //全局参数
        public static BLLCommon common = new BLLCommon();


        public static UserInfoService UserInfo_S = new UserInfoService();
        static List<UserInfo> userInfo_List;
        /// <summary>
        /// 用户信息
        /// </summary>
        public static List<UserInfo> UserInfo_List
        {
            get
            {
                if (userInfo_List == null)
                {

                    userInfo_List = ConverList<UserInfo>.ConvertToList("UserInfo");
                }
                return userInfo_List;

            }
            set { userInfo_List = value; }
        }

        public static Award_PublicService Award_Public_S = new Award_PublicService();
        static List<Award_Public> award_Public_List;
        /// <summary>
        /// 历史奖项
        /// </summary>
        public static List<Award_Public> Award_Public_List
        {
            get
            {
                if (award_Public_List == null)
                {

                    award_Public_List = ConverList<Award_Public>.ConvertToList("Award_Public");
                }
                return award_Public_List;

            }
            set { award_Public_List = value; }
        }



        public static GlobeService Globe_S = new GlobeService();
        static List<Globe> globe_List;
        /// <summary>
        /// 彩球
        /// </summary>
        public static List<Globe> Globe_List
        {
            get
            {
                if (globe_List == null)
                {
                    globe_List = ConverList<Globe>.ConvertToList("Globe");
                }
                return globe_List;

            }
            set { globe_List = value; }
        }

        public static Globe_ClueService Globe_Clue_S = new Globe_ClueService();
        static List<Globe_Clue> globe_clue_List;
        /// <summary>
        /// 六合彩规则
        /// </summary>
        public static List<Globe_Clue> Globe_Clue_List
        {
            get
            {
                if (globe_clue_List == null)
                {
                    globe_clue_List = ConverList<Globe_Clue>.ConvertToList("Globe_Clue");
                }
                return globe_clue_List;

            }
            set { globe_clue_List = value; }
        }

        public static Operation_RecordService Operation_Record_S = new Operation_RecordService();
        static List<Operation_Record> operation_Record_List;
        /// <summary>
        /// 操作记录
        /// </summary>
        public static List<Operation_Record> Operation_Record_List
        {
            get
            {
                if (operation_Record_List == null)
                {
                    operation_Record_List = ConverList<Operation_Record>.ConvertToList("Operation_Record");
                }
                return operation_Record_List;

            }
            set { operation_Record_List = value; }
        }

        public static DetailService Detail_S = new DetailService();
        static List<Detail> detail_List;
        /// <summary>
        /// 尾数
        /// </summary>
        public static List<Detail> Detail_List
        {
            get
            {
                if (detail_List == null)
                {
                    detail_List = ConverList<Detail>.ConvertToList("Detail");
                }
                return detail_List;

            }
            set { detail_List = value; }
        }

        public static Animal_InfoService Animal_Info_S = new Animal_InfoService();
        static List<Animal_Info> animal_Info_List;
        /// <summary>
        /// 尾数
        /// </summary>
        public static List<Animal_Info> Animal_Info_List
        {
            get
            {
                if (animal_Info_List == null)
                {
                    animal_Info_List = ConverList<Animal_Info>.ConvertToList("Animal_Info");
                }
                return animal_Info_List;

            }
            set { animal_Info_List = value; }
        }

        public static Size_SpecialService Size_Special_S = new Size_SpecialService();
        static List<Size_Special> size_Special_List;
        /// <summary>
        /// 特码用
        /// </summary>
        public static List<Size_Special> Size_Special_List
        {
            get
            {
                if (size_Special_List == null)
                {
                    size_Special_List = ConverList<Size_Special>.ConvertToList("Size_Special");
                }
                return size_Special_List;

            }
            set { size_Special_List = value; }
        }
        public static Size_SpecialNormalService Size_SpecialNormal_S = new Size_SpecialNormalService();
        static List<Size_SpecialNormal> size_SpecialNormal_List;
        /// <summary>
        /// 正码用
        /// </summary>
        public static List<Size_SpecialNormal> Size_SpecialNormal_List
        {
            get
            {
                if (size_SpecialNormal_List == null)
                {
                    size_SpecialNormal_List = ConverList<Size_SpecialNormal>.ConvertToList("Size_SpecialNormal");
                }
                return size_SpecialNormal_List;

            }
            set { size_SpecialNormal_List = value; }
        }

        public static Size_SixService Size_Six_S = new Size_SixService();
        static List<Size_Six> size_Six_List;
        /// <summary>
        /// 六系
        /// </summary>
        public static List<Size_Six> Size_Six_List
        {
            get
            {
                if (size_Six_List == null)
                {
                    size_Six_List = ConverList<Size_Six>.ConvertToList("Size_Six");
                }
                return size_Six_List;

            }
            set { size_Six_List = value; }
        }


        public static WaveService Wave_S = new WaveService();
        static List<Wave> wave_List;
        /// <summary>
        /// 半波
        /// </summary>
        public static List<Wave> Wave_List
        {
            get
            {
                if (wave_List == null)
                {
                    wave_List = ConverList<Wave>.ConvertToList("Wave");
                }
                return wave_List;

            }
            set { wave_List = value; }
        }

        public static MoneyLogService MoneyLog_S = new MoneyLogService();
        static List<MoneyLog> moneyLog_List;
        /// <summary>
        /// 半波
        /// </summary>
        public static List<MoneyLog> MoneyLog_List
        {
            get
            {
                if (moneyLog_List == null)
                {
                    moneyLog_List = ConverList<MoneyLog>.ConvertToList("MoneyLog");
                }
                return moneyLog_List;

            }
            set { moneyLog_List = value; }
        }

        #endregion

        #region 辅助函数

        /// <summary>
        /// 页转HT
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="request"></param>
        public static void SizeToHT(Hashtable ht, HttpRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request["PageIndex"]))
            {
                ht.Add("PageIndex", Convert.ToString(request["PageIndex"]));
            }
            if (!string.IsNullOrWhiteSpace(request["PageSize"]))
            {
                ht.Add("PageSize", Convert.ToString(request["PageSize"]));
            }
        }

        #endregion

        #region 异常处理（返回数据包）

        public static JsonModel ErrorGetData(Exception ex)
        {
            JsonModel jsonModel = new JsonModel()
            {
                errMsg = ex.Message,
                retData = "",
                status = "no"
            };

            return jsonModel;
        }

        public static JsonModel ErrorGetData(string ex)
        {
            JsonModel jsonModel = new JsonModel()
            {
                errMsg = ex,
                retData = "",
                status = "no"
            };

            return jsonModel;
        }

        #endregion

        #region 定时释放垃圾

        static System.Timers.Timer Glob_Timer = null;

        /// <summary>
        /// 释放用不上的缓存（计算机运算时产生的缓存垃圾）【不包含从数据库去除的缓存数据】
        /// </summary>
        public static void Dispose_All()
        {
            if (Glob_Timer == null)
            {
                //Timer_Setup();

                Glob_Timer = new System.Timers.Timer();
                Glob_Timer.Interval = 1000 * 60 * 10;
                Glob_Timer.Elapsed += (object sender, ElapsedEventArgs e) =>
                {
                    GC_Helper();
                };
            }
        }

        public static void GC_Helper()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #endregion

        #region 时间进行同步【和垃圾定时器初始化时】

        /// <summary>
        /// 时间进行同步【和垃圾定时器初始化时】
        /// </summary>
        public static void Timer_Setup()
        {
            try
            {
                //bool result = false;
                //DateTime dt = default(DateTime);
                //while (result == false)
                //{
                //    dt = NetTime.GetBeijingTime(ref result);
                //}


                //UpdateTime.SetDate(dt);

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// JSON格式字符转换为T类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T ParseFormByJson<T>(string jsonStr)
        {
            T obj = Activator.CreateInstance<T>();
            using (System.IO.MemoryStream ms =
            new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonStr)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Json转换成List集合，返回对象List
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="jsonString">反序列化字符串</param>
        /// <returns>反序列化后的值</returns>
        public static List<T> JsonToList<T>(string jsonString)
        {
            return ParseFormByJson<List<T>>(jsonString);
        }

        /// <summary>
        ///页面数据回调
        /// </summary>
        /// <param name="errNum"></param>
        /// <param name="errMsg"></param>
        /// <param name="retData"></param>
        /// <returns></returns>
        public static JsonModel get_jsonmodel(int errNum, string errMsg, object retData)
        {
            return new JsonModel()
            {
                errNum = errNum,
                errMsg = errMsg,
                retData = retData,
            };
        }

        /// <summary>
        ///页面数据回调
        /// </summary>
        /// <param name="errNum"></param>
        /// <param name="errMsg"></param>
        /// <param name="retData"></param>
        /// <returns></returns>
        public static JsonModel get_jsonmodel(int errNum, string errMsg, object retData, string status)
        {
            return new JsonModel()
            {
                errNum = errNum,
                errMsg = errMsg,
                retData = retData,
                status = status
            };
        }

        #endregion

        #region 判断是否同一个星期


        /// <summary>   
        /// 判断两个日期是否在同一周   
        /// </summary>   
        /// <param name="dtmS">开始日期</param>   
        /// <param name="dtmE">结束日期</param>  
        /// <returns></returns>   
        public static bool IsInSameWeek(DateTime dtmS, DateTime dtmE)
        {
            bool result = false;
            int s1 = (int)dtmS.DayOfWeek;
            if (s1 == 0)
            {
                s1 = 7;
            }
            int s2 = (int)dtmE.DayOfWeek;
            if (s2 == 0)
            {
                s2 = 7;
            }
            DateTime temp1 = dtmS.AddDays(-s1).Date;
            DateTime temp2 = dtmE.AddDays(-s2).Date;
            if (temp1 == temp2)
            {
                result = true;
            }
            return result;
        }

        #endregion

        #region 使用反射进行数据的克隆

        /// <summary>
        /// 使用反射进行数据的克隆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Clone<T>(T data)
        {
            //定义默认类型对象
            T obj = default(T);
            try
            {
                //获取对象的类型
                Type type = typeof(T);
                //获取该类的属性集
                PropertyInfo[] propertyInfos = type.GetProperties();
                //创建实例
                obj = Activator.CreateInstance<T>();

                //遍历属性值
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    //获取当前属性的名称
                    string propertyInfoName = propertyInfo.Name;
                    var value = propertyInfo.GetValue(data);
                    try
                    {
                        //给该字段设置值
                        propertyInfo.SetValue(obj, value, null);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return obj;
        }

        #endregion

        #region 授权码设置

        public static void Set_Login_DIP(string UID, string dsp)
        {
            try
            {
                if (!dicLogin_dsp.ContainsKey(UID))
                {
                    dicLogin_dsp.Add(UID, dsp);
                }
                else
                {
                    dicLogin_dsp[UID] = dsp;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        #endregion

        #region 授权码移除

        public static bool Remove_Login_DIP(string UID)
        {
            bool result = false;
            try
            {
                if (dicLogin_dsp.ContainsKey(UID))
                {
                    dicLogin_dsp.Remove(UID);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return result;
        }

        #endregion

        #region 授权码验证

        public static bool Check_Login_DIP(string UID, string dsp)
        {
            bool result = false;
            try
            {
                if (dicLogin_dsp.ContainsKey(UID))
                {
                    if (dicLogin_dsp[UID] == dsp)
                    {
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return result;
        }

        static List<string> adminUserinList = new List<string>();
        public static bool Check_Login_DIP_Admin(string UID, string dsp)
        {
            bool result = false;
            try
            {
                if (dicLogin_dsp.ContainsKey(UID))
                {
                    if (dicLogin_dsp[UID] == dsp)
                    {
                        if (adminUserinList.Contains(UID))
                        {
                            result = true;
                        }
                        else
                        {
                            List<UserInfo> userinfs = Constant.UserInfo_List;
                            UserInfo userin = userinfs.FirstOrDefault(u => u.LoginName == UID && u.Role == (int)RoleType.Admin);

                            if (userin != null)
                            {
                                result = true;
                                adminUserinList.Add(userin.LoginName);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return result;
        }

        #endregion


        #region 定时奖项填充

       static bool IsSyncTimer = false;

       public static void SyncTimer()
        {
            //if (!IsSyncTimer)
            //{
            //    Timer_Setup();
            //    IsSyncTimer = true;
            //}
        }


        #endregion

        #region 支出支入统计

        public static void MoneyAnsys(Operation_Record Operation_Record
            , decimal Using_Money, UserInfo userInfo, MoneyType MoneyType, string Araw_RetrunContent)
        {
            try
            {
                List<Award_Public> Award_Public_List = Constant.Award_Public_List;
                List<Operation_Record> Operation_Record_List = Constant.Operation_Record_List;
                List<Globe_Clue> Globe_Clue_List = Constant.Globe_Clue_List;
                List<UserInfo> UserInfo_List = Constant.userInfo_List;
                List<Globe> Globe_List = Constant.Globe_List;
                List<MoneyLog> MoneyLog_List = Constant.MoneyLog_List;

                MoneyLog MoneyLog = MoneyLog = new MoneyLog()
                {
                    UserID = userInfo.LoginName,
                    UserName = userInfo.Name,
                    O_Money = Using_Money,
                    CreateTime = DateTime.Now,
                    OperationType = (int)MoneyType,
                    CreateUID = userInfo.LoginName,
                    IsDelete = 0,
                    IsEnable = (int)IsEnable.Enable,

                };
                if (MoneyType == TLC_Model.Enums.MoneyType.充值)
                {
                    MoneyLog.Type = (int)MoneyLogType.Add;
                    MoneyLog.O_Content = "操作内容：" + "充值" + ";金额：" + Using_Money;
                }
                else if (MoneyType == TLC_Model.Enums.MoneyType.提现)
                {

                    MoneyLog.Type = (int)MoneyLogType.Reduce;
                    MoneyLog.O_Content = "操作内容：" + "提现" + ";金额：" + Using_Money;
                }
                else
                {
                    //为了做支出支入做统计
                    Globe_Clue clue = Globe_Clue_List.FirstOrDefault(i => i.Code == Operation_Record.ClueCode);
                    Award_Public Award_Public = Award_Public_List.FirstOrDefault(i => i.Code == Operation_Record.AwardCode);
                    Operation_Record_S os = OperationManage.Get_Operation_Record_S(Operation_Record, Award_Public, clue, userInfo, Globe_List);
                    OperationManage.SetContent(clue, os);
                    switch (MoneyType)
                    {
                        case MoneyType.下注:
                            MoneyLog.Type = (int)MoneyLogType.Reduce;
                            MoneyLog.O_Content = "操作内容：" + "下注->" + "年号->" + Award_Public.Year + "期号->" + Award_Public.Name + clue.First_Name + "->" +
                       clue.Second_Name + "->下注内容(" + os.BuyDisplay + os.BuyDisplay2 + ")->下注单价(" + Operation_Record.UnitPrice + ")" + ";金额：" + Using_Money;
                            break;
                        case MoneyType.返还奖金:
                            MoneyLog.Type = (int)MoneyLogType.Add;
                            MoneyLog.O_Content = "操作内容：" + "返水->" + "年号->" + Award_Public.Year + "期号->" + Award_Public.Name + clue.First_Name + "->" +
                      clue.Second_Name + "->下注内容(" + os.BuyDisplay + os.BuyDisplay2 + ")->下注单价(" + Operation_Record.UnitPrice + ")" + ";金额：" + Using_Money;
                            break;
                        case MoneyType.中奖:
                            MoneyLog.Type = (int)MoneyLogType.Add;
                            MoneyLog.O_Content = "操作内容：" + "中奖->" + "年号->" + Award_Public.Year + "期号->" + Award_Public.Name + clue.First_Name + "->" +
                      clue.Second_Name + "->下注内容(" + os.BuyDisplay + os.BuyDisplay2 + ")->下注单价(" + Operation_Record.UnitPrice + ")" + ")->派奖内容【" + Araw_RetrunContent + "】" + ";金额：" + Using_Money;
                            break;
                        case MoneyType.综合:
                            MoneyLog.Type = (int)MoneyLogType.Add;
                            MoneyLog.O_Content = "操作内容：" + "和局->" + "年号->" + Award_Public.Year + "期号->" + Award_Public.Name + clue.First_Name + "->" +
                      clue.Second_Name + "->下注内容(" + os.BuyDisplay + os.BuyDisplay2 + ")->下注单价(" + Operation_Record.UnitPrice + ")" + ")->派奖内容【" + Araw_RetrunContent + "】" + ";金额：" + Using_Money;
                            break;
                        case MoneyType.充值:

                        default:
                            break;
                    }
                }
                var jsm = Constant.MoneyLog_S.Add(MoneyLog);
                if (jsm.errNum == 0)
                {
                    MoneyLog.Id = Convert.ToInt32(jsm.retData);
                    MoneyLog_List.Add(MoneyLog);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        #endregion
    }
}