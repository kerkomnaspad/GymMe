<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PSD_GymMe.View.Login" unobtrusivevalidationmode="none" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="outer-container">
            <div class="container">
                <div class="inner-container">
                    <div id="title">
                        Login Page
                        <br />
                        <br />
                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Username" runat="server" Text="Username: "></asp:Label>
                        <asp:TextBox ID="Txt_Username" runat="server"></asp:TextBox>

                    </div>

                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_Password" runat="server" Text="Password: "></asp:Label>
                        <asp:TextBox ID="Txt_Password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="lbl_tb">
                        <asp:CheckBox ID="CHK_Remember" runat="server" Text="Remember Me" />
                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_error" runat="server" CssClass="error" Text=""></asp:Label>
                    </div>
                    <div class="lbl_tb">
                        <asp:Button ID="Btn_login" runat="server" Text="Login" OnClick="Btn_login_Click" />
                    </div>
                    <div>

                        <br />
                        <br />
                        Don't have an account yet?
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Register.aspx">Register here!</asp:HyperLink>

                    </div>
                </div>

            </div>

        </div>

    </form>
</body>
</html>
