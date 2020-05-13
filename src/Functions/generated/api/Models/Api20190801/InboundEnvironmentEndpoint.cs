namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The IP Addresses and Ports that require inbound network access to and within the subnet of the App Service Environment.
    /// </summary>
    public partial class InboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IInboundEnvironmentEndpointInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Short text describing the purpose of the network traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string[] _endpoint;

        /// <summary>The IP addresses that network traffic will originate from in cidr notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private string[] _port;

        /// <summary>The ports that network traffic will arrive to the App Service Environment at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Port { get => this._port; set => this._port = value; }

        /// <summary>Creates an new <see cref="InboundEnvironmentEndpoint" /> instance.</summary>
        public InboundEnvironmentEndpoint()
        {

        }
    }
    /// The IP Addresses and Ports that require inbound network access to and within the subnet of the App Service Environment.
    public partial interface IInboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Short text describing the purpose of the network traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Short text describing the purpose of the network traffic.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The IP addresses that network traffic will originate from in cidr notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP addresses that network traffic will originate from in cidr notation.",
        SerializedName = @"endpoints",
        PossibleTypes = new [] { typeof(string) })]
        string[] Endpoint { get; set; }
        /// <summary>The ports that network traffic will arrive to the App Service Environment at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ports that network traffic will arrive to the App Service Environment at.",
        SerializedName = @"ports",
        PossibleTypes = new [] { typeof(string) })]
        string[] Port { get; set; }

    }
    /// The IP Addresses and Ports that require inbound network access to and within the subnet of the App Service Environment.
    internal partial interface IInboundEnvironmentEndpointInternal

    {
        /// <summary>Short text describing the purpose of the network traffic.</summary>
        string Description { get; set; }
        /// <summary>The IP addresses that network traffic will originate from in cidr notation.</summary>
        string[] Endpoint { get; set; }
        /// <summary>The ports that network traffic will arrive to the App Service Environment at.</summary>
        string[] Port { get; set; }

    }
}