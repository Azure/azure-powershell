namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorizationInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; set => this._applicationId = value; }

        /// <summary>Backing field for <see cref="ManagedByRoleDefinitionId" /> property.</summary>
        private string _managedByRoleDefinitionId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ManagedByRoleDefinitionId { get => this._managedByRoleDefinitionId; set => this._managedByRoleDefinitionId = value; }

        /// <summary>Backing field for <see cref="RoleDefinitionId" /> property.</summary>
        private string _roleDefinitionId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string RoleDefinitionId { get => this._roleDefinitionId; set => this._roleDefinitionId = value; }

        /// <summary>Creates an new <see cref="ResourceProviderAuthorization" /> instance.</summary>
        public ResourceProviderAuthorization()
        {

        }
    }
    public partial interface IResourceProviderAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"managedByRoleDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedByRoleDefinitionId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"roleDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string RoleDefinitionId { get; set; }

    }
    internal partial interface IResourceProviderAuthorizationInternal

    {
        string ApplicationId { get; set; }

        string ManagedByRoleDefinitionId { get; set; }

        string RoleDefinitionId { get; set; }

    }
}