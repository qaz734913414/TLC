using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_Line
{
    public class LineModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueLine> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Globe> Globe_List)
        {
            List<Globe_ClueLine> list = new List<Globe_ClueLine>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.Line select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueLine globe_Special = Globe_ClueLine.GetBase(item);
                    globe_Special.Set_Clobe(item, Globe_List);
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

        public static decimal GetAward(Globe_Clue Globe_Clue, string PrizeContent, Operation_Record record, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            string awardCollect = string.Empty;
            try
            {             
                List<int> contList6 = Split_Hepler.str_to_ints(PrizeContent).ToList();
                contList6.RemoveAt(contList6.Count - 1);

                List<int> buyList = Split_Hepler.str_to_ints(record.Buy_Content).ToList();

                var cont7 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[6] : "0";
                //特奖
                int conti7 = Convert.ToInt32(cont7);

                int count = 0;
                LineType LineType = (LineType)Globe_Clue.Second_Type;
                if (LineType == LineType.三全中)
                {
                    foreach (var wawardClobe in contList6)
                    {
                        if (buyList.Contains(wawardClobe))
                        {
                            count++;
                            awardCollect += Convert.ToString(wawardClobe) + ",";
                        }
                    }
                    if (count >= 3)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(Convert.ToString(awardCollect));
                    }
                }
                else if (LineType == LineType.二全中 || LineType == LineType.三中二之中二)
                {
                    foreach (var wawardClobe in contList6)
                    {
                        if (buyList.Contains(wawardClobe))
                        {
                            count++;
                            awardCollect += Convert.ToString(wawardClobe) + ",";
                        }
                    }
                    if (count >= 2)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(Convert.ToString(awardCollect));
                    }
                }
                else if (LineType == LineType.二中特之中二)
                {
                    foreach (var wawardClobe in contList6)
                    {
                        if (buyList.Contains(wawardClobe))
                        {
                            count++;
                            awardCollect += Convert.ToString(wawardClobe) + ",";
                        }
                    }                    
                    if (count >= 2)
                    {
                        getdecimal += (decimal)(record.MaxPayReturn * record.UnitPrice);
                        AwardList.Add(Convert.ToString(awardCollect));
                    }
                }
                else if (LineType == TLC_Model.Enums.LineType.二中特之中特 || LineType == TLC_Model.Enums.LineType.特串)
                {
                    foreach (var wawardClobe in contList6)
                    {
                        if (buyList.Contains(wawardClobe))
                        {
                            count++;
                            awardCollect += Convert.ToString(wawardClobe) + ",";
                            break;
                        }
                    }
                    if (buyList.Contains(conti7))
                    {
                        count++;
                        awardCollect += Convert.ToString(conti7) + ",";
                    }
                    if (count >= 2)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(Convert.ToString(awardCollect));
                    }
                }
                else if(LineType == TLC_Model.Enums.LineType.四中一)
                {
                    foreach (var wawardClobe in contList6)
                    {
                        if (buyList.Contains(wawardClobe))
                        {
                            count++;
                            awardCollect += Convert.ToString(wawardClobe) + ",";
                            break;
                        }
                    }                   
                    if (count >= 1)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(Convert.ToString(awardCollect));
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
