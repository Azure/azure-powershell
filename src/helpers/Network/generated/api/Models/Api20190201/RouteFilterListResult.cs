namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for the ListRouteFilters API service call.</summary>
    public partial class RouteFilterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter[] _value;

        /// <summary>Gets a list of route filters in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="RouteFilterListResult" /> instance.</summary>
        public RouteFilterListResult()
        {

        }
    }
    /// Response for the ListRouteFilters API service call.
    public partial interface IRouteFilterListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets a list of route filters in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a list of route filters in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter[] Value { get; set; }

    }
    /// Response for the ListRouteFilters API service call.
    internal partial interface IRouteFilterListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets a list of route filters in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter[] Value { get; set; }

    }
}