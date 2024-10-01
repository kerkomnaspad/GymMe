using PSD_GymMe.Handler;
using PSD_GymMe.Model;
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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser usr;
                if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                }
                else
                {
                    if (Session["user"] == null)
                    {
                        string id = Request.Cookies["user_cookie"].Value;
                        usr = UserHandler.GetUserByID(id);
                        Session["user"] = usr;
                    }
                    else
                    {
                        usr = Session["user"] as MsUser;
                    }

                    if (UserHandler.isAdmin(usr) == true)
                    {
                        customer_list.Visible = true;
                        navbar_customer.Visible = false;
                    }
                    else
                    {
                        customer_list.Visible = false;
                        navbar_admin.Visible = false;
                    }
                    Lbl_user.Text = usr.UserRole;

                    GridView1.DataSource=UserHandler.getAllUser();
                    GridView1.DataBind();

                }
            }




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
            string id= usr.UserID.ToString();
            Response.Redirect("~/View/Profile.aspx?ID="+ id);
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.NewEditIndex];
            string id = rows.Cells[0].Text.ToString();
            Response.Redirect("~/View/Profile.aspx?ID="+id);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows= GridView1.Rows[e.RowIndex];
            string id= rows.Cells[0].Text.ToString();
            UserHandler.DeleteUserByID(id);
            Response.Redirect("~/View/Home.aspx");
        }
    }
}