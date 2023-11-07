namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Datadog organization properties</summary>
    public partial class DatadogOrganizationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiKey" /> property.</summary>
        private string _apiKey;

        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string ApiKey { get => this._apiKey; set => this._apiKey = value; }

        /// <summary>Backing field for <see cref="ApplicationKey" /> property.</summary>
        private string _applicationKey;

        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string ApplicationKey { get => this._applicationKey; set => this._applicationKey = value; }

        /// <summary>Backing field for <see cref="EnterpriseAppId" /> property.</summary>
        private string _enterpriseAppId;

        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string EnterpriseAppId { get => this._enterpriseAppId; set => this._enterpriseAppId = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="LinkingAuthCode" /> property.</summary>
        private string _linkingAuthCode;

        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string LinkingAuthCode { get => this._linkingAuthCode; set => this._linkingAuthCode = value; }

        /// <summary>Backing field for <see cref="LinkingClientId" /> property.</summary>
        private string _linkingClientId;

        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string LinkingClientId { get => this._linkingClientId; set => this._linkingClientId = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationPropertiesInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="RedirectUri" /> property.</summary>
        private string _redirectUri;

        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string RedirectUri { get => this._redirectUri; set => this._redirectUri = value; }

        /// <summary>Creates an new <see cref="DatadogOrganizationProperties" /> instance.</summary>
        public DatadogOrganizationProperties()
        {

        }
    }
    /// Datadog organization properties
    public partial interface IDatadogOrganizationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Api key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Api key associated to the Datadog organization.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application key associated to the Datadog organization.",
        SerializedName = @"applicationKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the Enterprise App used for Single sign on.",
        SerializedName = @"enterpriseAppId",
        PossibleTypes = new [] { typeof(string) })]
        string EnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the Datadog organization.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The auth code used to linking to an existing datadog organization.",
        SerializedName = @"linkingAuthCode",
        PossibleTypes = new [] { typeof(string) })]
        string LinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client_id from an existing in exchange for an auth token to link organization.",
        SerializedName = @"linkingClientId",
        PossibleTypes = new [] { typeof(string) })]
        string LinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Datadog organization.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The redirect uri for linking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The redirect uri for linking.",
        SerializedName = @"redirectUri",
        PossibleTypes = new [] { typeof(string) })]
        string RedirectUri { get; set; }

    }
    /// Datadog organization properties
    internal partial interface IDatadogOrganizationPropertiesInternal

    {
        /// <summary>Api key associated to the Datadog organization.</summary>
        string ApiKey { get; set; }
        /// <summary>Application key associated to the Datadog organization.</summary>
        string ApplicationKey { get; set; }
        /// <summary>The Id of the Enterprise App used for Single sign on.</summary>
        string EnterpriseAppId { get; set; }
        /// <summary>Id of the Datadog organization.</summary>
        string Id { get; set; }
        /// <summary>The auth code used to linking to an existing datadog organization.</summary>
        string LinkingAuthCode { get; set; }
        /// <summary>
        /// The client_id from an existing in exchange for an auth token to link organization.
        /// </summary>
        string LinkingClientId { get; set; }
        /// <summary>Name of the Datadog organization.</summary>
        string Name { get; set; }
        /// <summary>The redirect uri for linking.</summary>
        string RedirectUri { get; set; }

    }
}