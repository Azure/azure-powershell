namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>An identity that can be associated with a resource.</summary>
    public partial class ResourceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal
    {

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? _type;

        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UserAssignedIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities _userAssignedIdentity;

        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities UserAssignedIdentity { get => (this._userAssignedIdentity = this._userAssignedIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentityUserAssignedIdentities()); set => this._userAssignedIdentity = value; }

        /// <summary>Creates an new <see cref="ResourceIdentity" /> instance.</summary>
        public ResourceIdentity()
        {

        }
    }
    /// An identity that can be associated with a resource.
    public partial interface IResourceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of the identity. This property will only be provided for a system-assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities. The type 'None' will remove any identities.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? Type { get; set; }
        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
    /// An identity that can be associated with a resource.
    internal partial interface IResourceIdentityInternal

    {
        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        string PrincipalId { get; set; }
        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? Type { get; set; }
        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
}