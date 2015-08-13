using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AaruthraEduEvolvConstants
{
    public class Customer
    {
        public int intUserID { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strOrganisationName { get; set; }
        public string strEmailID { get; set; }
        public string strMobileNumber { get; set; }
        public DateTime dtCreatedDate { get; set; }
        public DateTime dtModifiedDate { get; set; }
        public int intAccountID { get; set; }
        public string strUserName { get; set; }
        public string StatusID { get; set; }
        public List<Video.Course> Courses { get; set; }

        public List<Customer> toCustomer(DataTable customerDataTable)
        {
            List<Customer> lsCustomers = new List<Customer>();
            foreach (DataRow row in customerDataTable.Rows)
            {
                try
                {
                    Customer cs = new Customer();
                    cs.intUserID = Convert.ToInt16(row["UserID"].ToString());
                    cs.strFirstName = Convert.ToString(row["FirstName"].ToString());
                    cs.strLastName = Convert.ToString(row["LastName"].ToString());
                    cs.strOrganisationName = Convert.ToString(row["OrganizationName"].ToString());
                    cs.strEmailID = Convert.ToString(row["EmailID"].ToString());
                    cs.strMobileNumber = Convert.ToString(row["MobileNo"].ToString());
                    cs.dtCreatedDate = Convert.ToDateTime(row["CreatedDate"].ToString());
                    cs.dtModifiedDate = Convert.ToDateTime(row["ModifiedDate"].ToString());
                    cs.intAccountID = Convert.ToInt16(row["AccountID"].ToString());
                    cs.strUserName = Convert.ToString(row["UserName"].ToString());
                    lsCustomers.Add(cs);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return lsCustomers;
        }
    }
}
