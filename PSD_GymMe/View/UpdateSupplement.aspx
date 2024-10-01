<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="PSD_GymMe.View.UpdateSupplement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Supplement</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/InsertUpdateS.css" />
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
        <div class="outer-container">
            <div class="container">
                <div class="inner-container">

                    <div id="title">
                        <center>
                            Update Supplement
                            <br />
                            <br />
                        </center>
                    </div>


                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_name" runat="server" Text="Supplement Name:"></asp:Label>
                        <asp:TextBox ID="Txt_name" runat="server" CssClass="tb1"></asp:TextBox>

                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_DOB"  CssClass="lbl2" runat="server" Text="Expiry Date (DD/MM/YY): "></asp:Label>
                        <asp:TextBox ID="Txt_DD" runat="server"></asp:TextBox>/
                        <asp:TextBox ID="Txt_MM" runat="server"></asp:TextBox>/
                        <asp:TextBox ID="Txt_YY" runat="server"></asp:TextBox>
                        <%--pake calendar??????????????--%>
                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_price" runat="server" Text="Supplement Price:"></asp:Label>
                        <asp:TextBox ID="Txt_price" runat="server" CssClass="tb3"></asp:TextBox>

                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_typeID" runat="server" Text="Supplement Type ID:"></asp:Label>
                        <asp:TextBox ID="Txt_typeID" runat="server" CssClass="tb4"></asp:TextBox>

                    </div>


                    <div>
                        <asp:Label ID="Lbl_error" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Lbl_scs" CssClass="success" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div style="align-self: center">
                        <asp:Button ID="Btn_update" runat="server" Text="Update" OnClick="Btn_update_Click" />
                    </div>


                </div>
            </div>
        </div>
    </form>
</body>
</html>
