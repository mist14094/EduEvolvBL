using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using AaruthraEduEvolvConstants;
using NLog;

namespace AaruthraEduEvolvDL
{
    public class DataAccess
    {
        internal Logger Nlog = LogManager.GetCurrentClassLogger();
        readonly AaruthraEduEvolvConstants.Constants _constants = new Constants();
        private string _connectionString;

        public DataAccess()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            _connectionString = _constants.DefaultConnectionString;
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Exit");
        }

        public DataTable GetAllUser()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllUser)
                ,
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public int CheckUser(string Username, string Password)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_CheckUserAccount),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@Username", Username);
            selectCommand.Parameters.AddWithValue("@Password", Password);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable ManualActivation(string UserID, DateTime ExpirationDate)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.ManualActivation),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@UserID", UserID);
            selectCommand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetAllCourse()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllCourse)
                ,
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetAllMaterials()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllMaterials)
                ,
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetUserSubscription(string UserID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetSubscription),
                CommandType = CommandType.Text,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@UserID", UserID);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }



        public int insertUser(string FirstName, string LastName, string CompanyName, string Address, string City, string State, string Pincode, string Phone, string Email, string Username, string Password)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_InsertUserAccount),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@FirstName", FirstName);
            selectCommand.Parameters.AddWithValue("@LastName", LastName);
            selectCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
            selectCommand.Parameters.AddWithValue("@Address", Address);
            selectCommand.Parameters.AddWithValue("@City", City);
            selectCommand.Parameters.AddWithValue("@State", State);
            selectCommand.Parameters.AddWithValue("@Pincode", Pincode);
            selectCommand.Parameters.AddWithValue("@Phone", Phone);
            selectCommand.Parameters.AddWithValue("@Email", Email);
            selectCommand.Parameters.AddWithValue("@Username", Username);
            selectCommand.Parameters.AddWithValue("@Password", Password);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataSet sendActivationMail(int userId)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataSet = new DataSet();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_SendAccountActivationMail),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@UserID", userId);
          
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public int ActivateUser(string code)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_ActivateMailAccount),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@code", code);
           
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public int RessetPassword(string EmailID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_RequestPasswordReset),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@EmailID", EmailID);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }

        }
        public DataSet SendPasswordResetMail(int userId)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataSet = new DataSet();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_SendPasswordResetMail),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@UserID", userId);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }
        public int RequestForPasswordChange(string code)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_RequestPasswordChange),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@code", code);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }


        public int ChangePassword(string code, string password)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_ChangePassword),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@code", code);
            selectCommand.Parameters.AddWithValue("@password", password);

            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                return Convert.ToInt32(selectCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public object GetCustomerCourse(int UserID)
        {
            throw new NotImplementedException();
        }


        public String InsertDatabaseLog(string keyName, string keyValues,string dt)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.InsertDatabaseLog,keyName,keyValues,dt)
                ,
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return "1";
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }


        //public string insertUser(string FirstName, string LastName, string CompanyName, string Address, string City, string State, string Pincode, string Phone, string Email, string Username, string Password)
        //{
        //    try
        //    {
        //        int userId = 0;
        //        string constr = _constants.DefaultConnectionString;
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("sp_InsertUser"))
        //            {
        //                using (SqlDataAdapter sda = new SqlDataAdapter())
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
        //                    cmd.Parameters.AddWithValue("@LastName", LastName);
        //                    cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
        //                    cmd.Parameters.AddWithValue("@Address", Address);
        //                    cmd.Parameters.AddWithValue("@City", City);
        //                    cmd.Parameters.AddWithValue("@State", State);
        //                    cmd.Parameters.AddWithValue("@Pincode", Pincode);
        //                    cmd.Parameters.AddWithValue("@Phone", Phone);
        //                    cmd.Parameters.AddWithValue("@Email", Email);
        //                    cmd.Parameters.AddWithValue("@Username", Username);
        //                    cmd.Parameters.AddWithValue("@Password", Password);

        //                    cmd.Connection = con;
        //                    con.Open();
        //                    userId = Convert.ToInt32(cmd.ExecuteScalar());
        //                    con.Close();
        //                }
        //            }
        //            string message = string.Empty;
        //            switch (userId)
        //            {
        //                case -1:
        //                    message = "Username already exists.Please choose a different username.";
        //                    break;
        //                case -2:
        //                    message = "Entered email address has already been used.";
        //                    break;
        //                case -3:
        //                    message = "Entered mobile has already been used.";
        //                    break;
        //                default:
        //                    message = "Registration successful. Activation Mail Sent to the registered email ID";
        //                    sendActivationMail(userId);
        //                    break;
        //            }
        //            return message;
        //            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("SQL Error" + ex.Message.ToString());
        //        return "Error";
        //    }
        //}



        public DataSet CheckUserSubscriptions(string userName)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_CheckUserSubscriptions),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@Username", userName);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetAllTransactions()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllTransactions),
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }


        public DataTable GetTransaction(string TransactionMaster)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetTranscation, TransactionMaster),
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }


        public DataSet MakeTransaction(int UserID, string CourseID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_MakeTranscation),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@UserID", UserID);
            selectCommand.Parameters.AddWithValue("@CourseID", CourseID);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetAllSubscriptionRequests()
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllSubscriptionRequests),
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }

        }
        public DataTable CompleteTransaction(string strTransactionID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.CompleteTransaction, strTransactionID),
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }


        public DataTable MakeSubscription(string strTransactionID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.sp_MakeSubscriptions),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            //selectCommand.Parameters.AddWithValue("@UserID", UserID);
            selectCommand.Parameters.AddWithValue("@TransactionID", strTransactionID);
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataTable GetAllSubscription(string strUserID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetAllSubscription,strUserID)
                ,
                CommandTimeout = 180,
            };


            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataSet GetSubscriptionDetails(int intSubscription)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.GetSubscriptionDetails),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@SubscriptionID", intSubscription);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataSet UpdateSubscription(DateTime ExpirationDate,int SubscriptionID, int UserID, int CourseID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.UpdateSubscription),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@ExpiredOn", ExpirationDate);
            selectCommand.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
            selectCommand.Parameters.AddWithValue("@UserID", UserID);
            selectCommand.Parameters.AddWithValue("@CourseID", CourseID);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

        public DataSet DeleteSubscription(DateTime ExpirationDate, int SubscriptionID, int UserID, int CourseID)
        {
            Nlog.Trace(message: this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name + "::Entering");
            var dataTable = new DataTable();
            var selectCommand = new SqlCommand
            {
                CommandText = string.Format(_constants.DeleteSubscription),
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 180,
            };
            selectCommand.Parameters.AddWithValue("@ExpiredOn", ExpirationDate);
            selectCommand.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
            selectCommand.Parameters.AddWithValue("@UserID", UserID);
            selectCommand.Parameters.AddWithValue("@CourseID", CourseID);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(selectCommand);
            var connection = new SqlConnection(_constants.DefaultConnectionString);
            selectCommand.Connection = connection;
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                Nlog.Trace(
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Error", ex);
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                Nlog.Trace(message:
                    this.GetType().Namespace + ":" + MethodBase.GetCurrentMethod().DeclaringType.Name + ":" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name + "::Leaving");
            }
        }

    }
}
