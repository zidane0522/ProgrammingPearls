using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.DataSortFun;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArrayCls dc = new DataArrayCls(10000000);
            Console.WriteLine(dc.InitMillionArray());
            Console.WriteLine(dc.ZiShenXiuGai());//一秒左右,比SuoJianWeiBu方法稍快十分之一
            //Console.WriteLine(dc.WriteArrayToTxt(dc.IniArray));//写入文本
            //Console.WriteLine(dc.ReadArrayFromTxt(@"D:\datasort.txt"));
            DataSortCls dsc = new DataSortCls();
            Console.WriteLine(dsc.Sort(dc.RadomArray));
            //foreach (var item in dsc.SortArray)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            Console.ReadKey();
        }
    }
}
