namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the move collection properties.</summary>
    public partial class MoveCollectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveCollectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveCollectionPropertiesInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveCollectionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? _provisioningState;

        /// <summary>Defines the provisioning states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SourceRegion" /> property.</summary>
        private string _sourceRegion;

        /// <summary>Gets or sets the source region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourceRegion { get => this._sourceRegion; set => this._sourceRegion = value; }

        /// <summary>Backing field for <see cref="TargetRegion" /> property.</summary>
        private string _targetRegion;

        /// <summary>Gets or sets the target region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TargetRegion { get => this._targetRegion; set => this._targetRegion = value; }

        /// <summary>Creates an new <see cref="MoveCollectionProperties" /> instance.</summary>
        public MoveCollectionProperties()
        {

        }
    }
    /// Defines the move collection properties.
    public partial interface IMoveCollectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Defines the provisioning states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the provisioning states.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Gets or sets the source region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the source region.",
        SerializedName = @"sourceRegion",
        PossibleTypes = new [] { typeof(string) })]
        string SourceRegion { get; set; }
        /// <summary>Gets or sets the target region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the target region.",
        SerializedName = @"targetRegion",
        PossibleTypes = new [] { typeof(string) })]
        string TargetRegion { get; set; }

    }
    /// Defines the move collection properties.
    internal partial interface IMoveCollectionPropertiesInternal

    {
        /// <summary>Defines the provisioning states.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets or sets the source region.</summary>
        string SourceRegion { get; set; }
        /// <summary>Gets or sets the target region.</summary>
        string TargetRegion { get; set; }

    }
}