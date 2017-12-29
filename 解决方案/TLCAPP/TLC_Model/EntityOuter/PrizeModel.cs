using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC_Model.EntityOuter
{
    public class PrizeModel
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
        public int? Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PrizeContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime { get; set; }

        public int? Leave_Day { get; set; }

        public int? Leave_Minuite { get; set; }

        public int? Leave_Second { get; set; }

        public List<TLC_Model.OutterManage.Globe_S> GlobeList { get; set; }

        public int? Leave_Hour { get; set; }

        public byte? IsEnable { get; set; }

        public byte? IsCompleate { get; set; }

        /// <summary>
        /// 1  未开始  2 进行中  3已封盘
        /// </summary>
        public int State { get; set; }
        
    }
}
