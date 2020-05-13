namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Properties that define an Application Insights component resource.</summary>
    public partial class ApplicationInsightsComponentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>Application Insights Unique ID for your Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; }

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>
        /// The unique ID of your application. This field mirrors the 'Name' field and cannot be changed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; }

        /// <summary>Backing field for <see cref="ApplicationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType _applicationType;

        /// <summary>Type of application being monitored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType ApplicationType { get => this._applicationType; set => this._applicationType = value; }

        /// <summary>Backing field for <see cref="CreationDate" /> property.</summary>
        private global::System.DateTime? _creationDate;

        /// <summary>Creation Date for the Application Insights component, in ISO 8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationDate { get => this._creationDate; }

        /// <summary>Backing field for <see cref="FlowType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType? _flowType;

        /// <summary>
        /// Used by the Application Insights system to determine what kind of flow this component was created by. This is to be set
        /// to 'Bluefield' when creating/updating a component via the REST API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType? FlowType { get => this._flowType; set => this._flowType = value; }

        /// <summary>Backing field for <see cref="HockeyAppId" /> property.</summary>
        private string _hockeyAppId;

        /// <summary>
        /// The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HockeyAppId { get => this._hockeyAppId; set => this._hockeyAppId = value; }

        /// <summary>Backing field for <see cref="HockeyAppToken" /> property.</summary>
        private string _hockeyAppToken;

        /// <summary>
        /// Token used to authenticate communications with between Application Insights and HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HockeyAppToken { get => this._hockeyAppToken; }

        /// <summary>Backing field for <see cref="InstrumentationKey" /> property.</summary>
        private string _instrumentationKey;

        /// <summary>
        /// Application Insights Instrumentation key. A read-only value that applications can use to identify the destination for
        /// all telemetry sent to Azure Application Insights. This value will be supplied upon construction of each new Application
        /// Insights component.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InstrumentationKey { get => this._instrumentationKey; }

        /// <summary>Internal Acessors for AppId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.AppId { get => this._appId; set { {_appId = value;} } }

        /// <summary>Internal Acessors for ApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.ApplicationId { get => this._applicationId; set { {_applicationId = value;} } }

        /// <summary>Internal Acessors for CreationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.CreationDate { get => this._creationDate; set { {_creationDate = value;} } }

        /// <summary>Internal Acessors for HockeyAppToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.HockeyAppToken { get => this._hockeyAppToken; set { {_hockeyAppToken = value;} } }

        /// <summary>Internal Acessors for InstrumentationKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.InstrumentationKey { get => this._instrumentationKey; set { {_instrumentationKey = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Current state of this component: whether or not is has been provisioned within the resource group it is defined. Users
        /// cannot change this value but are able to read from it. Values will include Succeeded, Deploying, Canceled, and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RequestSource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource? _requestSource;

        /// <summary>
        /// Describes what tool created this Application Insights component. Customers using this API should set this to the default
        /// 'rest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource? RequestSource { get => this._requestSource; set => this._requestSource = value; }

        /// <summary>Backing field for <see cref="SamplingPercentage" /> property.</summary>
        private double? _samplingPercentage;

        /// <summary>
        /// Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? SamplingPercentage { get => this._samplingPercentage; set => this._samplingPercentage = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Azure Tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Creates an new <see cref="ApplicationInsightsComponentProperties" /> instance.</summary>
        public ApplicationInsightsComponentProperties()
        {

        }
    }
    /// Properties that define an Application Insights component resource.
    public partial interface IApplicationInsightsComponentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Application Insights Unique ID for your Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Application Insights Unique ID for your Application.",
        SerializedName = @"AppId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get;  }
        /// <summary>
        /// The unique ID of your application. This field mirrors the 'Name' field and cannot be changed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The unique ID of your application. This field mirrors the 'Name' field and cannot be changed.",
        SerializedName = @"ApplicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get;  }
        /// <summary>Type of application being monitored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of application being monitored.",
        SerializedName = @"Application_Type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType ApplicationType { get; set; }
        /// <summary>Creation Date for the Application Insights component, in ISO 8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Creation Date for the Application Insights component, in ISO 8601 format.",
        SerializedName = @"CreationDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationDate { get;  }
        /// <summary>
        /// Used by the Application Insights system to determine what kind of flow this component was created by. This is to be set
        /// to 'Bluefield' when creating/updating a component via the REST API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used by the Application Insights system to determine what kind of flow this component was created by. This is to be set to 'Bluefield' when creating/updating a component via the REST API.",
        SerializedName = @"Flow_Type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType? FlowType { get; set; }
        /// <summary>
        /// The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.",
        SerializedName = @"HockeyAppId",
        PossibleTypes = new [] { typeof(string) })]
        string HockeyAppId { get; set; }
        /// <summary>
        /// Token used to authenticate communications with between Application Insights and HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Token used to authenticate communications with between Application Insights and HockeyApp.",
        SerializedName = @"HockeyAppToken",
        PossibleTypes = new [] { typeof(string) })]
        string HockeyAppToken { get;  }
        /// <summary>
        /// Application Insights Instrumentation key. A read-only value that applications can use to identify the destination for
        /// all telemetry sent to Azure Application Insights. This value will be supplied upon construction of each new Application
        /// Insights component.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Application Insights Instrumentation key. A read-only value that applications can use to identify the destination for all telemetry sent to Azure Application Insights. This value will be supplied upon construction of each new Application Insights component.",
        SerializedName = @"InstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string InstrumentationKey { get;  }
        /// <summary>
        /// Current state of this component: whether or not is has been provisioned within the resource group it is defined. Users
        /// cannot change this value but are able to read from it. Values will include Succeeded, Deploying, Canceled, and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current state of this component: whether or not is has been provisioned within the resource group it is defined. Users cannot change this value but are able to read from it. Values will include Succeeded, Deploying, Canceled, and Failed.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Describes what tool created this Application Insights component. Customers using this API should set this to the default
        /// 'rest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes what tool created this Application Insights component. Customers using this API should set this to the default 'rest'.",
        SerializedName = @"Request_Source",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource? RequestSource { get; set; }
        /// <summary>
        /// Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.",
        SerializedName = @"SamplingPercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? SamplingPercentage { get; set; }
        /// <summary>Azure Tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Azure Tenant Id.",
        SerializedName = @"TenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }

    }
    /// Properties that define an Application Insights component resource.
    internal partial interface IApplicationInsightsComponentPropertiesInternal

    {
        /// <summary>Application Insights Unique ID for your Application.</summary>
        string AppId { get; set; }
        /// <summary>
        /// The unique ID of your application. This field mirrors the 'Name' field and cannot be changed.
        /// </summary>
        string ApplicationId { get; set; }
        /// <summary>Type of application being monitored.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType ApplicationType { get; set; }
        /// <summary>Creation Date for the Application Insights component, in ISO 8601 format.</summary>
        global::System.DateTime? CreationDate { get; set; }
        /// <summary>
        /// Used by the Application Insights system to determine what kind of flow this component was created by. This is to be set
        /// to 'Bluefield' when creating/updating a component via the REST API.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType? FlowType { get; set; }
        /// <summary>
        /// The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.
        /// </summary>
        string HockeyAppId { get; set; }
        /// <summary>
        /// Token used to authenticate communications with between Application Insights and HockeyApp.
        /// </summary>
        string HockeyAppToken { get; set; }
        /// <summary>
        /// Application Insights Instrumentation key. A read-only value that applications can use to identify the destination for
        /// all telemetry sent to Azure Application Insights. This value will be supplied upon construction of each new Application
        /// Insights component.
        /// </summary>
        string InstrumentationKey { get; set; }
        /// <summary>
        /// Current state of this component: whether or not is has been provisioned within the resource group it is defined. Users
        /// cannot change this value but are able to read from it. Values will include Succeeded, Deploying, Canceled, and Failed.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Describes what tool created this Application Insights component. Customers using this API should set this to the default
        /// 'rest'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource? RequestSource { get; set; }
        /// <summary>
        /// Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.
        /// </summary>
        double? SamplingPercentage { get; set; }
        /// <summary>Azure Tenant Id.</summary>
        string TenantId { get; set; }

    }
}