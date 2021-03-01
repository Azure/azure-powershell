namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Collection of ClientDiscovery details.</summary>
    public partial class OperationsDiscoveryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscoveryCollection,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscoveryCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets or sets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscovery[] _value;

        /// <summary>Gets or sets the ClientDiscovery details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscovery[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationsDiscoveryCollection" /> instance.</summary>
        public OperationsDiscoveryCollection()
        {

        }
    }
    /// Collection of ClientDiscovery details.
    public partial interface IOperationsDiscoveryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets or sets the ClientDiscovery details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the ClientDiscovery details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscovery) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscovery[] Value { get; set; }

    }
    /// Collection of ClientDiscovery details.
    internal partial interface IOperationsDiscoveryCollectionInternal

    {
        /// <summary>Gets or sets the value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>Gets or sets the ClientDiscovery details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationsDiscovery[] Value { get; set; }

    }
}