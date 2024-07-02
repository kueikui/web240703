using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace web_1.Web
{
    public partial class changePassword : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                if (Session["LoginType"].ToString() == "System")//系統
                {
                    string token_system = Request.QueryString["token"];
                    if (string.IsNullOrEmpty(token_system))
                    {
                        Response.Redirect("Login.aspx");
                    }

                    string email = HttpUtility.UrlDecode(token_system);
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT cAccount FROM CarerLogin WHERE cAccount = @Email";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Email", email);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (!reader.Read())
                        {
                            Response.Redirect("Login.aspx");
                            return;
                        }
                    }
                }
                else if (Session["LoginType"].ToString() == "Home")//居家
                {

                    string token_home = Session["homeAccount"].ToString();
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT homeEmail FROM HomeLogin WHERE homeEmail = @Email";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Email", token_home);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (!reader.Read())
                        {
                            Response.Redirect("Login.aspx");
                            return;
                        }
                    }
                }
            }
        }

        protected void ButtonResetPassword_Click(object sender, EventArgs e)
        {
            if (Session["LoginType"].ToString() == "System")//系統
            {
                string token_system = Request.QueryString["token"];
                if (string.IsNullOrEmpty(token_system))
                {
                    Response.Redirect("Login.aspx");
                }

                string email = HttpUtility.UrlDecode(token_system);
                string newPassword = TextBoxNewPassword.Text.Trim();
                string confirmPassword = TextBoxConfirmPassword.Text.Trim();

                if (newPassword != confirmPassword)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "再次輸入密碼與新密碼不相符";
                    return;
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE CarerLogin SET cPassword = @cPassword WHERE cAccount = @cAccount";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cPassword", newPassword);
                    command.Parameters.AddWithValue("@cAccount", email);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('密碼重置成功'); window.location.href = 'AdministratorInfo.aspx';", true);

                        // 删除会话中的令牌
                        //Session.Remove("ResetEmail");
                    }
                    else
                    {
                        LabelMessage.Visible = true;
                        LabelMessage.Text = "重置密碼時發生錯誤。請再試一次";
                    }

                }
            }
            else if (Session["LoginType"].ToString() == "Home")//居家
            {
                string token_home = Session["homeAccount"].ToString();
                if (string.IsNullOrEmpty(token_home))
                {
                    Response.Redirect("Login.aspx");
                }

                string email = HttpUtility.UrlDecode(token_home);
                string newPassword = TextBoxNewPassword.Text.Trim();
                string confirmPassword = TextBoxConfirmPassword.Text.Trim();

                if (newPassword != confirmPassword)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "再次輸入密碼與新密碼不相符";
                    return;
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE HomeLogin SET homePassword = @homePassword WHERE homeEmail = @homeEmail";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@homePassword", newPassword);
                    command.Parameters.AddWithValue("@homeEmail", email);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('密碼重置成功'); window.location.href = 'WebForm1.aspx';", true);

                        // 删除会话中的令牌
                        //Session.Remove("ResetEmail");
                    }
                    else
                    {
                        LabelMessage.Visible = true;
                        LabelMessage.Text = "重置密碼時發生錯誤。請再試一次";
                    }
                }
            }
        }
    }
}