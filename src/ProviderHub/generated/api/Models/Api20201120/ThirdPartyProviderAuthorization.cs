namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ThirdPartyProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorizationInternal
    {

        /// <summary>Backing field for <see cref="Authorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] _authorization;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] Authorization { get => this._authorization; set => this._authorization = value; }

        /// <summary>Backing field for <see cref="ManagedByTenantId" /> property.</summary>
        private string _managedByTenantId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ManagedByTenantId { get => this._managedByTenantId; set => this._managedByTenantId = value; }

        /// <summary>Creates an new <see cref="ThirdPartyProviderAuthorization" /> instance.</summary>
        public ThirdPartyProviderAuthorization()
        {

        }
    }
    public partial interface IThirdPartyProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"authorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] Authorization { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"managedByTenantId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedByTenantId { get; set; }

    }
    internal partial interface IThirdPartyProviderAuthorizationInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[] Authorization { get; set; }

        string ManagedByTenantId { get; set; }

    }
}