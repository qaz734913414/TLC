using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_Normal
{
    public class NormalSixModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueNormalSix> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Size_Six> Size_Six_List)
        {
            List<Globe_ClueNormalSix> list = new List<Globe_ClueNormalSix>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.NormalSix select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueNormalSix globe_Special = Globe_ClueNormalSix.GetBase(item);
                    globe_Special.Set_SizeSix(item, Size_Six_List);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Size_Six> Size_Six_List, ref List<Araw_Return_S> Araw_Return_Ss, ref List<string> NoAwardList, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {
                //获取1-6买码对应数据
                List<Size_Six_S> Size_Six_Ss = Size_Six_S.GetBase(record.Buy_Content, Size_Six_List, record.BuyPayReturn);
                //获取开奖六位数
                List<int> contList6 = Split_Hepler.str_to_ints(PrizeContent).ToList();
                contList6.RemoveAt(contList6.Count - 1);
               
                //对应指定的码特
                int count = 1;
                foreach (var item in contList6)
                {
                    foreach (var buyItem in Size_Six_Ss.Where(i=>i.Award_Globe == count))
                    {
                        if (buyItem.GlobeCodeList.Contains(item))
                        {
                            //if (item == 49 && buyItem.IsEnable == (int)IsEnable.Enable)
                            //{
                            //    //使用和局
                            //    Araw_Return_Ss.Add(new Araw_Return_S() { Name = buyItem.Name, Araw_Money = (decimal)record.UnitPrice });
                            //}
                            //else
                            //{
                                getdecimal += (decimal)(buyItem.PayReturn * record.UnitPrice);
                                AwardList.Add(buyItem.Name);
                            //}
                           
                        }
                         else
                        {
                            NoAwardList.Add(buyItem.Name);
                        }
                    }
                    count++;
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
