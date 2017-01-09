using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataSortFun
{
    /// <summary>
    /// 位图/向量排序法，仅适用于元素唯一不重复的数组,并且是稠集合，这样才能达到节省空间的目的。
    /// </summary>
    public class ZWeiTuSortCls : ZDataSortBase
    {
        public ZWeiTuSortCls(int maxvalue, int minvalue)
        {
            this.MaxValue = maxvalue;
            this.MinValue = minvalue;
            this.Limit = maxvalue - minvalue + 1;
        }
        public int MaxValue { get;private set; }

        public int MinValue { get; private set; }

        public int Limit { get; private set; }
        public override string Sort(int[] unsort_array)
        {
            DateTime startTime = DateTime.Now;
            WeiTuSort(unsort_array);
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "归并排序完成耗费" + runSpan.ToString() + "毫秒";
        }

        public void WeiTuSort(int[] unsort_array)
        {
            BitArray bitArray = new BitArray(Limit, false);
            int c = unsort_array.Length;
            foreach (int item in unsort_array)
            {
                bitArray.Set(item - MinValue, true);
            }
            SortArray = new int[c];
            int j = 0;
            for (int i = 0; i < Limit; i++)
            {
                if (bitArray[i])
                {
                    SortArray[j] = i;
                    j++;
                }
            }
        }
    }
}
