using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLC_Model.OutterManage
{
    public class Globe_S
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
        public string Color { get; set; }

        public float PayReturn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Byte? IsEnable { get; set; }

        public static Globe_S GetBase(Globe item, float pay)
        {
            Globe_S Globe_S = new Globe_S()
            {
                Id = item.Id,
                Code = item.Code,
                Color = item.Color,
                IsEnable = item.IsEnable,
                Name = item.Name,
                PayReturn = pay,
            };
            return Globe_S;
        }


        public static Globe_S GetBase(Globe globe)
        {
            Globe_S Globe_S = new Globe_S()
            {
                Id = globe.Id,
                Code = globe.Code,
                Color = globe.Color,
                IsEnable = globe.IsEnable,
                Name = globe.Name,
            };
            return Globe_S;
        }


        public static List<Globe_S> GetBase(string globes, List<Globe> Globe_List)
        {
            List<Globe_S> list = new List<Globe_S>();

            try
            {
                if(!string.IsNullOrEmpty(globes))
                {
                    string[] globeArray = globes.Split(new char[] { ',' });

                    for (int i = 0; i < globeArray.Length; i++)
                    {
                        int clue = Convert.ToInt32(globeArray[i]);
                        Globe globe = Globe_List.FirstOrDefault(g => g.Code == clue);
                        list.Add(Globe_S.GetBase(globe));
                    }
                }
              
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return list;
        }

        public static string GetBase_Str(string globes, List<Globe> Globe_List)
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
                        Globe globe = Globe_List.FirstOrDefault(g => g.Code == clue);
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

        public static List<Globe_S> GetBase(string globes, List<Globe> Globe_List,string pays)
        {
            List<Globe_S> list = new List<Globe_S>();

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
                        Globe globe = Globe_List.FirstOrDefault(g => g.Code == clue);
                        list.Add(Globe_S.GetBase(globe, (float)pay));
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }

            return list;
        }
    }
}
