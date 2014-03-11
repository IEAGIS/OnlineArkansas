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
namespace OnlineArkansas
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class OnlineArkansasContext : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new OnlineArkansasContext object using the connection string found in the 'OnlineArkansasContext' section of the application configuration file.
        /// </summary>
        public OnlineArkansasContext() : base("name=OnlineArkansasContext", "OnlineArkansasContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new OnlineArkansasContext object.
        /// </summary>
        public OnlineArkansasContext(string connectionString) : base(connectionString, "OnlineArkansasContext")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new OnlineArkansasContext object.
        /// </summary>
        public OnlineArkansasContext(EntityConnection connection) : base(connection, "OnlineArkansasContext")
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
        public ObjectSet<Course> Courses
        {
            get
            {
                if ((_Courses == null))
                {
                    _Courses = base.CreateObjectSet<Course>("Courses");
                }
                return _Courses;
            }
        }
        private ObjectSet<Course> _Courses;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Registration> Registrations
        {
            get
            {
                if ((_Registrations == null))
                {
                    _Registrations = base.CreateObjectSet<Registration>("Registrations");
                }
                return _Registrations;
            }
        }
        private ObjectSet<Registration> _Registrations;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<State> States
        {
            get
            {
                if ((_States == null))
                {
                    _States = base.CreateObjectSet<State>("States");
                }
                return _States;
            }
        }
        private ObjectSet<State> _States;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Configuration> Configurations
        {
            get
            {
                if ((_Configurations == null))
                {
                    _Configurations = base.CreateObjectSet<Configuration>("Configurations");
                }
                return _Configurations;
            }
        }
        private ObjectSet<Configuration> _Configurations;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Courses EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCourses(Course course)
        {
            base.AddObject("Courses", course);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Registrations EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRegistrations(Registration registration)
        {
            base.AddObject("Registrations", registration);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the States EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToStates(State state)
        {
            base.AddObject("States", state);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Configurations EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToConfigurations(Configuration configuration)
        {
            base.AddObject("Configurations", configuration);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OnlineArkansasModel", Name="Configuration")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Configuration : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Configuration object.
        /// </summary>
        /// <param name="primaryKey">Initial value of the primaryKey property.</param>
        /// <param name="value1">Initial value of the value1 property.</param>
        /// <param name="value2">Initial value of the value2 property.</param>
        /// <param name="keyCode">Initial value of the keyCode property.</param>
        public static Configuration CreateConfiguration(global::System.Int64 primaryKey, global::System.String value1, global::System.String value2, global::System.String keyCode)
        {
            Configuration configuration = new Configuration();
            configuration.primaryKey = primaryKey;
            configuration.value1 = value1;
            configuration.value2 = value2;
            configuration.keyCode = keyCode;
            return configuration;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 primaryKey
        {
            get
            {
                return _primaryKey;
            }
            set
            {
                if (_primaryKey != value)
                {
                    OnprimaryKeyChanging(value);
                    ReportPropertyChanging("primaryKey");
                    _primaryKey = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("primaryKey");
                    OnprimaryKeyChanged();
                }
            }
        }
        private global::System.Int64 _primaryKey;
        partial void OnprimaryKeyChanging(global::System.Int64 value);
        partial void OnprimaryKeyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String value1
        {
            get
            {
                return _value1;
            }
            set
            {
                Onvalue1Changing(value);
                ReportPropertyChanging("value1");
                _value1 = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("value1");
                Onvalue1Changed();
            }
        }
        private global::System.String _value1;
        partial void Onvalue1Changing(global::System.String value);
        partial void Onvalue1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String value2
        {
            get
            {
                return _value2;
            }
            set
            {
                Onvalue2Changing(value);
                ReportPropertyChanging("value2");
                _value2 = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("value2");
                Onvalue2Changed();
            }
        }
        private global::System.String _value2;
        partial void Onvalue2Changing(global::System.String value);
        partial void Onvalue2Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String keyCode
        {
            get
            {
                return _keyCode;
            }
            set
            {
                OnkeyCodeChanging(value);
                ReportPropertyChanging("keyCode");
                _keyCode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("keyCode");
                OnkeyCodeChanged();
            }
        }
        private global::System.String _keyCode;
        partial void OnkeyCodeChanging(global::System.String value);
        partial void OnkeyCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String codeDescription
        {
            get
            {
                return _codeDescription;
            }
            set
            {
                OncodeDescriptionChanging(value);
                ReportPropertyChanging("codeDescription");
                _codeDescription = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("codeDescription");
                OncodeDescriptionChanged();
            }
        }
        private global::System.String _codeDescription;
        partial void OncodeDescriptionChanging(global::System.String value);
        partial void OncodeDescriptionChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OnlineArkansasModel", Name="Course")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Course : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Course object.
        /// </summary>
        /// <param name="courseID">Initial value of the courseID property.</param>
        /// <param name="courseName">Initial value of the courseName property.</param>
        /// <param name="courseFee">Initial value of the courseFee property.</param>
        /// <param name="courseStartDate">Initial value of the courseStartDate property.</param>
        /// <param name="courseEndDate">Initial value of the courseEndDate property.</param>
        /// <param name="courseDescription">Initial value of the courseDescription property.</param>
        public static Course CreateCourse(global::System.Int64 courseID, global::System.String courseName, global::System.Decimal courseFee, global::System.DateTime courseStartDate, global::System.DateTime courseEndDate, global::System.String courseDescription)
        {
            Course course = new Course();
            course.courseID = courseID;
            course.courseName = courseName;
            course.courseFee = courseFee;
            course.courseStartDate = courseStartDate;
            course.courseEndDate = courseEndDate;
            course.courseDescription = courseDescription;
            return course;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 courseID
        {
            get
            {
                return _courseID;
            }
            set
            {
                if (_courseID != value)
                {
                    OncourseIDChanging(value);
                    ReportPropertyChanging("courseID");
                    _courseID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("courseID");
                    OncourseIDChanged();
                }
            }
        }
        private global::System.Int64 _courseID;
        partial void OncourseIDChanging(global::System.Int64 value);
        partial void OncourseIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String courseName
        {
            get
            {
                return _courseName;
            }
            set
            {
                OncourseNameChanging(value);
                ReportPropertyChanging("courseName");
                _courseName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("courseName");
                OncourseNameChanged();
            }
        }
        private global::System.String _courseName;
        partial void OncourseNameChanging(global::System.String value);
        partial void OncourseNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal courseFee
        {
            get
            {
                return _courseFee;
            }
            set
            {
                OncourseFeeChanging(value);
                ReportPropertyChanging("courseFee");
                _courseFee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseFee");
                OncourseFeeChanged();
            }
        }
        private global::System.Decimal _courseFee;
        partial void OncourseFeeChanging(global::System.Decimal value);
        partial void OncourseFeeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime courseStartDate
        {
            get
            {
                return _courseStartDate;
            }
            set
            {
                OncourseStartDateChanging(value);
                ReportPropertyChanging("courseStartDate");
                _courseStartDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseStartDate");
                OncourseStartDateChanged();
            }
        }
        private global::System.DateTime _courseStartDate;
        partial void OncourseStartDateChanging(global::System.DateTime value);
        partial void OncourseStartDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime courseEndDate
        {
            get
            {
                return _courseEndDate;
            }
            set
            {
                OncourseEndDateChanging(value);
                ReportPropertyChanging("courseEndDate");
                _courseEndDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseEndDate");
                OncourseEndDateChanged();
            }
        }
        private global::System.DateTime _courseEndDate;
        partial void OncourseEndDateChanging(global::System.DateTime value);
        partial void OncourseEndDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String courseInstructor
        {
            get
            {
                return _courseInstructor;
            }
            set
            {
                OncourseInstructorChanging(value);
                ReportPropertyChanging("courseInstructor");
                _courseInstructor = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("courseInstructor");
                OncourseInstructorChanged();
            }
        }
        private global::System.String _courseInstructor;
        partial void OncourseInstructorChanging(global::System.String value);
        partial void OncourseInstructorChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String courseDescription
        {
            get
            {
                return _courseDescription;
            }
            set
            {
                OncourseDescriptionChanging(value);
                ReportPropertyChanging("courseDescription");
                _courseDescription = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("courseDescription");
                OncourseDescriptionChanged();
            }
        }
        private global::System.String _courseDescription;
        partial void OncourseDescriptionChanging(global::System.String value);
        partial void OncourseDescriptionChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OnlineArkansasModel", Name="Registration")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Registration : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Registration object.
        /// </summary>
        /// <param name="registrationId">Initial value of the registrationId property.</param>
        /// <param name="firstName">Initial value of the firstName property.</param>
        /// <param name="lastName">Initial value of the lastName property.</param>
        /// <param name="address1">Initial value of the address1 property.</param>
        /// <param name="city">Initial value of the city property.</param>
        /// <param name="state">Initial value of the state property.</param>
        /// <param name="zipCode">Initial value of the zipCode property.</param>
        /// <param name="phone">Initial value of the phone property.</param>
        /// <param name="emailAddress">Initial value of the emailAddress property.</param>
        /// <param name="courseName">Initial value of the courseName property.</param>
        /// <param name="courseStartDate">Initial value of the courseStartDate property.</param>
        /// <param name="courseEndDate">Initial value of the courseEndDate property.</param>
        /// <param name="courseFee">Initial value of the courseFee property.</param>
        public static Registration CreateRegistration(global::System.Int64 registrationId, global::System.String firstName, global::System.String lastName, global::System.String address1, global::System.String city, global::System.String state, global::System.String zipCode, global::System.String phone, global::System.String emailAddress, global::System.String courseName, global::System.DateTime courseStartDate, global::System.DateTime courseEndDate, global::System.Decimal courseFee)
        {
            Registration registration = new Registration();
            registration.registrationId = registrationId;
            registration.firstName = firstName;
            registration.lastName = lastName;
            registration.address1 = address1;
            registration.city = city;
            registration.state = state;
            registration.zipCode = zipCode;
            registration.phone = phone;
            registration.emailAddress = emailAddress;
            registration.courseName = courseName;
            registration.courseStartDate = courseStartDate;
            registration.courseEndDate = courseEndDate;
            registration.courseFee = courseFee;
            return registration;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 registrationId
        {
            get
            {
                return _registrationId;
            }
            set
            {
                if (_registrationId != value)
                {
                    OnregistrationIdChanging(value);
                    ReportPropertyChanging("registrationId");
                    _registrationId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("registrationId");
                    OnregistrationIdChanged();
                }
            }
        }
        private global::System.Int64 _registrationId;
        partial void OnregistrationIdChanging(global::System.Int64 value);
        partial void OnregistrationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                OnfirstNameChanging(value);
                ReportPropertyChanging("firstName");
                _firstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("firstName");
                OnfirstNameChanged();
            }
        }
        private global::System.String _firstName;
        partial void OnfirstNameChanging(global::System.String value);
        partial void OnfirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                OnlastNameChanging(value);
                ReportPropertyChanging("lastName");
                _lastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("lastName");
                OnlastNameChanged();
            }
        }
        private global::System.String _lastName;
        partial void OnlastNameChanging(global::System.String value);
        partial void OnlastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String organization
        {
            get
            {
                return _organization;
            }
            set
            {
                OnorganizationChanging(value);
                ReportPropertyChanging("organization");
                _organization = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("organization");
                OnorganizationChanged();
            }
        }
        private global::System.String _organization;
        partial void OnorganizationChanging(global::System.String value);
        partial void OnorganizationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String address1
        {
            get
            {
                return _address1;
            }
            set
            {
                Onaddress1Changing(value);
                ReportPropertyChanging("address1");
                _address1 = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("address1");
                Onaddress1Changed();
            }
        }
        private global::System.String _address1;
        partial void Onaddress1Changing(global::System.String value);
        partial void Onaddress1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String address2
        {
            get
            {
                return _address2;
            }
            set
            {
                Onaddress2Changing(value);
                ReportPropertyChanging("address2");
                _address2 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("address2");
                Onaddress2Changed();
            }
        }
        private global::System.String _address2;
        partial void Onaddress2Changing(global::System.String value);
        partial void Onaddress2Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String city
        {
            get
            {
                return _city;
            }
            set
            {
                OncityChanging(value);
                ReportPropertyChanging("city");
                _city = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("city");
                OncityChanged();
            }
        }
        private global::System.String _city;
        partial void OncityChanging(global::System.String value);
        partial void OncityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String state
        {
            get
            {
                return _state;
            }
            set
            {
                OnstateChanging(value);
                ReportPropertyChanging("state");
                _state = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("state");
                OnstateChanged();
            }
        }
        private global::System.String _state;
        partial void OnstateChanging(global::System.String value);
        partial void OnstateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String zipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                OnzipCodeChanging(value);
                ReportPropertyChanging("zipCode");
                _zipCode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("zipCode");
                OnzipCodeChanged();
            }
        }
        private global::System.String _zipCode;
        partial void OnzipCodeChanging(global::System.String value);
        partial void OnzipCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String phone
        {
            get
            {
                return _phone;
            }
            set
            {
                OnphoneChanging(value);
                ReportPropertyChanging("phone");
                _phone = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("phone");
                OnphoneChanged();
            }
        }
        private global::System.String _phone;
        partial void OnphoneChanging(global::System.String value);
        partial void OnphoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String fax
        {
            get
            {
                return _fax;
            }
            set
            {
                OnfaxChanging(value);
                ReportPropertyChanging("fax");
                _fax = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("fax");
                OnfaxChanged();
            }
        }
        private global::System.String _fax;
        partial void OnfaxChanging(global::System.String value);
        partial void OnfaxChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String emailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                OnemailAddressChanging(value);
                ReportPropertyChanging("emailAddress");
                _emailAddress = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("emailAddress");
                OnemailAddressChanged();
            }
        }
        private global::System.String _emailAddress;
        partial void OnemailAddressChanging(global::System.String value);
        partial void OnemailAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String courseName
        {
            get
            {
                return _courseName;
            }
            set
            {
                OncourseNameChanging(value);
                ReportPropertyChanging("courseName");
                _courseName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("courseName");
                OncourseNameChanged();
            }
        }
        private global::System.String _courseName;
        partial void OncourseNameChanging(global::System.String value);
        partial void OncourseNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime courseStartDate
        {
            get
            {
                return _courseStartDate;
            }
            set
            {
                OncourseStartDateChanging(value);
                ReportPropertyChanging("courseStartDate");
                _courseStartDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseStartDate");
                OncourseStartDateChanged();
            }
        }
        private global::System.DateTime _courseStartDate;
        partial void OncourseStartDateChanging(global::System.DateTime value);
        partial void OncourseStartDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime courseEndDate
        {
            get
            {
                return _courseEndDate;
            }
            set
            {
                OncourseEndDateChanging(value);
                ReportPropertyChanging("courseEndDate");
                _courseEndDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseEndDate");
                OncourseEndDateChanged();
            }
        }
        private global::System.DateTime _courseEndDate;
        partial void OncourseEndDateChanging(global::System.DateTime value);
        partial void OncourseEndDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal courseFee
        {
            get
            {
                return _courseFee;
            }
            set
            {
                OncourseFeeChanging(value);
                ReportPropertyChanging("courseFee");
                _courseFee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("courseFee");
                OncourseFeeChanged();
            }
        }
        private global::System.Decimal _courseFee;
        partial void OncourseFeeChanging(global::System.Decimal value);
        partial void OncourseFeeChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OnlineArkansasModel", Name="State")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class State : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new State object.
        /// </summary>
        /// <param name="stateId">Initial value of the stateId property.</param>
        /// <param name="stateCode">Initial value of the stateCode property.</param>
        /// <param name="stateName">Initial value of the stateName property.</param>
        public static State CreateState(global::System.Int32 stateId, global::System.String stateCode, global::System.String stateName)
        {
            State state = new State();
            state.stateId = stateId;
            state.stateCode = stateCode;
            state.stateName = stateName;
            return state;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 stateId
        {
            get
            {
                return _stateId;
            }
            set
            {
                if (_stateId != value)
                {
                    OnstateIdChanging(value);
                    ReportPropertyChanging("stateId");
                    _stateId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("stateId");
                    OnstateIdChanged();
                }
            }
        }
        private global::System.Int32 _stateId;
        partial void OnstateIdChanging(global::System.Int32 value);
        partial void OnstateIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String stateCode
        {
            get
            {
                return _stateCode;
            }
            set
            {
                OnstateCodeChanging(value);
                ReportPropertyChanging("stateCode");
                _stateCode = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("stateCode");
                OnstateCodeChanged();
            }
        }
        private global::System.String _stateCode;
        partial void OnstateCodeChanging(global::System.String value);
        partial void OnstateCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String stateName
        {
            get
            {
                return _stateName;
            }
            set
            {
                OnstateNameChanging(value);
                ReportPropertyChanging("stateName");
                _stateName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("stateName");
                OnstateNameChanged();
            }
        }
        private global::System.String _stateName;
        partial void OnstateNameChanging(global::System.String value);
        partial void OnstateNameChanged();

        #endregion

    
    }

    #endregion

    
}
