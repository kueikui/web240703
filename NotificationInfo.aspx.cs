using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace web_1
{
    public partial class NotificationInfo : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["ShowPanel"] != null && (bool)Session["ShowPanel"] == true)
            {
                Panel1.Visible = true;
                // 清除會話狀態，以便下次進入該頁面時不再顯示Panel1
                //Session["ShowPanel"] = false;
            }
            else
            {
                Panel1.Visible = false;
            }
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Session["ShowPanel"] = false;
        }

        protected void BindGridView()
        {
            if (Session["LoginType"] == "System")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT Fall.fId as 跌倒編號,Fall.eId as 長者編號,Elder.eName as 長者姓名 ,Fall.pId as 跌倒地點,Fall.fTime as 跌倒時間, Fall.fWhy as 跌倒原因 ,Fall.hId as 送醫 FROM Fall " +
                           "INNER JOIN Elder ON Fall.eId = Elder.eId";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;

                GridView1.DataBind();
                GridView1.Visible = true;
                connection.Close();
            }
            else if (Session["LoginType"] == "Home")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT HomeElderFall.hfId as 跌倒編號,HomeElderFall.heId as 長者編號,HomeElder.heName as 長者姓名 ,HomeElderFall.pId as 跌倒地點,HomeElderFall.hfTime as 跌倒時間, HomeElderFall.hfWhy as 跌倒原因 ,HomeElderFall.hId as 送醫 FROM HomeElderFall " +
                           "INNER JOIN HomeElder ON HomeElderFall.heId = HomeElder.heId";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;

                GridView1.DataBind();
                GridView1.Visible = true;
                connection.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}