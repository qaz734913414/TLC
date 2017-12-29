using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;

namespace TLC_Globe_LineDetail
{
    public class LineDetaillModel
    {
        #region 获取

        /// <summary>
        /// 获取尾数
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueLineDetail> Get_Globe(List<Globe_Clue> Globe_Clue_List,  List<Globe> Globe_List, List<Detail> Detail_List)
        {
            List<Globe_ClueLineDetail> list = new List<Globe_ClueLineDetail>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.LineDetail select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueLineDetail globe_Special = Globe_ClueLineDetail.GetBase(item);
                    globe_Special.Set_DetailF(item, Detail_List);
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

        public static decimal GetAward(Globe_Clue Globe_Clue, string PrizeContent, Operation_Record record, List<Detail> Detail_List, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            string animals = string.Empty;
            try
            {
                List<Detail_S> Detail_Ss = Detail_S.GetBase(record.Buy_Content, Detail_List, record.BuyPayReturn);

                List<int> contListall = Split_Hepler.str_to_ints(PrizeContent).ToList();

                int count = 0;
                LineDetailType LineType = (LineDetailType)Globe_Clue.Second_Type;
                if (LineType == LineDetailType.二尾连中 || LineType == LineDetailType.三尾连中 || LineType == LineDetailType.四尾连中)
                  
                {
                    foreach (var animal in Detail_Ss)
                    {
                        foreach (var awardGlobe in contListall)
                        {
                            if (animal.GlobeCodeList.Contains(awardGlobe))
                            {
                                count++;
                                animals += animal.Name + ",";
                                break;
                            }
                        }
                    }
                    if (count >= Detail_Ss.Count)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(animals);
                    }
                }
                else if (LineType == LineDetailType.二尾连不中 || LineType ==  LineDetailType.三尾连不中 || LineType ==  LineDetailType.四尾连不中)
                {
                    foreach (var animal in Detail_Ss)
                    {
                        bool NoAdd = false;
                        foreach (var awardGlobe in contListall)
                        {
                            if (!animal.GlobeCodeList.Contains(awardGlobe))
                            {
                                NoAdd = true;
                                break;
                            }
                        }
                        if (!NoAdd)
                        {
                            count++;
                        }
                    }
                    if (count >= Detail_Ss.Count)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
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
