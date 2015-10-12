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

public partial class AddSubscription : System.Web.UI.Page
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
            ddlUserList.DataSource = bl.GetAlCustomer();
            ddlUserList.DataValueField = "intUserID";
            ddlUserList.DataTextField = "strFirstName";
            
            ddlUserList.DataBind();
            ddlUserList.Items.Insert(0, new ListItem("-Select User-", "0"));

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

    protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvSubscription.DataSource = bl.GetAllSubscription(ddlUserList.SelectedValue);
        gvSubscription.DataBind();

       
    }

    protected void btnActivate_OnClick(object sender, EventArgs e)
    {
        Calendar calCalender = gvSubscription.Controls[0].Controls[0].FindControl("Calendar1") as Calendar;
        Label lblError = gvSubscription.Controls[0].Controls[0].FindControl("idError") as Label;

        if (calCalender.SelectedDate != DateTime.MinValue)
        {
            bl.ManualActivation(ddlUserList.SelectedValue, calCalender.SelectedDate);
            gvSubscription.DataSource = bl.GetAllSubscription(ddlUserList.SelectedValue);
            gvSubscription.DataBind();
           
        }
        else
        {
            lblError.Text = "Select a Date!";
        }
    }


}

