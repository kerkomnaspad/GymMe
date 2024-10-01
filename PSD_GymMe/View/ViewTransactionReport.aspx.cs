using PSD_GymMe.Dataset;
using PSD_GymMe.Handler;
using PSD_GymMe.Model;
using PSD_GymMe.Modules;
using PSD_GymMe.Report;
using PSD_GymMe.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_GymMe.View
{
    public partial class ViewTransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser usr;
            //Lbl_error.Visible = false;
            //Lbl_error2.Visible = false;
            //Lbl_scs.Visible = false;
            //Lbl_scs2.Visible = false;
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

                        //navbar_customer.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("~/View/Home.aspx");
                        //role_txt.Visible = false;
                        //navbar_admin.Visible = false;
                    }
                }
                CrystalReport1 report = new CrystalReport1();

                CrystalReportViewer1.ReportSource = report;

                List<TransactionHeader> tHeader = TransactionHandler.GetAllTransactions();

                DataSet1 dataset = GetDataSet(tHeader);

                report.SetDataSource(dataset);
            }
        }

        protected DataSet1 GetDataSet(List<TransactionHeader> tHeader)
        {
            DataSet1 dataSet = new DataSet1();

            var headerTable = dataSet.TransactionHeader;
            var detailTable = dataSet.TransactionDetail;
            var userTable = dataSet.MsUser;
            var subdetailTable = dataSet.MsSupplement;

            // iterasi 2d
            foreach (TransactionHeader h in tHeader)
            {

                var header_row = headerTable.NewRow();

                header_row["TransactionID"] = h.TransactionID;
                header_row["TransactionDate"] = h.TransactionDate;
                header_row["UserID"] = h.UserID;
                header_row["Status"] = h.Status;

                //var user_row = userTable.NewRow();
                //foreach (MsUser u in h.MsUser)
                //{
                //    user_row["UserID"] = h.MsUser.UserID;
                //    user_row["UserName"] = h.MsUser.UserName;
                //    user_row["UserEmail"] = h.MsUser.UserEmail;
                //    user_row["UserDOB"] = h.MsUser.UserDOB;
                //    user_row["UserGender"] = h.MsUser.UserGender;
                //    user_row["UserRole"] = h.MsUser.UserRole;
                //}

                //userTable.Rows.Add(user_row);
                var detail_row = detailTable.NewRow();
                

                foreach (Model.TransactionDetail d in h.TransactionDetails)
                {

                    detail_row["TransactionID"] = d.TransactionID;
                    detail_row["SupplementID"] = d.SupplementID;
                    detail_row["Quantity"] = d.Quantity;
                    detail_row["Price"] = d.MsSupplement.SupplementPrice;
                    detail_row["Total"] = d.Quantity*d.MsSupplement.SupplementPrice;



                }
                detailTable.Rows.Add(detail_row);
                headerTable.Rows.Add(header_row);
            }
            return dataSet;
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