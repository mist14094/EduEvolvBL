using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvBL;
using AaruthraEduEvolvBL;
using AaruthraEduEvolvConstants;

namespace AaruthraEduEvolvWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            AaruthraEduEvolvBL.BusinessLr bl = new BusinessLr();
          List<Customer> cst = bl.GetAlCustomer();
        }
    }
}