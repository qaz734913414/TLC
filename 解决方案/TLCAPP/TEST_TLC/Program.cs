using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLC_Handler;
using TLC_Handler.Admin;
using TLC_Handler.Client;
using TLC_Handler.Globe_Manage;
using TLC_Model.Common;
using TLC_Model.Common.DES;

namespace TEST_TLC
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p = 6 / 5;
            //var p1 = 1 % 5;
            //var p2 = 2 % 5;
            //var p3 = 3 % 5;
            //var p4 = 4 % 5;

            var pc = Admin.PayAward_Helper(9, "lilin", "1,7,13,36,25,8,49");

            //var dfs = Admin.GetAward_Helper(0, 0, "", true, false);


            //List<string> lst = new List<string> { "a", "b", "c", "d", "e" };

            //foreach (var comb in Combinations(lst, 0, 5, 3))
            //{
            //    string r = new string(comb.Take(3).ToArray());
            //    Console.WriteLine(r);
            //}
            //Console.ReadLine();

            //var se = OperationManage.GroupHelper(lst,3);

            //string password = "123456";
            //var salt = Utils.GetCheckCode(6);

            //以随机生成的6位字符串做为密钥加密
            //var ps = DESEncrypt.Encrypt(password, salt);sinptech777

            //var ss = DESEncrypt.Decrypt("7B878AF28F1A208B", "ZRJ820");


            //var jsm = Admin.PayAward_Helper(4, "admin", "4,12,15,1,2,22,24");

           //var re = Constant.UserInfo_List;
           //var re1 = Constant.Globe_Clue_List;
           //var re2 = Constant.Globe_List;
           //var re3 = Constant.Award_Public_List;
           //var re4 = Constant.Animal_Info_List;
           //var re5 = Constant.Detail_List;
           //var re6 = Constant.MoneyLog_List;
           //var re7 = Constant.Size_Six_List;
           //var re8 = Constant.Operation_Record_List;
           //var re9 = Constant.Size_SpecialNormal_List;
           //var re11 = Constant.Size_Special_List;
        }

        public static IEnumerable<List<char>> Combinations(List<char> sq, int i0, int n, int c)  
        {
            if (c == 0) yield return sq;
            else
            {
                for (int i = 0; i < n; i++)
                {
                    foreach (var perm in Combinations
                        (sq, i0 + 1, n - 1 - i, c - 1))
                        yield return perm;
                    RL(sq, i0, n);
                }
            }
        }

        private static void RL(List<char> sq, int i0, int n)
        {
            char tmp = sq[i0];
            sq.RemoveAt(i0);
            sq.Insert(i0 + n - 1, tmp);
        }



        #region test

        public static void ss()
        {
            //var list = SpecialModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List, Constant.Size_SpecialNormal_List);//获取
            //var list2 = NormalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取
            //var list3 = SpecialNormalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List, Constant.Size_Special_List);//获取

            //var list4 = NormalSixModel.Get_Globe(Constant.Globe_Clue_List,Constant.Size_Six_List );//获取
            //var list5 = LineModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取
            //var list6 = WaveModel.Get_Globe(Constant.Globe_Clue_List, Constant.Wave_List, Constant.Globe_List);//获取

            //var list7 = DetailModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List, Constant.Detail_List);//获取

            //var list8 = SpecialAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
            //var list9 = CombineAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
            //var list10 = LineAnimalModel.Get_Globe(Constant.Globe_Clue_List, Constant.Animal_Info_List, Constant.Globe_List);//获取
            //var list11 = LineDetaillModel.Get_Globe(Constant.Globe_Clue_List,  Constant.Globe_List, Constant.Detail_List);//获取
            //var list12 = NotAllModel.Get_Globe(Constant.Globe_Clue_List, Constant.Globe_List);//获取


            //Admin.AddUser_Helper("admin", "admin", "123456", "超级管理员", (decimal)500.45);
            //var ss = DESEncrypt.Decrypt("2C63E8F7F9990A09", "6Z86X0");

            //var js = Admin.Login_Helper("admin", "123456");

            //var js = Admin.GetUserInfo_Helper();


        }

        #endregion


        #region 正码1-6

        public static void LLL()
        {
            StringBuilder bulder = new StringBuilder();
            bulder.Append(Environment.NewLine);
            bulder.Append(Environment.NewLine);

            var pc = "1.91";

            for (int i = 1; i < 79; i++)
            {
                if (i <= 24)
                {
                    pc = "1.95";
                }
                else if (i > 24 && i <= 30)
                {
                    pc = "2.65";
                }
                else if (i > 30 && i <= 36)
                {
                    pc = "2.75";
                }
                else if (i > 36 && i <= 42)
                {
                    pc = "2.75";
                }
                else if (i > 42)
                {
                    pc = "1.95";
                }

                bulder.Append(i + ",");
            }
            var str = bulder.ToString();
            str = str.Trim(',');


            File.AppendAllText(@"C:\Users\Administrator\Desktop\tmp.txt", str);
        }

        #endregion

        #region 正码大小

        public static void Size_Six()
        {
            StringBuilder bulder = new StringBuilder();
            bulder.Append(Environment.NewLine);
            bulder.Append(Environment.NewLine);
            for (int i = 1; i < 50; i++)
            {
                #region 单双

                //if (i % 2 != 0)
                //{
                //    bulder.Append(i +",");
                //}

                #endregion

                #region 大小

                //if (i >= 25)
                //{
                //    bulder.Append(i + ",");
                //}

                #endregion

                #region 颜色

                //if (i == 5 || i - 6 == 5 || i - 6 * 2 == 5 || i - 6 * 3 == 5 || i - 6 * 4 == 5 || i - 6 * 5 == 5 || i - 6 * 6 == 5 || i - 6 * 7 == 5 || i - 6 * 8 == 5)
                //{
                //    bulder.Append(i + ",");
                //}
                //if (i == 6 || i - 6 == 6 || i - 6 * 2 == 6 || i - 6 * 3 == 6 || i - 6 * 4 == 6 || i - 6 * 5 == 6 || i - 6 * 6 == 6 || i - 6 * 7 == 6 || i - 6 * 8 == 6)
                //{
                //    bulder.Append(i + ",");
                //}

                #endregion

                #region 合单

                //if (i < 10)
                //{
                //    if (i % 2 == 0)
                //    {
                //        bulder.Append(i + ",");
                //    }
                //}
                //else
                //{
                //    var data = Convert.ToString(i);
                //    int da = Convert.ToInt32( data[0]) +  Convert.ToInt32(data[1]);
                //    if (da % 2 == 0)
                //    {
                //        bulder.Append(i + ",");
                //    }

                //}

                #endregion

                #region 尾数大小

                //if (i < 10)
                //{
                //    if (i <5)
                //    {
                //        bulder.Append(i + ",");
                //    }
                //}
                //else
                //{
                //    string data = Convert.ToString(i);
                //    string ddd =Convert.ToString( data[1]);
                //    int da = Convert.ToInt32(ddd);
                //    if (da  < 5)
                //    {
                //        bulder.Append(i + ",");
                //    }

                //}

                #endregion

            }
            var str = bulder.ToString();
            str = str.Trim(',');


            File.AppendAllText(@"C:\Users\Administrator\Desktop\tmp.txt", str);
        }

        #endregion

        #region 规则

        public static void Clue_globe()
        {
            StringBuilder bulder = new StringBuilder();
            bulder.Append(Environment.NewLine);
            bulder.Append(Environment.NewLine);
            for (int i = 1; i < 50; i++)
            {
                //bulder.Append(i + ",");
                bulder.Append("1.81" + ",");
            }
            var str = bulder.ToString();
            str = str.Trim(',');


            File.AppendAllText(@"C:\Users\Administrator\Desktop\tmp.txt", str);
        }

        #endregion

        #region 半波


        public static void wave()
        {
            //蓝合双 5.30

            //15 31 37 4 20 26 42 48
            string str = "5.61 5.06 6.51 4.51 5.61 6.51 5.61 6.61 5.61 5.61 5.06 6.51 5.61 5.30 5.30 5.30 5.30 5.30";
            str = str.Replace(" ", ",");

            //Constant.Wave_S.Add(new TLC_Model.Wave() { Code = 18, Name = "蓝合双", Globe = str });


            File.AppendAllText(@"C:\Users\Administrator\Desktop\tmp.txt", str);
        }

        #endregion

        #region 球的code同步

        public static void syncGlobe()
        {
            foreach (var item in Constant.Globe_List)
            {
                item.Name = Convert.ToString(item.Code);
                Constant.Globe_S.Update(item);
            }
        }

        #endregion

        #region 设置生肖

        /// <summary>
        /// 设置生肖
        /// </summary>
        /// <returns></returns>
        public static void SetAnimal()
        {
            var dic = AnimalSetting.GetAnimal();

            int number = 1;
            foreach (var item in dic)
            {
                Constant.Animal_Info_S.Add(new TLC_Model.Animal_Info() { Code = number, Name = item.Key, Globe = item.Value.Trim(','), Operation_Year = DateTime.Now.Year });
                number++;
            }
        }

        #endregion

        #region 连尾

        public static void Detail()
        {
            //bool result = false;
            //DateTime dt = default(DateTime);
            //while (result == false)
            //{
            //    dt = NetTime.GetBeijingTime(ref result);
            //}

            StringBuilder bulder = new StringBuilder();
            bulder.Append(Environment.NewLine);
            bulder.Append(Environment.NewLine);
            for (int i = 1; i < 11; i++)
            {
                //bulder.Append(i + ",");
                bulder.Append("1.81" + ",");
            }
            var str = bulder.ToString();
            str = str.Trim(',');


            File.AppendAllText(@"C:\Users\Administrator\Desktop\tmp.txt", str);


        }

        #endregion

        #region 球色

        public static void fill()
        {
            for (int i = 1; i < 50; i++)
            {
                string color = "";
                if (i == 1 || i - 6 == 1 || i - 6 * 2 == 1 || i - 6 * 3 == 1 || i - 6 * 4 == 1 || i - 6 * 5 == 1 || i - 6 * 6 == 1 || i - 6 * 7 == 1 || i - 6 * 8 == 1)
                {
                    color = "red";
                }
                if (i == 2 || i - 6 == 2 || i - 6 * 2 == 2 || i - 6 * 3 == 2 || i - 6 * 4 == 2 || i - 6 * 5 == 2 || i - 6 * 6 == 2 || i - 6 * 7 == 2 || i - 6 * 8 == 2)
                {
                    color = "red";
                }


                if (i == 3 || i - 6 == 3 || i - 6 * 2 == 3 || i - 6 * 3 == 3 || i - 6 * 4 == 3 || i - 6 * 5 == 3 || i - 6 * 6 == 3 || i - 6 * 7 == 3 || i - 6 * 8 == 3)
                {
                    color = "blue";
                }
                if (i == 4 || i - 6 == 4 || i - 6 * 2 == 4 || i - 6 * 3 == 4 || i - 6 * 4 == 4 || i - 6 * 5 == 4 || i - 6 * 6 == 4 || i - 6 * 7 == 4 || i - 6 * 8 == 4)
                {
                    color = "blue";
                }

                if (i == 5 || i - 6 == 5 || i - 6 * 2 == 5 || i - 6 * 3 == 5 || i - 6 * 4 == 5 || i - 6 * 5 == 5 || i - 6 * 6 == 5 || i - 6 * 7 == 5 || i - 6 * 8 == 5)
                {
                    color = "green";
                }
                if (i == 6 || i - 6 == 6 || i - 6 * 2 == 6 || i - 6 * 3 == 6 || i - 6 * 4 == 6 || i - 6 * 5 == 6 || i - 6 * 6 == 6 || i - 6 * 7 == 6 || i - 6 * 8 == 6)
                {
                    color = "green";
                }

                Constant.Globe_S.Add(new TLC_Model.Globe() { Code = i, Color = color, IsDelete = 0, IsEnable = 0, CreateTime = DateTime.Now, CreateUID = "admin" });
            }
        }

        #endregion
    }
}
