namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LightHouseAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorizationInternal
    {

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Backing field for <see cref="RoleDefinitionId" /> property.</summary>
        private string _roleDefinitionId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string RoleDefinitionId { get => this._roleDefinitionId; set => this._roleDefinitionId = value; }

        /// <summary>Creates an new <see cref="LightHouseAuthorization" /> instance.</summary>
        public LightHouseAuthorization()
        {

        }
    }
    public partial interface ILightHouseAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"roleDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string RoleDefinitionId { get; set; }

    }
    internal partial interface ILightHouseAuthorizationInternal

    {
        string PrincipalId { get; set; }

        string RoleDefinitionId { get; set; }

    }
}