using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLC_Model.EntityOuter
{
    public class Operation_Record_S
    {
        public int Id { get; set; }

        public int AwardCode { get; set; }

        public int ClueCode { get; set; }

        public string Buy_Content { get; set; }

        public string Buy_Content2 { get; set; }

        public string BuyPayReturn { get; set; }

        public string BuyPayReturn2 { get; set; }

        public int UnitPrice { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime Operation_Time { get; set; }

        public int IsWin { get; set; }

        public string UserID { get; set; }


        public decimal Get_Money { get; set; }

        public decimal Using_Money { get; set; }

        public decimal Araw_ReturnMoney { get; set; }

        public decimal Win_Money { get; set; }

        public decimal Return_Money { get; set; }

        public string PrizeContent { get; set; }

        public string First_Name { get; set; }

        public string Second_Name { get; set; }

        public string user_Name { get; set; }

        public List<TLC_Model.OutterManage.Globe_S> GlobeList { get; set; }

        public int? Year { get; set; }

        public int? award_Name { get; set; }

        public string BuyDisplay { get; set; }

        public string BuyDisplay2 { get; set; }

        public bool FirstIsGloble { get; set; }

        public List<TLC_Model.OutterManage.Globe_S> FirstGlobeList { get; set; }

        public bool SecondIsGloble { get; set; }

        public string Araw_RetrunContent { get; set; }

        public bool IsShowMin { get; set; }
        public bool IsShowMax { get; set; }

        public decimal MinPayReturn { get; set; }
    }
}
