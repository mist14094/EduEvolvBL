using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aaruthra.Mails;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public string insertUser(string FirstName, string LastName, string CompanyName, string Address, string City, string State, string Pincode, string Phone, string Email, string Username, string Password)
    {
        try
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["Connstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertUser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@Pincode", Pincode);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Username already exists.Please choose a different username.";
                        break;
                    case -2:
                        message = "Entered email address has already been used.";
                        break;
                    case -3:
                        message = "Entered mobile has already been used.";
                        break;
                    default:
                        message = "Registration successful. Activation Mail Sent to the registered email ID";
                        sendActivationMail(userId);
                        break;
                }
                return message;
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL Error" + ex.Message.ToString());
            return "Error";
        }
    }

    private void sendActivationMail(int userId)
    {
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        DataSet ds  =  bl.sendActivationMail(userId);
        try
        {
            string s = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                       (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
           string mailcon = SendMail.BuildMail(ds,"Activation",s);
            DataTable DtMailContent = ds.Tables[0];
            DataTable DtUserData= ds.Tables[1];
            
            sendMailContemt(DtMailContent.Rows[0]["FormatName"].ToString(),mailcon, DtUserData.Rows[0]["EmailID"].ToString());
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
    public void insertUser()
    {
        string FirstName, LastName, CompanyName, Address, City, State, Pincode, Phone, Email, Username, Password;

        FirstName = txt_firstname.Text.ToString();
        LastName = txt_lastname.Text.ToString();
        CompanyName = txt_companyname.Text.ToString();
        Address = txt_address.Text.ToString();
        City = txt_city.Text.ToString();
        State = txt_state.Text.ToString();
        Pincode = txt_Pincode.Text.ToString();
        Phone = txt_phone.Text.ToString();
        Email = txt_email.Text.ToString();
        Username = txt_username.Text.ToString();
        Password = txt_passowrd.Text.ToString();
        var bl = new AaruthraEduEvolvBL.BusinessLr();
        try
        {
            int userId = bl.insertUser(FirstName, LastName, CompanyName, Address, City, State, Pincode, Phone, Email, Username, Password);
            
            
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Username already exists. Please choose a different username.";
                        break;
                    case -2:
                        message = "Entered email address has already been used.";
                        break;
                    case -3:
                        message = "Entered mobile has already been used.";
                        break;
                    default:
                         message = "Registration successful. Activation Mail Sent to the registered email ID";
                        sendActivationMail(userId);
                        break;
                }
                //return message;
                alert.InnerHtml = message;
                alert.Style.Add("display", "true");
                ClearValues();
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL Error" + ex.Message.ToString());
            alert.InnerHtml = ex.Message.ToString();
            alert.Style.Add("display", "true");
            //return "Error";
        }
    }

    private void ClearValues()
    {
        txt_firstname.Text="";
        txt_lastname.Text="";
        txt_companyname.Text="";
        txt_address.Text="";
        txt_city.Text="";
        txt_state.Text="";
         txt_Pincode.Text="";
        txt_phone.Text="";
        txt_email.Text="";
        txt_username.Text="";
        txt_passowrd.Text="";
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        //alert.InnerHtml = "Thanks for signing up. Now you can sign in as " + txt_username.Text.ToString();
        //alert.Style.Add("display", "true");
        if (Page.IsValid)
            insertUser();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        insertUser();
    }
}

