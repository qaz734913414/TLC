using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.Enums;
using TLC_Model.OutterManage;

namespace TLC_Globe_LineAnimal
{
    public class LineAnimalModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueLineAnimal> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Animal_Info> Animal_Info_List, List<Globe> Globe_List)
        {
            List<Globe_ClueLineAnimal> list = new List<Globe_ClueLineAnimal>();
            try
            {
                Animal_Info_List = (from animal in Animal_Info_List orderby animal.Code select animal).ToList();
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Code where g.First_Type == (int)GlobeClueType.LineAnimal select g).ToList();

                list_s.ForEach(item =>
                {
                    Globe_ClueLineAnimal globe_Special = Globe_ClueLineAnimal.GetBase(item);
                    globe_Special.Set_Animal(item, Animal_Info_List, Globe_List);
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

        public static decimal GetAward(Globe_Clue Globe_Clue, string PrizeContent, Operation_Record record, List<Animal_Info> Animal_Info_List, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            string animals = string.Empty;
            try
            {
                List<Animal_Info_S> Animal_Info_Ss = Animal_Info_S.GetBase(record.Buy_Content, Animal_Info_List, record.BuyPayReturn);

                List<int> contListall = Split_Hepler.str_to_ints(PrizeContent).ToList();

                int count = 0;
                LineAnimalType LineType = (LineAnimalType)Globe_Clue.Second_Type;
                if (LineType == LineAnimalType.二肖连中 || LineType == LineAnimalType.三肖连中 || LineType == LineAnimalType.四肖连中
                    || LineType == LineAnimalType.五肖连中)
                {
                    foreach (var animal in Animal_Info_Ss)
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
                    if (count >= Animal_Info_Ss.Count)
                    {
                        getdecimal += (decimal)(record.MinPayReturn * record.UnitPrice);
                        AwardList.Add(animals);
                    }
                }
                else if (LineType == LineAnimalType.二肖连不中 || LineType == LineAnimalType.三肖连不中 || LineType == LineAnimalType.四肖连不中)
                {
                    foreach (var animal in Animal_Info_Ss)
                    {
                        bool NoAdd = false;
                        foreach (var awardGlobe in contListall)
                        {
                            if (animal.GlobeCodeList.Contains(awardGlobe))
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
                    if (count >= Animal_Info_Ss.Count)
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
