using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// 文件读写方法
    /// </summary>
    public class ZFile
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        private void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 将数组数据写入文件
        /// </summary>
        public string WriteArrayToTxt(int[] array,string path)
        {
            DeleteFile(path);
            int c = array.Count();
            DateTime startTime = DateTime.Now;
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    try
                    {
                        for (int i = 0; i < c - 1; i++)
                        {
                            sw.WriteLine(array[i].ToString());
                        }
                        sw.Write(array[c - 1].ToString());
                    }
                    finally
                    {
                        sw.Close();
                        fs.Close();
                    }
                }
            }
            DateTime endTime = DateTime.Now;
            double runSpan = endTime.Subtract(startTime).TotalMilliseconds;
            return "写入"+c.ToString()+"长度数组耗费" + runSpan.ToString() + "毫秒";
        }

        /// <summary>
        /// 将文本数据读取到整数列表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<int> ReadArrayFromTxt(string path)
        {
            List<int> list = new List<int>();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    try
                    {
                        int i = 0;
                        while (true)
                        {
                            string p = sr.ReadLine();
                            if (string.IsNullOrEmpty(p))
                            {
                                break;
                            }

                            list.Add(Convert.ToInt32(p));
                            i++;
                        }
                    }
                    finally
                    {
                        sr.Close();
                        fs.Close();
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 将列表数据写入文件
        /// </summary>
        public void WriteListToTxt(List<int> list,string path)
        {
            DeleteFile(path);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    try
                    {
                        foreach (int item in list)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }
                    finally
                    {
                        sw.Close();
                        fs.Close();
                    }
                }
            }
        }
    }
}
