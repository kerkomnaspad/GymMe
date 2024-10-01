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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_GymMe.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser usr;
            Lbl_error.Visible = false;
            Lbl_error2.Visible = false;
            Lbl_scs.Visible = false;
            Lbl_scs2.Visible = false;
            if (!IsPostBack)
            {
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        string ids = Request.Cookies["user_cookie"].Value;
                        usr = UserHandler.GetUserByID(ids);
                        Session["user"] = usr;

                    }
                    else
                    {
                        usr = Session["user"] as MsUser;
                    }

                    if (UserHandler.isAdmin(usr) == true)
                    {

                        navbar_customer.Visible = false;
                    }
                    else
                    {
                        role_txt.Visible = false;
                        navbar_admin.Visible = false;
                    }
                }

                


                string id = Request["ID"];

                if(id==null)
                {
                    Response.Redirect("~/View/Home.aspx");
                }

                MsUser user = UserHandler.GetUserByID(id);

                //Txt_Password.Text = user.UserPassword;
                //Txt_Password.TextMode = TextBoxMode.Password;
                Txt_Email.Text = user.UserEmail;
                Txt_Username.Text = user.UserName;
                RBtn_Gender.SelectedValue = user.UserGender;
                Txt_DD.Text = user.UserDOB.Day.ToString();
                Txt_MM.Text = user.UserDOB.Month.ToString();
                Txt_YY.Text = user.UserDOB.Year.ToString();
                Txt_role.Text = user.UserRole;
            }




        }

        protected void Btn_UpdatePro_Click(object sender, EventArgs e)
        {
            Lbl_error.Visible = false;
            Lbl_error2.Visible = false;
            Lbl_scs.Visible = false;
            Lbl_scs2.Visible = false;

            string id = Request["ID"];
            MsUser usr = UserHandler.GetUserByID(id);
            string username = Txt_Username.Text;
            string email = Txt_Email.Text;
            string gender = RBtn_Gender.SelectedValue;
            string date = Txt_MM.Text + "/" + Txt_DD.Text + "/" + Txt_YY.Text;
            string role = Txt_role.Text;

            Response<MsUser> updatedProfile = UserHandler.ValidateUpdateProf(usr.UserID,username,email,gender,date,role);

            if(updatedProfile.Success==false)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = updatedProfile.Message;
                Lbl_scs.Visible = false;
                return;
            }
           

            Lbl_error.Text = "";
            Lbl_error.Visible = false;
            Lbl_scs.Visible = true;
            Lbl_scs.Text = updatedProfile.Message;

            //Response.Redirect("~/View/Profile.aspx?ID="+id);

            //Lbl_out.Text = dateTime.ToString();
        }
        protected void Btn_updatePwd_Click(object sender, EventArgs e)
        {
            Lbl_error.Visible = false;
            Lbl_error2.Visible = false;
            Lbl_scs.Visible = false;
            Lbl_scs2.Visible = false;

            string id = Request["ID"];
            MsUser usr = UserHandler.GetUserByID(id);
            string Opassword = Txt_OPassword.Text;
            string Npassword = Txt_NPassword.Text;

            Response<MsUser> updatePwd = UserHandler.ValidateUpdatePwd(usr.UserID,usr.UserPassword, Npassword, Opassword);

            if(updatePwd.Success==false)
            {
                Lbl_error2.Visible = true;
                Lbl_error2.Text = updatePwd.Message;
                Lbl_scs2.Visible = false;
                return;
            }

            Lbl_error2.Text = "";
            Lbl_error2.Visible = false;
            Lbl_scs2.Visible = true;
            Lbl_scs2.Text = updatePwd.Message;

            //Response.Redirect("~/View/Profile.aspx?ID="+id);
        }

        protected void Logout_btn_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("~/View/Login.aspx");
        }

        protected void Profile_btn_Click(object sender, EventArgs e)
        {
            MsUser usr = Session["user"] as MsUser;
            string id = usr.UserID.ToString();
            Response.Redirect("~/View/Profile.aspx?ID=" + id);
        }

        protected void Order_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderSupplement.aspx");
        }

        protected void History_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/History.aspx");
        }

        protected void Home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void Manage_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageSupplement.aspx");
        }

        protected void Queue_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionQueue.aspx");
        }

        protected void Report_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ViewTransactionReport.aspx");
        }


    }
}