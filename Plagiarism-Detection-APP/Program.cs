using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plagiarism_Detection_APP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginMention());*/
            //foreach (string filename in GetFiles("C:\\Path", "*.txt", SearchOption.SearchOption.AllDirectories))
            //    Console.WriteLine(filename);
            //string filecontent = string.Join("\r\n", System.IO.File.ReadAllLines(filename));
            //bsGetFiles s = new bsGetFiles();E:\GoogleChrome\4\ 1001\55171115_HomeWork4
            //string back =bsGetFiles.getContent(@"E:\GoogleChrome\4\ 1001");
            //Console.WriteLine(back);
            //List<string> dirs = getDir.getDirName(@"E:\GoogleChrome\4");
            List<string> con = getContent.getContents(@"E:\GoogleChrome\4");
            Console.WriteLine("hhh");
        }
    }
}
