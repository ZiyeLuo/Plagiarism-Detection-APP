using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.IO;

namespace Plagiarism_Detection_APP
{
    public class bsGetFiles
    {
        public bsGetFiles()
        {
        }
        private static string result = "";
        /// <summary>
        /// 得某文件夹下所有的文件
        /// </summary>
        /// <param name="directory">文件夹名称</param>
        /// <param name="pattern">搜寻指类型</param>
        /// <returns></returns>
        public static string GetFiles(DirectoryInfo directory, string pattern)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {

                foreach (FileInfo info in directory.GetFiles(pattern))
                {
                    result = result + info.FullName.ToString() + ";";
                    //result = result + info.Name.ToString() + ";";
                }

                foreach (DirectoryInfo info in directory.GetDirectories())
                {
                    GetFiles(info, pattern);
                }
            }
            string returnString = result;
            return returnString;
        }

        public static String getContent(string filename)//得到一个文件夹下的所有.cs内容
        {
            string []path=GetFiles(new DirectoryInfo(filename), "*.cs").Split(';');
            string filecontent="";
            foreach (string file in path)
            {
                if (file == "") continue;
                filecontent += string.Join("", System.IO.File.ReadAllLines(file));
            }
            filecontent = filecontent.Replace("\n", "").Replace(" ", "").Replace("\t","").Replace("\r", "");
                
            return filecontent;
        }
    }
}
