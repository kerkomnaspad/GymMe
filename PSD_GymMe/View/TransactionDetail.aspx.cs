using PSD_GymMe.Handler;
using PSD_GymMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_GymMe.View
{
    public partial class TransactionDetail : System.Web.UI.Page
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
                        navbar_customer.Visible = false;

                    }
                    else
                    {
                        navbar_admin.Visible = false;

                    }

                    string tID = Request["tID"];

                    List<Model.TransactionDetail> td = TransactionHandler.GetAllTransactionDetailByID(tID).Payload;
                    TransactionHeader th = TransactionHandler.GetHeader(tID);

                    lbl_sts.Text = "Status: "+ th.Status.ToString();

                    GridView1.DataSource = TransactionHandler.GetAllInfo(tID);
                    GridView1.DataBind();
                    //lbl_qty.Text = "Quantity: " + td.Quantity.ToString();
                    //lbl_sID.Text = "Supplement ID: " + td.SupplementID.ToString();
                    //lbl_sName.Text = "Supplement Name: " + SupplementHandler.GetSpByID(td.SupplementID.ToString()).SupplementName.ToString();
                    lbl_tID.Text = "Transaction ID: " + tID.ToString();

                    //string spTyID= SupplementHandler.GetSpByID(td.SupplementID.ToString()).SupplementTypeID.ToString();

                    //lbl_tName.Text = "Supplement Type: " + SupplementHandler.GetSpTyByID(spTyID).SupplementTypeName;
                    //lbl_tyID.Text = "Supplement Type ID: " + spTyID;

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