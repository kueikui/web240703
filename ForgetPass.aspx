<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="web_1.Web.ForgetPass1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title>
    <style>
    .container {
        width: 400px;
        margin: 0px auto;
        margin-top:100px;
        text-align: center;
        padding: 20px;
        border: 1px solid #ccc;
        border-bottom-left-radius: 0;
        border-bottom-right-radius: 0;
    }

    .login-btn {
        background-color: #4CAF50;
        border: none;
        color: white;
        padding: 12px 24px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        border-radius: 7px;
        margin-right: 10px;
    }

    h2 {
        background-color: #0077b6;
        color: white;
        text-align: center;
        padding: 10px 20px;
        display: inline-block;
        border-radius: 20px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
             <h2>輸入您的密碼</h2><br />
              <div class="form-container">
                <asp:Label ID="LabelMessage" runat="server" Visible="False" ForeColor="#FF5050"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="請輸入密碼:"></asp:Label>
                <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="再次輸入密碼:"></asp:Label>
                <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <div class="login-container">
                    <asp:Button ID="ButtonResetPassword" runat="server" Text="確定" OnClick="ButtonResetPassword_Click" CssClass="login-btn" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
