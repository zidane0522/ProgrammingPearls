using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.chapter8
{
    /// <summary>
    /// 第8章8.1节的问题解决
    /// </summary>
    public class OneD_8_1_V
    {
        public int[] Vctor { get; set; }

        public int LeftLimit { get; set; }

        public int RightLimit { get; set; }

        /// <summary>
        /// 简单计算
        /// </summary>
        /// <returns></returns>
        public int NormalMethod()
        {
            int maxSubVSum = Vctor[0];
     
            for (int i = 0; i < Vctor.Length; i++)
            {
                for (int j = i; j < Vctor.Length; j++)
                {
                    int currentSum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        currentSum = currentSum + Vctor[i];
                    }
                    if (currentSum > maxSubVSum)
                    {
                        maxSubVSum = currentSum;
                        LeftLimit = i;
                        RightLimit = j;
                    }
                }
            }
            return maxSubVSum;
        }
        /// <summary>
        /// 二次算法。改进上面的方法，减少重复的求和计算
        /// </summary>
        /// <returns></returns>
        public int AdvancedNormalMethod()
        {
            int maxSubVSum = Vctor[0];

            for (int i = 0; i < Vctor.Length; i++)
            {
                int currentSum = 0;
                for (int j = i; j < Vctor.Length; j++)
                {
                    currentSum = currentSum + Vctor[j];
                    if (currentSum > maxSubVSum)
                    {
                        maxSubVSum = currentSum;
                        LeftLimit = i;
                        RightLimit = j;
                    }
                }
            }
            return maxSubVSum;
        }

        /// <summary>
        /// 二次算法。减少重复的求和计算，另一种处理
        /// </summary>
        /// <returns></returns>
        public int AdvancedNormalMethod2()
        {
            int maxSubVSum = Vctor[0];
            int currentSum = 0;
            int par = 0;
            for (int i = 0; i < Vctor.Length; i++)
            {
                if (i>0)
                {
                    par = Vctor[i - 1];
                }
                for (int j = i; j < Vctor.Length; j++)
                {
                    currentSum = currentSum + Vctor[j] - par;
                    if (currentSum > maxSubVSum)
                    {
                        maxSubVSum = currentSum;
                        LeftLimit = i;
                        RightLimit = j;
                    }
                }
            }
            return maxSubVSum;
        }

        /// <summary>
        /// 分治算法
        /// </summary>
        /// <returns></returns>
        public int DevideMethod()
        {
            int left = 0;
            int right = 0;
            return RecursionDevide(ref left, ref right, 0, Vctor.Length - 1);
        }

        /// <summary>
        /// 分治法中的递归逻辑
        /// </summary>
        /// <param name="currentleft"></param>
        /// <param name="currentright"></param>
        /// <param name="leftLimit"></param>
        /// <param name="rightLimit"></param>
        /// <returns></returns>
        private int RecursionDevide(ref int currentleft,ref int currentright,int leftLimit,int rightLimit)
        {
            int left1 = 0;
            int right1 = 0;
            int left2 = 0;
            int right2 = 0;
            int i = (rightLimit-leftLimit+1) / 2;
            if (i==0)
            {
                currentleft = i;
                currentright = i;
                if (Vctor[i]>0)
                {
                    return Vctor[i];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                int maxa= RecursionDevide(ref left1,ref right1,leftLimit,i-1);
                int maxb = RecursionDevide(ref left2, ref right2, i, rightLimit);
                if (right1 == left2 + 1)
                {
                    return maxa + maxb;
                }
                else
                {
                    return maxa > maxb ? maxa : maxb;
                }
            }
        }

        /// <summary>
        /// 扫描算法
        /// </summary>
        public int ScanMethod()
        {
            int res = 0;
            if (Vctor.Length==1)
            {
                res= Vctor[0] > 0 ? Vctor[0] : 0;
            }
            else
            {
                int currentSum = 0;
                int Max = 0;
                int currentLeft = 0;
                int currentRight = 0;
                for (int i = 0; i <Vctor.Length; i++)
                {
                    if (Vctor[i] <= 0)
                    {
                        if (currentSum + Vctor[i] < 0)
                        {
                            currentSum = 0;
                            //currentLeft = 0;
                            //currentRight = 0;
                        }
                        else
                        {
                            //Max = currentSum;
                            currentRight = i;
                            currentSum = currentSum + Vctor[i];
                        }
                    }
                    else
                    {
                        if (currentSum==0)
                        {
                            currentLeft = i;
                        }
                        currentSum += Vctor[i];
                        currentRight = i;
                        if (currentSum>Max)
                        {
                            Max = currentSum;
                            LeftLimit = currentLeft;
                            RightLimit = currentRight;
                        }
                    }
                }
                res = Max;
            }
            return res;
        }
    }
}
