namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the collection of move collections.</summary>
    public partial class MoveCollectionResultList :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollectionResultList,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollectionResultListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollection[] _value;

        /// <summary>Gets the list of move collections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollection[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="MoveCollectionResultList" /> instance.</summary>
        public MoveCollectionResultList()
        {

        }
    }
    /// Defines the collection of move collections.
    public partial interface IMoveCollectionResultList :
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
        /// <summary>Gets the list of move collections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the list of move collections.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollection) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollection[] Value { get; set; }

    }
    /// Defines the collection of move collections.
    internal partial interface IMoveCollectionResultListInternal

    {
        /// <summary>Gets the value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>Gets the list of move collections.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveCollection[] Value { get; set; }

    }
}