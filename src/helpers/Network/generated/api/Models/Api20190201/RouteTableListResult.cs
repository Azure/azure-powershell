namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for the ListRouteTable API service call.</summary>
    public partial class RouteTableListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTableListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable[] _value;

        /// <summary>Gets a list of route tables in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="RouteTableListResult" /> instance.</summary>
        public RouteTableListResult()
        {

        }
    }
    /// Response for the ListRouteTable API service call.
    public partial interface IRouteTableListResult :
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
        /// <summary>Gets a list of route tables in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a list of route tables in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable[] Value { get; set; }

    }
    /// Response for the ListRouteTable API service call.
    internal partial interface IRouteTableListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets a list of route tables in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteTable[] Value { get; set; }

    }
}