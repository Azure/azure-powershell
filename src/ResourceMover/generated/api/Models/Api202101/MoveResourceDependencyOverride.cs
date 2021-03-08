namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the dependency override of the move resource.</summary>
    public partial class MoveResourceDependencyOverride :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverrideInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Gets or sets the ARM ID of the dependent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>
        /// Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of
        /// the dependent resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; set => this._targetId = value; }

        /// <summary>Creates an new <see cref="MoveResourceDependencyOverride" /> instance.</summary>
        public MoveResourceDependencyOverride()
        {

        }
    }
    /// Defines the dependency override of the move resource.
    public partial interface IMoveResourceDependencyOverride :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the ARM ID of the dependent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the ARM ID of the dependent resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of
        /// the dependent resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of
        the dependent resource.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get; set; }

    }
    /// Defines the dependency override of the move resource.
    internal partial interface IMoveResourceDependencyOverrideInternal

    {
        /// <summary>Gets or sets the ARM ID of the dependent resource.</summary>
        string Id { get; set; }
        /// <summary>
        /// Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of
        /// the dependent resource.
        /// </summary>
        string TargetId { get; set; }

    }
}