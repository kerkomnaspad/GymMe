<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PSD_GymMe.View.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile page</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/Profile.css" />
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
        <div class="outer-container">
            <div class="container">
                <div class="inner-container">

                    <div class="title">
                        Profile Page
                            <br />
                        <br />

                    </div>


                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Username" runat="server" Text="Username:"></asp:Label>
                        <asp:TextBox ID="Txt_Username" runat="server" CssClass="tb1"></asp:TextBox>

                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Email" runat="server" Text="Email:"></asp:Label>
                        <asp:TextBox ID="Txt_Email" runat="server" CssClass="tb2"></asp:TextBox>

                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
                        <asp:RadioButtonList ID="RBtn_Gender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>

                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth (DD/MM/YY): "></asp:Label>
                        <asp:TextBox ID="Txt_DD" runat="server"></asp:TextBox>/
                    <asp:TextBox ID="Txt_MM" runat="server"></asp:TextBox>/
                    <asp:TextBox ID="Txt_YY" runat="server"></asp:TextBox>
                        <%--pake calendar??????????????--%>
                    </div>
                    <asp:Panel ID="role_txt" runat="server">
                        <div class="lbl_tb">
                            <asp:Label ID="Label1" runat="server" Text="User role: "></asp:Label>
                            <asp:TextBox ID="Txt_role" runat="server" CssClass=""></asp:TextBox>

                        </div>
                    </asp:Panel>
                    <div>
                        <asp:Label ID="Lbl_error" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Lbl_scs" CssClass="success" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div style="align-self: center">
                        <br />
                        <asp:Button ID="Btn_UpdatePro" CssClass="btnn" runat="server" Text="Update Profile" OnClick="Btn_UpdatePro_Click" />
                    </div>
                    <%--<div style="align-self: center">
                        <br />
                        Already have an account? 
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Login.aspx">Login here!</asp:HyperLink>

                    </div>
                    <asp:Label ID="Lbl_out" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="inner-container2">

                    <div class="title">
                        Password
                        <br />
                        <br />
                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Password" runat="server" Text="Old Password: "></asp:Label>
                        <asp:TextBox ID="Txt_OPassword" runat="server" CssClass="tb3" TextMode="Password"></asp:TextBox>



                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_CPassword" runat="server" Text="New Password: "></asp:Label>
                        <asp:TextBox ID="Txt_NPassword" runat="server" CssClass="tb4" TextMode="Password"></asp:TextBox>

                    </div>
                    <div>
                        <asp:Label ID="Lbl_error2" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Lbl_scs2" CssClass="success" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                    <div style="align-self: center">
                        <br />
                        <asp:Button ID="Btn_updatePwd" CssClass="btnn" runat="server" Text="Update Password" OnClick="Btn_updatePwd_Click" />
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
