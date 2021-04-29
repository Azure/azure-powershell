namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderAuthentication :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthenticationInternal
    {

        /// <summary>Backing field for <see cref="AllowedAudience" /> property.</summary>
        private string[] _allowedAudience;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] AllowedAudience { get => this._allowedAudience; set => this._allowedAudience = value; }

        /// <summary>Creates an new <see cref="ResourceProviderAuthentication" /> instance.</summary>
        public ResourceProviderAuthentication()
        {

        }
    }
    public partial interface IResourceProviderAuthentication :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"allowedAudiences",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedAudience { get; set; }

    }
    internal partial interface IResourceProviderAuthenticationInternal

    {
        string[] AllowedAudience { get; set; }

    }
}