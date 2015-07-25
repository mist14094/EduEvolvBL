using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvConstants;

namespace AaruthraEduEvolvWeb
{
    public partial class CourseSubscription : System.Web.UI.Page
    {
        AaruthraEduEvolvBL.BusinessLr bl = new AaruthraEduEvolvBL.BusinessLr();
         
        protected bool SubscripeValue(object o)
        {
            if (o.ToString() == "Subscribed")
                return false;
            else
                return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cs = (Customer)Session["UserData"];
            if (cs != null)
            {
                Session["UserData"] = bl.GetCustomer(cs.strUserName);
                lblUserName.Text = cs.strFirstName + " &nbsp; &nbsp;";

            }
            else
            {
                Response.Redirect("signin.aspx");
            }
            if (!IsPostBack)
            {
                Customer cs1 = (Customer)Session["UserData"];
                ListView1.Items.Clear();
                ListView1.DataSource = bl.CheckUserSubscriptions(cs1.strUserName); //GetCustomerCourse(cs.intUserID);
                ListView1.DataBind();
                if (Request.QueryString.HasKeys())
                {
                    makeAlert();

                }
            }
        }

        private void makeAlert()
        {
            string PaymentID = Request.QueryString["payment_id"].ToString();
            string Status = Request.QueryString["status"].ToString();
            if (Status == "success")
            {
           
            alert.InnerHtml = "Your Payment ID is : "+PaymentID +" Your Transaction is Success, your subscription will be activated with in 24 Hrs";
            alert.Attributes["class"] = "alert alert-success";
            alert.Style.Add("display", "true");
            }
            else
            {
                alert.Attributes["class"] = "alert alert-danger";
                alert.InnerHtml = "Transaction Failed, Your Payment ID is : "+PaymentID;
                alert.Style.Add("display", "true");
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }

        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {

            
            ListViewDataItem item = (ListViewDataItem)e.Item;
            string CourseID = ListView1.DataKeys[item.DataItemIndex]["CourseID"].ToString();
            string Fees = ListView1.DataKeys[item.DataItemIndex]["Fees"].ToString();
            //string CourseID = (String) e.CommandArgument;
            Customer cs1 = (Customer)Session["UserData"];
            DataSet ds = bl.MakeTransaction(cs1.intUserID, CourseID); //GetCustomerCourse(cs.intUserID);
            //FirstName,EmailID,MobileNo, TXN
            Response.Redirect("https://www.instamojo.com/salesaaruthra/test-trans/?data_readonly=data_name&data_readonly=data_email&data_readonly=data_phone&data_readonly=data_amount&data_readonly=data_Field_32797&data_email=" + ds.Tables[0].Rows[0]["EmailID"] + "&data_amount=" + Fees + "&data_name=" + ds.Tables[0].Rows[0]["FirstName"] + "&data_phone=" + ds.Tables[0].Rows[0]["MobileNo"] + "&data_Field_32797=" + ds.Tables[0].Rows[0]["TXN"]);
            //Literal1.Text = "You clicked the " + (String)e.CommandArgument + " button";
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnLogOff_Click(object sender, EventArgs e)
        {
            Session["UserData"] = null;
            Response.Redirect("signin.aspx");
        }
    }
}