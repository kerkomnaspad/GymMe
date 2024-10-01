using PSD_GymMe.Controller;
using PSD_GymMe.Factory;
using PSD_GymMe.Handler;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PSD_GymMe.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user"] != null || Request.Cookies["user_cookie"]!=null)
            {
                Response.Redirect("~/View/Home.aspx");
            }

        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            string username = Txt_Username.Text;
            string email = Txt_Email.Text;
            string gender = RBtn_Gender.SelectedValue;
            string password = Txt_Password.Text;
            string Cpassword = Txt_CPassword.Text;
            string date = Txt_MM.Text + "/" + Txt_DD.Text + "/" + Txt_YY.Text;

            Response<MsUser> newUser= UserHandler.ValidateRegister(username, email, gender, password, Cpassword, date);

            if(newUser.Success==false)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = newUser.Message;
                return;
            }


            Lbl_error.Text = "";
            Lbl_error.Visible = false;
            Lbl_scs.Visible = true;
            Lbl_scs.Text = newUser.Message;

            Response.Redirect("~/View/Home.aspx");

        }
    }
}