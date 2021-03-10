namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>The move custom error info.</summary>
    public partial class MoveErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveErrorInfo,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveErrorInfoInternal
    {

        /// <summary>Internal Acessors for MoveResource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveErrorInfoInternal.MoveResource { get => this._moveResource; set { {_moveResource = value;} } }

        /// <summary>Backing field for <see cref="MoveResource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] _moveResource;

        /// <summary>The affected move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get => this._moveResource; }

        /// <summary>Creates an new <see cref="MoveErrorInfo" /> instance.</summary>
        public MoveErrorInfo()
        {

        }
    }
    /// The move custom error info.
    public partial interface IMoveErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>The affected move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected move resources.",
        SerializedName = @"moveResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get;  }

    }
    /// The move custom error info.
    internal partial interface IMoveErrorInfoInternal

    {
        /// <summary>The affected move resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get; set; }

    }
}