using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace web_1.Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                // 初始化影片
                videoPlayer.Attributes["src"] = "video1.mp4";

                string token = Request.QueryString["token"];
                if (string.IsNullOrEmpty(token)){
                    Response.Redirect("Login.aspx");
                }
                
                string email = HttpUtility.UrlDecode(token);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT homeEmail FROM HomeLogin WHERE homeEmail = @Email";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        Response.Redirect("Login.aspx");
                        return;
                    }

                    // 将邮箱地址存储到会话中
                    Session["ResetEmail"] = email;
                }
                //if (string.IsNullOrEmpty(token))
                //{
                //    Console.WriteLine("Token is missing in the query string.");
                //    Response.Redirect("Login.aspx");
                //    return;
                //}

                //if (Session[token] == null)//卡在這裡
                //{
                //    Console.WriteLine("Token is not found in the session.");
                //    Response.Redirect("Login.aspx");
                //    return;
                //}

                //Console.WriteLine("Token found: " + token);
            }
        }
        protected void Chart1_Load(object sender, EventArgs e)
        {
            //string connectionString = "your_connection_string";
            string query = "SELECT f.fTime, e.eGender, COUNT(f.fId) AS FallCount FROM Elder e JOIN Fall f ON e.eId = f.eId GROUP BY f.fTime, e.eGender ORDER BY f.fTime, e.eGender";

            DataTable dt = new DataTable();

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);


            Chart1.Series.Clear();
            Series maleSeries = new Series("男性");
            maleSeries.ChartType = SeriesChartType.Column;
            maleSeries.Color = System.Drawing.Color.Blue;

            Series femaleSeries = new Series("女性");
            femaleSeries.ChartType = SeriesChartType.Column;
            femaleSeries.Color = System.Drawing.Color.Pink;

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["fTime"]);
                string gender = row["eGender"].ToString();
                int fallCount = Convert.ToInt32(row["FallCount"]);

                if (gender == "male")
                {
                    maleSeries.Points.AddXY(date, fallCount);
                }
                else if (gender == "female")
                {
                    femaleSeries.Points.AddXY(date, fallCount);
                }
            }

            Chart1.Series.Add(maleSeries);
            Chart1.Series.Add(femaleSeries);

            Chart1.ChartAreas[0].AxisX.Title = "日期";
            Chart1.ChartAreas[0].AxisY.Title = "跌倒次數";
            Chart1.Titles[0].Text = "每日男女跌倒次數比較";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test.mp4";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "test.mp4";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            videoPlayer.Attributes["src"] = "123.mp4";
        }

        //protected void ButtonResetPassword_Click(object sender, EventArgs e)
        //{
        //    //string token = Request.QueryString["token"];
        //    string email = Session["ResetEmail"] as string;
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        LabelMessage.Visible = true;
        //        LabelMessage.Text = "Invalid token.";
        //        return;
        //    }

        //    string newPassword = TextBoxNewPassword.Text.Trim();
        //    string confirmPassword = TextBoxConfirmPassword.Text.Trim();

        //    if (newPassword != confirmPassword)
        //    {
        //        LabelMessage.Visible = true;
        //        LabelMessage.Text = "Passwords do not match.";
        //        return;
        //    }
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "UPDATE HomeLogin SET homePassword = @homePassword WHERE homeEmail = @homeEmail";
        //        MySqlCommand command = new MySqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@homePassword", newPassword);
        //        command.Parameters.AddWithValue("@homeEmail", email);
        //        int result = command.ExecuteNonQuery();

        //        if (result > 0)
        //        {
        //            LabelMessage.Visible = true;
        //            LabelMessage.Text = "Password reset successfully.";
        //            // 删除会话中的令牌
        //            Session.Remove("ResetEmail");
        //        }
        //        else
        //        {
        //            LabelMessage.Visible = true;
        //            LabelMessage.Text = "Error resetting password. Please try again.";
        //        }
        //    }
        //}
    }
}