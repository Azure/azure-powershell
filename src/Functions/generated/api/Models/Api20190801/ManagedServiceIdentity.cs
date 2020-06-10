namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Managed service identity.</summary>
    public partial class ManagedServiceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal
    {

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? _type;

        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UserAssignedIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities _userAssignedIdentity;

        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities UserAssignedIdentity { get => (this._userAssignedIdentity = this._userAssignedIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentityUserAssignedIdentities()); set => this._userAssignedIdentity = value; }

        /// <summary>Creates an new <see cref="ManagedServiceIdentity" /> instance.</summary>
        public ManagedServiceIdentity()
        {

        }
    }
    /// Managed service identity.
    public partial interface IManagedServiceIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Principal Id of managed service identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Tenant of managed service identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of managed service identity.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? Type { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
    /// Managed service identity.
    internal partial interface IManagedServiceIdentityInternal

    {
        /// <summary>Principal Id of managed service identity.</summary>
        string PrincipalId { get; set; }
        /// <summary>Tenant of managed service identity.</summary>
        string TenantId { get; set; }
        /// <summary>Type of managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? Type { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
}