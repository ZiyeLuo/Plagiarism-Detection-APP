using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagiarism_Detection_APP
{
    public class getContent
    {
        public static List<string> getContents(String dirpath)
        {
            List<string> dirs = getDir.getDirName(@"E:\GoogleChrome\4");
            List<string> contents = new List<string>();
            foreach (string each in dirs)
            {
                contents.Add(bsGetFiles.getContent(@each));
            }
            return contents;
        }
    }
}
