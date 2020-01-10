namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Backend address of an application gateway.</summary>
    public partial class ApplicationGatewayBackendAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddress,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressInternal
    {

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>Fully qualified domain name (FQDN).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>IP address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayBackendAddress" /> instance.</summary>
        public ApplicationGatewayBackendAddress()
        {

        }
    }
    /// Backend address of an application gateway.
    public partial interface IApplicationGatewayBackendAddress :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Fully qualified domain name (FQDN).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified domain name (FQDN).",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>IP address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }

    }
    /// Backend address of an application gateway.
    internal partial interface IApplicationGatewayBackendAddressInternal

    {
        /// <summary>Fully qualified domain name (FQDN).</summary>
        string Fqdn { get; set; }
        /// <summary>IP address</summary>
        string IPAddress { get; set; }

    }
}