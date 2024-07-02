<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Statistic.aspx.cs" Inherits="web_1.Statistic" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .panel-container {
        }
        .panel-left {
            float:left;
            width:250px;

        }
        .panel-right {
            margin-left:250px;
        }
    </style>
    <main aria-labelledby="title" class="panel-container">
        <div class="panel-left">
            <asp:Panel ID="Panel1" runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>長者ID</asp:ListItem>
                    <asp:ListItem>地點</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Visible="False">
                </asp:DropDownList>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" BackColor="#CCFFFF" Height="70px" Text="Label" Width="205px" style="font-size:40px"></asp:Label>
                <asp:Label ID="Label2" runat="server" BackColor="#66FFFF" Height="70px" Text="Label" Width="100px" style="font-size:40px"></asp:Label>
                <asp:Label ID="Label3" runat="server" BackColor="#FFCCFF" Height="70px" Text="Label" Width="100px" style="font-size:40px"></asp:Label>
            </asp:Panel>
        </div>


        <div class="panel-right">
            <asp:Panel ID="Panel2" runat="server">
                <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" AlternateText="載入失敗" BackColor="FloralWhite" BorderlineWidth="0" Height="250px">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="人數"></asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒次數總紀錄" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" Legend="Legend1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Annotations>
                        <asp:LineAnnotation LineColor="Brown" Name="LineAnnotation2"></asp:LineAnnotation>
                    </Annotations>
                </asp:Chart>
               
                <asp:Chart ID="Chart2" runat="server" OnLoad="Chart2_Load" Height="250px">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="人數"></asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒地點紀錄" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" Legend="Legend1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Annotations>
                        <asp:LineAnnotation LineColor="Brown" Name="LineAnnotation2"></asp:LineAnnotation>
                    </Annotations>
                </asp:Chart>
                <br />
                <asp:Chart ID="Chart3" runat="server" OnLoad="Chart3_Load" Height="250px">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="性別"></asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒男女比" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" Legend="Legend1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Annotations>
                        <asp:LineAnnotation LineColor="Brown" Name="LineAnnotation2"></asp:LineAnnotation>
                    </Annotations>
                </asp:Chart>
                <asp:Chart ID="Chart4" runat="server" OnLoad="Chart4_Load" Height="250px">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="原因"></asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒原因紀錄" />
                    </Titles>
                        <Series>
                        <asp:Series Name="Series1" Legend="Legend1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Annotations>
                        <asp:LineAnnotation LineColor="Brown" Name="LineAnnotation2"></asp:LineAnnotation>
                    </Annotations>
                </asp:Chart>
           </asp:Panel>



            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <asp:Chart ID="Chart5" runat="server" OnLoad="Chart5_Load" Height="250px">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="人數"></asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒次數總紀錄" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            
                <asp:Chart ID="Chart6" runat="server" Height="250px">
                     <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="人數"></asp:Legend>
                   </Legends>
                   <Titles>
                        <asp:Title Text="跌倒地點" />
                   </Titles>
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <br />
                <asp:Chart ID="Chart7" runat="server" Height="250px" OnLoad="Chart4_Load">
                    <Legends>
                        <asp:Legend AutoFitMinFontSize="5" Name="Legend1" Title="原因">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Text="跌倒原因紀錄" />
                    </Titles>
                    <Series>
                        <asp:Series ChartType="Pie" Legend="Legend1" Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Annotations>
                        <asp:LineAnnotation LineColor="Brown" Name="LineAnnotation2">
                        </asp:LineAnnotation>
                    </Annotations>
                </asp:Chart>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <asp:Chart ID="Chart8" runat="server" Height="250px">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Text="room1" />
                    </Titles>
                </asp:Chart>
                <asp:Chart ID="Chart9" runat="server" Height="250px">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Text="room2" />
                    </Titles>
                </asp:Chart>
            </asp:Panel>
        </div>
    </main>
</asp:Content>
