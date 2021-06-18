namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the request body for updating move collection.</summary>
    public partial class UpdateMoveCollectionRequest :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequest,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal
    {

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity _identity;

        /// <summary>Defines the MSI properties of the Move Collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.Identity()); set => this._identity = value; }

        /// <summary>Gets or sets the principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>Gets or sets the tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).TenantId = value ?? null; }

        /// <summary>The type of identity used for the resource mover service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType)""); }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.Identity()); set { {_identity = value;} } }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags _tag;

        /// <summary>Gets or sets the Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.UpdateMoveCollectionRequestTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="UpdateMoveCollectionRequest" /> instance.</summary>
        public UpdateMoveCollectionRequest()
        {

        }
    }
    /// Defines the request body for updating move collection.
    public partial interface IUpdateMoveCollectionRequest :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the principal id.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get; set; }
        /// <summary>Gets or sets the tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get; set; }
        /// <summary>The type of identity used for the resource mover service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the resource mover service.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>Gets or sets the Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags Tag { get; set; }

    }
    /// Defines the request body for updating move collection.
    internal partial interface IUpdateMoveCollectionRequestInternal

    {
        /// <summary>Defines the MSI properties of the Move Collection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IIdentity Identity { get; set; }
        /// <summary>Gets or sets the principal id.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>Gets or sets the tenant id.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The type of identity used for the resource mover service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>Gets or sets the Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUpdateMoveCollectionRequestTags Tag { get; set; }

    }
}