namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list VirtualHubs. It contains a list of VirtualHubs and a URL nextLink to get the next set of
    /// results.
    /// </summary>
    public partial class ListVirtualHubsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVirtualHubsResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVirtualHubsResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHub[] _value;

        /// <summary>List of VirtualHubs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHub[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListVirtualHubsResult" /> instance.</summary>
        public ListVirtualHubsResult()
        {

        }
    }
    /// Result of the request to list VirtualHubs. It contains a list of VirtualHubs and a URL nextLink to get the next set of
    /// results.
    public partial interface IListVirtualHubsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of VirtualHubs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of VirtualHubs.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHub) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHub[] Value { get; set; }

    }
    /// Result of the request to list VirtualHubs. It contains a list of VirtualHubs and a URL nextLink to get the next set of
    /// results.
    internal partial interface IListVirtualHubsResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of VirtualHubs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHub[] Value { get; set; }

    }
}