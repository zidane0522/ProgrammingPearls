using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 生成随机数组接口
    /// </summary>
    interface IRadomArray
    {
        void ZiShenXiuGai(int[] iniArray);

        int[] SuoJianWeiBu(int[] iniArray);

        int[] DingWeiYouBuYouDong(int[] intArray);

        int[] ZhengTiYiDong(int[] intArray);
    }
}
