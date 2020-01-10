namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list VpnSites. It contains a list of VpnSites and a URL nextLink to get the next set of results.
    /// </summary>
    public partial class ListVpnSitesResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnSitesResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IListVpnSitesResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite[] _value;

        /// <summary>List of VpnSites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ListVpnSitesResult" /> instance.</summary>
        public ListVpnSitesResult()
        {

        }
    }
    /// Result of the request to list VpnSites. It contains a list of VpnSites and a URL nextLink to get the next set of results.
    public partial interface IListVpnSitesResult :
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
        /// <summary>List of VpnSites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of VpnSites.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite[] Value { get; set; }

    }
    /// Result of the request to list VpnSites. It contains a list of VpnSites and a URL nextLink to get the next set of results.
    internal partial interface IListVpnSitesResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of VpnSites.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnSite[] Value { get; set; }

    }
}