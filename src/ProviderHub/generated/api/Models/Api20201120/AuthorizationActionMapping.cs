namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class AuthorizationActionMapping :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMappingInternal
    {

        /// <summary>Backing field for <see cref="Desired" /> property.</summary>
        private string _desired;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Desired { get => this._desired; set => this._desired = value; }

        /// <summary>Backing field for <see cref="Original" /> property.</summary>
        private string _original;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Original { get => this._original; set => this._original = value; }

        /// <summary>Creates an new <see cref="AuthorizationActionMapping" /> instance.</summary>
        public AuthorizationActionMapping()
        {

        }
    }
    public partial interface IAuthorizationActionMapping :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"desired",
        PossibleTypes = new [] { typeof(string) })]
        string Desired { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"original",
        PossibleTypes = new [] { typeof(string) })]
        string Original { get; set; }

    }
    internal partial interface IAuthorizationActionMappingInternal

    {
        string Desired { get; set; }

        string Original { get; set; }

    }
}