using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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



        string defaultPath = " ";
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

        }
    }
}
