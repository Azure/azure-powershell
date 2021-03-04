namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Summary Collection.</summary>
    public partial class SummaryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryCollectionInternal
    {

        /// <summary>Backing field for <see cref="FieldName" /> property.</summary>
        private string _fieldName;

        /// <summary>Gets or sets the field name on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string FieldName { get => this._fieldName; set => this._fieldName = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] _summary;

        /// <summary>Gets or sets the list of summary items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Creates an new <see cref="SummaryCollection" /> instance.</summary>
        public SummaryCollection()
        {

        }
    }
    /// Summary Collection.
    public partial interface ISummaryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the field name on which summary is done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the field name on which summary is done.",
        SerializedName = @"fieldName",
        PossibleTypes = new [] { typeof(string) })]
        string FieldName { get; set; }
        /// <summary>Gets or sets the list of summary items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of summary items.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] Summary { get; set; }

    }
    /// Summary Collection.
    internal partial interface ISummaryCollectionInternal

    {
        /// <summary>Gets or sets the field name on which summary is done.</summary>
        string FieldName { get; set; }
        /// <summary>Gets or sets the list of summary items.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary[] Summary { get; set; }

    }
}