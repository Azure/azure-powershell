namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Collection of Inbound Environment Endpoints</summary>
    public partial class InboundEnvironmentEndpointCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpointCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpointCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpointCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="InboundEnvironmentEndpointCollection" /> instance.</summary>
        public InboundEnvironmentEndpointCollection()
        {

        }
    }
    /// Collection of Inbound Environment Endpoints
    public partial interface IInboundEnvironmentEndpointCollection :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint[] Value { get; set; }

    }
    /// Collection of Inbound Environment Endpoints
    internal partial interface IInboundEnvironmentEndpointCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint[] Value { get; set; }

    }
}