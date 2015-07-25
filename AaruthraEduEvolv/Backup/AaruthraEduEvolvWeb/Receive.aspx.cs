using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvBL;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AaruthraEduEvolvWeb
{
    public partial class Receive : System.Web.UI.Page
    {
        AaruthraEduEvolvBL.BusinessLr Lr = new BusinessLr();

        class variants
        {
            public string options;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

           
            string strMasterTransactionNumber = DateTime.Now.ToString("yyyyMMddhhmmsss");


            foreach (string key in Request.Form.Keys)
            {
                try
                {
                    Response.Write(key);
                    string response = Lr.InsertDatabaseLog(key, Request.Form[key], strMasterTransactionNumber);
                }
                catch (Exception ex)
                {
                    string response = Lr.InsertDatabaseLog(key + "Error", ex.Message.Substring(0, 50), strMasterTransactionNumber);

                }
            }

            AaruthraEduEvolvBL.Transaction transaction= new Transaction();
            transaction = transaction.GetTransaction(strMasterTransactionNumber);//use transaction number

            var allList = transaction.GetAllTransaction();
            string response1 = Lr.InsertDatabaseLog("TransactionID", transaction.custom_fields.Field_32797.value, strMasterTransactionNumber);
            transaction.CompleteTransaction(transaction.custom_fields.Field_32797.value);
        }
    }
}