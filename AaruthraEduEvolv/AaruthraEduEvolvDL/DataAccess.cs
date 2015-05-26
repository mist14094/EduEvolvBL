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
    }
}
