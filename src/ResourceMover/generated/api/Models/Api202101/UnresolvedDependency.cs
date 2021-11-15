namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Unresolved dependency.</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.DoNotFormat]
    public partial class UnresolvedDependency :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependency,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IUnresolvedDependencyInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>Gets or sets the count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Gets or sets the arm id of the dependency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="UnresolvedDependency" /> instance.</summary>
        public UnresolvedDependency()
        {

        }
    }
    /// Unresolved dependency.
    public partial interface IUnresolvedDependency :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>Gets or sets the arm id of the dependency.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the arm id of the dependency.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Unresolved dependency.
    internal partial interface IUnresolvedDependencyInternal

    {
        /// <summary>Gets or sets the count.</summary>
        int? Count { get; set; }
        /// <summary>Gets or sets the arm id of the dependency.</summary>
        string Id { get; set; }

    }
}