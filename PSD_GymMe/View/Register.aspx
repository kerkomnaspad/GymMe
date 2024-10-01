<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PSD_GymMe.View.Register" unobtrusivevalidationmode="none" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Register Page</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Style/Register.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="outer-container">
            <div class="container">
                <div class="inner-container">

                    <div id="title">
                        <center>
                            Register Page
                                <br />
                            <br />
                        </center>
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
                        <asp:Label ID="Lbl_Password" runat="server" Text="Password: "></asp:Label>
                        <asp:TextBox ID="Txt_Password" runat="server" CssClass="tb3" TextMode="Password"></asp:TextBox>



                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_CPassword" runat="server" Text="Confirm Password: "></asp:Label>
                        <asp:TextBox ID="Txt_CPassword" runat="server" CssClass="tb4" TextMode="Password"></asp:TextBox>

                    </div>
                    <div class="lbl_tb">
                        <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth (DD/MM/YY): "></asp:Label>
                        <asp:TextBox ID="Txt_DD" runat="server"></asp:TextBox>/
                        <asp:TextBox ID="Txt_MM" runat="server"></asp:TextBox>/
                        <asp:TextBox ID="Txt_YY" runat="server"></asp:TextBox>
                        <%--pake calendar??????????????--%>
                    </div>
                    <div>
                        <asp:Label ID="Lbl_error" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Lbl_scs" CssClass="success" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div style="align-self: center">
                        <asp:Button ID="Btn_Register" runat="server" Text="Register" OnClick="Btn_Register_Click" />
                    </div>
                    <div style="align-self: center">    
                        <br />
                        Already have an account? 
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Login.aspx">Login here!</asp:HyperLink>

                    </div>
                    <%--<asp:Label ID="Lbl_out" runat="server" Text=""></asp:Label>--%>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
