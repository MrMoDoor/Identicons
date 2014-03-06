using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IdenticonsDll;

namespace TestDllWf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Create();
        }
        IdenticonsDll.IdIcon ic = new IdIcon();
        private void Create()
        {
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
            lst = ic.ListCreate(8);//8个
            string json = ic.LstTjson(lst);
            System.Drawing.Image img = ic.IdenticonsCreate(this.pictureBox1.Width,this.pictureBox1.Height, lst, Color.Silver, "#A87EDF", "#A87EDF");//浅紫色
            pictureBox1.Image = img;
            label1.Text = "time:" + DateTime.Now.ToString() + "\n" + "id:" + json;
        }
    }
}
