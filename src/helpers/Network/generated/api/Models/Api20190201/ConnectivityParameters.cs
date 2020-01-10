namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that determine how the connectivity check will be performed.</summary>
    public partial class ConnectivityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal
    {

        /// <summary>Backing field for <see cref="Destination" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination _destination;

        /// <summary>Describes the destination of connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityDestination()); set => this._destination = value; }

        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).Address; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).Address = value; }

        /// <summary>Port on which check connectivity will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? DestinationPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).Port = value; }

        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal)Destination).ResourceId = value; }

        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationHeader; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationHeader = value; }

        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationMethod = value; }

        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int[] HttpConfigurationValidStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationValidStatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfigurationValidStatusCode = value; }

        /// <summary>Internal Acessors for Destination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal.Destination { get => (this._destination = this._destination ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityDestination()); set { {_destination = value;} } }

        /// <summary>Internal Acessors for ProtocolConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal.ProtocolConfiguration { get => (this._protocolConfiguration = this._protocolConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration()); set { {_protocolConfiguration = value;} } }

        /// <summary>Internal Acessors for ProtocolConfigurationHttpConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal.ProtocolConfigurationHttpConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)ProtocolConfiguration).HttpConfiguration = value; }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityParametersInternal.Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivitySource()); set { {_source = value;} } }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol? _protocol;

        /// <summary>Network protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProtocolConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration _protocolConfiguration;

        /// <summary>Configuration of the protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration ProtocolConfiguration { get => (this._protocolConfiguration = this._protocolConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration()); set => this._protocolConfiguration = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource _source;

        /// <summary>Describes the source of the connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivitySource()); set => this._source = value; }

        /// <summary>The source port from which a connectivity check will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? SourcePort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySourceInternal)Source).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySourceInternal)Source).Port = value; }

        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySourceInternal)Source).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySourceInternal)Source).ResourceId = value; }

        /// <summary>Creates an new <see cref="ConnectivityParameters" /> instance.</summary>
        public ConnectivityParameters()
        {

        }
    }
    /// Parameters that determine how the connectivity check will be performed.
    public partial interface IConnectivityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address or URI the resource to which a connection attempt will be made.",
        SerializedName = @"address",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationAddress { get; set; }
        /// <summary>Port on which check connectivity will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Port on which check connectivity will be performed.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? DestinationPort { get; set; }
        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the resource to which a connection attempt will be made.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationResourceId { get; set; }
        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of HTTP headers.",
        SerializedName = @"headers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get; set; }
        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP method.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get; set; }
        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid status codes.",
        SerializedName = @"validStatusCodes",
        PossibleTypes = new [] { typeof(int) })]
        int[] HttpConfigurationValidStatusCode { get; set; }
        /// <summary>Network protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network protocol.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol? Protocol { get; set; }
        /// <summary>The source port from which a connectivity check will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source port from which a connectivity check will be performed.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? SourcePort { get; set; }
        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the resource from which a connectivity check will be initiated.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get; set; }

    }
    /// Parameters that determine how the connectivity check will be performed.
    internal partial interface IConnectivityParametersInternal

    {
        /// <summary>Describes the destination of connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination Destination { get; set; }
        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        string DestinationAddress { get; set; }
        /// <summary>Port on which check connectivity will be performed.</summary>
        int? DestinationPort { get; set; }
        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        string DestinationResourceId { get; set; }
        /// <summary>List of HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get; set; }
        /// <summary>HTTP method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get; set; }
        /// <summary>Valid status codes.</summary>
        int[] HttpConfigurationValidStatusCode { get; set; }
        /// <summary>Network protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Protocol? Protocol { get; set; }
        /// <summary>Configuration of the protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration ProtocolConfiguration { get; set; }
        /// <summary>HTTP configuration of the connectivity check.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration ProtocolConfigurationHttpConfiguration { get; set; }
        /// <summary>Describes the source of the connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource Source { get; set; }
        /// <summary>The source port from which a connectivity check will be performed.</summary>
        int? SourcePort { get; set; }
        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        string SourceResourceId { get; set; }

    }
}