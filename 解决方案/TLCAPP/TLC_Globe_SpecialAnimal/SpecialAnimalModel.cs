using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;

namespace TLC_Globe_SpecialAnimal
{
    public class SpecialAnimalModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueSpecialAnimal> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Animal_Info> Animal_Info_List, List<Globe> Globe_List)
        {
            List<Globe_ClueSpecialAnimal> list = new List<Globe_ClueSpecialAnimal>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.SpecialAnimal select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueSpecialAnimal globe_ClueSpecialAnimal = Globe_ClueSpecialAnimal.GetBase(item);
                    globe_ClueSpecialAnimal.Set_Animal(item, Animal_Info_List, Globe_List);                 
                    list.Add(globe_ClueSpecialAnimal);
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Animal_Info> Animal_Info_List, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {
                List<Animal_Info_S> Detail_Ss = Animal_Info_S.GetBase(record.Buy_Content, Animal_Info_List, record.BuyPayReturn);
                var cont7 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[6] : "0";
                //特奖
                int conti7 = Convert.ToInt32(cont7);
                foreach (var item in Detail_Ss)
                {
                    if (item.GlobeCodeList.Contains(conti7))
                    {
                        getdecimal += (decimal)(item.PayReturn * record.UnitPrice);
                        AwardList.Add(item.Name);
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
