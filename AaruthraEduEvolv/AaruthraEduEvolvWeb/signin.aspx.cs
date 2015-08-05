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

public partial class signin : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var bl = new AaruthraEduEvolvBL.BusinessLr();

        Customer cs = (Customer)Session["UserData"];
        if (cs != null)
        {

            Response.Redirect("CourseDetails.aspx");
        }
        else
        {
          
        }
        //var material = bl.GetMaterials();
        //var courses = bl.GetCourses();
        //var csC = bl.GetCoursesWithMaterials();
     }

    private void LoginUser()
    {
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        try
        {
            int userId = bl.CheckUser(txt_username.Text, txt_passowrd.Text);
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    alert.Attributes["class"] = "alert alert-danger";
                    message = "Username doesn't exist !";
                    break;
                case -2:
                    alert.Attributes["class"] = "alert alert-danger";
                    message = "Incorrect Pasword !!!";
                    break;
                case -3:
                    alert.Attributes["class"] = "alert alert-danger";
                    message = "User inactive, Contact customer support ! ";
                    break;
                default:
                    Session["UserData"] = bl.GetCustomer(txt_username.Text);

                    Response.Redirect("CourseDetails.aspx");
                    // message = "user account " + txt_username.Text.ToString();
                    break;
            }
            //return message;
            alert.InnerHtml = message;
            alert.Attributes["class"] = "alert alert-success";
            alert.Style.Add("display", "true");
            ClearValues();

    



            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
        catch (Exception ex)
        {
            //VeeraEDUEntities db = new VeeraEDUEntities();

            //ErrorLog errorLog = new ErrorLog();
            //errorLog.Activity = ;
            //errorLog.ActivityDesc = ActivityDesc;
            //errorLog.LogTime = DateTime.Now;
            //errorLog.ErrorMessage = ErrorMessage;
            //db.ErrorLogs.AddObject(errorLog);
            //db.SaveChanges(); 
      
           
            Console.WriteLine("SQL Error" + ex.Message.ToString(CultureInfo.InvariantCulture));
            alert.InnerHtml = ex.Message.ToString(CultureInfo.InvariantCulture);
            alert.Attributes["class"] = "alert alert-danger";
            alert.Style.Add("display", "true");
            //return "Error";
        }
    }
    private void ClearValues()
    {
        txt_username.Text = "";
        txt_passowrd.Text = "";
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        LoginUser();
    }

}
