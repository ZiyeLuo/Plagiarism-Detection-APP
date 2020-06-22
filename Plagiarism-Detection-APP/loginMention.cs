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



        string defaultPath = "";
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
            try
            {
            List<string> files = getContent.getContents(@defaultPath);

                //获得所有的文件名字
             operation(ref files);
            }
            catch (Exception)
            {
                MessageBox.Show("文件夹内文件读取出现问题，请检查文件格式");
            }
        }
        /*
         * strs 传入的是每个用户文件的内容，调用接口
         * 这里是给wlx的提供的接口，可能会有栈溢出，我这已经占用了少部分内存
         * 如果有栈溢出则需要修改为保存strs到文件
         */
        
        private void operation(ref List<string>strs)
        {
            /***
             *这里是王的操作空间
             *
             */
            Console.WriteLine("please write here");  
        }
        /*
         * 这个方法用于将最后结果写到文件里
         * 参数是最后的结果List(每一行存一个)和文件路路径
         */
        void WriteWS(string filePath,List<string> input)
        {


            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
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
