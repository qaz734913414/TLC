using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_SpecialNormal
{
    public class SpecialNormalModel
    {
        #region 获取

        /// <summary>
        /// 获取正码特
        /// </summary>
        /// <param name="Globe_Clue_List">原始规则集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueSpecialNormal> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Globe> Globe_List, List<Size_SpecialNormal> Size_SpecialNormal_List)
        {
            List<Globe_ClueSpecialNormal> list = new List<Globe_ClueSpecialNormal>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.SpecialNormal select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueSpecialNormal globe_Special = Globe_ClueSpecialNormal.GetBase(item);
                    globe_Special.Set_Clobe(item, Globe_List);
                    globe_Special.Set_SizeNormal(item, Size_SpecialNormal_List);
                    list.Add(globe_Special);
                });

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return list;
        }

        #endregion

        #region 派奖

        public static decimal GetAward(Globe_Clue clue, string PrizeContent, Operation_Record record, List<Globe> Globe_List, List<Size_SpecialNormal> Size_Special_List, ref List<Araw_Return_S> Araw_Return_Ss, ref List<string> NoAwardList, ref List<string> AwardList,ref int paytype)
        {
            decimal getdecimal = 0;
            try
            {

                List<Globe_S> globes = Globe_S.GetBase(record.Buy_Content, Globe_List, record.BuyPayReturn);
                List<Size_NormalS> Size_Normals = Size_NormalS.GetBase(record.Buy_Content2, Size_Special_List, record.BuyPayReturn2);
                var cont1_6 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[(int)clue.Second_Type - 1] : "0";
                //特奖
                int conti1_6 = Convert.ToInt32(cont1_6);

                if (!string.IsNullOrEmpty(record.Buy_Content))
                {
                    paytype = 0;
                    List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();
                    if (contents.Contains(conti1_6))
                    {
                        Globe_S globe_ss = globes.FirstOrDefault(i => i.Code == conti1_6);
                        if (globe_ss != null)
                        {
                            getdecimal += (decimal)(globe_ss.PayReturn * record.UnitPrice);
                            AwardList.Add(globe_ss.Name);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(record.Buy_Content2))
                {
                    paytype = 1;
                    List<int> contents2 = Split_Hepler.str_to_ints(record.Buy_Content2).ToList();
                    foreach (var buycontent in contents2)
                    {
                        Size_NormalS size_NormalS = Size_Normals.FirstOrDefault(i => i.Code == buycontent);
                        if (size_NormalS.GlobeCodeList.Contains(conti1_6))
                        {
                            //if (conti1_6 == 49 && size_NormalS.IsEnable == (int)IsEnable.Enable)
                            //{
                            //    //使用和局
                            //    Araw_Return_Ss.Add(new Araw_Return_S() { Name = size_NormalS.Name, Araw_Money = (decimal)record.UnitPrice });
                            //}
                            //else
                            //{
                                getdecimal += (decimal)(size_NormalS.PayReturn * record.UnitPrice);
                                AwardList.Add(size_NormalS.Name);
                            //}

                        }
                        else
                        {
                            NoAwardList.Add(size_NormalS.Name);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            return getdecimal;
        }

        #endregion
    }
}
