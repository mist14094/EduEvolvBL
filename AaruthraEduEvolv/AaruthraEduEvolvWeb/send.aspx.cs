using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvBL;
using AaruthraEduEvolvBL;
using AaruthraEduEvolvConstants;
using System.Net;
using System.Text;

namespace AaruthraEduEvolvWeb
{
    public partial class send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["thing1"] = "hello";
                values["thing2"] = "world";

                var response = client.UploadValues("http://localhost:11830/Receive.aspx", values);

                var responseString = Encoding.Default.GetString(response);
            }
        }
    }
}