namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Response for ListAuthorizations API service call retrieves all authorizations that belongs to an ExpressRouteCircuit.
    /// </summary>
    public partial class AuthorizationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAuthorizationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAuthorizationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitAuthorization[] _value;

        /// <summary>The authorizations in an ExpressRoute Circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitAuthorization[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AuthorizationListResult" /> instance.</summary>
        public AuthorizationListResult()
        {

        }
    }
    /// Response for ListAuthorizations API service call retrieves all authorizations that belongs to an ExpressRouteCircuit.
    public partial interface IAuthorizationListResult :
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
        /// <summary>The authorizations in an ExpressRoute Circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The authorizations in an ExpressRoute Circuit.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitAuthorization[] Value { get; set; }

    }
    /// Response for ListAuthorizations API service call retrieves all authorizations that belongs to an ExpressRouteCircuit.
    internal partial interface IAuthorizationListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>The authorizations in an ExpressRoute Circuit.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitAuthorization[] Value { get; set; }

    }
}