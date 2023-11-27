namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Properties specific to the monitor resource.</summary>
    public partial class MonitorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DatadogOrganizationProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties _datadogOrganizationProperty;

        /// <summary>Datadog organization properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties DatadogOrganizationProperty { get => (this._datadogOrganizationProperty = this._datadogOrganizationProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties()); set => this._datadogOrganizationProperty = value; }

        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).ApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).ApiKey = value ?? null; }

        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyApplicationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).ApplicationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).ApplicationKey = value ?? null; }

        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyEnterpriseAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).EnterpriseAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).EnterpriseAppId = value ?? null; }

        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Id; }

        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyLinkingAuthCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).LinkingAuthCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).LinkingAuthCode = value ?? null; }

        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyLinkingClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).LinkingClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).LinkingClientId = value ?? null; }

        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Name; }

        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string DatadogOrganizationPropertyRedirectUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).RedirectUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).RedirectUri = value ?? null; }

        /// <summary>Backing field for <see cref="LiftrResourceCategory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? _liftrResourceCategory;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get => this._liftrResourceCategory; }

        /// <summary>Backing field for <see cref="LiftrResourcePreference" /> property.</summary>
        private int? _liftrResourcePreference;

        /// <summary>The priority of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public int? LiftrResourcePreference { get => this._liftrResourcePreference; }

        /// <summary>Backing field for <see cref="MarketplaceSubscriptionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? _marketplaceSubscriptionStatus;

        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get => this._marketplaceSubscriptionStatus; }

        /// <summary>Internal Acessors for DatadogOrganizationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.DatadogOrganizationProperty { get => (this._datadogOrganizationProperty = this._datadogOrganizationProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationProperties()); set { {_datadogOrganizationProperty = value;} } }

        /// <summary>Internal Acessors for DatadogOrganizationPropertyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.DatadogOrganizationPropertyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Id = value; }

        /// <summary>Internal Acessors for DatadogOrganizationPropertyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.DatadogOrganizationPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal)DatadogOrganizationProperty).Name = value; }

        /// <summary>Internal Acessors for LiftrResourceCategory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.LiftrResourceCategory { get => this._liftrResourceCategory; set { {_liftrResourceCategory = value;} } }

        /// <summary>Internal Acessors for LiftrResourcePreference</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.LiftrResourcePreference { get => this._liftrResourcePreference; set { {_liftrResourcePreference = value;} } }

        /// <summary>Internal Acessors for MarketplaceSubscriptionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.MarketplaceSubscriptionStatus { get => this._marketplaceSubscriptionStatus; set { {_marketplaceSubscriptionStatus = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for UserInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorPropertiesInternal.UserInfo { get => (this._userInfo = this._userInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfo()); set { {_userInfo = value;} } }

        /// <summary>Backing field for <see cref="MonitoringStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? _monitoringStatus;

        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get => this._monitoringStatus; set => this._monitoringStatus = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="UserInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo _userInfo;

        /// <summary>User info</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo UserInfo { get => (this._userInfo = this._userInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfo()); set => this._userInfo = value; }

        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).EmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).EmailAddress = value ?? null; }

        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).Name = value ?? null; }

        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string UserInfoPhoneNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).PhoneNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal)UserInfo).PhoneNumber = value ?? null; }

        /// <summary>Creates an new <see cref="MonitorProperties" /> instance.</summary>
        public MonitorProperties()
        {

        }
    }
    /// Properties specific to the monitor resource.
    public partial interface IMonitorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Api key associated to the Datadog organization.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application key associated to the Datadog organization.",
        SerializedName = @"applicationKey",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the Enterprise App used for Single sign on.",
        SerializedName = @"enterpriseAppId",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyEnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the Datadog organization.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyId { get;  }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The auth code used to linking to an existing datadog organization.",
        SerializedName = @"linkingAuthCode",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyLinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client_id from an existing in exchange for an auth token to link organization.",
        SerializedName = @"linkingClientId",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyLinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Datadog organization.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyName { get;  }
        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The redirect uri for linking.",
        SerializedName = @"redirectUri",
        PossibleTypes = new [] { typeof(string) })]
        string DatadogOrganizationPropertyRedirectUri { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"liftrResourceCategory",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get;  }
        /// <summary>The priority of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The priority of the resource.",
        SerializedName = @"liftrResourcePreference",
        PossibleTypes = new [] { typeof(int) })]
        int? LiftrResourcePreference { get;  }
        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will go in Suspended state.",
        SerializedName = @"marketplaceSubscriptionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get;  }
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if the resource monitoring is enabled or disabled.",
        SerializedName = @"monitoringStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email of the user used by Datadog for contacting them if needed",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoEmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the user",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoName { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Phone number of the user used by Datadog for contacting them if needed",
        SerializedName = @"phoneNumber",
        PossibleTypes = new [] { typeof(string) })]
        string UserInfoPhoneNumber { get; set; }

    }
    /// Properties specific to the monitor resource.
    internal partial interface IMonitorPropertiesInternal

    {
        /// <summary>Datadog organization properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties DatadogOrganizationProperty { get; set; }
        /// <summary>Api key associated to the Datadog organization.</summary>
        string DatadogOrganizationPropertyApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        string DatadogOrganizationPropertyApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        string DatadogOrganizationPropertyEnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        string DatadogOrganizationPropertyId { get; set; }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        string DatadogOrganizationPropertyLinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        string DatadogOrganizationPropertyLinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        string DatadogOrganizationPropertyName { get; set; }
        /// <summary>The redirect uri for linking.</summary>
        string DatadogOrganizationPropertyRedirectUri { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories? LiftrResourceCategory { get; set; }
        /// <summary>The priority of the resource.</summary>
        int? LiftrResourcePreference { get; set; }
        /// <summary>
        /// Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will
        /// go in Suspended state.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get; set; }
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>User info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo UserInfo { get; set; }
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        string UserInfoEmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        string UserInfoName { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        string UserInfoPhoneNumber { get; set; }

    }
}