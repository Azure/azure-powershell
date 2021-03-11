namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Summary item.</summary>
    public partial class Summary :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummary,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISummaryInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>Gets the count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="Item" /> property.</summary>
        private string _item;

        /// <summary>Gets the item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Item { get => this._item; set => this._item = value; }

        /// <summary>Creates an new <see cref="Summary" /> instance.</summary>
        public Summary()
        {

        }
    }
    /// Summary item.
    public partial interface ISummary :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets the count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>Gets the item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the item.",
        SerializedName = @"item",
        PossibleTypes = new [] { typeof(string) })]
        string Item { get; set; }

    }
    /// Summary item.
    internal partial interface ISummaryInternal

    {
        /// <summary>Gets the count.</summary>
        int? Count { get; set; }
        /// <summary>Gets the item.</summary>
        string Item { get; set; }

    }
}