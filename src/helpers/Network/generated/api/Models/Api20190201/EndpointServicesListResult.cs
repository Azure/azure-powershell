namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for the ListAvailableEndpointServices API service call.</summary>
    public partial class EndpointServicesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServicesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServicesListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceResult[] _value;

        /// <summary>List of available endpoint services in a region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceResult[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="EndpointServicesListResult" /> instance.</summary>
        public EndpointServicesListResult()
        {

        }
    }
    /// Response for the ListAvailableEndpointServices API service call.
    public partial interface IEndpointServicesListResult :
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
        /// <summary>List of available endpoint services in a region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available endpoint services in a region.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceResult[] Value { get; set; }

    }
    /// Response for the ListAvailableEndpointServices API service call.
    internal partial interface IEndpointServicesListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>List of available endpoint services in a region.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceResult[] Value { get; set; }

    }
}