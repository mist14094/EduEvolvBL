using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvBL;

namespace AaruthraEduEvolvWeb
{
    public partial class Receive : System.Web.UI.Page
    {
        AaruthraEduEvolvBL.BusinessLr Lr= new BusinessLr();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string key in Request.Form.Keys)
            {
                Response.Write(key);
                string response = Lr.InsertDatabaseLog(key, Request.Form[key]);
            }

        }
    }
}