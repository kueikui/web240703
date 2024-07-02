<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="web_1.Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Session最常用在會員登入的身分檢查上面</title>
    <style type="text/css">
    .auto-style1 {
        background-color: #FFFF00;
    }
    .auto-style2 {
        color: #FF3300;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
       


     <asp:Panel ID="ChartPanel" runat="server"></asp:Panel>


        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" AlternateText="載入失敗" BackColor="FloralWhite" BorderlineWidth="0" Height="250px" Width="500px">
    <Legends>
        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="性別"></asp:Legend>
    </Legends>
    <Titles>
        <asp:Title Text="男女跌倒次數比較" />
    </Titles>
    <Series>
        <asp:Series Name="Series1" Legend="Legend1" ChartType="Column"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>
        <div>
            <video id="videoPlayer" width="600" controls runat="server">
                <source src="123.mp4" type="video/mp4" />
                Your browser does not support the video tag.
            </video>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Video 1" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Video 2" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Video 3" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
