namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SourceControl resource specific properties</summary>
    public partial class SourceControlProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISourceControlProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISourceControlPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ExpirationTime" /> property.</summary>
        private global::System.DateTime? _expirationTime;

        /// <summary>OAuth token expiration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationTime { get => this._expirationTime; set => this._expirationTime = value; }

        /// <summary>Backing field for <see cref="RefreshToken" /> property.</summary>
        private string _refreshToken;

        /// <summary>OAuth refresh token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RefreshToken { get => this._refreshToken; set => this._refreshToken = value; }

        /// <summary>Backing field for <see cref="Token" /> property.</summary>
        private string _token;

        /// <summary>OAuth access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Token { get => this._token; set => this._token = value; }

        /// <summary>Backing field for <see cref="TokenSecret" /> property.</summary>
        private string _tokenSecret;

        /// <summary>OAuth access token secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TokenSecret { get => this._tokenSecret; set => this._tokenSecret = value; }

        /// <summary>Creates an new <see cref="SourceControlProperties" /> instance.</summary>
        public SourceControlProperties()
        {

        }
    }
    /// SourceControl resource specific properties
    public partial interface ISourceControlProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>OAuth token expiration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OAuth token expiration.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>OAuth refresh token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OAuth refresh token.",
        SerializedName = @"refreshToken",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshToken { get; set; }
        /// <summary>OAuth access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OAuth access token.",
        SerializedName = @"token",
        PossibleTypes = new [] { typeof(string) })]
        string Token { get; set; }
        /// <summary>OAuth access token secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OAuth access token secret.",
        SerializedName = @"tokenSecret",
        PossibleTypes = new [] { typeof(string) })]
        string TokenSecret { get; set; }

    }
    /// SourceControl resource specific properties
    internal partial interface ISourceControlPropertiesInternal

    {
        /// <summary>OAuth token expiration.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>OAuth refresh token.</summary>
        string RefreshToken { get; set; }
        /// <summary>OAuth access token.</summary>
        string Token { get; set; }
        /// <summary>OAuth access token secret.</summary>
        string TokenSecret { get; set; }

    }
}