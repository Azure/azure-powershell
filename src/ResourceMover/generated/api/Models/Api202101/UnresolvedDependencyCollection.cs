namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Unresolved dependency collection.</summary>
    public partial class UnresolvedDependencyCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal
    {

        /// <summary>Internal Acessors for SummaryCollection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal.SummaryCollection { get => (this._summaryCollection = this._summaryCollection ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollection()); set { {_summaryCollection = value;} } }

        /// <summary>Internal Acessors for TotalCount</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyCollectionInternal.TotalCount { get => this._totalCount; set { {_totalCount = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets or sets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="SummaryCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection _summaryCollection;

        /// <summary>Gets or sets the list of summary items and the field on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection SummaryCollection { get => (this._summaryCollection = this._summaryCollection ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.SummaryCollection()); }

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
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[] _value;

        /// <summary>Gets or sets the list of unresolved dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="UnresolvedDependencyCollection" /> instance.</summary>
        public UnresolvedDependencyCollection()
        {

        }
    }
    /// Unresolved dependency collection.
    public partial interface IUnresolvedDependencyCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the value of  next link.",
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
        /// <summary>Gets or sets the list of unresolved dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of unresolved dependencies.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[] Value { get; set; }

    }
    /// Unresolved dependency collection.
    internal partial interface IUnresolvedDependencyCollectionInternal

    {
        /// <summary>Gets or sets the value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>Gets or sets the list of summary items and the field on which summary is done.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection SummaryCollection { get; set; }
        /// <summary>Gets or sets the field name on which summary is done.</summary>
        string SummaryCollectionFieldName { get; set; }
        /// <summary>Gets or sets the list of summary items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] SummaryCollectionSummary { get; set; }
        /// <summary>Gets the total count.</summary>
        long? TotalCount { get; set; }
        /// <summary>Gets or sets the list of unresolved dependencies.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency[] Value { get; set; }

    }
}