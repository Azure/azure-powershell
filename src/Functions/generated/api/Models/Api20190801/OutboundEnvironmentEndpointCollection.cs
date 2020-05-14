namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Collection of Outbound Environment Endpoints</summary>
    public partial class OutboundEnvironmentEndpointCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpointCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpointCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpointCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OutboundEnvironmentEndpointCollection" /> instance.</summary>
        public OutboundEnvironmentEndpointCollection()
        {

        }
    }
    /// Collection of Outbound Environment Endpoints
    public partial interface IOutboundEnvironmentEndpointCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Collection of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint[] Value { get; set; }

    }
    /// Collection of Outbound Environment Endpoints
    internal partial interface IOutboundEnvironmentEndpointCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint[] Value { get; set; }

    }
}