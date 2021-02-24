namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Move resource filter.</summary>
    public partial class MoveResourceFilter :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilter,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterProperties Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceFilterProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceFilterProperties()); set => this._property = value; }

        /// <summary>The provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Creates an new <see cref="MoveResourceFilter" /> instance.</summary>
        public MoveResourceFilter()
        {

        }
    }
    /// Move resource filter.
    public partial interface IMoveResourceFilter :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>The provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Move resource filter.
    internal partial interface IMoveResourceFilterInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceFilterProperties Property { get; set; }
        /// <summary>The provisioning state.</summary>
        string ProvisioningState { get; set; }

    }
}