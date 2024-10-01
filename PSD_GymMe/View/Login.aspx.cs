using PSD_GymMe.Controller;
using PSD_GymMe.Handler;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_GymMe.View
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
            //}


        }

        protected void Btn_login_Click(object sender, EventArgs e)
        {

            Response<MsUser> user = UserHandler.ValidateLogin(Txt_Username.Text,Txt_Password.Text);

            if (user.Success==false)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = user.Message;
                return;
            }

                Lbl_error.Text = "Login success!";
                Lbl_error.CssClass = "success";
                if (CHK_Remember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.Payload.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                    //Lbl_error.Text = usr.UserID.ToString();
                }


                Session["user"] = user.Payload;
                Response.Redirect("~/View/Home.aspx");


        }
    }
}