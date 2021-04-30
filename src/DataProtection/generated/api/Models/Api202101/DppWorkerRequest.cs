namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    public partial class DppWorkerRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestInternal
    {

        /// <summary>Backing field for <see cref="CultureInfo" /> property.</summary>
        private string _cultureInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string CultureInfo { get => this._cultureInfo; set => this._cultureInfo = value; }

        /// <summary>Backing field for <see cref="Header" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders _header;

        /// <summary>
        /// Dictionary of <components·ikn5y4·schemas·dppworkerrequest·properties·headers·additionalproperties>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders Header { get => (this._header = this._header ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppWorkerRequestHeaders()); set => this._header = value; }

        /// <summary>Backing field for <see cref="HttpMethod" /> property.</summary>
        private string _httpMethod;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string HttpMethod { get => this._httpMethod; set => this._httpMethod = value; }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters _parameter;

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters Parameter { get => (this._parameter = this._parameter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppWorkerRequestParameters()); set => this._parameter = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Backing field for <see cref="SupportedGroupVersion" /> property.</summary>
        private string[] _supportedGroupVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] SupportedGroupVersion { get => this._supportedGroupVersion; set => this._supportedGroupVersion = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Creates an new <see cref="DppWorkerRequest" /> instance.</summary>
        public DppWorkerRequest()
        {

        }
    }
    public partial interface IDppWorkerRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"cultureInfo",
        PossibleTypes = new [] { typeof(string) })]
        string CultureInfo { get; set; }
        /// <summary>
        /// Dictionary of <components·ikn5y4·schemas·dppworkerrequest·properties·headers·additionalproperties>
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <components·ikn5y4·schemas·dppworkerrequest·properties·headers·additionalproperties>",
        SerializedName = @"headers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders Header { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"httpMethod",
        PossibleTypes = new [] { typeof(string) })]
        string HttpMethod { get; set; }
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters Parameter { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"supportedGroupVersions",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedGroupVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }

    }
    internal partial interface IDppWorkerRequestInternal

    {
        string CultureInfo { get; set; }
        /// <summary>
        /// Dictionary of <components·ikn5y4·schemas·dppworkerrequest·properties·headers·additionalproperties>
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestHeaders Header { get; set; }

        string HttpMethod { get; set; }
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppWorkerRequestParameters Parameter { get; set; }

        string SubscriptionId { get; set; }

        string[] SupportedGroupVersion { get; set; }

        string Uri { get; set; }

    }
}