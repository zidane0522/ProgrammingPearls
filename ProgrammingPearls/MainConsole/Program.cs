using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary1.DataSortFun;
using ClassLibrary1.chapter8;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //int intiNum = 20;
            //ZRadomDataArrayCls dc = new ZRadomDataArrayCls(0,intiNum,intiNum);
            //Console.WriteLine(dc.InitMillionArray());
            //Console.WriteLine(dc.ZiShenXiuGai());//一秒左右,比SuoJianWeiBu方法稍快十分之一
            //foreach (var item in dc.IniArray)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //ZFile zfile = new ZFile();
            //Console.WriteLine(zfile.WriteArrayToTxt(dc.IniArray, @"D:\datasort.txt"));//写入文本


            //int[] unsortArray = zfile.ReadArrayFromTxt(@"D:\datasort.txt").ToArray();
            ////ZDataSortBase dsc = new ZGuiBingSortCls();
            ////Console.WriteLine(dsc.Sort(unsortArray));
            //ZDataSortBase weit = new ZWeiTuSortCls(intiNum, 0);
            //Console.WriteLine(weit.Sort(unsortArray));
            //foreach (var item in weit.SortArray)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            OneD_8_1_V v = new OneD_8_1_V();
            v.Vctor = new int[] { -8,7,5,-9,5,6,0,1,-46,5};
            int max= v.ScanMethod();
            Console.WriteLine(v.LeftLimit.ToString()+"   "+v.RightLimit.ToString()+"  "+max.ToString());
            Console.ReadKey();
        }
    }
}
