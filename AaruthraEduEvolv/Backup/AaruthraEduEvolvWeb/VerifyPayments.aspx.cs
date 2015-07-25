using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvConstants;
using AaruthraEduEvolvWeb;

public partial class VerifyPayments : System.Web.UI.Page
{
    AaruthraEduEvolvBL.BusinessLr bl = new AaruthraEduEvolvBL.BusinessLr();
    protected void Page_Load(object sender, EventArgs e)
    {
        
     
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
    
}
