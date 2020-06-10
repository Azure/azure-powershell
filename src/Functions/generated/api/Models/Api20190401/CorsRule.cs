namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Specifies a CORS rule for the Blob service.</summary>
    public partial class CorsRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRuleInternal
    {

        /// <summary>Backing field for <see cref="AllowedHeader" /> property.</summary>
        private string[] _allowedHeader;

        /// <summary>
        /// Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedHeader { get => this._allowedHeader; set => this._allowedHeader = value; }

        /// <summary>Backing field for <see cref="AllowedMethod" /> property.</summary>
        private string[] _allowedMethod;

        /// <summary>
        /// Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedMethod { get => this._allowedMethod; set => this._allowedMethod = value; }

        /// <summary>Backing field for <see cref="AllowedOrigin" /> property.</summary>
        private string[] _allowedOrigin;

        /// <summary>
        /// Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedOrigin { get => this._allowedOrigin; set => this._allowedOrigin = value; }

        /// <summary>Backing field for <see cref="ExposedHeader" /> property.</summary>
        private string[] _exposedHeader;

        /// <summary>
        /// Required if CorsRule element is present. A list of response headers to expose to CORS clients.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] ExposedHeader { get => this._exposedHeader; set => this._exposedHeader = value; }

        /// <summary>Backing field for <see cref="MaxAgeInSecond" /> property.</summary>
        private int _maxAgeInSecond;

        /// <summary>
        /// Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int MaxAgeInSecond { get => this._maxAgeInSecond; set => this._maxAgeInSecond = value; }

        /// <summary>Creates an new <see cref="CorsRule" /> instance.</summary>
        public CorsRule()
        {

        }
    }
    /// Specifies a CORS rule for the Blob service.
    public partial interface ICorsRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.",
        SerializedName = @"allowedHeaders",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedHeader { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.",
        SerializedName = @"allowedMethods",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedMethod { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or ""*"" to allow all domains",
        SerializedName = @"allowedOrigins",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedOrigin { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of response headers to expose to CORS clients.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Required if CorsRule element is present. A list of response headers to expose to CORS clients.",
        SerializedName = @"exposedHeaders",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExposedHeader { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.",
        SerializedName = @"maxAgeInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int MaxAgeInSecond { get; set; }

    }
    /// Specifies a CORS rule for the Blob service.
    internal partial interface ICorsRuleInternal

    {
        /// <summary>
        /// Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
        /// </summary>
        string[] AllowedHeader { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
        /// </summary>
        string[] AllowedMethod { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
        /// </summary>
        string[] AllowedOrigin { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. A list of response headers to expose to CORS clients.
        /// </summary>
        string[] ExposedHeader { get; set; }
        /// <summary>
        /// Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
        /// </summary>
        int MaxAgeInSecond { get; set; }

    }
}