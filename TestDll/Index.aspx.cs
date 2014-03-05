using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdenticonsDll;
using System.Drawing;

namespace TestDll
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        IdenticonsDll.IdIcon ic = new IdIcon();

        private void Create()
        {
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
            lst = ic.ListCreate(8);
            System.Drawing.Image img = ic.IdenticonsCreate(200, 200, lst, Color.Silver, "#A87EDF", "#A87EDF");//浅紫色
            Image1.ImageUrl(
            ///    Bitmap bitmap = (Bitmap)img;
            ///    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ///    bitmap.Save(ms, ImageFormat.Png);
            ///    Response.ClearContent();
            ///    Response.ContentType = "image/png";
            ///    Response.BinaryWrite(ms.ToArray());
        }
    }
}