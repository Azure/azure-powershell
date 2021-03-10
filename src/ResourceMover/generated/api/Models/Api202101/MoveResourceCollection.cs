namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the collection of move resources.</summary>
    public partial class MoveResourceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceCollectionInternal
    {

        /// <summary>Internal Acessors for SummaryCollection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceCollectionInternal.SummaryCollection { get => (this._summaryCollection = this._summaryCollection ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollection()); set { {_summaryCollection = value;} } }

        /// <summary>Internal Acessors for TotalCount</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceCollectionInternal.TotalCount { get => this._totalCount; set { {_totalCount = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="SummaryCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection _summaryCollection;

        /// <summary>Gets or sets the list of summary items and the field on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection SummaryCollection { get => (this._summaryCollection = this._summaryCollection ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollection()); set => this._summaryCollection = value; }

        /// <summary>Gets or sets the field name on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string SummaryCollectionFieldName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollectionInternal)SummaryCollection).FieldName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollectionInternal)SummaryCollection).FieldName = value ?? null; }

        /// <summary>Gets or sets the list of summary items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] SummaryCollectionSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollectionInternal)SummaryCollection).Summary; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollectionInternal)SummaryCollection).Summary = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="TotalCount" /> property.</summary>
        private long? _totalCount;

        /// <summary>Gets the total count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public long? TotalCount { get => this._totalCount; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource[] _value;

        /// <summary>Gets the list of move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="MoveResourceCollection" /> instance.</summary>
        public MoveResourceCollection()
        {

        }
    }
    /// Defines the collection of move resources.
    public partial interface IMoveResourceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the value of  next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets or sets the field name on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the field name on which summary is done.",
        SerializedName = @"fieldName",
        PossibleTypes = new [] { typeof(string) })]
        string SummaryCollectionFieldName { get; set; }
        /// <summary>Gets or sets the list of summary items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of summary items.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] SummaryCollectionSummary { get; set; }
        /// <summary>Gets the total count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the total count.",
        SerializedName = @"totalCount",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalCount { get;  }
        /// <summary>Gets the list of move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the list of move resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource[] Value { get; set; }

    }
    /// Defines the collection of move resources.
    internal partial interface IMoveResourceCollectionInternal

    {
        /// <summary>Gets the value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>Gets or sets the list of summary items and the field on which summary is done.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection SummaryCollection { get; set; }
        /// <summary>Gets or sets the field name on which summary is done.</summary>
        string SummaryCollectionFieldName { get; set; }
        /// <summary>Gets or sets the list of summary items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] SummaryCollectionSummary { get; set; }
        /// <summary>Gets the total count.</summary>
        long? TotalCount { get; set; }
        /// <summary>Gets the list of move resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource[] Value { get; set; }

    }
}