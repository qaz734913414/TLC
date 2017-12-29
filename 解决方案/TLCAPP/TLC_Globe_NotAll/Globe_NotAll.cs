using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Model;
using TLC_Model.OutterManage;

namespace TLC_Globe_NotAll
{
    public class Globe_NotAll : Globe_ClueBase
    {             
        #region 静态方法

        public static Globe_NotAll GetBase(Globe_Clue item)
        {
            Globe_NotAll model = null;
            try
            {
                model = new Globe_NotAll()
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
    }
}
