using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Model.Common;

namespace TLC_Model.EntityOuter
{
    public class Detail_S
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Globe { get; set; }       
        /// <summary>
        /// 
        /// </summary>
        public Byte? IsEnable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int[] globeCodeList = new int[0];
        /// <summary>
        /// 球的Code集合
        /// </summary>
        public int[] GlobeCodeList
        {
            get { return globeCodeList; }
            set { globeCodeList = value; }
        }
        public float PayReturn { get; set; }

        public static Detail_S GetBase(Detail item, float pay)
        {
            Detail_S Size_Six_S = new Detail_S()
            {
                Id = item.Id,
                Code = item.Code,
                GlobeCodeList = Split_Hepler.str_to_ints(item.Globe),
                IsEnable = item.IsEnable,
                Name = item.Name,
                PayReturn = pay,
            };
            return Size_Six_S;
        }

        public static List<Detail_S> GetBase(string globes, List<Detail> Item_List, string pays)
        {
            List<Detail_S> list = new List<Detail_S>();

            try
            {
                if (!string.IsNullOrEmpty(globes) && !string.IsNullOrEmpty(pays))
                {
                    string[] globeArray = globes.Split(new char[] { ',' });
                    string[] payArray = pays.Split(new char[] { ',' });
                    for (int i = 0; i < globeArray.Length; i++)
                    {
                        int clue = Convert.ToInt32(globeArray[i]);
                        decimal pay = Convert.ToDecimal(payArray[i]);
                        Detail globe = Item_List.FirstOrDefault(g => g.Code == clue);
                        list.Add(Detail_S.GetBase(globe, (float)pay));
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return list;
        }

        public static string GetBase_Str(string globes, List<Detail> Item_List)
        {
            string content = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(globes))
                {
                    string[] globeArray = globes.Split(new char[] { ',' });
                    for (int i = 0; i < globeArray.Length; i++)
                    {
                        int clue = Convert.ToInt32(globeArray[i]);
                        Detail globe = Item_List.FirstOrDefault(g => g.Code == clue);
                        content += globe.Name + ",";
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return content;
        }

       
    }
}
