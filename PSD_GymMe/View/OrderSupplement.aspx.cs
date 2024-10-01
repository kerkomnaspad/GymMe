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
    public partial class OrderSupplement : System.Web.UI.Page
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
                        Response.Redirect("~/View/Home.aspx");
                    }
                    
                    //Lbl_user.Text = usr.UserRole;

                    GridView1.DataSource = SupplementHandler.GetAllSupplement_Merged();
                    GridView1.DataBind();

                    Btn_load_Click(sender,e);
                    

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

        

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.NewEditIndex];
            string id = rows.Cells[0].Text.ToString();
            Response.Redirect("~/View/Profile.aspx?ID=" + id);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            string id = rows.Cells[0].Text.ToString();
            //UserRepository.deleteUserByID(id);
            Response.Redirect("~/View/Home.aspx");
        }

        protected void Btn_order_Click(object sender, EventArgs e)
        {
            Btn_cart_Click(sender, e);
            MsUser user = Session["user"] as MsUser;

            //int qty = 0;
            List<MsCart> cart = CartHandler.GetUserCart(user.UserID);
            
            
            Response<string> transaction = TransactionHandler.CreateTransaction(user.UserID,cart);

            Lbl_status.Visible = true;
            Lbl_status.Text= transaction.Message;



            //Lbl_status.Text = qty.ToString();
        }

        protected void Btn_cart_Click(object sender, EventArgs e)
        {
            
            MsUser user = Session["user"] as MsUser;
            CartHandler.DeleteUserCart(user.UserID);
            //int qty = 0;

            
            int i = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {

                TextBox SpQty = row.FindControl("TextBox1") as TextBox;

                if (!string.IsNullOrEmpty(SpQty.Text.ToString()))
                {

                    string supplementQty = SpQty.Text;
                    Response<int> respQty = SupplementHandler.ValidateQty(supplementQty);
                    if (respQty.Success == false)
                    {
                        Lbl_status.CssClass = "error";
                        Lbl_status.Text = respQty.Message;
                        i++;
                        continue;
                    }
                    //qty += respQty.Payload;
                    if (respQty.Payload > 0 && respQty.Success==true)
                    {
                        //TransactionDetailFactory.CreateDetail(row.Cells[0].Text.ToString(), respQty.Payload, lastID+1);
                        //Lbl_status.Text = GridView1.DataKeys[i].Value.ToString();
                        //Lbl_status.Visible = true;
                        CartFactory.CreateCart(GridView1.DataKeys[i].Value.ToString(), respQty.Payload, user.UserID);
                    }

                }
                i++;
            }

            Lbl_status.Text = "Saved to cart";
        }

        protected void Btn_load_Click(object sender, EventArgs e)
        {
            Btn_clear_Click(sender, e);
            MsUser usr= Session["user"] as MsUser;

            List<MsCart> cart = CartHandler.GetUserCart(usr.UserID);
            int i = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                foreach (MsCart item in cart)
                {
                    if (Convert.ToInt16(GridView1.DataKeys[i].Value) == item.SuplementID)
                    {
                        TextBox SpQty = row.FindControl("TextBox1") as TextBox;

                        SpQty.Text = item.Quantity.ToString();

                    }

                }
                i++;
            }

        }

        protected void Btn_clear_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {

                TextBox SpQty = row.FindControl("TextBox1") as TextBox;
                SpQty.Text = null;

            }

        }
    }
}