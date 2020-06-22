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
using System.Text.RegularExpressions;

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
            result = "";
            string []path=GetFiles(new DirectoryInfo(filename), "*.cs").Split(';');
            string filecontent="";
            foreach (string file in path)
            {
                if (file == "") continue;
                filecontent += getFile(@file);
            }
            filecontent = filecontent.Replace("\n", "").Replace(" ", "").Replace("\t","").Replace("\r", "");
                
            return filecontent;
        }
        public static string getFile(string path)
        {
            string pattern = @"//.*";
            Regex r1 = new Regex(pattern); 
            string pattern2 = @"\[a.*";
            Regex r2 = new Regex(pattern2);
            string str ="";
            string[] lines = System.IO.File.ReadAllLines(@path);
            foreach (string line in lines)
            {
                if (r1.IsMatch(line)||r2.IsMatch(line)) continue;
                str += line;
            }
            return str;
        }
    }

}
