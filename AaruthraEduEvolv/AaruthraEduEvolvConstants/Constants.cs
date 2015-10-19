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

        public string sp_ChangePassword = "sp_ChangePassword";

        public string InsertDatabaseLog = "INSERT INTO [rasucas].[DataBaseLog]([KeyName],[KeyValue],TransactionMaster)VALUES ('{0}','{1}','{2}')";

        public string sp_CheckUserSubscriptions = "sp_CheckUserSubscriptions";


        public string GetTranscation =
            "SELECT * FROM (SELECT [TransactionMaster], [KeyName], [KeyValue]FROM  [DataBaseLog] WHERE [TransactionMaster]='{0}' ) AS InitialValue   PIVOT  (MAX  ([KeyValue]) FOR [keyname] IN (custom_fields,amount,offer_title,offer_slug,buyer_name,unit_price,status,mac,quantity,payment_id,variants,fees,currency,buyer_phone,buyer,verified)) AS pivotValue";

        public string GetAllTransactions = "SELECT * FROM (SELECT [TransactionMaster], [KeyName], [KeyValue]FROM  [DataBaseLog] ) AS InitialValue   PIVOT  (MAX  ([KeyValue]) FOR [keyname] IN (custom_fields,amount,offer_title,offer_slug,buyer_name,unit_price,status,mac,quantity,payment_id,variants,fees,currency,buyer_phone,buyer,verified)) AS pivotValue";

        public string sp_MakeTranscation = "sp_MakeTranscation";
        public string GetAllSubscriptionRequests = @"SELECT * FROM (
        SELECT [TransactionMaster], [KeyName], [KeyValue]FROM  [DataBaseLog] ) AS InitialValue
        PIVOT
        (MAX
        ([KeyValue]) FOR [keyname] IN (payment_id,custom_fields,amount,offer_title,offer_slug,buyer_name,status,verified,TransactionID)) AS pivotValue
        ORDER BY verified";

        public string CompleteTransaction =
           "  UPDATE TransactionMaster SET IsCompleteTransaction=1 WHERE TransactionID='{0}'";

        public string sp_MakeSubscriptions = "sp_MakeSubscriptions";

        public string GetAllSubscription = "SELECT *  FROM [course].[Subscription] WHERE UserID={0}";

        public string ManualActivation = "sp_ManualActivation";

        public string GetSubscriptionDetails = "sp_GetSubscriptionDetails";

        public string UpdateSubscription = "sp_UpdateSubscription"; 
        public string DeleteSubscription = "sp_DeleteSubscription";
        public string GetTestMasterDetail = "SELECT *   FROM [veeraEDU].[rasucas].[TestMaster] WHERE MaterialID={0}";

        public string GetQuestionSetForMaster =
            "SELECT *  FROM [veeraEDU].[rasucas].[TestQuestions] WHERE MasterTestID={0}";

        public string GetOralMasterDetail = "SELECT *   FROM [veeraEDU].[rasucas].[OralMaster] WHERE MaterialID={0}";

        public string GetOralQuestionSetForMaster =
            "SELECT *  FROM [veeraEDU].[rasucas].[OralQuestions] WHERE MasterTestID={0}";
    }
}
