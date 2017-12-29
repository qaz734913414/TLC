using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Enums;

namespace TLC_Globe_LineAnimal
{
    public class CombineAnimalModel
    {
        #region 获取

        /// <summary>
        /// 获取正码
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueCombineAnimal> Get_Globe(List<Globe_Clue> Globe_Clue_List, List<Animal_Info> Animal_Info_List, List<Globe> Globe_List)
        {
            List<Globe_ClueCombineAnimal> list = new List<Globe_ClueCombineAnimal>();
            try
            {              
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort  where g.First_Type == (int)GlobeClueType.CombineAnimal select g).ToList();

                list_s.ForEach(item =>
                {
                    Globe_ClueCombineAnimal globe_Special = Globe_ClueCombineAnimal.GetBase(item);
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
    }
}
