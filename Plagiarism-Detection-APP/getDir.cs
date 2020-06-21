using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagiarism_Detection_APP
{
    public class getDir
    {
        public static List<string> getDirName(string path)
        {
            List<string> dirs = new List<string>();
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                dirs.Add(path+"\\"+d.Name);
            }
            return dirs;
        }
    }
}
