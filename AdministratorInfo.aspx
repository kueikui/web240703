<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdministratorInfo.aspx.cs" Inherits="web_1.AdministratorInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
         <h1>管理員資料</h1>

  <asp:Panel ID="Panel1" runat="server">
      <asp:TextBox ID="Search_Text" runat="server"></asp:TextBox>
      <asp:Button ID="search_Btn" runat="server" OnClick="search_Btn_Click" Text="搜尋" />
      &nbsp;<asp:Button ID="show_AllGridView" runat="server" OnClick="show_AllGridView_Click" Text="顯示全部" Visible="False" />
      <br />
      <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <Columns>
              <asp:ButtonField ButtonType="Button" Text="詳細資料" />
          </Columns>
          <EditRowStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#E9E7E2" />
          <SortedAscendingHeaderStyle BackColor="#506C8C" />
          <SortedDescendingCellStyle BackColor="#FFFDF8" />
          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
      </asp:GridView>
  </asp:Panel>
   <!--OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"-->
  <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFCC">
      管理員資料<br /> 管理員編號:&nbsp; &nbsp;
      <asp:Label ID="cId_Text" runat="server"></asp:Label>
      <br />
      管理員姓名:<asp:TextBox ID="cName_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;身分證字號:<asp:TextBox ID="cIdCard_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;性別:&nbsp;&nbsp;<asp:DropDownList ID="cGender_list" runat="server" ReadOnly="True" Enabled="False">
          <asp:ListItem>male</asp:ListItem>
          <asp:ListItem>female</asp:ListItem>
      </asp:DropDownList>
      &nbsp;生日:<asp:TextBox ID="cBirth_Text" runat="server" Width="160px" TextMode="Date" ReadOnly="True"></asp:TextBox>
      <br />
      電話:<asp:TextBox ID="cPhone_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
      &nbsp;通訊地址:
      <asp:TextBox ID="cAddress_Text" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
      &nbsp;<br />
      <br />
  </asp:Panel>
  <asp:Panel ID="Panel3" runat="server" BackColor="#99FFCC" CssClass="panel3">
      負責的長者<br /> 
      <asp:GridView ID="GridView2" runat="server"  OnRowCommand="GridView2_RowCommand">
      </asp:GridView>
      <br /> 
      <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click" />
     
      <asp:Button ID="edit" runat="server" OnClick="edit_Click1" Text="編輯" />
     
      <asp:Button ID="save" runat="server" Text="儲存" OnClick="save_Click" Visible="False" />
      <asp:Button ID="changePW" runat="server" OnClick="changePW_Click" Text="更改密碼" />
  </asp:Panel>
    </main>
</asp:Content>
