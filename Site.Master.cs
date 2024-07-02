using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] != null)
                {
                    welcomeMessage.InnerText = "您好, " + Session["userName"].ToString();
                }

                if( Session["LoginType"] != null && Session["LoginType"].ToString() == "Home")//居家登入權限
                {
                    FindControl("adminPage").Visible = false;
                    FindControl("changepwPage").Visible = true;
                }
                else if (Session["LoginType"] != null && Session["LoginType"].ToString() == "System")//系統登入權限
                {
                    FindControl("adminPage").Visible = true;
                    FindControl("changepwPage").Visible = false;
                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}