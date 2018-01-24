using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renhao.Model
{
    public class FileHelper
    {
        public static List<string> pathList = new List<string>();//定义list变量，存放获取到的路径
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path"></param>
        public static List<DataModel> Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            var list = new List<DataModel>();
            while ((line = sr.ReadLine()) != null)
            {
                var temp = new DataModel(line.ToString(), path);
                list.Add(temp);
            }
            return list;
        }

        /// <summary>
        /// 遍历所有路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> getPath(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                pathList.Add(f.FullName);//添加文件的路径到列表
            }
            //获取子文件夹内的文件列表，递归遍历
            foreach (DirectoryInfo d in dii)
            {
                getPath(d.FullName);
                //list.Add(d.FullName);//添加文件夹的路径到列表
            }
            return pathList;
        }
    }
}
