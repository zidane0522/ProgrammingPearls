using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataSortFun
{
    /// <summary>
    /// 数据排序算法类
    /// </summary>
    public class DataSortCls
    {
        public int[] SortArray{ get; private set; }

        public string Sort(int[] unsort_array)
        {
            DateTime startTime = DateTime.Now;
            SortArray = Sort_Descend(unsort_array,0,unsort_array.Length-1);
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "归并排序完成耗费" + runSpan.ToString() + "毫秒";
        }

        public int[] Sort_Descend(int[] unsort_array,int start1,int end1)
        {
            if (end1==start1)
            {
                return new int[] { unsort_array[end1] };
            }
            else if(end1 == start1+1)
            {
                return HeBingDataSort_Descend(new int[] { unsort_array[start1]},new int[] { unsort_array[end1] });
            }
            else
            {
                int[] firsthalf = Sort_Descend(unsort_array, start1, start1 + (end1 - start1) / 2);
                int[] lasthalf= Sort_Descend(unsort_array, start1+(end1 - start1) / 2 + 1, end1);
                return HeBingDataSort_Descend(firsthalf, lasthalf);
            }
        }

        /// <summary>
        /// 合并排序（降序情况）,将数组分成两部分，每部分排序，再合并排序。递归到每部分只有一个元素，排序后逐渐归并到一个数组内。排序完成.也就是说总是操作两个有序列表
        /// </summary>
        private int[] HeBingDataSort_Descend(int[] descend_Array1,int[] descend_Array2)
        {
            int c1 = descend_Array1.Count();
            int c2 = descend_Array2.Count();
            int c = c1 + c2;
            int[] descend_array = new int[c];
            int i1=0, i2=0;
            for (int i = 0; i < c; i++)
            {
                if (i1==c1)
                {
                    while (i2<c2)
                    {
                        descend_array[i1+i2] = descend_Array2[i2];
                        i2++;
                    }
                    break;
                }
                if (i2 == c2)
                {
                    while (i1 < c1)
                    {
                        descend_array[i1 + i2] = descend_Array1[i1];
                        i1++;
                    }
                    break;
                }
                if (descend_Array1[i1]>=descend_Array2[i2])
                {
                    descend_array[i] = descend_Array1[i1];
                    i1++;
                    continue;
                }
                else
                {
                    descend_array[i] = descend_Array2[i2];
                    i2++;
                    continue;
                }
            }

            return descend_array;
        }

        /// <summary>
        /// 多通道排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void DuoTongDaoSort<T>()
        {

        }

        /// <summary>
        /// 精彩排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void JingCaiDataSort<T>()
        {

        }
    }
}
