using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using litclassicbot.Classes;

namespace litclassicbot
{
    public partial class Reader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageSetting();
        }


        private void PageSetting()
        {
            if (Request.Browser.Cookies)
            {
                Response.Cookies["litclassic-cookie"]["last-visit"] = DateTime.Now.ToString();
                Response.Cookies["litclassic-cookie"].Expires = DateTime.Now.AddYears(3);
            }
        }
    }
}