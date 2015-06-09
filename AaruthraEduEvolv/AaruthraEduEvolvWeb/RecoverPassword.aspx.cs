using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AaruthraEduEvolvWeb
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var bl = new AaruthraEduEvolvBL.BusinessLr();
            try
            {
                int userId = bl.ressetPassword(txt_EmailID.Text);
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        alert.Attributes["class"] = "alert alert-danger";
                        message = "Not a valid register emailID! ";
                        break;
                    case -2:
                        alert.Attributes["class"] = "alert alert-danger";
                        message = "User inactive, Contact customer support ! ";
                        break;
                    default:
                        alert.Attributes["class"] = "alert alert-success";
                         message = "password change link sent to the registered email Id" ;
                         SendPasswordResetMail(userId);
                        break;
                }
                //return message;
                
                
                alert.InnerHtml = message;
                alert.Style.Add("display", "true");
                ClearValues();
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-danger";
                Console.WriteLine("SQL Error" + ex.Message.ToString(CultureInfo.InvariantCulture));
                alert.InnerHtml = ex.Message.ToString(CultureInfo.InvariantCulture);
                alert.Style.Add("display", "true");
                
            }
        }
        private void SendPasswordResetMail(int userId)
        {
            var bl = new AaruthraEduEvolvBL.BusinessLr();
            DataSet ds = bl.SendPasswordResetMail(userId);
            try
            {
                string s = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                           (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
                string mailcon = SendMail.BuildMail(ds, "ResetPassword", s);
                DataTable DtMailContent = ds.Tables[0];
                DataTable DtUserData = ds.Tables[1];

                sendMailContemt(DtMailContent.Rows[0]["FormatName"].ToString(), mailcon, DtUserData.Rows[0]["EmailID"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                alert.InnerHtml = ex.Message.ToString();
                alert.Style.Add("display", "true");
            }
        }

        private void sendMailContemt(string header, string body, string to)
        {
            SendMail.SendMailNow(to, header, body, true);
        }
        private void ClearValues()
        {
            txt_EmailID.Text = "";
        }
    }
}