namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Cross-Origin Resource Sharing (CORS) settings for the app.</summary>
    public partial class CorsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettingsInternal
    {

        /// <summary>Backing field for <see cref="AllowedOrigin" /> property.</summary>
        private string[] _allowedOrigin;

        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AllowedOrigin { get => this._allowedOrigin; set => this._allowedOrigin = value; }

        /// <summary>Backing field for <see cref="SupportCredentials" /> property.</summary>
        private bool? _supportCredentials;

        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? SupportCredentials { get => this._supportCredentials; set => this._supportCredentials = value; }

        /// <summary>Creates an new <see cref="CorsSettings" /> instance.</summary>
        public CorsSettings()
        {

        }
    }
    /// Cross-Origin Resource Sharing (CORS) settings for the app.
    public partial interface ICorsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of origins that should be allowed to make cross-origin
        calls (for example: http://example.com:12345). Use ""*"" to allow all.",
        SerializedName = @"allowedOrigins",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedOrigin { get; set; }
        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets whether CORS requests with credentials are allowed. See
        https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        for more details.",
        SerializedName = @"supportCredentials",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SupportCredentials { get; set; }

    }
    /// Cross-Origin Resource Sharing (CORS) settings for the app.
    internal partial interface ICorsSettingsInternal

    {
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        string[] AllowedOrigin { get; set; }
        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        bool? SupportCredentials { get; set; }

    }
}