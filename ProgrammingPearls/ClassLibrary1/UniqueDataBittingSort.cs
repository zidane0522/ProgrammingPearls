using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 位图数据结构排序法
    /// </summary>
    public class UniqueDataBittingSort
    {
        //有若干个无序不重复整数

            /// <summary>
            /// 生成无序不重复整数到一个文件中
            /// </summary>
            /// <param name="limitNum"></param>
        public void CreateDataFile(int limitNum)
        {
            List<int> datalist = new List<int>();
            int[] d = new int[1000];
            for (int i = 1; i <= 1000; i++)
            {
                datalist.Add(i);
            }
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Random r = new Random(1000 - j - 1);
                    int index = r.Next();
                    d[j - 1] = datalist[index];
                    datalist.RemoveAt(index);
                }
                WriteInRangedData(d);
                for (int  k = 1; k <= 1000; k++)
                {
                    datalist.Add((i + 1) * 1000 + i);
                }
            }
        }

        private void WriteInRangedData(int[] data)
        {

        }
    } 
}
