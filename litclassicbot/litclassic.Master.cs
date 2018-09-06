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

        }

        protected void LinkButtonMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://litclassic.com");
        }

        //protected void LinkButtonVKPublic_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://vk.com/litclassic");
        //}

        //protected void LinkButtonTelegramBot_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://t.me/litclassicbot");
        //}

        protected void LinkButtonAuthorization_Click(object sender, EventArgs e)
        {

        }
    }
}