namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the MSI properties of the Move Collection.</summary>
    public partial class Identity :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IIdentityInternal
    {

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>Gets or sets the principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Gets or sets the tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? _type;

        /// <summary>The type of identity used for the region move service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Identity" /> instance.</summary>
        public Identity()
        {

        }
    }
    /// Defines the MSI properties of the Move Collection.
    public partial interface IIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the principal id.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }
        /// <summary>Gets or sets the tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }
        /// <summary>The type of identity used for the region move service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the region move service.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? Type { get; set; }

    }
    /// Defines the MSI properties of the Move Collection.
    internal partial interface IIdentityInternal

    {
        /// <summary>Gets or sets the principal id.</summary>
        string PrincipalId { get; set; }
        /// <summary>Gets or sets the tenant id.</summary>
        string TenantId { get; set; }
        /// <summary>The type of identity used for the region move service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResourceIdentityType? Type { get; set; }

    }
}