using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_1
{
    public partial class AdministratorInfo : System.Web.UI.Page
    {
        static string connectionString = "server=203.64.84.154;database=care;uid=root;password=Topic@2024;port = 33061";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cAccount"] == null && Session["homeAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            BindGridView();
            if (!IsPostBack)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
        }
        protected void BindGridView()//gridview elder
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            string query = "SELECT Carer.cId as 管理員編號,Carer.cName as 管理員姓名,Carer.cGender as 管理員性別,Carer.cBirth as 管理員生日,Carer.cIdCard as 管理員身分證,Carer.cPhone as 管理員電話,Carer.cAddress as 管理員住所地址,Carer.cSalary as 管理員薪水 FROM Carer";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
            connection.Close();
        }
        protected void edit_Click1(object sender, EventArgs e)//編輯
        {
            edit.Visible = false;
            save.Visible = true;
            cName_Text.ReadOnly = false;
            cIdCard_Text.ReadOnly = false;
            cGender_list.Enabled = true;
            //cBirth_Text.ReadOnly = false;
            cPhone_Text.ReadOnly = false;
            cAddress_Text.ReadOnly = false;
        }

        protected void save_Click(object sender, EventArgs e)//儲存
        {
            edit.Visible = true;
            save.Visible = false;
            cName_Text.ReadOnly = true;
            cIdCard_Text.ReadOnly = true;
            cGender_list.Enabled = false;
            cBirth_Text.ReadOnly = true;
            cPhone_Text.ReadOnly = true;
            cAddress_Text.ReadOnly = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('儲存成功');", true);
        }
        protected void back_Click(object sender, EventArgs e)//返回
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            edit.Visible = true;
            save.Visible = false;
            cId_Text.Text = "";
            cName_Text.Text = "";
            cIdCard_Text.Text = "";
            //cGender_list.Text = "";
            cBirth_Text.Text = "";
            cPhone_Text.Text = "";
            cAddress_Text.Text = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)//管理員詳細資料
        {
            // 获取选定的行的索引
            int Index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[Index];

            TableCell cIdCell = selectedRow.Cells[1];
            TableCell cNameCell = selectedRow.Cells[2];
            TableCell cGenderCell = selectedRow.Cells[3];
            TableCell cBirthCell = selectedRow.Cells[4];
            TableCell cIdCardCell = selectedRow.Cells[5];
            TableCell cPhoneCell = selectedRow.Cells[6];
            TableCell cAddressCell = selectedRow.Cells[7];

            cId_Text.Text = cIdCell.Text;
            cName_Text.Text = cNameCell.Text;
            cGender_list.Text = cGenderCell.Text;
            cBirth_Text.Text =  Convert.ToDateTime(cBirthCell.Text).ToString("yyyy-MM-dd");
            cIdCard_Text.Text = cIdCardCell.Text;
            cPhone_Text.Text = cPhoneCell.Text;
            cAddress_Text.Text = cAddressCell.Text;

            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel1.Visible = false;
            GridView2_RowCommand(sender, e);
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)//管理員負責長者
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT Elder.eId, Elder.eName, Elder.eGender, Elder.pId, Elder.cId FROM Elder, Carer WHERE Elder.cId = Carer.cId AND Carer.cId = @cId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cId", cId_Text.Text);

            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            GridView2.DataSource = dt;
            GridView2.DataBind();
            
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//取得點擊這列的id

            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionStrings的name"].ConnectionString;
            SqlConnection Connection = new SqlConnection(get);

            SqlCommand command = new SqlCommand($"DELETE  FROM Carer WHERE   (id = {id}) ", Connection);
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
            Response.Redirect(Request.Url.ToString());
        }

        protected void search_Btn_Click(object sender, EventArgs e)
        {
            if (Search_Text.Text == "")
            {
                return;
            }
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT Carer.cId as 管理員編號,Carer.cName as 管理員姓名,Carer.cGender as 管理員性別,Carer.cBirth as 管理員生日,Carer.cIdCard as 管理員身分證,Carer.cPhone as 管理員電話,Carer.cAddress as 管理員住所地址,Carer.cSalary as 管理員薪水 FROM Carer WHERE cId=@cId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@cId", Search_Text.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
            connection.Close();

            show_AllGridView.Visible = true;
        }

        protected void show_AllGridView_Click(object sender, EventArgs e)
        {
            show_AllGridView.Visible = false;
            BindGridView();
        }

        protected void changePW_Click(object sender, EventArgs e)
        {
            string token = Session["cAccount"].ToString();
            //Response.Redirect("changePassword.aspx");

            string url = "changePassword.aspx?token=" + HttpUtility.UrlEncode(token);
            Response.Redirect(url);
        }



        /*新增 修改
          protected void Button1_Click(object sender, EventArgs e)//新增
        {
            
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\二上\\網二\\20221102\\" +
                                                   "MS_SQL_2017\\SQL_DB\\MS_SQL_2012\\northwnd.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) " +
                                            "values(@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)", conn);
            try
            {
                cmd.Parameters.Add("@CustomerID", SqlDbType.NChar, 5).Value = TextBox1.Text;
                cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40).Value = TextBox2.Text;
                cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar, 30).Value = TextBox3.Text;
                cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar, 30).Value = TextBox4.Text;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 60).Value = TextBox5.Text;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar, 15).Value = TextBox6.Text;
                cmd.Parameters.Add("@Region", SqlDbType.NVarChar, 15).Value = TextBox7.Text;
                cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 10).Value = TextBox8.Text;
                cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value = TextBox9.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 24).Value = TextBox10.Text;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar, 24).Value = TextBox11.Text;
                int rows = cmd.ExecuteNonQuery();//ExecuteNonQuery 來執行 INSERT 陳述式，以將記錄插入資料庫。

                Label1.Text = string.Format("新增產品資料記錄{0}筆成功！", rows);


                Show();
            }
            catch (Exception ex)
            {
                Label1.Text = "已有此Customer資料";  //顯示錯誤訊息
            }

            cmd.Cancel();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)//修改
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\二上\\網二\\20221102\\" +
                                                   "MS_SQL_2017\\SQL_DB\\MS_SQL_2012\\northwnd.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update Customers Set CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle,Address=@Address," +
                                            "City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax Where CustomerID=@CustomerID", conn);
            try
            {
                cmd.Parameters.Add("@CustomerID", SqlDbType.NChar, 5).Value = TextBox1.Text;
                cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40).Value = TextBox2.Text;
                cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar, 30).Value = TextBox3.Text;
                cmd.Parameters.Add("@ContactTitle", SqlDbType.NVarChar, 30).Value = TextBox4.Text;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 60).Value = TextBox5.Text;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar, 15).Value = TextBox6.Text;
                cmd.Parameters.Add("@Region", SqlDbType.NVarChar, 15).Value = TextBox7.Text;
                cmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 10).Value = TextBox8.Text;
                cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 15).Value = TextBox9.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 24).Value = TextBox10.Text;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar, 24).Value = TextBox11.Text;
                int rows = cmd.ExecuteNonQuery();

                Label1.Text = string.Format("修改產品資料記錄{0}筆成功！", rows);
                Show();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();  //顯示錯誤訊息
            }

            cmd.Cancel();
            conn.Close();
        }
        
        protected void Show()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\二上\\網二\\20221102\\" +
                                                   "MS_SQL_2017\\SQL_DB\\MS_SQL_2012\\northwnd.mdf;Integrated Security=True;Connect Timeout=30");
            //連接資料庫字串
            conn.Open();

            SqlCommand cmd = new SqlCommand("select *from Customers", conn);
            //SqlCommand:select、Insert、Delete、Update
            SqlDataReader dr = cmd.ExecuteReader();//把查詢結果讀出


            GridView1.DataSource = dr;
            GridView1.DataBind();  //資料繫結


            cmd.Cancel();
            dr.Close();
            conn.Close();
        }

         */





    }
}