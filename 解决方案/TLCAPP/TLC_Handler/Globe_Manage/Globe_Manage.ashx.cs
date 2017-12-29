using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLC_Globe_Special;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Enums;
using TLC_Globe_LineAnimal;
using TLC_Globe_LineDetail;
using TLC_Globe_Normal;
using TLC_Globe_SpecialAnimal;
using TLC_Globe_SpecialNormal;
using TLC_Handler;
using TLC_Globe_NotAll;
using TLC_Globe_Line;
using TLC_Globe_Wave;

namespace TLC_Handler.Globe_Manage
{
    /// <summary>
    /// Globe 的摘要说明
    /// </summary>
    public class Globe_Manage : IHttpHandler
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
                    case "Get_Globe": Get_Globe(context); break;
                    case "Globe_PaySetting": Globe_PaySetting(context); break;

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

        #region 获取各码

        public void Get_Globe(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string Type = RequestHelper.string_transfer(request, "Type");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP(UID, dsp);//获取各码
                //if (result)
                //{
                   
                //}
                //else
                //{
                //    jsonModel = JsonModel.GetJsonModel(1000, "已超时");
                //}
                jsonModel = Get_Globe_Helper(Type);

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

        public static JsonModel Get_Globe_Helper(string Type)
        {
            JsonModel jsm = null;
            try
            {
                GlobeClueType GlobeClueType = (GlobeClueType)Enum.Parse(typeof(GlobeClueType), Type);
                object Globe_ClueBase = null;//获取                                          
                switch (GlobeClueType)
                {
                    case GlobeClueType.Special:
                        Globe_ClueBase = SpecialModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List, Constant.Size_Special_List);
                        break;
                    case GlobeClueType.Normal:
                        Globe_ClueBase = NormalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.SpecialNormal:
                        Globe_ClueBase = SpecialNormalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List, Constant.Size_SpecialNormal_List);//获取
                        break;
                    case GlobeClueType.NormalSix:
                        Globe_ClueBase = NormalSixModel.Get_Globe(Constant.Globe_Clue_List, Constant.Size_Six_List);//获取
                        break;
                    case GlobeClueType.Line:
                        Globe_ClueBase = LineModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.Wave:
                        Globe_ClueBase = WaveModel.Get_Globe(Constant.Globe_Clue_List, Constant.Wave_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.Detail:
                        Globe_ClueBase = DetailModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List, Constant.Detail_List);//获取
                        break;
                    case GlobeClueType.SpecialAnimal:
                        Globe_ClueBase = SpecialAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.CombineAnimal:
                        Globe_ClueBase = CombineAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.LineAnimal:
                        Globe_ClueBase = LineAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
                        break;
                    case GlobeClueType.LineDetail:
                        Globe_ClueBase = LineDetaillModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List, Constant.Detail_List);//获取               
                        break;
                    case GlobeClueType.NotAll:
                        Globe_ClueBase = NotAllModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取
                        break;
                    default:
                        break;
                }
                jsm = JsonModel.GetJsonModel(0, "successed", Globe_ClueBase);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return jsm;
        }

        #endregion

        #region 设置赔率

        public void Globe_PaySetting(HttpContext context)
        {
            try
            {
                HttpRequest request = context.Request;
                string Code = RequestHelper.string_transfer(request, "Code");
                string Pay1 = RequestHelper.string_transfer(request, "Pay1");
                string Pay2 = RequestHelper.string_transfer(request, "Pay2");
                decimal Return_Pay = RequestHelper.decimal_transfer(request, "Return_Pay");
                decimal Return_Pay2 = RequestHelper.decimal_transfer(request, "Return_Pay2");

                string UID = RequestHelper.string_transfer(request, "UID");
                string dsp = RequestHelper.string_transfer(request, "dsp");
                bool result = Constant.Check_Login_DIP_Admin(UID, dsp);
                if (result)
                {
                    jsonModel = Globe_PaySetting_Helper(Code, Pay1, Pay2, Return_Pay, Return_Pay2);
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
        /// 设置辅助
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="pay1"></param>
        /// <param name="pay2"></param>
        /// <returns></returns>
        public static JsonModel Globe_PaySetting_Helper(string Code, string pay1, string pay2, decimal Return_Pay, decimal Return_Pay2)
        {
            JsonModel jsm = null;
            try
            {
                //GlobeClueType GlobeClueType = (GlobeClueType)Enum.Parse(typeof(GlobeClueType), Type);
                Globe_Clue globe_Clue = Constant.Globe_Clue_List.FirstOrDefault(i => Convert.ToString(i.Code) == Code);
                if (globe_Clue != null)
                {
                    Globe_Clue globe_clue_clone = Constant.Clone<Globe_Clue>(globe_Clue);
                    globe_clue_clone.Pay = pay1;
                    globe_clue_clone.Pay2 = pay2;
                    globe_clue_clone.Return_Pay = Return_Pay;
                    globe_clue_clone.Return_Pay2 = Return_Pay2;
                    jsm = Constant.Globe_Clue_S.Update(globe_clue_clone);
                    if (jsm.errNum == 0)
                    {
                        globe_Clue.Pay = pay1;
                        globe_Clue.Pay2 = pay2;
                        globe_Clue.Return_Pay = Return_Pay;
                        globe_Clue.Return_Pay2 = Return_Pay2;
                    }
                }
                else
                {
                    jsm = JsonModel.GetJsonModel(300, "successed", "该规则不存在");
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