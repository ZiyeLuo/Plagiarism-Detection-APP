using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Plagiarism_Detection_APP
{
    public partial class loginMention : Form
    {
        public loginMention()
        {
            InitializeComponent();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        string defaultPath ="";
        string lanType = "NULL";

        private void addFirstFiles(object sender, EventArgs e)
        {
            lanType = "C#";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //打开的文件夹浏览对话框上的描述
            dialog.Description = "请选择一个文件夹";
            //是否显示对话框左下角 新建文件夹 按钮，默认为 true
            dialog.ShowNewFolderButton = false;
            //首次defaultPath为空，按FolderBrowserDialog默认设置（即桌面）选择
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录
                dialog.SelectedPath = defaultPath;
            }
            //按下确定选择的按钮
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录
                defaultPath = dialog.SelectedPath;
            }
            MessageBox.Show(defaultPath);
            this.lanAns.Text = lanType;
            this.pathAns.Text = defaultPath;
        }
        private void addSecondFiles(object sender, EventArgs e)
        {
            lanType = "C++";
            Common.Type = 1;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //打开的文件夹浏览对话框上的描述
            dialog.Description = "请选择一个文件夹";
            //是否显示对话框左下角 新建文件夹 按钮，默认为 true
            dialog.ShowNewFolderButton = false;
            //首次defaultPath为空，按FolderBrowserDialog默认设置（即桌面）选择
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录
                dialog.SelectedPath = defaultPath;
            }
            //按下确定选择的按钮
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录
                defaultPath = dialog.SelectedPath;
            }
            MessageBox.Show(defaultPath);
            this.lanAns.Text = lanType;
            this.pathAns.Text = defaultPath;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void pullAction(object sender, EventArgs e)
        {
            if (defaultPath == "")
            {
                MessageBox.Show("empty path ,you need to choose a dir");
                return;
            }
            //绝对路径
                List<string> files = getContent.getContents(@defaultPath);

                //获得所有的文件名字
                operation(ref files);

        }
        /*
         * strs 传入的是每个用户文件的内容，调用接口
         * 这里是给wlx的提供的接口，可能会有栈溢出，我这已经占用了少部分内存
         * 如果有栈溢出则需要修改为保存strs到文件
         */
        public class LevenshteinDistance
        {
            /// <summary>
            /// 取最小的一位数
            /// </summary>
            /// <param name="first"></param>
            /// <param name="second"></param>
            /// <param name="third"></param>
            /// <returns></returns>
            private   int LowerOfThree(int first, int second, int third)
            {
                int min = Math.Min(first, second);
                return Math.Min(min, third);
            }

            private  int Levenshtein_Distance(string str1, string str2)
            {
                int[,] Matrix;
                int n = str1.Length;
                int m = str2.Length;

                int temp = 0;
                char ch1;
                char ch2;
                int i = 0;
                int j = 0;
                if (n == 0)
                {
                    return m;
                }
                if (m == 0)
                {

                    return n;
                }
                Matrix = new int[n + 1, m + 1];

                for (i = 0; i <= n; i++)
                {
                    //初始化第一列
                    Matrix[i, 0] = i;
                }

                for (j = 0; j <= m; j++)
                {
                    //初始化第一行
                    Matrix[0, j] = j;
                }

                for (i = 1; i <= n; i++)
                {
                    ch1 = str1[i - 1];
                    for (j = 1; j <= m; j++)
                    {
                        ch2 = str2[j - 1];
                        if (ch1.Equals(ch2))
                        {
                            temp = 0;
                        }
                        else
                        {
                            temp = 1;
                        }
                        Matrix[i, j] = LowerOfThree(Matrix[i - 1, j] + 1, Matrix[i, j - 1] + 1, Matrix[i - 1, j - 1] + temp);
                    }
                }
                /*    for (i = 0; i <= n; i++)
                    {
                        for (j = 0; j <= m; j++)
                        {
                            Console.Write(" {0} ", Matrix[i, j]);
                        }
                        Console.WriteLine("");
                    }
    */
                return Matrix[n, m];
            }

            /// <summary>
            /// 计算字符串相似度
            /// </summary>
            /// <param name="str1"></param>
            /// <param name="str2"></param>
            /// <returns></returns>
            public   decimal LevenshteinDistancePercent(string str1, string str2)
            {
                //int maxLenth = str1.Length > str2.Length ? str1.Length : str2.Length;
                int val = Levenshtein_Distance(str1, str2);
                return 1 - (decimal)val / Math.Max(str1.Length, str2.Length);
            }
        }

        private void operation(ref List<string> strs)
        {
            /***
             *这里是王的操作空间
             *
             */
            Console.WriteLine("加载完成");
            LevenshteinDistance ins;
            for (int i = 0; i < strs.Count(); i++)
            {

                for (int j = i+1; j < strs.Count(); j++)
                {
                    ins = new LevenshteinDistance();
                    decimal acc=ins.LevenshteinDistancePercent(strs[i], strs[j]) * 100;
                    Console.WriteLine("{0}---{1}   {2}", i+1, j+1,acc);
                    if (acc > 60)
                    {
                        try
                        {
                            StreamWriter sw = new StreamWriter(@"D:\plageList.txt", true);
                            Console.WriteLine("{0}**************{1}   {2}", i+1, j+1,acc);
                            sw.Write(i + 1);
                            sw.Write('\t');
                            sw.Write(j + 1);
                            sw.Write('\t');
                            sw.Write("similarity is"+acc);
                            sw.Write('\n');
                            sw.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("文件夹内文件读取出现问题，请检查文件格式");
                        }
                    }
                    ins = null;
                    GC.Collect();
                }
            }
            Console.WriteLine("Finish!");
        }
        /*
         * 这个方法用于将最后结果写到文件里
         * 参数是最后的结果List(每一行存一个)和文件路路径
         */
        void WriteWS(string filePath,List<string> input)
        {


            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(filePath, true);
            try
            {   foreach(string each in input)
                {
                    sw.WriteLine(input);
                    sw.Flush();
                }
                sw.Close();
                fs.Close();
                Console.WriteLine("Writing has been completed");
            }
            catch (IOException e)
            {
                sw.Flush();
                sw.Close();
                fs.Close();
                Console.WriteLine(e.ToString());
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.lanAns.Text = "null";
            this.pathAns.Text = "null";
        }

        private void loginMention_Load(object sender, EventArgs e)
        {

        }


    }
}
