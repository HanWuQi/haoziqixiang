using renhao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace renhao
{
    public partial class ChooseFolder : Form
    {
        delegate void pbRun();

        public ChooseFolder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileHelper.pathList.Clear();
            FileHelper.getPath(textBox1.Text);

            progressBar1.Maximum = FileHelper.pathList.Count;//设置最大长度值
            progressBar1.Value = 0;//设置当前值
            progressBar1.Step = 1;//设置没次增长多少
            
            Task.Factory.StartNew(() =>
            {
                FileHelper.pathList.ForEach(x =>
                {
                    var dmList = FileHelper.Read(x);
                    MongoDBHelper.UpsertDataModel(dmList);
                    if (progressBar1.InvokeRequired)
                    {
                        pbRun pbrun = new pbRun(pbAdd);
                        progressBar1.Invoke(pbrun);
                    }
                    //if(label1.InvokeRequired)
                    //{
                    //    pbRun pbrun = new pbRun(SetLabelValue);
                    //    label1.Invoke(pbrun);
                    //}
                });
            });
        }

        public void pbAdd()
        {
            progressBar1.Value += progressBar1.Step;
        }

        public void SetLabelValue()
        {
            label1.Text = (100 * (progressBar1.Value / progressBar1.Maximum)).ToString()+"%";
        }


        private void ChooseFolder_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件夹路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }
    }
}
