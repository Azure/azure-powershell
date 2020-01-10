namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Vpn Client Parameters for package generation</summary>
    public partial class VpnClientParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientParametersInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? _authenticationMethod;

        /// <summary>VPN client authentication method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get => this._authenticationMethod; set => this._authenticationMethod = value; }

        /// <summary>Backing field for <see cref="ClientRootCertificate" /> property.</summary>
        private string[] _clientRootCertificate;

        /// <summary>
        /// A list of client root certificates public certificate data encoded as Base-64 strings. Optional parameter for external
        /// radius based authentication with EAPTLS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] ClientRootCertificate { get => this._clientRootCertificate; set => this._clientRootCertificate = value; }

        /// <summary>Backing field for <see cref="ProcessorArchitecture" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture? _processorArchitecture;

        /// <summary>VPN client Processor Architecture. Possible values are: 'AMD64' and 'X86'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture? ProcessorArchitecture { get => this._processorArchitecture; set => this._processorArchitecture = value; }

        /// <summary>Backing field for <see cref="RadiusServerAuthCertificate" /> property.</summary>
        private string _radiusServerAuthCertificate;

        /// <summary>
        /// The public certificate data for the radius server authentication certificate as a Base-64 encoded string. Required only
        /// if external radius authentication has been configured with EAPTLS authentication.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RadiusServerAuthCertificate { get => this._radiusServerAuthCertificate; set => this._radiusServerAuthCertificate = value; }

        /// <summary>Creates an new <see cref="VpnClientParameters" /> instance.</summary>
        public VpnClientParameters()
        {

        }
    }
    /// Vpn Client Parameters for package generation
    public partial interface IVpnClientParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>VPN client authentication method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN client authentication method.",
        SerializedName = @"authenticationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get; set; }
        /// <summary>
        /// A list of client root certificates public certificate data encoded as Base-64 strings. Optional parameter for external
        /// radius based authentication with EAPTLS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of client root certificates public certificate data encoded as Base-64 strings. Optional parameter for external radius based authentication with EAPTLS.",
        SerializedName = @"clientRootCertificates",
        PossibleTypes = new [] { typeof(string) })]
        string[] ClientRootCertificate { get; set; }
        /// <summary>VPN client Processor Architecture. Possible values are: 'AMD64' and 'X86'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VPN client Processor Architecture. Possible values are: 'AMD64' and 'X86'.",
        SerializedName = @"processorArchitecture",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture? ProcessorArchitecture { get; set; }
        /// <summary>
        /// The public certificate data for the radius server authentication certificate as a Base-64 encoded string. Required only
        /// if external radius authentication has been configured with EAPTLS authentication.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public certificate data for the radius server authentication certificate as a Base-64 encoded string. Required only if external radius authentication has been configured with EAPTLS authentication.",
        SerializedName = @"radiusServerAuthCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string RadiusServerAuthCertificate { get; set; }

    }
    /// Vpn Client Parameters for package generation
    internal partial interface IVpnClientParametersInternal

    {
        /// <summary>VPN client authentication method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod? AuthenticationMethod { get; set; }
        /// <summary>
        /// A list of client root certificates public certificate data encoded as Base-64 strings. Optional parameter for external
        /// radius based authentication with EAPTLS.
        /// </summary>
        string[] ClientRootCertificate { get; set; }
        /// <summary>VPN client Processor Architecture. Possible values are: 'AMD64' and 'X86'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture? ProcessorArchitecture { get; set; }
        /// <summary>
        /// The public certificate data for the radius server authentication certificate as a Base-64 encoded string. Required only
        /// if external radius authentication has been configured with EAPTLS authentication.
        /// </summary>
        string RadiusServerAuthCertificate { get; set; }

    }
}