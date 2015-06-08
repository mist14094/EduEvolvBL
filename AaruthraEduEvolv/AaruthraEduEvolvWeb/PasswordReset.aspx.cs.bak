using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AaruthraEduEvolvWeb
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        private static int uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            var bl = new AaruthraEduEvolvBL.BusinessLr();
            string code = (Request.QueryString["Code"] == null )? string.Empty : Request.QueryString["Code"].ToString();
            if (code != "")
            {
                int checkValue = bl.RequestForPasswordChange(code); ;
                string message = "";
                switch (checkValue)
                {
                    
                    case -1:
                        message = "Invalid Pasword reset Code.";
                        ChangePassword.Style.Add("display", "none");
                        alert.InnerHtml = message;
                        alert.Style.Add("display", "true");
                        break;
                    case -2:
                        message = "This Pasword reset Code Expired Gendrate Again";
                        alert.InnerHtml = message;
                         alert.Style.Add("display", "true");
                        ChangePassword.Style.Add("display", "none");
                        break;
                   
                    default:
                        ChangePassword.Style.Add("display", "true");
                        alert.Style.Add("display", "none");
                        uid = checkValue;
                        //message = "Thanks for signing up. Now you can sign in as " + txt_username.Text.ToString();
                        //sendActivationMail(userId);
                        break;
                }
                //return message;
                
                //ClearValues();
               
                
            }
            else
            {
                Response.Redirect("signin.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string code = (Request.QueryString["Code"] == null) ? string.Empty : Request.QueryString["Code"].ToString();

        }
    }
}