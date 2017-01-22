using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.chapter3
{
    public class QiDuanZhuangZhi
    {
        public byte[] BianHao(Int16 num, int numLength)
        {
            byte[] res = new byte[numLength];
            int[][] numCodes = new int[10][] 
            {
                new[] { 0,2,3,4,5,6},
                new[] {4,6 },
                new[] { 0,1,2,4,5},
                new[] { 0,1,2,4,6},
                new[] { 1,3,4,6},
                new[] { 0,1,2,3,6},
                new[] { 0,1,2,3,5,6},
                new[] {2,4,6},
                new[] { 0,1,2,3,4,5,6},
                new[] { 1,2,3,4,6}
            };
            string numStr = num.ToString();
            if (numStr.Length < numLength)
            {
                for (int i = 0; i < numLength-numStr.Length; i++)
                {
                    numStr = "0" + numStr;
                }

            }

            for (int i = 0; i < numLength; i++)
            {
                string s = numStr.Substring(i, 1);
                Int16 loc = Int16.Parse(s);
                //BitArray bitArray = new BitArray(8,false);
                int sum = 0;
                for (int j = 0; j < numCodes[loc].Length; j++)
                {
                    //bitArray.Set(numCodes[loc][j], true);
                    sum += (int)Math.Pow(2, numCodes[loc][j]);
                }
                res[i] = Byte.Parse(sum.ToString());
            }
            return res;
        }


    }
}
