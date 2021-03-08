namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>The RP custom operation error info.</summary>
    public partial class AffectedMoveResource :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The affected move resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for MoveResource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResourceInternal.MoveResource { get => this._moveResource; set { {_moveResource = value;} } }

        /// <summary>Internal Acessors for SourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResourceInternal.SourceId { get => this._sourceId; set { {_sourceId = value;} } }

        /// <summary>Backing field for <see cref="MoveResource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] _moveResource;

        /// <summary>The affected move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get => this._moveResource; }

        /// <summary>Backing field for <see cref="SourceId" /> property.</summary>
        private string _sourceId;

        /// <summary>The affected move resource source id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourceId { get => this._sourceId; }

        /// <summary>Creates an new <see cref="AffectedMoveResource" /> instance.</summary>
        public AffectedMoveResource()
        {

        }
    }
    /// The RP custom operation error info.
    public partial interface IAffectedMoveResource :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>The affected move resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected move resource id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The affected move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected move resources.",
        SerializedName = @"moveResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get;  }
        /// <summary>The affected move resource source id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The affected move resource source id.",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get;  }

    }
    /// The RP custom operation error info.
    internal partial interface IAffectedMoveResourceInternal

    {
        /// <summary>The affected move resource id.</summary>
        string Id { get; set; }
        /// <summary>The affected move resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAffectedMoveResource[] MoveResource { get; set; }
        /// <summary>The affected move resource source id.</summary>
        string SourceId { get; set; }

    }
}