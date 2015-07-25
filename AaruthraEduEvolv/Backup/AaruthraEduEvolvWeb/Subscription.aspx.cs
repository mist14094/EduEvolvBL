using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvConstants;

namespace AaruthraEduEvolvWeb
{
    public partial class Subscription : System.Web.UI.Page
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
    }
}