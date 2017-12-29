using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLC_Model.Common;

namespace TLC_Model.OutterManage
{
    public class Size_NormalS
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
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



        public float? PayReturn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte? IsEnable { get; set; }


        public static Size_NormalS GetBase(Size_SpecialNormal item, float pay)
        {
            Size_NormalS Size_S = new Size_NormalS()
            {
                Id = item.Id,
                Code = item.Code,
                GlobeCodeList = Split_Hepler.str_to_ints(item.Globe),
                IsEnable = item.IsEnable,
                Name = item.Name,
                PayReturn = pay,
            };
            return Size_S;
        }

        public static List<Size_NormalS> GetBase(string globes, List<Size_SpecialNormal> Item_List, string pays)
        {
            List<Size_NormalS> list = new List<Size_NormalS>();

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
                        Size_SpecialNormal globe = Item_List.FirstOrDefault(g => g.Code == clue);
                        list.Add(Size_NormalS.GetBase(globe, (float)pay));
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return list;
        }

        public static string GetBase_Str(string globes, List<Size_SpecialNormal> Item_List)
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
                        Size_SpecialNormal globe = Item_List.FirstOrDefault(g => g.Code == clue);
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
