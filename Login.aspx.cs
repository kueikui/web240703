using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace web_1.Web
{
    public partial class Login : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";
        
        int gap = 0;//gap=0為系統登入 gap=1為居家登入
        protected void Page_Load(object sender, EventArgs e)
        {
            //https://ithelp.ithome.com.tw/articles/10265283?sc=rss.iron
        }


        protected void btnLogin_Click(object sender, EventArgs e)//登入按鈕
        {
            string account = cAccountText.Text.Trim();
            string password = cPasswordText.Text.Trim();
            int gap = Convert.ToInt32(Session["gap"]); // 从会话变量中获取 gap 的值
            if (gap == 0) {//系統登入
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM CarerLogin WHERE cAccount = @Account AND cPassword = @Password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Account", account);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read()){
                    Session["cAccount"] = reader["cAccount"].ToString();
                    Session["userName"] = reader["cId"].ToString();
                    Session["LoginType"] = "System";
                    Response.Redirect("WebForm1.aspx");
                }
                else{
                    Label1.Visible = true;
                    Label1.Text = "帳號或密碼不正確";
                }
                reader.Close();
                connection.Close();
            }
            else if (gap == 1){//居家登入
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM HomeLogin WHERE homeEmail = @homeEmail AND homePassword = @homePassword";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@homeEmail", account);
                command.Parameters.AddWithValue("@homePassword", password);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Session["homeAccount"] = reader["homeEmail"].ToString();
                    Session["userName"] = reader["homeName"].ToString() ;
                    Session["LoginType"] = "Home";
                    Response.Redirect("WebForm1.aspx");
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "帳號或密碼不正確";
                }
                reader.Close();
                connection.Close();
            }
        }
        protected void btnSign_Click(object sender, EventArgs e)//註冊按鈕
        {
            string homeName = signup_name.Text.Trim();
            string homeEmail = signup_account.Text.Trim();
            string homePassword = signup_password.Text.Trim();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM HomeLogin WHERE homeEmail = @Email AND homePassword = @Password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", homeEmail);
            command.Parameters.AddWithValue("@Password", homePassword);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())//已註冊
            {
                Label2.Visible = true;
                Label2.Text = "帳號已註冊";
                reader.Close();
                connection.Close();
            }
            else//先判對有沒有在系統登入的帳密組中
            {
                connection.Close();
                connection.Open();
                query = "SELECT * FROM CarerLogin WHERE cAccount = @cAccount AND cPassword = @cPassword";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@cAccount", homeEmail);
                command.Parameters.AddWithValue("@cPassword", homePassword);
                reader = command.ExecuteReader();

                if (reader.Read())//已註冊
                {
                    Label2.Visible = true;
                    Label2.Text = "帳號已註冊";
                    reader.Close();
                    connection.Close();
                }
                else//尚未註冊
                {
                    connection.Close();
                    connection.Open();
                    query = "INSERT INTO HomeLogin (homeName, homeEmail, homePassword) VALUES (@homeName, @homeEmail, @homePassword)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@homeName", signup_name.Text);
                    command.Parameters.AddWithValue("@homeEmail", signup_account.Text);
                    command.Parameters.AddWithValue("@homePassword", signup_password.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    Label2.Visible = true;
                    Label2.Text = "註冊成功";
                    signup_account.Text = "";
                    signup_name.Text = "";
                    signup_password.Text = "";
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)//系統登入
        {
            Session["gap"] = 0;
            sign_up.Visible = false;
            Panel1.Visible=true; 
            Panel2.Visible=false; 
            Panel4.Visible=false;
            
            Button1.BackColor = System.Drawing.Color.Aqua;
            Button2.BackColor = System.Drawing.Color.LightBlue;
            signup_name.Text = "";
            signup_account.Text = "";
            signup_password.Text = "";
            Label1.Visible = false;
            cAccountText.Text = "";
            cPasswordText.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)//居家登入
        {
            Session["gap"] = 1;
            sign_up.Visible = true;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel4.Visible = false;
            Button2.BackColor = System.Drawing.Color.Aqua;
            Button1.BackColor = System.Drawing.Color.LightBlue;
            signup_name.Text = "";
            signup_account.Text = "";
            signup_password.Text = "";
            Label1.Visible = false;
            cAccountText.Text = "";
            cPasswordText.Text = "";
        }

        protected void sign_up_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel4.Visible = false;
        }

        protected void forget_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            Panel1.Visible = false;   
        }
        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            // 自定義電子郵件內容
            e.Message.Body = "Dear User,\n\nPlease use the following link to reset your password:\n" + e.Message.Body;
        }
        protected void PasswordRecovery1_VerifyingUser(object sender, LoginCancelEventArgs e)
        {
            PasswordRecovery recovery = (PasswordRecovery)sender;
            string email = recovery.UserName;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM HomeLogin WHERE homeEmail = @homeEmail";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@homeEmail", email);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    // 如果電子郵件地址不存在，取消恢復密碼過程
                    e.Cancel = true;
                    Label3.Text = "電子郵件地址不存在。";
                    Label3.Visible = true;
                }
                else
                {
                    SendPasswordRecoveryEmail(email);
                }
                reader.Close();
            }
        }
        private void SendPasswordRecoveryEmail(string email)//https://www.gmass.co/blog/gmail-smtp/
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            string smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
            string smtpPass = ConfigurationManager.AppSettings["SmtpPass"];

            // 生成验证令牌
            string token = email;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add(email);
            mail.Subject = "全方位守護者 重新設定密碼";
            mail.Body = "您好!\n\n請點擊下方連結重新設定密碼:\n" +
                        "https://localhost:44313/Web/ForgetPass.aspx?token=" + token;//33061
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mail);
                Session["Email"] = "Email";
                Label3.Text = "An email with instructions to reset your password has been sent to you.";
                Label3.Visible = true;
            }
            catch (Exception ex)
            {
                Label3.Text = "Failed to send email. Please try again later.";
                Label3.Visible = true;
                Console.WriteLine("Exception: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
        }

       
    }






} //if (TextBox1.Text == "123" & TextBox2.Text == "123")
            //{
            //    Response.Cookies["u_name"].Value = "123";

            //    Response.Cookies["Login"].Value = "OK";
            //    Response.Cookies["Login"].Expires = DateTime.Now.AddDays(30);
            //    //登入成功，這個Cookie的期限是三十天內都有效！
            //}

            //Response.Redirect("Cookie_Login_end.aspx");
            //登入後，不管帳號密碼對不對，都會到下一個網頁。
            //帳號密碼正確的人，下一頁會看見正確訊息！
            //帳號密碼錯誤的人，下一頁會看見錯誤訊息。
        //    protected void Page_Load(object sender, EventArgs e)
        //{
        //    GenerateCaptcha();
        //}

       
        //protected void btnRefreshCaptcha_Click(object sender, EventArgs e)
        //{
        //    // 刷新驗證碼
        //    GenerateCaptcha();
        //}

        //private void GenerateCaptcha()
        //{
        //    // 生成隨機驗證碼
        //    string captcha = GenerateRandomCode();

        //    // 將驗證碼存入Session，以便在驗證時使用
        //    Session["Captcha"] = captcha;

        //    // 產生圖片並顯示驗證碼
        //    imgCaptcha.ImageUrl = "GenerateCaptchaImage.ashx?code=" + captcha;
        //}

        //private string GenerateRandomCode()
        //{
        //    // 生成4位隨機數字驗證碼
        //    Random random = new Random();
        //    string chars = "0123456789";
        //    string code = "";
        //    for (int i = 0; i < 4; i++)
        //    {
        //        code += chars[random.Next(chars.Length)];
        //    }
        //    return code;
        //}