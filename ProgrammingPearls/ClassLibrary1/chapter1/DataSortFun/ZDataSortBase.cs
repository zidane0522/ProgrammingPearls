using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataSortFun
{
    /// <summary>
    /// 数据排序算法基类
    /// </summary>
    public abstract class ZDataSortBase
    {
        /// <summary>
        /// 保存排序完成后的有序数组
        /// </summary>
        public int[] SortArray{ get; protected set; }

        public abstract string Sort(int[] unsort_array);
    }
}
