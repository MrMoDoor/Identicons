using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Identicons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Width = 200;
            this.pictureBox1.Height = 200;

            Image img = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.Silver);

            int w=this.pictureBox1.Width;
            int h=this.pictureBox1.Height;
            int wPix = Convert.ToInt32(this.pictureBox1.Width * 0.2);
            int hPix = Convert.ToInt32(this.pictureBox1.Height * 0.2);


            //Rectangle rec=new Rectangle(0,0,w,h);
            Pen pen = new Pen(Color.LightBlue);

            Random rm=new Random();
            

            int x=0;// rm.Next(0,3); 0,1,2
            int y=0;//rm.Next(0,5); 0,1,2,3,4
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();

            int num=8;//生成点数
            bool con=true;
            //生成坐标点不同的五个坐标
            while (con)
            {
                x = rm.Next(0, 3);
                y = rm.Next(0, 5);
                if (lst.Count == 0)
                {
                    Dictionary<int, int> dic = new Dictionary<int, int>();
                    dic.Add(x, y);
                    lst.Add(dic);
                }
                else if (lst.Count >= 1 & lst.Count < num)
                {
                    bool numadd = true;
                    for (int i = 0; i < lst.Count; i++)
                    {
                        foreach (var item in lst[i])
                        {
                            if (item.Key == x && item.Value == y)
                            {
                                //相同
                                numadd = false;
                            }
                        }
                    }
                    if (numadd)
                    {
                        Dictionary<int, int> dic = new Dictionary<int, int>();
                        dic.Add(x, y);
                        lst.Add(dic);                        
                    }
                }
                else if (lst.Count >= num)
                {
                    con = false;
                }
            }

            Brush brush=Brushes.LightBlue;
            
            for (int i = 0; i < lst.Count; i++)
			{
                foreach (var item in lst[i])
                {
                    x = item.Key;
                    y = item.Value;

                    if (x==0||x==1)//方形长度为单位1
	                {
                        g.DrawRectangle(pen,x*wPix,y*hPix,wPix,hPix);
                        //横向 反向
                        g.DrawRectangle(pen, (4 - x) * wPix, y * hPix, wPix, hPix);
                        //斜向 反向
                        //g.DrawRectangle(pen, (4 - x) * wPix, (4-y) * hPix, wPix, hPix);
                        //填充颜色
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
                        g.FillRectangle(brush, (4 - x) * wPix, y * hPix, wPix, hPix);

	                }
                    else if (x==2)//长度为 单位1/2
	                {
                        g.DrawRectangle(pen, x * wPix, y * hPix, wPix, hPix);
                        //g.DrawRectangle(pen,x*wPix,y*hPix,wPix/2,hPix);
                        //g.DrawRectangle(pen,
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
	                }                    
                }



			}
            //g.DrawRectangle(pen, 0, 0, wPix, hPix);
            //g.DrawRectangle(pen, wPix, hPix, wPix, hPix);
            //g.DrawRectangle(pen, 2 * wPix, 2 * hPix, wPix / 2, hPix);

            //g.DrawRectangle(pen, w - wPix, 0, wPix, hPix);
            //g.DrawRectangle(pen, w - 2 * wPix, hPix, wPix, hPix);
            //g.DrawRectangle(pen,

            //Brush brush=Brushes.LightBlue;
            //g.FillRectangle(brush, 0, 0, wPix, hPix);
            //g.FillRectangle(brush, wPix, hPix, wPix, hPix);
            //g.FillRectangle(brush, 2 * wPix, 2 * hPix, wPix / 2, hPix);


            pictureBox1.Image = img;
        }


    }
}
