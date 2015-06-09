using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AaruthraEduEvolvWeb
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateRandomValue();
            }
        }

        private void GenerateRandomValue()
        {
            Random rndRandom = new Random();
            int intNumber1 = rndRandom.Next(1, 10);
            int intNumber2 = rndRandom.Next(1, 10);

            lblNumber1.Text = intNumber1.ToString();
            lblNumber2.Text = intNumber2.ToString();
            lblResult.Text = "";
        }

        protected void SendEmail_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == (Convert.ToInt16(lblNumber1.Text) + Convert.ToInt16(lblNumber2.Text)).ToString())
            {

                try
                {
                    AaruthraEduEvolvBL.SendMail mail = new AaruthraEduEvolvBL.SendMail();
                    mail.SendMailNow("info@veeraseducation.com", "From " + txtName.Text,
                        "Email Address : " + txtEmail.Text + "<br/> Website :  " + txtWebsite.Text + "<br/> " +
                        txtMessage.Text, true);
                    GenerateRandomValue();
                    lblResult.Text = "Email Sent!";
                }
                catch (Exception ex)
                {
                    lblResult.Text = "Somewthing went wrong, Your Email is not sent. Try Again!";
                }

            }

            else
            {
                lblResult.Text = "Get a Math tutor first!";
            }
        }
    }
}