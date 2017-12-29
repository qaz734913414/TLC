
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TLC_Model.EntityOuter;

namespace TLC_Model.OutterManage
{
    public class Globe_ClueBase
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
        public int? Limit_Max { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Limit_Min { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? First_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Second_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string First_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Second_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte? IsEnable { get; set; }

        public decimal? Return_Pay { get; set; }

        public decimal? Return_Pay2 { get; set; }

        List<Globe_S> globe_S_List = new List<Globe_S>();
        /// <summary>
        /// 球
        /// </summary>
        public List<Globe_S> Globe_S_List
        {
            get { return globe_S_List; }
            set { globe_S_List = value; }
        }

        List<Size_NormalS> size_NormalS_List = new List<Size_NormalS>();
        /// <summary>
        /// 正码
        /// </summary>
        public List<Size_NormalS> Size_NormalS_List
        {
            get { return size_NormalS_List; }
            set { size_NormalS_List = value; }
        }

        List<Size_S> size_S_List = new List<Size_S>();
        /// <summary>
        /// 码
        /// </summary>
        public List<Size_S> Size_S_List
        {
            get { return size_S_List; }
            set { size_S_List = value; }
        }

        List<Size_Six_S> size_Six_S_List = new List<Size_Six_S>();
        /// <summary>
        /// 六系
        /// </summary>
        public List<Size_Six_S> Size_Six_S_List
        {
            get { return size_Six_S_List; }
            set { size_Six_S_List = value; }
        }

        List<Wave_S> wave_List = new List<Wave_S>();
        /// <summary>
        /// 半波
        /// </summary>
        public List<Wave_S> Wave_List
        {
            get { return wave_List; }
            set { wave_List = value; }
        }

        List<Animal_Info_S> animal_List = new List<Animal_Info_S>();
        /// <summary>
        /// 半波
        /// </summary>
        public List<Animal_Info_S> Animal_List
        {
            get { return animal_List; }
            set { animal_List = value; }
        }

        List<Detail_S> detail_List = new List<Detail_S>();
        /// <summary>
        /// 尾
        /// </summary>
        public List<Detail_S> Detail_List
        {
            get { return detail_List; }
            set { detail_List = value; }
        }

        /// <summary>
        /// 设置球个例
        /// </summary>
        public void Set_Clobe(Globe_Clue item, List<Globe> Globe_List)
        {
            try
            {
                string[] globe_clues = item.Clue.Split(new char[] { ',' });
                string[] globe_pays = item.Pay.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Globe globe = Globe_List.FirstOrDefault(g => g.Code == clue);
                    if (globe != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Globe_S Globe_S = Globe_S.GetBase(globe, pay);
                        this.Globe_S_List.Add(Globe_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 设置特码个例
        /// </summary>
        public void Set_Size(Globe_Clue item, List<Size_Special> Size_Special_List)
        {
            try
            {
                string[] globe_clues2 = item.Clue2.Split(new char[] { ',' });
                string[] globe_pays2 = item.Pay2.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues2.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues2[i]);
                    float pay = float.Parse(globe_pays2[i]);

                    Size_Special size_Special = Size_Special_List.FirstOrDefault(g => g.Code == clue);
                    if (size_Special != null)
                    {
                        Size_S Size_S = Size_S.GetBase(size_Special, pay);
                        this.Size_S_List.Add(Size_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }


        /// <summary>
        /// 设置正码个例
        /// </summary>
        public void Set_SizeNormal(Globe_Clue item, List<Size_SpecialNormal> Size_SpecialNormal_List)
        {
            try
            {
                string[] globe_clues2 = item.Clue2.Split(new char[] { ',' });
                string[] globe_pays2 = item.Pay2.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues2.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues2[i]);
                    float pay = float.Parse(globe_pays2[i]);

                    Size_SpecialNormal size_Special = Size_SpecialNormal_List.FirstOrDefault(g => g.Code == clue);
                    if (size_Special != null)
                    {
                        Size_NormalS Size_NormalS = Size_NormalS.GetBase(size_Special, pay);
                        this.Size_NormalS_List.Add(Size_NormalS);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 设置6系
        /// </summary>
        public void Set_SizeSix(Globe_Clue item, List<Size_Six> Size_Six_List)
        {
            try
            {
                string[] globe_clues = item.Clue.Split(new char[] { ',' });
                string[] globe_pays = item.Pay.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Size_Six Size_Six = Size_Six_List.FirstOrDefault(g => g.Code == clue);
                    if (Size_Six != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Size_Six_S Size_Six_S = Size_Six_S.GetBase(Size_Six, pay);
                        this.Size_Six_S_List.Add(Size_Six_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }


        /// <summary>
        /// 设置半波
        /// </summary>
        public void Set_Wave(Globe_Clue item, List<Wave> Wave_List, List<Globe> GlobeList)
        {
            try
            {
                string[] globe_clues = item.Clue.Split(new char[] { ',' });
                string[] globe_pays = item.Pay.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Wave wave = Wave_List.FirstOrDefault(g => g.Code == clue);
                    if (wave != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Wave_S Wave_S = Wave_S.GetBase(wave, pay);

                        List<Globe_S> templist = new List<Globe_S>();
                        foreach (var code in Wave_S.GlobeCodeList)
                        {
                            Globe globle = GlobeList.FirstOrDefault(c => c.Code == code);
                            if (globle != null)
                            {
                                Globe_S globle_s = Globe_S.GetBase(globle);
                                templist.Add(globle_s);
                            }
                           
                        }
                        Wave_S.GlobeList = templist.ToArray();
                        this.Wave_List.Add(Wave_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 设置尾数
        /// </summary>
        public void Set_Detail(Globe_Clue item, List<Detail> Detail_List)
        {
            try
            {
                string[] globe_clues = item.Clue2.Split(new char[] { ',' });
                string[] globe_pays = item.Pay2.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Detail Detail = Detail_List.FirstOrDefault(g => g.Code == clue);
                    if (Detail != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Detail_S Detail_S = Detail_S.GetBase(Detail, pay);
                        this.Detail_List.Add(Detail_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 设置尾数
        /// </summary>
        public void Set_DetailF(Globe_Clue item, List<Detail> Detail_List)
        {
            try
            {
                string[] globe_clues = item.Clue.Split(new char[] { ',' });
                string[] globe_pays = item.Pay.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Detail Detail = Detail_List.FirstOrDefault(g => g.Code == clue);
                    if (Detail != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Detail_S Detail_S = Detail_S.GetBase(Detail, pay);
                        this.Detail_List.Add(Detail_S);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 设置生肖
        /// </summary>
        public void Set_Animal(Globe_Clue item, List<Animal_Info> Animal_Info_List ,List<Globe> GlobeList)
        {
            try
            {
                string[] globe_clues = item.Clue.Split(new char[] { ',' });
                string[] globe_pays = item.Pay.Split(new char[] { ',' });
                for (int i = 0; i < globe_clues.Length; i++)
                {
                    int clue = Convert.ToInt32(globe_clues[i]);
                    Animal_Info animal_Info = Animal_Info_List.FirstOrDefault(g => g.Code == clue);
                    if (animal_Info != null)
                    {
                        float pay = float.Parse(globe_pays[i]);
                        Animal_Info_S Animal_InfoS = Animal_Info_S.GetBase(animal_Info, pay);

                        List<Globe_S> templist = new List<Globe_S>();
                        foreach (var code in Animal_InfoS.GlobeCodeList)
                        {
                            Globe globle = GlobeList.FirstOrDefault(c => c.Code == code);
                            if (globle != null)
                            {
                                Globe_S globle_s = Globe_S.GetBase(globle);
                                templist.Add(globle_s);
                            }

                        }
                        Animal_InfoS.GlobeList = templist.ToArray();
                        this.Animal_List.Add(Animal_InfoS);
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex);
            }
        }

       
    }



}