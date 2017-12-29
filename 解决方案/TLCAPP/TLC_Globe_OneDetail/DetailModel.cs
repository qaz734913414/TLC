using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model;
using TLC_Model.Enums;

namespace TLC_Globe_LineDetail
{
    public class DetailModel
    {
        #region 获取

        /// <summary>
        /// 获取尾数
        /// </summary>
        /// <param name="Globe_Clue_List">原始特码集合</param>
        /// <param name="Globe_List">彩球集合</param>
        /// <param name="Size_Special_List">各码集合</param>
        /// <returns></returns>
        public static List<Globe_ClueDetail> Get_Globe(List<Globe_Clue> Globe_Clue_List,List<Animal_Info> Animal_Info_List, List<Globe> Globe_List,List<Detail> Detail_List)
        {
            List<Globe_ClueDetail> list = new List<Globe_ClueDetail>();
            try
            {
                List<Globe_Clue> list_s = (from g in Globe_Clue_List orderby g.Sort where g.First_Type == (int)GlobeClueType.Detail select g).ToList();
                list_s.ForEach(item =>
                {
                    Globe_ClueDetail globe_Special = Globe_ClueDetail.GetBase(item);                   
                    globe_Special.Set_Animal(item, Animal_Info_List, Globe_List);
                    globe_Special.Set_Detail(item, Detail_List);
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
