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

public partial class ChangeSubscription : System.Web.UI.Page
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
                hpSubscribe.Visible = true;
            }

            else
            {
                Response.Redirect("403.aspx");
                hpVerifyPayment.Visible = false;
                hpSubscribe.Visible = false;

            }

        }
        else
        {
            Response.Redirect("signin.aspx");
        }

        if (!IsPostBack)
        
        {
            try
            {
                var dsf = Request.QueryString["ID"];
                if (dsf != null)
                {
                    var intSubscriptionId = int.Parse(Request.QueryString["ID"]);
                    DataSet ds = bl.GetSubscriptionDetails(intSubscriptionId);
                    lblName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " +
                                   ds.Tables[0].Rows[0]["LastName"].ToString();
                    lblCourseDetails.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                    calCalendar.SelectedDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpiredOn"].ToString()).Date;
                    calCalendar.VisibleDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpiredOn"].ToString());
                    lblSubscriptionID.Text = ds.Tables[0].Rows[0]["SubscriptionID"].ToString();
                    lblUserID.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
                    lblCourseID.Text = ds.Tables[0].Rows[0]["CourseID"].ToString();
                    lblActivationDate.Text = ds.Tables[0].Rows[0]["ActivationDate"].ToString();
                }
            }
            catch (Exception ex)
            {
                
               
            }
          //  gvSubscription.DataSource = bl.GetSubscriptionDetails(1014);
          //  gvSubscription.DataBind();
           

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



    protected void btnActivate_OnClick(object sender, EventArgs e)
    {
      
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            bl.UpdateSubscription(calCalendar.SelectedDate, int.Parse(lblSubscriptionID.Text), int.Parse(lblUserID.Text),
    int.Parse(lblCourseID.Text));
            lblError.Text = "Update Successful";
        }
        catch (Exception)
        {

            lblError.Text = "**Oops, Something is wrong.";
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bl.DeleteSubscription(calCalendar.SelectedDate, int.Parse(lblSubscriptionID.Text), int.Parse(lblUserID.Text),
    int.Parse(lblCourseID.Text));
            lblError.Text = "Delete Successful";
            Response.Redirect("AddSubscription.aspx");
        }
        catch (Exception)
        {

            lblError.Text = "**Oops, Something is wrong.";
        }
    }
}

