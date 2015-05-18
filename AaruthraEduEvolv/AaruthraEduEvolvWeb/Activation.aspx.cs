using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AaruthraEduEvolvWeb
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bl = new AaruthraEduEvolvBL.BusinessLr();
            //Session["UserData"] = bl.GetCustomer("ananthcdm");
            string code = (Request.QueryString["Code"] == null )? string.Empty : Request.QueryString["Code"].ToString();
            if (code != "")
            {
                //Session["UserData"] = 
                int checkValue = bl.ActivateUser(code);;
                string message = "";
                switch (checkValue)
                {
                    case 1:
                        message = "Account Activated Successfully Now you can Login With your User Name";
                        break;
                    case -1:
                        message = "Invalid Activation Code.";
                        break;
                    case -2:
                        message = "This Account Activated Already";
                        break;
                   
                    default:
                        //message = "Thanks for signing up. Now you can sign in as " + txt_username.Text.ToString();
                        //sendActivationMail(userId);
                        break;
                }
                //return message;
                alert.InnerHtml = message;
                alert.Style.Add("display", "true");
                //ClearValues();
               
                
            }
            else
            {
                Response.Redirect("signin.aspx");
            }
        }
    }
}