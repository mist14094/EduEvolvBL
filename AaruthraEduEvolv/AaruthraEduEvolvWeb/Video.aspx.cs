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

public partial class Video : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        //Session["UserData"] = bl.GetCustomer("ananthcdm");
        Customer cs = (Customer) Session["UserData"];
        int MaterialID = 0;
        bool check = int.TryParse(Request.QueryString["MaterialID"] ?? "0", out MaterialID);

        if (cs != null)
        {
            Session["UserData"] = bl.GetCustomer(cs.strUserName);
            cs = (Customer)Session["UserData"];
            lblUserName.Text = cs.strFirstName + " &nbsp; &nbsp;"; ;
            bool checkValue = false;
            foreach (var course in cs.Courses)
            {
                for (int i = 0; i < course.Materials.Count; i++)
                {
                    if (course.Materials[i].MaterialID == MaterialID)
                    {
                        header.InnerHtml = course.Materials[i].Title;
                        player.Attributes.Add("src", course.Materials[i].VideoURL);
                        Description.InnerHtml = course.Materials[i].Description;   
         
                    }
                    
                }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        int MaterialID = 0;
        int.TryParse(Request.QueryString["MaterialID"] ?? "0", out MaterialID);

        Response.Redirect("TestYourSkill.aspx?MaterialID=" + MaterialID);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int MaterialID = 0;
        int.TryParse(Request.QueryString["MaterialID"] ?? "0", out MaterialID);

        Response.Redirect("TestYourOralSkill.aspx?MaterialID=" + MaterialID);
    }
}