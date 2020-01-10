namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListExpressRoutePorts API service call.</summary>
    public partial class ExpressRoutePortListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePort[] _value;

        /// <summary>A list of ExpressRoutePort resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePort[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ExpressRoutePortListResult" /> instance.</summary>
        public ExpressRoutePortListResult()
        {

        }
    }
    /// Response for ListExpressRoutePorts API service call.
    public partial interface IExpressRoutePortListResult :
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
        /// <summary>A list of ExpressRoutePort resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of ExpressRoutePort resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePort) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePort[] Value { get; set; }

    }
    /// Response for ListExpressRoutePorts API service call.
    internal partial interface IExpressRoutePortListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of ExpressRoutePort resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePort[] Value { get; set; }

    }
}