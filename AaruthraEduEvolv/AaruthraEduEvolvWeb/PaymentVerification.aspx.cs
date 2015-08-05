using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvConstants;

public partial class PaymentVerification : System.Web.UI.Page
{
    AaruthraEduEvolvBL.BusinessLr bl = new AaruthraEduEvolvBL.BusinessLr();
    protected void Page_Load(object sender, EventArgs e)
    {
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        Customer cs = (Customer)Session["UserData"];
        if (cs != null)
        {
            Session["UserData"] = bl.GetCustomer(cs.strUserName);
            lblUserName.Text = cs.strFirstName + " &nbsp; &nbsp;";

            if (cs.strUserName.ToUpper() == "ADMIN")
            {
                hpVerifyPayment.Visible = true;
            }

            else
            {
                Response.Redirect("403.aspx");
                hpVerifyPayment.Visible = false;

            }

        }
        else
        {
            Response.Redirect("signin.aspx");
        }

        if (!IsPostBack)
        {
            gvPayments.DataSource = bl.GetAllSubscriptionRequests(); //GetCustomerCourse(cs.intUserID);
            gvPayments.DataBind();

        }
    }
    protected bool VerifiyValue(object o)
    {
        if (o.ToString() == "true")
            return false;
        else
            return true;
    }
    protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Verify")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Literal ltrlpayment_id = (Literal)gvPayments.Rows[index].FindControl("ltrlpayment_id");
            Literal ltrlTransactionID = (Literal)gvPayments.Rows[index].FindControl("ltrlTransactionID");
            //Make Subscription Entry
            bl.MakeSubscription(ltrlTransactionID.Text);
            // ScriptManager.RegisterStartupScript(this, this.GetType(),
            // "Message", "alert('" + ltrlName.Text + "');", true);
            //Send Mail to User on  Subscription
            gvPayments.DataSource = bl.GetAllSubscriptionRequests(); //GetCustomerCourse(cs.intUserID);
            gvPayments.DataBind();
            //Send Mail to User on  Subscription

        }
    }
    protected void btnBuyPlan_onClickEvent(object sender, EventArgs e)
    {
        Response.Redirect("CourseSubscription.aspx");

    }

    protected void btnLogOff_Click(object sender, EventArgs e)
    {
        Session["UserData"] = null;
        Response.Redirect("signin.aspx");
    }
}

