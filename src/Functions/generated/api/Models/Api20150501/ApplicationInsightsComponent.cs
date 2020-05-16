namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An Application Insights component definition.</summary>
    public partial class ApplicationInsightsComponent :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResource __componentsResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentsResource();

        /// <summary>Application Insights Unique ID for your Application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).AppId; }

        /// <summary>
        /// The unique ID of your application. This field mirrors the 'Name' field and cannot be changed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ApplicationId; }

        /// <summary>Type of application being monitored.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType ApplicationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ApplicationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ApplicationType = value; }

        /// <summary>Creation Date for the Application Insights component, in ISO 8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).CreationDate; }

        /// <summary>
        /// Used by the Application Insights system to determine what kind of flow this component was created by. This is to be set
        /// to 'Bluefield' when creating/updating a component via the REST API.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType? FlowType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).FlowType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).FlowType = value; }

        /// <summary>
        /// The unique application ID created when a new application is added to HockeyApp, used for communications with HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HockeyAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).HockeyAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).HockeyAppId = value; }

        /// <summary>
        /// Token used to authenticate communications with between Application Insights and HockeyApp.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HockeyAppToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).HockeyAppToken; }

        /// <summary>Azure resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Id; }

        /// <summary>
        /// Application Insights Instrumentation key. A read-only value that applications can use to identify the destination for
        /// all telemetry sent to Azure Application Insights. This value will be supplied upon construction of each new Application
        /// Insights component.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string InstrumentationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).InstrumentationKey; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>
        /// The kind of application that this component refers to, used to customize UI. This value is a freeform string, values should
        /// typically be one of the following: web, ios, other, store, java, phone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Location = value; }

        /// <summary>Internal Acessors for AppId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.AppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).AppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).AppId = value; }

        /// <summary>Internal Acessors for ApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.ApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ApplicationId = value; }

        /// <summary>Internal Acessors for CreationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.CreationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).CreationDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).CreationDate = value; }

        /// <summary>Internal Acessors for HockeyAppToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.HockeyAppToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).HockeyAppToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).HockeyAppToken = value; }

        /// <summary>Internal Acessors for InstrumentationKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.InstrumentationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).InstrumentationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).InstrumentationKey = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal.TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).TenantId = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Type = value; }

        /// <summary>Azure resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties _property;

        /// <summary>Properties that define an Application Insights component resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentProperties()); set => this._property = value; }

        /// <summary>
        /// Current state of this component: whether or not is has been provisioned within the resource group it is defined. Users
        /// cannot change this value but are able to read from it. Values will include Succeeded, Deploying, Canceled, and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Describes what tool created this Application Insights component. Customers using this API should set this to the default
        /// 'rest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource? RequestSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).RequestSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).RequestSource = value; }

        /// <summary>
        /// Percentage of the data produced by the application being monitored that is being sampled for Application Insights telemetry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? SamplingPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).SamplingPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).SamplingPercentage = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Tag = value; }

        /// <summary>Azure Tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentPropertiesInternal)Property).TenantId; }

        /// <summary>Azure resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)__componentsResource).Type; }

        /// <summary>Creates an new <see cref="ApplicationInsightsComponent" /> instance.</summary>
        public ApplicationInsightsComponent()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__componentsResource), __componentsResource);
            await eventListener.AssertObjectIsValid(nameof(__componentsResource), __componentsResource);
        }
    }
    /// An Application Insights component definition.
    public partial interface IApplicationInsightsComponent :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResource
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
        /// The kind of application that this component refers to, used to customize UI. This value is a freeform string, values should
        /// typically be one of the following: web, ios, other, store, java, phone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The kind of application that this component refers to, used to customize UI. This value is a freeform string, values should typically be one of the following: web, ios, other, store, java, phone.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get; set; }
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
    /// An Application Insights component definition.
    internal partial interface IApplicationInsightsComponentInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal
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
        /// The kind of application that this component refers to, used to customize UI. This value is a freeform string, values should
        /// typically be one of the following: web, ios, other, store, java, phone.
        /// </summary>
        string Kind { get; set; }
        /// <summary>Properties that define an Application Insights component resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties Property { get; set; }
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