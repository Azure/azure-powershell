namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the collection of move resources.</summary>
    public partial class MoveResourceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResource[] _value;

        /// <summary>Gets the list of move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResource[] Value { get => this._value; set => this._value = value; }

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
        /// <summary>Gets the list of move resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the list of move resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResource[] Value { get; set; }

    }
    /// Defines the collection of move resources.
    internal partial interface IMoveResourceCollectionInternal

    {
        /// <summary>Gets the value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>Gets the list of move resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResource[] Value { get; set; }

    }
}