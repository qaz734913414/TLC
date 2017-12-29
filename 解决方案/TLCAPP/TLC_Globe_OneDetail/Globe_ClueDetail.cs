using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Model;
using TLC_Model.Common;
using TLC_Model.EntityOuter;
using TLC_Model.OutterManage;

namespace TLC_Globe_LineDetail
{
    public class Globe_ClueDetail : Globe_ClueBase
    {
        #region 静态方法

        public static Globe_ClueDetail GetBase(Globe_Clue item)
        {
            Globe_ClueDetail model = null;
            try
            {
                model = new Globe_ClueDetail()
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

        public static decimal GetAward(string PrizeContent, Operation_Record record, List<Animal_Info> Animal_Info_List, List<Detail> Detail_List, ref List<string> AwardList)
        {
            decimal getdecimal = 0;
            try
            {


                List<Animal_Info_S> Animal_Info_Ss = Animal_Info_S.GetBase(record.Buy_Content, Animal_Info_List, record.BuyPayReturn);
                List<Detail_S> Detail_Ss = Detail_S.GetBase(record.Buy_Content2, Detail_List, record.BuyPayReturn2);


                var contList7 = Split_Hepler.str_to_ints(PrizeContent).ToList();

                foreach (var content in Animal_Info_Ss)
                {
                    foreach (var item in contList7)
                    {
                        //Animal_Info_S animal_Info_S = Animal_Info_Ss.FirstOrDefault(i => i.Code == content);
                        if (content.GlobeCodeList.Contains(item))
                        {
                            getdecimal += (decimal)(content.PayReturn * record.UnitPrice);
                            AwardList.Add(content.Name);
                            break;
                        }
                    }
                }


                foreach (var content in Detail_Ss)
                {
                    foreach (var item in contList7)
                    {
                        //Detail_S detail_S = Detail_Ss.FirstOrDefault(i => i.Code == content);
                        if (content.GlobeCodeList.Contains(item))
                        {
                            getdecimal += (decimal)(content.PayReturn * record.UnitPrice);
                            AwardList.Add(content.Name);
                            break;
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
