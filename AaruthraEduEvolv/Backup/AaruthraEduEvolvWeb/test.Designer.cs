﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace AaruthraEduEvolvWeb
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class VeeraEDUEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new VeeraEDUEntities object using the connection string found in the 'VeeraEDUEntities' section of the application configuration file.
        /// </summary>
        public VeeraEDUEntities() : base("name=VeeraEDUEntities", "VeeraEDUEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new VeeraEDUEntities object.
        /// </summary>
        public VeeraEDUEntities(string connectionString) : base(connectionString, "VeeraEDUEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new VeeraEDUEntities object.
        /// </summary>
        public VeeraEDUEntities(EntityConnection connection) : base(connection, "VeeraEDUEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ErrorLog> ErrorLogs
        {
            get
            {
                if ((_ErrorLogs == null))
                {
                    _ErrorLogs = base.CreateObjectSet<ErrorLog>("ErrorLogs");
                }
                return _ErrorLogs;
            }
        }
        private ObjectSet<ErrorLog> _ErrorLogs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ActivityLog> ActivityLogs
        {
            get
            {
                if ((_ActivityLogs == null))
                {
                    _ActivityLogs = base.CreateObjectSet<ActivityLog>("ActivityLogs");
                }
                return _ActivityLogs;
            }
        }
        private ObjectSet<ActivityLog> _ActivityLogs;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ErrorLogs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToErrorLogs(ErrorLog errorLog)
        {
            base.AddObject("ErrorLogs", errorLog);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ActivityLogs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToActivityLogs(ActivityLog activityLog)
        {
            base.AddObject("ActivityLogs", activityLog);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="VeeraEDUModel", Name="ActivityLog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ActivityLog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ActivityLog object.
        /// </summary>
        /// <param name="logID">Initial value of the LogID property.</param>
        public static ActivityLog CreateActivityLog(global::System.Int32 logID)
        {
            ActivityLog activityLog = new ActivityLog();
            activityLog.LogID = logID;
            return activityLog;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LogID
        {
            get
            {
                return _LogID;
            }
            set
            {
                if (_LogID != value)
                {
                    OnLogIDChanging(value);
                    ReportPropertyChanging("LogID");
                    _LogID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("LogID");
                    OnLogIDChanged();
                }
            }
        }
        private global::System.Int32 _LogID;
        partial void OnLogIDChanging(global::System.Int32 value);
        partial void OnLogIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                OnUserIDChanging(value);
                ReportPropertyChanging("UserID");
                _UserID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserID");
                OnUserIDChanged();
            }
        }
        private Nullable<global::System.Int32> _UserID;
        partial void OnUserIDChanging(Nullable<global::System.Int32> value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CreatedTime
        {
            get
            {
                return _CreatedTime;
            }
            set
            {
                OnCreatedTimeChanging(value);
                ReportPropertyChanging("CreatedTime");
                _CreatedTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedTime");
                OnCreatedTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _CreatedTime;
        partial void OnCreatedTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnCreatedTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Page
        {
            get
            {
                return _Page;
            }
            set
            {
                OnPageChanging(value);
                ReportPropertyChanging("Page");
                _Page = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Page");
                OnPageChanged();
            }
        }
        private global::System.String _Page;
        partial void OnPageChanging(global::System.String value);
        partial void OnPageChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Action
        {
            get
            {
                return _Action;
            }
            set
            {
                OnActionChanging(value);
                ReportPropertyChanging("Action");
                _Action = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Action");
                OnActionChanged();
            }
        }
        private global::System.String _Action;
        partial void OnActionChanging(global::System.String value);
        partial void OnActionChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="VeeraEDUModel", Name="ErrorLog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ErrorLog : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ErrorLog object.
        /// </summary>
        /// <param name="logID">Initial value of the LogID property.</param>
        /// <param name="logTime">Initial value of the LogTime property.</param>
        public static ErrorLog CreateErrorLog(global::System.Int32 logID, global::System.DateTime logTime)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.LogID = logID;
            errorLog.LogTime = logTime;
            return errorLog;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 LogID
        {
            get
            {
                return _LogID;
            }
            set
            {
                if (_LogID != value)
                {
                    OnLogIDChanging(value);
                    ReportPropertyChanging("LogID");
                    _LogID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("LogID");
                    OnLogIDChanged();
                }
            }
        }
        private global::System.Int32 _LogID;
        partial void OnLogIDChanging(global::System.Int32 value);
        partial void OnLogIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LogTime
        {
            get
            {
                return _LogTime;
            }
            set
            {
                OnLogTimeChanging(value);
                ReportPropertyChanging("LogTime");
                _LogTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LogTime");
                OnLogTimeChanged();
            }
        }
        private global::System.DateTime _LogTime;
        partial void OnLogTimeChanging(global::System.DateTime value);
        partial void OnLogTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Activity
        {
            get
            {
                return _Activity;
            }
            set
            {
                OnActivityChanging(value);
                ReportPropertyChanging("Activity");
                _Activity = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Activity");
                OnActivityChanged();
            }
        }
        private global::System.String _Activity;
        partial void OnActivityChanging(global::System.String value);
        partial void OnActivityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ActivityDesc
        {
            get
            {
                return _ActivityDesc;
            }
            set
            {
                OnActivityDescChanging(value);
                ReportPropertyChanging("ActivityDesc");
                _ActivityDesc = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ActivityDesc");
                OnActivityDescChanged();
            }
        }
        private global::System.String _ActivityDesc;
        partial void OnActivityDescChanging(global::System.String value);
        partial void OnActivityDescChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                OnErrorMessageChanging(value);
                ReportPropertyChanging("ErrorMessage");
                _ErrorMessage = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ErrorMessage");
                OnErrorMessageChanged();
            }
        }
        private global::System.String _ErrorMessage;
        partial void OnErrorMessageChanging(global::System.String value);
        partial void OnErrorMessageChanged();

        #endregion

    
    }

    #endregion

    
}