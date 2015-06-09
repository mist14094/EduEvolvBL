//--------------------------------------------------
// Project: EduEvolv
// Web site: http:\\www.aaruthura.com
//--------------------------------------------------

using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace AaruthraEduEvolvWeb
{
    public class SendMail
    {

    
        public static bool SendMailThread(string strTo, string strSubject, string strText, bool isBodyHtml, string smtpServer, string login, string password, int port, string emailFrom, bool ssl)
        {
            return (SendMailThreadStringResult(strTo, strSubject, strText, isBodyHtml, smtpServer, login, password, port, emailFrom, ssl) == "True");
        }

        public static string SendMailThreadStringResult(string strTo, string strSubject, string strText, bool isBodyHtml, string smtpServer, string login, string password, int port, string emailFrom, bool ssl)
        {
            string strResult = "True";

            if (strText == null)
            {
                return "False";
            }


            try
            {
                using (var emailClient = new SmtpClient(smtpServer)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(login, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = port,
                    EnableSsl = ssl
                })
                {
                    string[] strMails = strTo.Split(';');
                    foreach (string strEmail in strMails)
                    {
                        string strE = strEmail.Trim();
                        if (string.IsNullOrEmpty(strE)) continue;

                      //  if (!ValidationHelper.IsValidEmail(strE)) continue;
                        using (var message = new MailMessage(emailFrom, strE, strSubject, strText))
                        {
                            message.IsBodyHtml = isBodyHtml;
                            emailClient.Send(message);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                strResult = ex.Message;
               
            }

            return strResult;
        }

        public static bool SendMailNow(string strTo, string strSubject, string strText, bool isBodyHtml, string setSmtpServer, int setPort, string setLogin, string setPassword, string setEmailFrom, bool setSsl)
        {

            int workerThreads;
            int asyncIoThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out asyncIoThreads);
            if (workerThreads != 0)
                ThreadPool.QueueUserWorkItem(a => SendMailThread(strTo, strSubject, strText, isBodyHtml, setSmtpServer, setLogin, setPassword, setPort, setEmailFrom, setSsl));
            else
                new Thread(a => SendMailThread(strTo, strSubject, strText, isBodyHtml, setSmtpServer, setLogin, setPassword, setPort, setEmailFrom, setSsl)).Start();

            //ThreadPool.QueueUserWorkItem(a => SendMailThread(strTo, strSubject, strText, isBodyHtml, setSmtpServer, setLogin, setPassword, setPort, setEmailFrom, setSsl));
            return true;
        }

        public static bool SendMailNow(string strTo, string strSubject, string strText, bool isBodyHtml)
        {
            string login = "veeraedu@aaruthra.com";
            string smtp = "mail.aaruthra.com";
            string password = "veeraedu@1234";
            int port = 587;
            string email = "veeraedu@aaruthra.com";
            bool ssl = false;

            return SendMailNow(strTo, strSubject, strText, isBodyHtml, smtp, port, login, password, email, ssl);
        }

        #region  BuildMail

     
       #endregion

        internal static string BuildMail(DataSet ds, string MailType,string domain)
        {
            DataTable DtMailContent = ds.Tables[0];
            DataTable DtUserData = ds.Tables[1];
            string Body = DtMailContent.Rows[0]["FormatText"].ToString();
            switch (MailType)
            {
                case "Activation":
                    
                    //User First Name - #FIRSTNAME#, website - #URL#,Registration Date - #REGDATE#,Login user Name - #USERNAME#, Account Activation - #LINK#
                    //FirstName,UserName,UA.CreatedDate,EmailVerificationID
                    Body = Body.Replace("#FIRSTNAME#", DtUserData.Rows[0]["FirstName"].ToString());
                    Body = Body.Replace("#URL#", domain);
                    Body = Body.Replace("#REGDATE#", DtUserData.Rows[0]["CreatedDate"].ToString());
                    Body = Body.Replace("#USERNAME#", DtUserData.Rows[0]["UserName"].ToString());
                    Body = Body.Replace("#LINK#", domain + "/activation.aspx?code=" + DtUserData.Rows[0]["EmailVerificationID"].ToString());
                    return Body;
                    break;
                case  "ResetPassword":
                    //User First Name - #FIRSTNAME#, reset link - #LINK#
                    //FirstName,ResetCode
                    Body = Body.Replace("#FIRSTNAME#", DtUserData.Rows[0]["FirstName"].ToString());
                    Body = Body.Replace("#LINK#", domain + "/PasswordReset.aspx?code=" + DtUserData.Rows[0]["ResetCode"].ToString());
                    return Body;
                    break;
                default:
                    break;

            }
            return Body;
        }
    }
}