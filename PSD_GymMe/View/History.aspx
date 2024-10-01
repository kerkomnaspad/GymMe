<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="PSD_GymMe.View.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/History.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="navbar_customer" runat="server">
            <div class="navbar">
                <div class="navbar-container1">
                    <asp:Button ID="order_btn_cus" class="navbar_link" runat="server" Text="Order Supplement" OnClick="Order_btn_Click" />
                    <asp:Button ID="history_btn_cus" class="navbar_link" runat="server" Text="History" OnClick="History_btn_Click" />
                </div>
                <div class="navbar-container2">
                    <asp:Button ID="home_btn_cus" class="navbar_link" runat="server" Text="Gym Me" OnClick="Home_btn_Click" Style="text-decoration: none" />
                </div>
                <div class="navbar-container3">
                    <asp:Button ID="profile_btn_cus" class="navbar_link" runat="server" Text="Profile" OnClick="Profile_btn_Click" />
                    <asp:Button ID="logout_btn_cus" class="navbar_link" runat="server" Text="Logout" OnClick="Logout_btn_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="navbar_admin" runat="server">
            <div class="navbar">
                <div class="navbar-container1">
                    <asp:Button ID="home_btn" class="navbar_link" runat="server" Text="Home" OnClick="Home_btn_Click" />
                    <asp:Button ID="manage_btn" class="navbar_link" runat="server" Text="Manage Supplement" OnClick="Manage_btn_Click" />
                    <asp:Button ID="queue_btn" class="navbar_link" runat="server" Text="Order Queue" OnClick="Queue_btn_Click" />
                </div>
                <div class="navbar-container2">
                    <asp:Button ID="Button3" class="navbar_link" runat="server" Text="Gym Me" OnClick="Home_btn_Click" Style="text-decoration: none" />
                </div>
                <div class="navbar-container3">
                    <asp:Button ID="profile_btn" class="navbar_link" runat="server" Text="Profile" OnClick="Profile_btn_Click" />
                    <asp:Button ID="report_btn" class="navbar_link" runat="server" Text="Transaction Report" OnClick="Report_btn_Click" />
                    <asp:Button ID="logout_btn" class="navbar_link" runat="server" Text="Logout" OnClick="Logout_btn_Click" />

                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="transaction_list" runat="server">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">

                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" ItemStyle-CssClass="center-column" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" ItemStyle-CssClass="center-column" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate"  ItemStyle-CssClass="center-column" DataFormatString="{0:d MMMM yyyy}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Action" ShowHeader="True" Text="Detail" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />

            </asp:GridView>
        </asp:Panel>

    </form>
</body>
</html>
