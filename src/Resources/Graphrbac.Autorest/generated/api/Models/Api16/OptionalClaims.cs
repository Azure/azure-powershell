namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Specifying the claims to be included in the token.</summary>
    public partial class OptionalClaims :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaims,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaimsInternal
    {

        /// <summary>Backing field for <see cref="AccessToken" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] _accessToken;

        /// <summary>Optional claims requested to be included in the access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] AccessToken { get => this._accessToken; set => this._accessToken = value; }

        /// <summary>Backing field for <see cref="IdToken" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] _idToken;

        /// <summary>Optional claims requested to be included in the id token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] IdToken { get => this._idToken; set => this._idToken = value; }

        /// <summary>Backing field for <see cref="SamlToken" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] _samlToken;

        /// <summary>Optional claims requested to be included in the saml token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] SamlToken { get => this._samlToken; set => this._samlToken = value; }

        /// <summary>Creates an new <see cref="OptionalClaims" /> instance.</summary>
        public OptionalClaims()
        {

        }
    }
    /// Specifying the claims to be included in the token.
    public partial interface IOptionalClaims :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>Optional claims requested to be included in the access token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the access token.",
        SerializedName = @"accessToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] AccessToken { get; set; }
        /// <summary>Optional claims requested to be included in the id token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the id token.",
        SerializedName = @"idToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] IdToken { get; set; }
        /// <summary>Optional claims requested to be included in the saml token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional claims requested to be included in the saml token.",
        SerializedName = @"samlToken",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] SamlToken { get; set; }

    }
    /// Specifying the claims to be included in the token.
    internal partial interface IOptionalClaimsInternal

    {
        /// <summary>Optional claims requested to be included in the access token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] AccessToken { get; set; }
        /// <summary>Optional claims requested to be included in the id token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] IdToken { get; set; }
        /// <summary>Optional claims requested to be included in the saml token.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOptionalClaim[] SamlToken { get; set; }

    }
}