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

public partial class CourseList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        var cs = (Customer) Session["UserData"];
        var courseId = 0;
        var check = int.TryParse(Request.QueryString["CourseID"] ?? "0",out courseId);

        if (cs != null)
        {
            Session["UserData"] = bl.GetCustomer(cs.strUserName);
            cs = (Customer)Session["UserData"];
            lblUserName.Text = cs.strFirstName + " &nbsp; &nbsp;"; ;
            ListView1.Items.Clear();
            var firstOrDefault = cs.Courses.FirstOrDefault(course => course.CourseId.Equals(courseId));
            if (firstOrDefault != null)
            {
                ListView1.DataSource = firstOrDefault.Materials;
                ListView1.DataBind();
            }
            else
            {
                ListView1.DataBind();
            }
      
        }
        else
        {
            Response.Redirect("signin.aspx");
        }
    }

    protected void btnLogOff_Click(object sender, EventArgs e)
    {
        Session["UserData"] = null;
        Response.Redirect("signin.aspx");
    }
}