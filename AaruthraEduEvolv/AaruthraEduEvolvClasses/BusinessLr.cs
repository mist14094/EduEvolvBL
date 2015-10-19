using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using AaruthraEduEvolvDL;
using NLog;
using AaruthraEduEvolvConstants;
namespace AaruthraEduEvolvBL
{
    public class BusinessLr
    {
        private readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private AaruthraEduEvolvDL.DataAccess _access;
        private AaruthraEduEvolvConstants.Customer _customer;
        private AaruthraEduEvolvConstants.Video.Course _course;
        private AaruthraEduEvolvConstants.Video.Material _material;
        private AaruthraEduEvolvConstants.Test _test;
        private AaruthraEduEvolvConstants.QuestionandAnswers _questionandAnswers;

        public BusinessLr()
        {
            _nlog.Trace(message:
              this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
              System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            _access = new DataAccess();
            _customer = new Customer();
            _course = new Video.Course();
            _material = new Video.Material();
            _test = new Test();
            _questionandAnswers = new QuestionandAnswers();
            _nlog.Trace(message:
              this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
              System.Reflection.MethodBase.GetCurrentMethod().Name + "::Exit");
        }
        public List<Customer> GetAlCustomer()
        {
            _nlog.Trace(message:
              this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
              System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _customer.toCustomer(_access.GetAllUser());
        }

        public int CheckUser(string Username, string Password)
        {
            _nlog.Trace(message:
             this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
             System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.CheckUser(Username, Password);
        }

        public Customer GetCustomer(string UserName)
        {
            Customer csCustomer = GetAlCustomer().SingleOrDefault(customer => customer.strUserName == UserName);
            if (csCustomer != null)
            {
                csCustomer.Courses = GetUserSubscription(csCustomer.intUserID.ToString(CultureInfo.InvariantCulture));

            }
            return csCustomer;
        }


        public List<Video.Course> GetCourses()
        {
            _nlog.Trace(message:
           this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
           System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _course.ToVideo(_access.GetAllCourse());
        }

        public List<Video.Course> GetCoursesWithMaterials()
        {
            _nlog.Trace(message:
           this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
           System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            List<Video.Course> csCourses = _course.ToVideo(_access.GetAllCourse());
            int i = 0;
            foreach (var cCourses in csCourses)
            {
                csCourses[i].Materials = GetMaterialsForCourses(cCourses.CourseId);
                i++;
            }
            return csCourses;
        }

        public List<Video.Material> GetMaterialsForCourses(int courseID)
        {
            _nlog.Trace(message:
         this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
         System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _material.ToVideo(_access.GetAllMaterials()).Where(material => material.CourseID.Equals(courseID)).ToList();
        }
        public List<Video.Material> GetMaterials()
        {
            _nlog.Trace(message:
           this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
           System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _material.ToVideo(_access.GetAllMaterials());
        }

        public List<Video.Course> GetUserSubscription(string UserID)
        {
            _nlog.Trace(message:
           this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
           System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");

            List<Video.Course> i = new List<Video.Course>();
            List<Video.Course> cs = GetCoursesWithMaterials();
            foreach (DataRow VARIABLE in _access.GetUserSubscription(UserID).Rows)
            {
                i.Add(cs.SingleOrDefault(course => course.CourseId.Equals(VARIABLE["CourseID"])));
            }

            return i;
        }


        public int insertUser(string FirstName, string LastName, string CompanyName, string Address, string City, string State, string Pincode, string Phone, string Email, string Username, string Password)
        {
            _nlog.Trace(message:
               this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
               System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.insertUser(FirstName, LastName, CompanyName, Address, City, State, Pincode, Phone, Email, Username, Password);

        }

        public DataSet sendActivationMail(int userId)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.sendActivationMail(userId);
        }

        public int ActivateUser(string code)
        {
            _nlog.Trace(message:
             this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
             System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.ActivateUser(code);

        }

        public int ressetPassword(string EmailID)
        {
            _nlog.Trace(message:
             this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
             System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.RessetPassword(EmailID);
        }

        public DataSet SendPasswordResetMail(int userId)
        {
            _nlog.Trace(message:
                  this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                  System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.SendPasswordResetMail(userId);
        }

        public int RequestForPasswordChange(string code)
        {
            _nlog.Trace(message:
                  this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                  System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.RequestForPasswordChange(code);
        }

        public int ChangePassword(string code, string password)
        {
            _nlog.Trace(message:
                  this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                  System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.ChangePassword(code, password);
        }

        public object GetCustomerCourse(int UserID)
        {
            _nlog.Trace(message:
                   this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                   System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetCustomerCourse(UserID);
        }

        public String InsertDatabaseLog(string keyName, string keyValues, string dt)
        {
            _nlog.Trace(message:
                 this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                 System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.InsertDatabaseLog(keyName, keyValues, dt);
        }

        public DataSet CheckUserSubscriptions(string userName)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.CheckUserSubscriptions(userName);
        }

        public DataTable GetTransaction(string TransactionMaster)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetTransaction(TransactionMaster);
        }

        public DataTable GetAllTransactions()
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetAllTransactions();
        }

        public DataSet MakeTransaction(int UserID, string CourseID)
        {
            _nlog.Trace(message:
               this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
               System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.MakeTransaction(UserID, CourseID);
        }

        public DataTable GetAllSubscriptionRequests()
        {
            _nlog.Trace(message:
              this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
              System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetAllSubscriptionRequests();
        }



        public DataTable CompleteTransaction(string strTransactionID)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.CompleteTransaction(strTransactionID);
        }

        public DataTable MakeSubscription(string strTransactionID)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.MakeSubscription(strTransactionID);
        }

        public DataTable GetAllSubscription(string strUserID)
        {
            _nlog.Trace(message:
                this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetAllSubscription(strUserID);
        }

        public DataTable ManualActivation(string UserID, DateTime ExpirationDate)
        {
            _nlog.Trace(message:
             this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
             System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.ManualActivation(UserID, ExpirationDate);
        }

        public DataSet GetSubscriptionDetails(int intSubscription)
        {
            _nlog.Trace(message:
        this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
        System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.GetSubscriptionDetails(intSubscription);
        }

        public DataSet UpdateSubscription(DateTime ExpirationDate, int SubscriptionID, int UserID, int CourseID)
        {
            _nlog.Trace(message:
     this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
     System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.UpdateSubscription(ExpirationDate, SubscriptionID, UserID, CourseID);
        }
        public DataSet DeleteSubscription(DateTime ExpirationDate, int SubscriptionID, int UserID, int CourseID)
        {
            _nlog.Trace(message:
     this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
     System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _access.DeleteSubscription(ExpirationDate, SubscriptionID, UserID, CourseID);
        }


        public List<QuestionandAnswers> GetQuestionandAnswers(int intMasterTestID)
        {
            _nlog.Trace(message:
     this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
     System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _questionandAnswers.GetQuestionAnswers(_access.GetQuestionSetForMaster(intMasterTestID));
        }



        public Test GetMasterQuestionSet(int masterQuestion)
        {
            _nlog.Trace(message:
   this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
   System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var TestMaster = _access.GetTestMasterDetail(masterQuestion);
            if (TestMaster.Rows.Count > 0)
            {
                return _test.GetMasterQuestionSet(TestMaster,
                    GetQuestionandAnswers(Convert.ToInt16(TestMaster.Rows[0]["Sno"].ToString())));
            }
            else
            {
                return null;
            }
        }
        public List<QuestionandAnswers> GetOralQuestionandAnswers(int intMasterTestID)
        {
            _nlog.Trace(message:
     this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
     System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            return _questionandAnswers.GetQuestionAnswers(_access.GetOralQuestionSetForMaster(intMasterTestID));
        }

        public Test GetOralMasterQuestionSet(int masterQuestion)
        {
            _nlog.Trace(message:
   this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
   System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var TestMaster = _access.GetOralMasterDetail(masterQuestion);
            if (TestMaster.Rows.Count > 0)
            {
                return _test.GetMasterQuestionSet(TestMaster,
                    GetOralQuestionandAnswers(Convert.ToInt16(TestMaster.Rows[0]["Sno"].ToString())));
            }
            else
            {
                return null;
            }
        }

    }

}
