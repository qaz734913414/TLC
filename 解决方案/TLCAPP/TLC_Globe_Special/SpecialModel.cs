
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;


namespace TLC_Globe_Special
{
    public class SpecialModel
    {
        #region 获取

        /// <summary>
        /// 获取特码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueSpecial> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Globe> Globe_List, List<Size_Special> Size_Special_List)
        {
            List<Globe_ClueSpecial> list = new List<Globe_ClueSpecial>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.Special select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueSpecial globe_Special = Globe_ClueSpecial.GetBase(item);
                    globe_Special.Set_Clobe(item, Globe_List);
                    globe_Special.Set_Size(item, Size_Special_List);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Globe> Globe_List, List<Size_Special> Size_Special_List, ref List<Araw_Return_S> Araw_Return_Ss, ref List<string> NoAwardList, ref List<string> AwardList, ref int paytype)
        {
            decimal getdecimal = 0;
            try
            {

                List<Globe_S> globes = Globe_S.GetBase(record.Buy_Content, Globe_List, record.BuyPayReturn);
                List<Size_S> Size_Ss = Size_S.GetBase(record.Buy_Content2, Size_Special_List, record.BuyPayReturn2);

                var cont7 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[6] : "0";
                //特奖
                int conti7 = Convert.ToInt32(cont7);


                if (!string.IsNullOrEmpty(record.Buy_Content))
                {
                    paytype = 0;
                    List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();
                    if (contents.Contains(conti7))
                    {
                        Globe_S globe_ss = globes.FirstOrDefault(i => i.Code == conti7);
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
                        Size_S size_S = Size_Ss.FirstOrDefault(i => i.Code == buycontent);
                        if (size_S.GlobeCodeList.Contains(conti7))
                        {

                            //if (conti7 == 49 && size_S.IsEnable == (int)IsEnable.Enable)
                            //{
                            //    //使用和局
                            //    Araw_Return_Ss.Add(new Araw_Return_S() { Name = size_S.Name, Araw_Money = (decimal)record.UnitPrice });
                            //}
                            //else
                            //{
                                getdecimal += (decimal)(size_S.PayReturn * record.UnitPrice);
                                AwardList.Add(size_S.Name);
                            //}
                        }
                        else
                        {
                            NoAwardList.Add(size_S.Name);
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
