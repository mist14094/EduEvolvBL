using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace AaruthraEduEvolvConstants
{
    public class Test
    {
        public int intSno { get; set; }
        public int intMaterialID { get; set; }
        public string strTestTitle { get; set; }
        public string strDescription { get; set; }
        public string strSkillLevel { get; set; }
        public int intDuration { get; set; }
        public bool boolIsValid { get; set; }
        public DateTime dtCreatedDate { get; set; }
        public List<QuestionandAnswers> QuestionList { get; set; }

       

        public Test GetMasterQuestionSet(DataTable masterQuestion,List<QuestionandAnswers> lstQuestions)
        {
            Test test = new Test();
            foreach (DataRow row in masterQuestion.Rows)
            {
                try
                {

                    test.intSno = Convert.ToInt16(row["Sno"].ToString());
                    test.intMaterialID = Convert.ToInt16(row["MaterialID"].ToString());
                    test.strTestTitle = Convert.ToString(row["TestTitle"].ToString());
                    test.strDescription = Convert.ToString(row["TestDescription"].ToString());
                    test.strSkillLevel = Convert.ToString(row["SkillLevel"].ToString());
                    test.intDuration = Convert.ToInt16(row["DurationinMinutes"].ToString());
                    test.boolIsValid = Convert.ToBoolean(row["isValid"].ToString() == "1" ? "True" : "False");
                    test.dtCreatedDate = Convert.ToDateTime(row["CreatedDate"].ToString());
                    test.QuestionList = lstQuestions;

                }
                catch (Exception)
                {
                    throw;
                }

            }
            return test;
        }

    }

    public class QuestionandAnswers
    {
        public int intSno { get; set; }
        public int intMasterTestID { get; set; }
        public string strQuestionNumber { get; set; }
        public string strQuestion { get; set; }
        public string strQuestionDescription { get; set; }
        public string strQuestionHint { get; set; }
        public string strQuestionAL { get; set; }
        public string strAnswerChoice { get; set; }
        public string strAnswerHint { get; set; }
        public string strAnswerDesc { get; set; }
        public string strPositiveAnswerResponse { get; set; }
        public string strNegetiveAnswerResponse { get; set; }
        public string strAnswerAudio { get; set; }
        public int intSortOrder { get; set; }
        public bool blisValid { get; set; }
        public DateTime dtCreatedDate { get; set; }
        public int intPassMark { get; set; } 
        public int intFailMark { get; set; }

        public List<QuestionandAnswers> GetQuestionAnswers(DataTable questionTable)
        {
            List<QuestionandAnswers> lstQuestionandAnswers = new List<QuestionandAnswers>();
            foreach (DataRow row in questionTable.Rows)
            {
                try
                {
                    QuestionandAnswers qaAnswers = new QuestionandAnswers();
                    qaAnswers.intSno = Convert.ToInt16(row["Sno"].ToString());
                    qaAnswers.intMasterTestID = Convert.ToInt16(row["MasterTestID"].ToString());
                    qaAnswers.strQuestionNumber = Convert.ToString(row["QuestionNumber"].ToString());
                    qaAnswers.strQuestion = Convert.ToString(row["Question"].ToString());
                    qaAnswers.strQuestionDescription = Convert.ToString(row["QuestionDescription"].ToString());
                    qaAnswers.strQuestionHint = Convert.ToString(row["QuestionHint"].ToString());
                    qaAnswers.strQuestionAL = Convert.ToString(row["QuestionAudioLink"].ToString());
                    qaAnswers.strAnswerChoice = Convert.ToString(row["AnswerChoice"].ToString());
                    qaAnswers.strAnswerHint = Convert.ToString(row["AnswerHint"].ToString());
                    qaAnswers.strAnswerDesc = Convert.ToString(row["AnswerDescription"].ToString());
                    qaAnswers.strPositiveAnswerResponse = Convert.ToString(row["PositiveAnswerResponse"].ToString());
                    qaAnswers.strNegetiveAnswerResponse = Convert.ToString(row["NegativeAnswerResponse"].ToString());
                    qaAnswers.strAnswerAudio = Convert.ToString(row["AnswerAudio"].ToString());
                    qaAnswers.intSortOrder = Convert.ToInt16(row["SortOrder"].ToString());
                    qaAnswers.blisValid = Convert.ToBoolean(row["isValid"].ToString()=="1"?"True":"False");
                    qaAnswers.dtCreatedDate = Convert.ToDateTime(row["CreatedDate"].ToString());
                    qaAnswers.intPassMark = Convert.ToInt16(row["PassMark"].ToString());
                    qaAnswers.intFailMark = Convert.ToInt16(row["FailMark"].ToString());
                    lstQuestionandAnswers.Add(qaAnswers);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return lstQuestionandAnswers;
        }

       
    }


}
