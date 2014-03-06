using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdenticonsDll;

namespace TestDll
{
    public partial class lst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write(GetJson());
            }
        }
        IdenticonsDll.IdIcon ic = new IdIcon();
        public string GetJson()
        {
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
            lst = ic.ListCreate(8);//8个
            string json = ic.LstTjson(lst);
            return json;
        }

    }
}