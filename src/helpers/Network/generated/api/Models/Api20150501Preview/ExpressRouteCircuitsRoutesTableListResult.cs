namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListRoutesTable associated with the Express Route Circuits Api</summary>
    public partial class ExpressRouteCircuitsRoutesTableListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitsRoutesTableListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitsRoutesTableListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable[] _value;

        /// <summary>Gets List of RoutesTable</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteCircuitsRoutesTableListResult" /> instance.
        /// </summary>
        public ExpressRouteCircuitsRoutesTableListResult()
        {

        }
    }
    /// Response for ListRoutesTable associated with the Express Route Circuits Api
    public partial interface IExpressRouteCircuitsRoutesTableListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets List of RoutesTable</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets List of RoutesTable",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable[] Value { get; set; }

    }
    /// Response for ListRoutesTable associated with the Express Route Circuits Api
    internal partial interface IExpressRouteCircuitsRoutesTableListResultInternal

    {
        /// <summary>Gets the URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets List of RoutesTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitRoutesTable[] Value { get; set; }

    }
}