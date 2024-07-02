<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ElderlyInfo.aspx.cs" Inherits="web_1.ElderlyInfo" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <main aria-labelledby="title">
          <h1>長者資料</h1>
    <asp:Panel ID="Panel1" runat="server">新增一筆資料<asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="新增" />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Search_Text" runat="server"></asp:TextBox>

        <asp:Button ID="search_Btn" runat="server" Text="搜尋編號" OnClick="search_Btn_Click" />
        <asp:Button ID="show_AllGridView" runat="server" Text="顯示全部" OnClick="show_AllGridView_Click" Visible="False" />
        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" EnableSortingAndPagingCallbacks="True" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="基本資料" CommandName="Details"/>
                <asp:ButtonField Text="跌倒資料" CommandName="Fall" ButtonType="Button"/>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFCC" style="width:100%;" Visible="False">
        長者資料
        <table style="width:100%; box-sizing:border-box;">
            <tr>
                <td class="auto-style4">長者編號:<asp:Label ID="eId_Lebel" runat="server"></asp:Label>
                    <asp:TextBox ID="eId_Text" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style5"><asp:Label ID="cId_Label" runat="server" Text="管理員編號:"></asp:Label><asp:TextBox ID="cId_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                    
                    <asp:DropDownList ID="cId_list" runat="server" OnSelectedIndexChanged="cId_list_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td><asp:Label ID="pId_Label" runat="server" Text="房號:"></asp:Label><asp:TextBox ID="pId_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                    <asp:DropDownList ID="pId_list" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">長者姓名:<asp:TextBox ID="eName_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style5">身分證字號:<asp:TextBox ID="eIdCard_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>性別:<asp:DropDownList ID="eGender_list" runat="server" Enabled="False">
                    <asp:ListItem>male</asp:ListItem>
                    <asp:ListItem>female</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="height: 37px">生日:<asp:TextBox ID="eBirth_Text" runat="server" Width="160px" TextMode="Date" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style5" style="height: 37px">電話:<asp:TextBox ID="ePhone_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 37px">通訊地址:
                    <asp:TextBox ID="eAddress_Text" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"> 身高:<asp:TextBox ID="eHeight_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style5">體重:<asp:TextBox ID="eWeight_Text" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="createFile_Label" runat="server" Text="建檔日期:"></asp:Label>
                    <asp:TextBox ID="eCreateFile_Text" runat="server" TextMode="Date" Width="160px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr> 
        </table>
        <asp:Button ID="Home_back" runat="server" Text="返回" OnClick="Home_back_Click" Visible="False" />
        <asp:Button ID="Add_cancel" runat="server" OnClick="Add_cancel_Click" Text="取消新增" Visible="False" />
        <asp:Button ID="Add_check" runat="server" OnClick="Add_check_Click" Text="新增" Visible="False" />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <asp:RequiredFieldValidator ID="Required_eId" runat="server" ControlToValidate="eId_Text" ErrorMessage="長者編號不得為空" ForeColor="#FF3300" Enabled="False"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="Required_eName" runat="server" ControlToValidate="eName_Text" ErrorMessage="長者姓名不得為空" ForeColor="#FF3300" Enabled="False"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="Required_eBirth" runat="server" ControlToValidate="eBirth_Text" ErrorMessage="長者生日不得為空" ForeColor="#FF3300" Enabled="False"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="Required_eIdCard" runat="server" ControlToValidate="eIdCard_Text" ErrorMessage="長者身分證不得為空" ForeColor="#FF3300" Enabled="False"></asp:RequiredFieldValidator>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" BackColor="#CCFFCC" Visible="False">
        家屬資料<br /> 家屬姓名:<asp:TextBox ID="rName_Text" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp; 身分證字號:<asp:TextBox ID="rIdCard_Text" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp;&nbsp; 性別:<asp:DropDownList ID="rGender_list" runat="server" Enabled="False">
            <asp:ListItem>male</asp:ListItem>
            <asp:ListItem>female</asp:ListItem>
        </asp:DropDownList>
        <br />
        電&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 話:<asp:TextBox ID="rPhone_Text" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp; 通 訊 地 址 :<asp:TextBox ID="rAddress_Text" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 作:<asp:TextBox ID="rJob_Text" runat="server" ReadOnly="True"></asp:TextBox>
        &nbsp; 工 作 地 點 :<asp:TextBox ID="rWorkPlace_Text" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="back" runat="server" Text="返回" OnClick="back_Click"/>
        <asp:Button ID="edit" runat="server" Text="編輯" OnClick="edit_Click"/>
        <asp:Button ID="save" runat="server" Text="儲存" OnClick="save_Click" Visible="False" />
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <asp:RequiredFieldValidator ID="Required_rName" runat="server" ControlToValidate="rName_Text" Enabled="False" ErrorMessage="家屬姓名不可為空" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="Required_rPhone" runat="server" ControlToValidate="rName_Text" Enabled="False" ErrorMessage="家屬電話不可為空" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </asp:Panel> 
    <asp:Panel ID="Panel4" runat="server" BackColor="#FFCCCC" Visible="False">
        <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="編輯" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="FDetail_back" runat="server" Text="返回" OnClick="FDetail_back_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" BackColor="#CCCCFF" Visible="False">
        跌倒編號:
        <asp:Label ID="fId_Label" runat="server" Text=""></asp:Label>
        <br />
        長者編號:&nbsp;&nbsp;<asp:Label ID="feId_Label" runat="server" Text=""></asp:Label>
        &nbsp;長者姓名:
        <asp:TextBox ID="feName_Text" runat="server"></asp:TextBox>
        <br />
        跌倒時間:&nbsp;<asp:TextBox ID="fTime_Text" runat="server"></asp:TextBox>
        &nbsp; 跌倒地點:
        <asp:TextBox ID="fPlace_Text" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <br />
        送&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 醫:
        <asp:TextBox ID="fHospital_Text" runat="server"></asp:TextBox>
        <br />
        跌倒原因:&nbsp;<asp:TextBox ID="fWhy_Text" runat="server" TextMode="MultiLine"></asp:TextBox>
        &nbsp;<br />
        <asp:Button ID="Fback" runat="server" OnClick="Fback_Click" Text="返回" />
        <asp:Button ID="Fedit" runat="server" OnClick="Fedit_Click" Text="編輯" />
        <asp:Button ID="Fsave" runat="server" OnClick="Fsave_Click" Text="儲存" Visible="False" />
    </asp:Panel>
    </main>
   
</asp:Content>