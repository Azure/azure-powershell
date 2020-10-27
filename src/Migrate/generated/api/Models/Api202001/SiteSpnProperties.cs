namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for site properties.</summary>
    public partial class SiteSpnProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AadAuthority" /> property.</summary>
        private string _aadAuthority;

        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AadAuthority { get => this._aadAuthority; set => this._aadAuthority = value; }

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Backing field for <see cref="Audience" /> property.</summary>
        private string _audience;

        /// <summary>Intended audience for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Audience { get => this._audience; set => this._audience = value; }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="RawCertData" /> property.</summary>
        private string _rawCertData;

        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RawCertData { get => this._rawCertData; set => this._rawCertData = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="SiteSpnProperties" /> instance.</summary>
        public SiteSpnProperties()
        {

        }
    }
    /// Class for site properties.
    public partial interface ISiteSpnProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AAD Authority URL which was used to request the token for the service principal.",
        SerializedName = @"aadAuthority",
        PossibleTypes = new [] { typeof(string) })]
        string AadAuthority { get; set; }
        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }
        /// <summary>Intended audience for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Intended audience for the service principal.",
        SerializedName = @"audience",
        PossibleTypes = new [] { typeof(string) })]
        string Audience { get; set; }
        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get; set; }
        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Raw certificate data for building certificate expiry flows.",
        SerializedName = @"rawCertData",
        PossibleTypes = new [] { typeof(string) })]
        string RawCertData { get; set; }
        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// Class for site properties.
    internal partial interface ISiteSpnPropertiesInternal

    {
        /// <summary>
        /// AAD Authority URL which was used to request the token for the service principal.
        /// </summary>
        string AadAuthority { get; set; }
        /// <summary>
        /// Application/client Id for the service principal with which the on-premise management/data plane components would communicate
        /// with our Azure services.
        /// </summary>
        string ApplicationId { get; set; }
        /// <summary>Intended audience for the service principal.</summary>
        string Audience { get; set; }
        /// <summary>
        /// Object Id of the service principal with which the on-premise management/data plane components would communicate with our
        /// Azure services.
        /// </summary>
        string ObjectId { get; set; }
        /// <summary>Raw certificate data for building certificate expiry flows.</summary>
        string RawCertData { get; set; }
        /// <summary>
        /// Tenant Id for the service principal with which the on-premise management/data plane components would communicate with
        /// our Azure services.
        /// </summary>
        string TenantId { get; set; }

    }
}