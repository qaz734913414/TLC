using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_NotAll
{
    public class NotAllModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_NotAll> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Globe> Globe_List)
        {
            List<Globe_NotAll> list = new List<Globe_NotAll>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.NotAll select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_NotAll globe_Special = Globe_NotAll.GetBase(item);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record)
        {
            decimal getdecimal = 0;
            try
            {
                List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();

                List<int> contListall = Split_Hepler.str_to_ints(PrizeContent).ToList();
                int count = 0;

                foreach (var content in contents)
                {
                    if (!contListall.Contains(content))
                    {
                        count++;
                    }
                }
                if (count >= contents.Count)
                {
                    getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
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
