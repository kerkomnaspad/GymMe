<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="PSD_GymMe.View.OrderSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Supplement</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/OrderS.css" />
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

       
        <br />
        <%--<asp:Label ID="Label1" runat="server" Text="User role: ">
                <asp:Label ID="Lbl_user" runat="server"></asp:Label>--%>
        <%--</asp:Label>--%>
        <asp:Panel ID="customer_list" runat="server">
            <asp:GridView ID="GridView1" runat="server"  DataKeyNames="SupplementID"  AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >

                <Columns>
                    <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" Visible="false" ItemStyle-CssClass="center-column"/>
                    <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                    <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" DataFormatString="{0: d MMMM yyyy}" />
                    <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                    <asp:BoundField DataField="SupplementTypeName" HeaderText="Type Name" SortExpression="SupplementTypeName" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb" Visible="true"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
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
        <br />
        <asp:Label ID="Lbl_status" CssClass="success" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Btn_cart" runat="server" Text="Save cart" OnClick="Btn_cart_Click"/>&emsp;&emsp;
        <asp:Button ID="Btn_load" runat="server" Text="Load Cart" OnClick="Btn_load_Click"/>&emsp;&emsp;
        <asp:Button ID="Btn_clear" runat="server" Text="Clear Cart" OnClick="Btn_clear_Click"/>
        <br />
        <br />
        <br />
        <asp:Button ID="Btn_order" runat="server" Text="Order" OnClick="Btn_order_Click" />

    </form>
</body>
</html>
