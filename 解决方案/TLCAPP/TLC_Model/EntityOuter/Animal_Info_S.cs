using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Model.Common;
using TLC_Model.OutterManage;

namespace TLC_Model.EntityOuter
{
    public class Animal_Info_S
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
        public string Globe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Operation_Year { get; set; }       
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

        /// <summary>
        /// 
        /// </summary>
        Globe_S[] globeList = new Globe_S[0];
        /// <summary>
        /// 球的Code集合
        /// </summary>
        public Globe_S[] GlobeList
        {
            get { return globeList; }
            set { globeList = value; }
        }

        public float PayReturn { get; set; }
        public static Animal_Info_S GetBase(Animal_Info item, float pay)
        {
            Animal_Info_S Animal_InfoS = new Animal_Info_S()
            {
                Id = item.Id,
                Code = item.Code,
                GlobeCodeList = Split_Hepler.str_to_ints(item.Globe),
                IsEnable = item.IsEnable,
                Name = item.Name,
                PayReturn = pay,
            };
            return Animal_InfoS;
        }

        public static List<Animal_Info_S> GetBase(string globes, List<Animal_Info> Item_List, string pays)
        {
            List<Animal_Info_S> list = new List<Animal_Info_S>();

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
                        Animal_Info globe = Item_List.FirstOrDefault(g => g.Code == clue);
                        list.Add(Animal_Info_S.GetBase(globe, (float)pay));
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return list;
        }

        public static string GetBase_Str(string globes, List<Animal_Info> Item_List)
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
                        Animal_Info globe = Item_List.FirstOrDefault(g => g.Code == clue);
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
