using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using Newtonsoft.Json;
using NLog.LayoutRenderers.Wrappers;

namespace AaruthraEduEvolvBL
{
    public class Transaction
    {
        public string TransactionMaster { get; set; }
        public string amount { get; set; }
        public string offer_title { get; set; }
        public string offer_slug { get; set; }
        public string buyer_name { get; set; }
        public string unit_price { get; set; }
        public string status { get; set; }
        public string mac { get; set; }
        public string quantity { get; set; }
        public string payment_id { get; set; }
        public List<variants> Variants { get; set; }
        public string fees { get; set; }
        public string currency { get; set; }
        public string buyer_phone { get; set; }
        public string buyer { get; set; }
        public string verified { get; set; }
        public MainField custom_fields { get; set; }

        public class MainField
        {
            public Fields Field_32797;
            public Fields Field_93866;

        }

        public class Fields
        {
            public string value;
            public string required;
            public string type;
            public string label;
        }

        public class variants
        {
            public string options;
        }

        
        public Transaction GetTransaction(string transactionNumber)
        {
            AaruthraEduEvolvBL.BusinessLr dlBl = new AaruthraEduEvolvBL.BusinessLr();
            var transValue = dlBl.GetTransaction(transactionNumber);
            Transaction transaction = new Transaction();
            if (transValue != null)
                foreach (DataRow rows in transValue.Rows)
                {
                    transaction.custom_fields = JsonConvert.DeserializeObject<MainField>(rows["custom_fields"].ToString());
                    transaction.Variants = (List<Transaction.variants>)JsonConvert.DeserializeObject(rows["variants"].ToString(), typeof(List<variants>));
                    transaction.amount = rows["amount"].ToString();
                    transaction.offer_title = rows["offer_title"].ToString();
                    transaction.offer_slug = rows["offer_slug"].ToString();
                    transaction.buyer_name = rows["buyer_name"].ToString();
                    transaction.unit_price = rows["unit_price"].ToString();
                    transaction.status = rows["status"].ToString();
                    transaction.mac = rows["mac"].ToString();
                    transaction.quantity = rows["quantity"].ToString();
                    transaction.payment_id = rows["payment_id"].ToString();
                    transaction.fees = rows["fees"].ToString();
                    transaction.currency = rows["currency"].ToString();
                    transaction.buyer_phone = rows["buyer_phone"].ToString();
                    transaction.buyer = rows["buyer"].ToString();
                    transaction.TransactionMaster = transactionNumber;
                }
            return transaction;

        }

        public List<Transaction> GetAllTransaction()
        {
            List<Transaction> list = new List<Transaction>();
            AaruthraEduEvolvBL.BusinessLr dlBl = new AaruthraEduEvolvBL.BusinessLr();
            var transValue = dlBl.GetAllTransactions();
              if (transValue != null)
                  foreach (DataRow rows in transValue.Rows)
                  {
                      list.Add(GetTransaction(rows["TransactionMaster"].ToString()));
                  }
            return list;
        }

        public void CompleteTransaction(string strTransactionMsater)
        {
            AaruthraEduEvolvBL.BusinessLr dlBl = new AaruthraEduEvolvBL.BusinessLr();
            dlBl.CompleteTransaction(strTransactionMsater);
        }
    }
}
