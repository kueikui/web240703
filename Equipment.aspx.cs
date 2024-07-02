using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_1
{
    public partial class Equipment : System.Web.UI.Page
    {
        private static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Equipment";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
            connection.Close();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)//畫面
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[Index];

            if (e.CommandName == "View")
            {
                string cameraID = selectedRow.Cells[Index].Text;
                Response.Redirect($"WebForm1.aspx?CameraID={cameraID}");
            }
        }
    }
}