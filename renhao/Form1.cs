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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseFolder cf = new ChooseFolder();
            cf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请输入台站号");
                return;
            }

            var list = MongoDBHelper.GetData(Convert.ToInt32(textBox1.Text),dateTimePicker1.Value,dateTimePicker2.Value);
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["StationCode"].HeaderText = "台站号";
            dataGridView1.Columns["Lat"].HeaderText = "纬度";
            dataGridView1.Columns["Lng"].HeaderText = "经度";
            dataGridView1.Columns["Height"].HeaderText = "观测场海拔高度";
            dataGridView1.Columns["Datetime"].HeaderText = "日期";
            dataGridView1.Columns["AverAirPressure"].HeaderText = "平均本站气压";
            dataGridView1.Columns["MaxAirPressure"].HeaderText = "日最高本站气压";
            dataGridView1.Columns["MinAirPressure"].HeaderText = "日最低本站气压";
            dataGridView1.Columns["AverTemperature"].HeaderText = "平均气温";
            dataGridView1.Columns["MaxTemperature"].HeaderText = "日最高气温";
            dataGridView1.Columns["MinTemperature"].HeaderText = "日最低气温";
            dataGridView1.Columns["AverRelativeHumidity"].HeaderText = "平均相对湿度";
            dataGridView1.Columns["MixRRelativeHumidity"].HeaderText = "最小相对湿度";
            dataGridView1.Columns["Precipitation208"].HeaderText = "20-8时降水量";
            dataGridView1.Columns["Precipitation820"].HeaderText = "8-20时降水量";
            dataGridView1.Columns["Precipitation2020"].HeaderText = "20-20时累计降水量";
            dataGridView1.Columns["SmallEvaporation"].HeaderText = "小型蒸发量";
            dataGridView1.Columns["BigEvaporation"].HeaderText = "大型蒸发量";
            dataGridView1.Columns["AverWindSpeed"].HeaderText = "平均风速";
            dataGridView1.Columns["MaxWindSpeed"].HeaderText = "最大风速";
            dataGridView1.Columns["MaxWindSpeedDirection"].HeaderText = "最大风速风向";
            dataGridView1.Columns["VeryBigWindSpeed"].HeaderText = "极大风速";
            dataGridView1.Columns["VeryBigWindSpeedDirection"].HeaderText = "极大风速风向";
            dataGridView1.Columns["SunshineTime"].HeaderText = "日照时数";
            dataGridView1.Columns["AverGroundSufaceTemperature"].HeaderText = "平均地表气温";
            dataGridView1.Columns["MaxGroundSufaceTemperature"].HeaderText = "日最高地表气温";
            dataGridView1.Columns["MinGroundSufaceTemperature"].HeaderText = "日最低地表气温";
        }
    }
}
