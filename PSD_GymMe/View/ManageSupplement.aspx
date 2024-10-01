<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="PSD_GymMe.View.ManageSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Supplement</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/ManageS.css" />
</head>
<body>
    <form id="form1" runat="server">

        

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
        <br />
        
        <asp:Panel ID="customer_list" runat="server">
            <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing1" OnRowDeleting="GridView1_RowDeleting1" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">

                <Columns>
                    <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                    <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                    <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" DataFormatString="{0:d MMMM yyyy}" />
                    <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                    <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                    <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
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

        <div>
            <asp:Button ID="Btn_insert" runat="server" Text="Insert" OnClick="Btn_insert_Click" />
        </div>
    </form>
</body>
</html>
