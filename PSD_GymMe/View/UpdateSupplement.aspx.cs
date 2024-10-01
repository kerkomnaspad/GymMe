﻿using PSD_GymMe.Controller;
using PSD_GymMe.Factory;
using PSD_GymMe.Handler;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_GymMe.View
{
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser usr;
            Lbl_error.Visible = false;
            
            Lbl_scs.Visible = false;
            
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

                    if (UserHandler.isAdmin(usr) == false)
                    {
                        Response.Redirect("~/View/Home.aspx");
                    }
                    
                }




                string id = Request["ID"];

                if (id == null)
                {
                    Response.Redirect("~/View/ManageSupplement.aspx");
                }

                MsSupplement sp= SupplementHandler.GetSpByID(id);

                Txt_name.Text = sp.SupplementName;
                Txt_price.Text = sp.SupplementPrice.ToString();
                Txt_typeID.Text = sp.SupplementTypeID.ToString();
                Txt_DD.Text = sp.SupplementExpiryDate.Day.ToString();
                Txt_MM.Text = sp.SupplementExpiryDate.Month.ToString();
                Txt_YY.Text = sp.SupplementExpiryDate.Year.ToString();
                
            }





        }

        protected void Btn_update_Click(object sender, EventArgs e)
        {
            string name = Txt_name.Text;
            string date = Txt_MM.Text + "/" + Txt_DD.Text + "/" + Txt_YY.Text;
            string price = Txt_price.Text;
            string TypeID = Txt_typeID.Text;
            string id = Request["ID"];

            Response<MsSupplement> updatedSp = SupplementHandler.ValidateSupplementUpdate(id, name, date, price, TypeID);

            if (updatedSp.Success == false)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = updatedSp.Message;
                return;
            }

            


            if (SupplementHandler.CheckSpTypeID(TypeID) == false)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = "Supplement Type does not exist!";
                return;
            }


            Lbl_error.Text = "";
            Lbl_error.Visible = false;
            Lbl_scs.Visible = true;
            Lbl_scs.Text = "Supplement updated!";

            Txt_DD.Text = "";
            Txt_MM.Text = "";
            Txt_YY.Text = "";
            Txt_name.Text = "";
            Txt_price.Text = "";
            Txt_typeID.Text = "";

            Response.Redirect("~/View/ManageSupplement.aspx");

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
