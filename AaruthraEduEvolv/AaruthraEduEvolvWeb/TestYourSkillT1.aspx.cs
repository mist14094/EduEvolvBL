using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AaruthraEduEvolvConstants;

public partial class TestYourSkillT1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        var bl = new AaruthraEduEvolvBL.BusinessLr();

        


    //    Session["UserData"] = bl.GetCustomer("ananthcdm");
        Customer cs = (Customer) Session["UserData"];
        int MaterialID = 0;
        bool check = int.TryParse(Request.QueryString["MaterialID"] ?? "0", out MaterialID);
      //  MaterialID = 2;
        if (cs != null)
        {
            Session["UserData"] = bl.GetCustomer(cs.strUserName);
            cs = (Customer)Session["UserData"];
            lblUserName.Text = cs.strFirstName + " &nbsp; &nbsp;"; ;
            bool checkValue = false;
            var GetMasterQuestionSet = bl.GetMasterQuestionSet(MaterialID);
            if (!IsPostBack)
            {
                if (GetMasterQuestionSet != null)
                {
                    header.InnerHtml = GetMasterQuestionSet.strTestTitle;
                    desc.InnerHtml = GetMasterQuestionSet.strDescription;
                    Duration.InnerHtml = "Duration : " + GetMasterQuestionSet.intDuration.ToString();
                    SkillLevel.InnerHtml = "Skill Level : " + GetMasterQuestionSet.strSkillLevel;
                    ListView1.DataSource = GetMasterQuestionSet.QuestionList;
                    ListView1.DataBind();

                    if (GetMasterQuestionSet.QuestionList.Count < 1)
                    {
                        btnSubmit.Visible = false;
                        header.Visible = false;
                        desc.Visible = false;
                        Duration.Visible = false;
                        SkillLevel.Visible = false;

                    }
                }
            }


        }
        else
        {
            Response.Redirect("signin.aspx");
        }
    }

    protected void btnLogOff_Click(object sender, EventArgs e)
    {
        Session["UserData"] = null;
        Response.Redirect("signin.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (var item in ListView1.Items)
        {
            Label lblQuestionNumber = item.FindControl("lblQuestionNumber") as Label;
            Label lblstrQuestion = item.FindControl("lblstrQuestion") as Label;
            Label lblstrQuestionDescription = item.FindControl("lblstrQuestionDescription") as Label;
            Label lblstrQuestionHint = item.FindControl("lblstrQuestionHint") as Label;
            Label lblstrQuestionAL = item.FindControl("lblstrQuestionAL") as Label;
            Label lblstrAnswerDesc = item.FindControl("lblstrAnswerDesc") as Label;
            Label lblstrPositiveAnswerResponse = item.FindControl("lblstrPositiveAnswerResponse") as Label;
            Label lblstrNegetiveAnswerResponse = item.FindControl("lblstrNegetiveAnswerResponse") as Label;
            Label lblCorrectAnswertxt = item.FindControl("lblCorrectAnswertxt") as Label;
            Label lblCorrectAnswer = item.FindControl("lblCorrectAnswer") as Label;
            Label lblCheckAnswer = item.FindControl("lblCheckAnswer") as Label;
            TextBox txtAnswer = item.FindControl("txtAnswer") as TextBox;
            lblstrPositiveAnswerResponse.Visible = false;
            lblstrPositiveAnswerResponse.ForeColor=Color.Green;
            lblstrNegetiveAnswerResponse.Visible = false;
            lblstrNegetiveAnswerResponse.ForeColor = Color.DarkRed;
            lblCorrectAnswertxt.Visible = true;
            lblCorrectAnswer.Visible = true;



            if (lblCheckAnswer.Text.ToUpper().Trim().Contains(txtAnswer.Text.ToUpper().Trim()) && txtAnswer.Text != "")
            {
                lblstrPositiveAnswerResponse.Visible = true;
            }
            else
            {
                lblstrNegetiveAnswerResponse.Visible = true;
            }
        }
    }
}