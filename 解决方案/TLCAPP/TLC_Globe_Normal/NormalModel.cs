using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_Normal
{
    public class NormalModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueNormal> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Globe> Globe_List)
        {
            List<Globe_ClueNormal> list = new List<Globe_ClueNormal>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.Normal select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueNormal globe_Special = Globe_ClueNormal.GetBase(item);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Globe> Globe_List, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {

                List<Globe_S> globes = Globe_S.GetBase(record.Buy_Content, Globe_List, record.BuyPayReturn);

                var contList6 = Split_Hepler.str_to_ints(PrizeContent).ToList();
                contList6.RemoveAt(contList6.Count - 1);
                List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();
                foreach (var item in contList6)
                {                   
                    if (contents.Contains(item))
                    {
                        Globe_S globe_ss = globes.FirstOrDefault(i => i.Code == item);
                        if (globe_ss != null)
                        {
                            getdecimal += (decimal)(globe_ss.PayReturn * record.UnitPrice);
                            AwardList.Add(globe_ss.Name);
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
