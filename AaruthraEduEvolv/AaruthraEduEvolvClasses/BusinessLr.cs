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

        public BusinessLr()
        {
            _nlog.Trace(message:
              this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
              System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            _access = new DataAccess();
            _customer = new Customer();
            _course = new Video.Course();
            _material = new Video.Material();
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
    }

}
