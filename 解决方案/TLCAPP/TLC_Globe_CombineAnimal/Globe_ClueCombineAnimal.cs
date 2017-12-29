using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.OutterManage;

namespace TLC_Globe_LineAnimal
{
    public class Globe_ClueCombineAnimal : Globe_ClueBase
    {
        #region 静态方法

        public static Globe_ClueCombineAnimal GetBase(Globe_Clue item)
        {
            Globe_ClueCombineAnimal model = null;
            try
            {
                model = new Globe_ClueCombineAnimal()
                {
                    Id = item.Id,
                    Code = item.Code,
                    First_Name = item.First_Name,
                    First_Type = item.First_Type,
                    Limit_Max = item.Limit_Max,
                    Limit_Min = item.Limit_Min,
                    IsEnable = item.IsEnable,
                    Second_Name = item.Second_Name,
                    Second_Type = item.Second_Type,
                    Return_Pay = Convert.ToDecimal(item.Return_Pay),
                    Return_Pay2 = Convert.ToDecimal(item.Return_Pay2),
                };
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
            return model;
        }

        #endregion

        #region 派奖

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Animal_Info> Animal_Info_List, ref List<Araw_Return_S> Araw_Return_Ss, ref List<string> NoAwardList, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {
                List<Animal_Info_S> Animal_Info_Ss = Animal_Info_S.GetBase(record.Buy_Content, Animal_Info_List, record.BuyPayReturn);
                var cont7 = PrizeContent.Length >= 7 ? Split_Hepler.str_to_stringss(PrizeContent)[6] : "0";
                //特奖
                int conti7 = Convert.ToInt32(cont7);

                List<int> contents = Split_Hepler.str_to_ints(record.Buy_Content).ToList();
                foreach (var content in contents)
                {
                    Animal_Info_S detail_S = Animal_Info_Ss.FirstOrDefault(i => i.Code == content);
                    if (detail_S != null && detail_S.GlobeCodeList.Contains(conti7))
                    {
                        //if (conti7 == 49)
                        //{
                        //    //使用和局
                        //    Araw_Return_Ss.Add(new Araw_Return_S() { Name = detail_S.Name, Araw_Money = (decimal)record.UnitPrice });
                        //}
                        //else
                        //{
                            getdecimal += (decimal)(detail_S.PayReturn * record.UnitPrice);
                            AwardList.Add(detail_S.Name);
                        //}

                    }
                    else
                    {
                        NoAwardList.Add(detail_S.Name);
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
