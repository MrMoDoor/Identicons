using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IdenticonsDll
{
    public class IdIcon
    {
        /// <summary>
        /// 生成num个不同的坐标点
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns></returns>
        public List<Dictionary<int, int>> ListCreate(int num)
        {
            bool con = true;
            Random rm = new Random();
            int x = 0;// rm.Next(0,3); 0,1,2
            int y = 0;//rm.Next(0,5); 0,1,2,3,4
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
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
            return lst;

        }

        /// <summary>
        /// 将生成的lst转换为json(以便保存)
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public string LstTjson(List<Dictionary<int,int>> lst)
        {
            string json = "";
            for (int i = 0; i < lst.Count; i++)
            {
                foreach (var item in lst[i])
                {
                    json = json + "{" + item.Key.ToString() + "," + item.Value.ToString() + "}|";
                }
            }
            json = json.Replace("}|", "#").Replace("}", "");
            return json;
        }


        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="lst">生成的lst坐标点</param>
        /// <param name="bgcolor">背景颜色</param>
        /// <param name="pencolor">绘制颜色</param>
        /// <param name="brushcolor">填充颜色</param>
        /// <returns></returns>
        public Image IdenticonsCreate(int width,int height,List<Dictionary<int,int>> lst,Color bgcolor,Color pencolor,Color brushcolor)
        { 
            int count=lst.Count;
            Image img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);
            g.Clear(bgcolor);
            int x=0;
            int y=0;
            int wPix = Convert.ToInt32(width * 0.2);//5x5格式
            int hPix = Convert.ToInt32(height * 0.2);
            Pen pen=new Pen(pencolor);
            //Brush brush=Brushes.LightBlue;
            Brush brush = new SolidBrush(brushcolor);
            string json = "";
            for (int i = 0; i < count; i++)
			{
                foreach (var item in lst[i])
                {
                    x = item.Key;
                    y = item.Value;

                    if (x==0||x==1)//方形长度为单位1
	                {
                        g.DrawRectangle(pen,x*wPix,y*hPix,wPix,hPix);
                        //横向 反向
                        g.DrawRectangle(pen, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5
                        //斜向 反向
                        //g.DrawRectangle(pen, (4 - x) * wPix, (4-y) * hPix, wPix, hPix);
                        //填充颜色
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
                        g.FillRectangle(brush, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5

	                }
                    else if (x==2)//长度为 单位1/2
	                {
                        g.DrawRectangle(pen, x * wPix, y * hPix, wPix, hPix);
                        //g.DrawRectangle(pen,x*wPix,y*hPix,wPix/2,hPix);
                        //g.DrawRectangle(pen,
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
	                }

                    json = json+"{" + item.Key.ToString() + "," + item.Value.ToString() + "}|";
                }
            }
            return img;
        }

        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="lst">生成的lst坐标点</param>
        /// <param name="bgcolor">背景颜色</param>
        /// <param name="Rpen">绘制颜色R</param>
        /// <param name="Gpen">绘制颜色G</param>
        /// <param name="Bpen">绘制颜色B</param>
        /// <param name="Rbrush">填充颜色R</param>
        /// <param name="Gbrush">填充颜色G</param>
        /// <param name="Bbrush">填充颜色B</param>
        /// <returns></returns>
        public Image IdenticonsCreate(int width,int height,List<Dictionary<int,int>> lst,Color bgcolor,int Rpen,int Gpen,int Bpen,int Rbrush,int Gbrush,int Bbrush)
        { 
            int count=lst.Count;
            Image img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.Silver);
            int x=0;
            int y=0;
            int wPix = Convert.ToInt32(width * 0.2);//5x5格式
            int hPix = Convert.ToInt32(height * 0.2);
            Pen pen=new Pen(Color.FromArgb(Rpen,Gpen,Bpen));
            Brush brush = new SolidBrush(Color.FromArgb(Rbrush,Gbrush,Bbrush));

            string json = "";
            for (int i = 0; i < count; i++)
			{
                foreach (var item in lst[i])
                {
                    x = item.Key;
                    y = item.Value;

                    if (x==0||x==1)//方形长度为单位1
	                {
                        g.DrawRectangle(pen,x*wPix,y*hPix,wPix,hPix);
                        //横向 反向
                        g.DrawRectangle(pen, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5
                        //斜向 反向
                        //g.DrawRectangle(pen, (4 - x) * wPix, (4-y) * hPix, wPix, hPix);
                        //填充颜色
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
                        g.FillRectangle(brush, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5

	                }
                    else if (x==2)//长度为 单位1/2
	                {
                        g.DrawRectangle(pen, x * wPix, y * hPix, wPix, hPix);
                        //g.DrawRectangle(pen,x*wPix,y*hPix,wPix/2,hPix);
                        //g.DrawRectangle(pen,
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
	                }

                    json = json+"{" + item.Key.ToString() + "," + item.Value.ToString() + "}|";
                }
            }
            return img;
        }
   

        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="lst">生成的lst坐标点</param>
        /// <param name="bgcolor">背景颜色</param>
        /// <param name="pencolor">绘制颜色</param>
        /// <param name="brushcolor">填充颜色</param>
        /// <returns></returns>
        public Image IdenticonsCreate(int width,int height,List<Dictionary<int,int>> lst,Color bgcolor,string pencolor,string brushcolor)
        { 
            int count=lst.Count;
            Image img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.Silver);
            int x=0;
            int y=0;
            int wPix = Convert.ToInt32(width * 0.2);//5x5格式
            int hPix = Convert.ToInt32(height * 0.2);
            Pen pen=new Pen(ColorTranslator.FromHtml(pencolor));
            Brush brush = new SolidBrush(ColorTranslator.FromHtml(brushcolor));

            string json = "";
            for (int i = 0; i < count; i++)
			{
                foreach (var item in lst[i])
                {
                    x = item.Key;
                    y = item.Value;

                    if (x==0||x==1)//方形长度为单位1
	                {
                        g.DrawRectangle(pen,x*wPix,y*hPix,wPix,hPix);
                        //横向 反向
                        g.DrawRectangle(pen, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5
                        //斜向 反向
                        //g.DrawRectangle(pen, (4 - x) * wPix, (4-y) * hPix, wPix, hPix);
                        //填充颜色
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
                        g.FillRectangle(brush, (4 - x) * wPix, y * hPix, wPix, hPix);//5x5

	                }
                    else if (x==2)//长度为 单位1/2
	                {
                        g.DrawRectangle(pen, x * wPix, y * hPix, wPix, hPix);
                        //g.DrawRectangle(pen,x*wPix,y*hPix,wPix/2,hPix);
                        //g.DrawRectangle(pen,
                        g.FillRectangle(brush, x * wPix, y * hPix, wPix, hPix);
	                }

                    json = json+"{" + item.Key.ToString() + "," + item.Value.ToString() + "}|";
                }
            }
            return img;
        }
   
    
    }
}
