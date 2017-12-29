using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TLC_Handler.Outer
{
    public class Specital_Globle_Model
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Clue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Clue2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pay2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Limit_Max { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Limit_Min { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int First_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Second_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string First_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Second_Name { get; set; }
       
    }

    public class Globle_Model
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
    }
}