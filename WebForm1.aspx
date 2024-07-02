<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.cs" Inherits="web_1.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
        body, html {
            margin: 0;
            padding: 0;
            overflow: hidden;
            align-content:center;
        }
        .wrapper {
             display: grid;
             width:2500px;
             grid-template-rows: 2fr 5fr; 
             grid-template-columns: 1fr 5fr;
        }
        #button{
            float:left;
            width:500px;
            background-color:antiquewhite;
        }
        #alert{
            float:right;
            width:50px;
            height:40px;
            background-color:aquamarine;
        }

</style>
    <main aria-labelledby="title"> 
        <div class="wrapper">
            <div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/螢幕擷取畫面 2024-03-19 122535.png" Width="100%" />
            </div>
            <div> 
                <asp:Label ID="Label1" runat="server" Text="123"></asp:Label>
                <br />
                <video id="videoPlayer" runat="server" width="320" height="240" controls>
                    <source id="videoSource" runat="server"  src="tes.mp4" type="video/mp4">Your browser does not support the video tag.
                </video>
            </div>
            <div class="button">
                <table style="border:none">
                    <tr>
                        <td><asp:Button ID="Button1" runat="server" Text="一樓走廊-1" Width="100px" OnClick="Button1_Click"  /></td>
                        <td><asp:Button ID="Button2" runat="server" Text="一樓走廊-2" Width="100px" OnClick="Button2_Click" /></td>
                        <td><asp:Button ID="Button7" runat="server" Text="廚房" Width="100px" OnClick="Button7_Click" /></td>
                    </tr>
                    <tr>
                        <td> <asp:Button ID="Button8" runat="server" Text="客廳" Width="100px" OnClick="Button8_Click" /></td>
                        <td><asp:Button ID="Button9" runat="server" Text="玄關" Width="100px" OnClick="Button9_Click" /></td>
                        <td> <asp:Button ID="Button10" runat="server" Text="飯廳" Width="100px" OnClick="Button10_Click" /></td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="Button11" runat="server" Text="Button" OnClick="Button11_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server" class="alert" Visible="false" BackColor="#FF5050" ForeColor="White" Height="160px" Width="300px">
                在一樓走廊發生跌倒事件<br /> 請立即派人前往救助<br /> 請至通報系統填寫資料<br /> &nbsp;<asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="事件完成" OnClientClick="return confirm('確任通報單填寫完畢，要關閉視窗嗎？');" />
            </asp:Panel>
        </div>
    </main>
</asp:Content>