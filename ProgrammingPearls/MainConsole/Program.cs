using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArrayCls dc = new DataArrayCls();
            Console.WriteLine(dc.InitMillionArray());
            Console.WriteLine(dc.InitMillionList());
            Console.WriteLine(dc.LieBiaoShengCheng());//极慢，估计需要数十分钟，或数小时

            Console.WriteLine(dc.YuanSuGuDing());//一分钟左右
            Console.WriteLine(dc.SuoJianWeiBu());//一秒左右

            Console.WriteLine(dc.YiDongShuZu());//极慢，估计需要数小时甚至数天
            Console.WriteLine(dc.ZiShenXiuGai());//一秒左右,比SuoJianWeiBu方法稍快十分之一
            Console.ReadKey();
        }
    }
}
