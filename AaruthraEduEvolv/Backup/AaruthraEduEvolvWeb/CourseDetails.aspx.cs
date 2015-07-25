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

public partial class CourseDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var bl = new AaruthraEduEvolvBL.BusinessLr();
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
            ListView1.Items.Clear();
            ListView1.DataSource = cs.Courses;
            ListView1.DataBind();
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