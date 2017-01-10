using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 数组操作类
    /// </summary>
    public class ZRadomDataArrayCls
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit">随机数组范围0-limit</param>
        public ZRadomDataArrayCls(int min,int max,int limit)
        {
            this.IniArrayLimit = max - min;
            this.RadomArrayLimit = limit < IniArrayLimit ? limit : IniArrayLimit;
        }


        #region 初始化
        /// <summary>
        /// 初始化长度为百万的数组
        /// </summary>
        public string InitMillionArray()
        {
            IniArray = new int[IniArrayLimit];
            int c = IniArrayLimit;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < c; i++)
            {
                IniArray[i] = i;
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "初始化" + IniArrayLimit + "长度数组耗费" + runSpan.ToString() + "毫秒";
        }

        public string InitMillionList()
        {
            IniList = new List<int>();
            int c = IniArrayLimit;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < c; i++)
            {
                IniList.Add(i);
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "初始化" + IniArrayLimit + "长度列表耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 初始化随机列表
        /// </summary>
        private void IniRadomList()
        {
            if (RadomList != null)
            {
                RadomList.Clear();
            }
            else
            {
                RadomList = new List<int>();
            }
        }

        /// <summary>
        /// 初始化随机数组
        /// </summary>
        private void IniRadomArray()
        {
            if (RadomArray != null)
            {
                RadomArray.Initialize();
            }
            else
            {
                RadomArray = new int[RadomArrayLimit];
            }
        }
        #endregion

        #region 属性与字段
        public int IniArrayLimit { get;private set; }

        /// <summary>
        /// 随机数最大值
        /// </summary>
        public int RadomArrayLimit { get; private set; }

        /// <summary>
        /// 初始数组
        /// </summary>
        public int[] IniArray { get; private set; }

        /// <summary>
        /// 初始列表
        /// </summary>
        public List<int> IniList { get; private set; }

        /// <summary>
        /// 随机数组
        /// </summary>
        public int[] RadomArray { get; private set; }

        /// <summary>
        /// 随机列表
        /// </summary>
        public List<int> RadomList { get; private set; }

        #endregion

        #region 几种获取随机不重复数组/列表的接口
        /// <summary>
        /// 数据存储在列表中，随机定位初始列表，取出数据添加到随机列表。初始列表删除定位数据.执行完成后RadomList即为随机列表
        /// </summary>
        /// <returns>随机列表生成耗时说明</returns>
        public string LieBiaoShengCheng()
        {
            return LieBiaoShengCheng(IniList);
        }

        /// <summary>
        /// 数据存储在数组中，随机定位初始数组，取出数据添加到随机数组。初始数组定位处数据后面所有元素前移一位，覆盖定位数据。执行完成后RadomArray即为随机数组
        /// </summary>
        /// <returns>随机数组生成耗时说明</returns>
        public string YiDongShuZu()
        {
            return YiDongShuZu(IniArray);
        }

        /// <summary>
        /// 数据存储在数组中，随机定位初始数组，取出数据如果不为-1，则添加到随机数组，将定位处数据设为-1。如果等于-1，则向右移动一位，如果为-1，继续向右移动，直到定位处数据不为-1，取出数据添加到随机数组。如果移动到数组末尾，修改定位范围，重新定位，再向右移动
        /// 执行完成后RadomArray即为随机数组
        /// </summary>
        /// <returns></returns>
        public string YuanSuGuDing()
        {
            return YuanSuGuDing(IniArray);
        }

        /// <summary>
        /// 数据存储在数组中，随机定位初始数组,取出定位数据添加到随机数组中。将初始数组的末尾数据赋值到定位处。同时缩减数组定位范围。直到数组定位范围为0.执行完成后RadomArray即为随机数组。
        /// </summary>
        /// <returns></returns>
        public string SuoJianWeiBu()
        {
            return SuoJianWeiBu(IniArray);
        }

        /// <summary>
        /// 数据存储在数组中，原理与SuoJianWeiBu类似。不过只操作修改初始数组。随机定位，同时启动自增计数器。将定位处数据与计数器处数据互换。执行完成后IniArray即为随机数组
        /// </summary>
        /// <returns></returns>
        public string ZiShenXiuGai()
        {
            return ZiShenXiuGai(IniArray);
        }
        #endregion

        #region 几种获取随机不重复数组/列表的方法，私有
        /// <summary>
        /// 1.	将"+Limit+"个不重复整数随机排列，可以生成一个"+Limit+"长度整数数组，或者整数列表，随机取数字，取出后，数组或者列表长度减1，继续随机取数字，重复这个过程直到数组或者列表的长度变为1.
        /// </summary>
        private string LieBiaoShengCheng(List<int> iniList)
        {
            Random r = new Random(IniArrayLimit);
            int c = IniArrayLimit;
            IniRadomList();
            DateTime startTime = DateTime.Now;
            for (int i = RadomArrayLimit - 1; i >= 0; i--)
            {
                int n = r.Next(c);
                RadomList.Add(iniList[n]);
                iniList.RemoveAt(n);
                c--;
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "列表删除法，初始化" + RadomArrayLimit + "长度随机数组耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 随机定位，取出元素后，后面全部向前移动一位
        /// </summary>
        private string YiDongShuZu(int[] iniArray)
        {
            Random r = new Random(IniArrayLimit);
            int c = IniArrayLimit;
            IniRadomArray();
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < RadomArrayLimit; i++)
            {
                //随机数
                int rc = r.Next(c);
                //取值赋值
                RadomArray[i] = iniArray[rc];
                for (int j = rc; j < c - 1; j++)
                {
                    iniArray[rc] = iniArray[rc + 1];
                }
                c--;
                //移动数组
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "数组前移法，初始化" + RadomArrayLimit + "长度随机数组耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 2.	如果不移动数组元素，取随机数定位数组元素，当该位置没有内容时左右游动以命中内容
        /// </summary>
        private string YuanSuGuDing(int[] iniArray)
        {
            Random r = new Random(RadomArrayLimit);
            IniRadomArray();
            int dd = IniArrayLimit;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < RadomArrayLimit; i++)
            {
                int p = r.Next(dd);
                if (iniArray[p] != -1)
                {
                    RadomArray[i] = iniArray[p];
                    iniArray[p] = -1;
                }
                else
                {
                    int cc = p;
                    while (iniArray[p] == -1 && p < dd - 1)
                    {
                        p++;
                        if (iniArray[p] != -1)
                        {
                            RadomArray[i] = iniArray[p];
                            iniArray[p] = -1;
                            break;
                        }
                    }
                    if (p == dd)
                    {
                        dd = cc;
                    }
                }
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "游动取值法，初始化" + RadomArrayLimit + "长度随机数组耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 3.	如果不全部移动数组元素，随机定位数组元素，取出元素后，将数组最后的元素移动到取出元素的位置，虽然数组长度不变，但是数组内容个数在递减，重复该过程，直到数组中仅剩下一个元素
        /// </summary>
        private string SuoJianWeiBu(int[] iniArray)
        {
            Random r = new Random(RadomArrayLimit);
            IniRadomArray();
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < RadomArrayLimit; i++)
            {
                int p = r.Next(i, IniArrayLimit);
                RadomArray[i] = iniArray[p];
                iniArray[p] = iniArray[i];
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "数组动态替换法，初始化" + RadomArrayLimit + "长度随机数组耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 直接修改原数组,仅仅适用于初始数组与随机数组长度相等的情况，自增计数索引处值与随机定位值互换，以生成不重复随机列表。
        /// </summary>
        private string ZiShenXiuGai(int[] iniArray)
        {
            Random r = new Random(RadomArrayLimit);
            IniRadomArray();
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < RadomArrayLimit; i++)
            {
                int p = r.Next(i, RadomArrayLimit);
                int q = iniArray[i];
                iniArray[i] = iniArray[p];
                iniArray[p] = q;
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "直接修改原数组法，初始化" + RadomArrayLimit + "长度随机数组耗费" + runSpan.ToString() + "毫秒";
        }
        #endregion
    } 
}
