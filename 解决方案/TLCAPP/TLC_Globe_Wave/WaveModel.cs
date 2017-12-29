using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;

namespace TLC_Globe_Wave
{
    public class WaveModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueWave> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Wave> Wave_List, List<Globe> GlobeList)
        {
            List<Globe_ClueWave> list = new List<Globe_ClueWave>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.Wave select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueWave globe_ClueWave = Globe_ClueWave.GetBase(item);
                    globe_ClueWave.Set_Wave(item, Wave_List, GlobeList);
                    list.Add(globe_ClueWave);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Wave> Wave_List, ref List<Araw_Return_S> Araw_Return_Ss, ref List<string> NoAwardList, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {

                List<Wave_S> Wave_Ss = Wave_S.GetBase(record.Buy_Content, Wave_List, record.BuyPayReturn);
                string cont7 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[6] : "0";
                //特奖
                int conti7 = Convert.ToInt32(cont7);

                List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();
                foreach (var wav_select in contents)
                {
                    Wave_S wave_S = Wave_Ss.FirstOrDefault(i => i.Code == wav_select);
                    if (wave_S != null)
                    {
                        if (wave_S.GlobeCodeList.Contains(conti7))
                        {
                            //if (conti7 == 49)
                            //{
                            //    //使用和局
                            //    Araw_Return_Ss.Add(new Araw_Return_S() { Name = wave_S.Name, Araw_Money = (decimal)record.UnitPrice });
                            //}
                            //else
                            //{
                                getdecimal += (decimal)(wave_S.PayReturn * record.UnitPrice);
                                AwardList.Add(wave_S.Name);
                            //}

                        }
                        else
                        {
                            NoAwardList.Add(wave_S.Name);
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
