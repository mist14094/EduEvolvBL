using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace AaruthraEduEvolvConstants
{

    public class Constants
    {
        public static string DefaultString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public string DefaultConnectionString
        {
            get
            {
                return DefaultString;
            }
            set
            {
                DefaultString = value;
            }

            
    }
        public string GetAllUser =
            " SELECT  [user].UserDetails.UserID , FirstName , LastName , OrganizationName , EmailID , MobileNo , [user].UserDetails.CreatedDate , [user].UserDetails.ModifiedDate , AccountID , UserName FROM [USER].[USERDETAILS] LEFT OUTER JOIN [user].[UserAccounts] ON [user].UserDetails.UserID = [user].UserAccounts.UserID";

        public string sp_InsertUserAccount = "sp_InsertUser";

        public string sp_CheckUserAccount = "sp_CheckUserAccount";

        public string GetAllCourse =
            "SELECT [CourseID] ,[CourseName] ,[Description] ,[Thumbnail],[Author] ,[Duration] ,[SortOrder] ,[Fees] ,[CreatedDate] ,[ModifiedDate]  FROM [course].[CourseDetails]";

        public string GetAllMaterials = 
            "SELECT [MaterialID] ,[CourseID] ,[Title] ,[Description] ,[Length] ,[StatusID] ,[VideoURL] ,[Thumbnail],[SortOrder] ,[CreatedDate],[ModifiedDate]  FROM [course].[Material]";

        public string GetSubscription =
            "SELECT [SubscriptionID] ,[UserID] ,[CourseID] ,[ActivationDate] ,[ExpiredOn] ,[StatusID]  FROM [veeraEDU].[course].[Subscription] WHERE UserID = @userID and ExpiredOn >= getdate()";

        public string sp_SendAccountActivationMail = "sp_SendAccountActivationMail";

        public string sp_ActivateMailAccount = "sp_ActivateMailAccount";

        public string sp_RequestPasswordReset = "sp_RequestPasswordReset";

        public string sp_SendPasswordResetMail = "sp_SendPasswordResetMail";

        public string sp_RequestPasswordChange = "sp_CheckPasswordReset";
    }
}
