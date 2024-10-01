<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="PSD_GymMe.View.TransactionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Detail</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/TransactionDetail.css" />
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

        <center>
            <div class="outer-container">
                <div class="container">
                    <div class="inner-container">
                        <asp:Label ID="lbl_sts" runat="server" CssClass="labels"></asp:Label>
                        
                        <asp:Label ID="lbl_tID" CssClass="labels" runat="server"></asp:Label>
                        
                        <%-- <asp:Label ID="lbl_sID" CssClass="labels" runat="server" ></asp:Label><br /><br />
                        <asp:Label ID="lbl_sName" CssClass="labels" runat="server" ></asp:Label><br /><br />

                        <asp:Label ID="lbl_tyID" CssClass="labels" runat="server" Text=""></asp:Label><br /><br />
                        <asp:Label ID="lbl_tName" runat="server" CssClass="labels" Text=""></asp:Label><br /><br />

                        <asp:Label ID="lbl_qty" CssClass="labels" runat="server" ></asp:Label>--%>
                        <center>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="SupplementID" HeaderText="SupplementID" SortExpression="SupplementID" />
                                    <asp:BoundField DataField="SupplementName" HeaderText="SupplementName" SortExpression="SupplementName" />
                                    <asp:BoundField DataField="SupplementTypeID" HeaderText="TypeID" SortExpression="SupplementTypeID" />
                                    <asp:BoundField DataField="SupplementTypeName" HeaderText="SupplementTypeName" SortExpression="SupplementTypeName" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                </Columns>
                            </asp:GridView>
                        </center>

                    </div>
                </div>
            </div>
        </center>

    </form>
</body>
</html>
