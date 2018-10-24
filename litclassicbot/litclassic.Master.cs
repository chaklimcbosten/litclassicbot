using litclassicbot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace litclassicbot
{
    public partial class litclassic : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["litclassic-cookie"]["last-visit"] = DateTime.Now.ToString();
            Response.Cookies["litclassic-cookie"].Expires = DateTime.Now.AddYears(3);
        }
    }
}