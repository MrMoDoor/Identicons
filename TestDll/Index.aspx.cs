using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdenticonsDll;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestDll
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Create();
            
        }
        IdenticonsDll.IdIcon ic = new IdIcon();

        private void Create()
        {
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
            string json = ic.LstTjson(lst);

            lst = ic.ListCreate(8);
            System.Drawing.Image img = ic.IdenticonsCreate(200, 200, lst, Color.Silver, "#A87EDF", "#A87EDF");//浅紫色
            //怎么将image直接显示在控件上呢
            
            //Image1.ImageUrl(
            Bitmap bitmap = (Bitmap)img;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
            //Label1.Text = json;
        }
    }
}