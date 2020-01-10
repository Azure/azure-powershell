namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ApplicationGatewaySslPredefinedPolicy</summary>
    public partial class ApplicationGatewaySslPredefinedPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicyPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicyPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="CipherSuite" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] _cipherSuite;

        /// <summary>Ssl cipher suites to be enabled in the specified order for application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get => this._cipherSuite; set => this._cipherSuite = value; }

        /// <summary>Backing field for <see cref="MinProtocolVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? _minProtocolVersion;

        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get => this._minProtocolVersion; set => this._minProtocolVersion = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewaySslPredefinedPolicyPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewaySslPredefinedPolicyPropertiesFormat()
        {

        }
    }
    /// Properties of ApplicationGatewaySslPredefinedPolicy
    public partial interface IApplicationGatewaySslPredefinedPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Ssl cipher suites to be enabled in the specified order for application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl cipher suites to be enabled in the specified order for application gateway.",
        SerializedName = @"cipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum version of Ssl protocol to be supported on application gateway.",
        SerializedName = @"minProtocolVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get; set; }

    }
    /// Properties of ApplicationGatewaySslPredefinedPolicy
    internal partial interface IApplicationGatewaySslPredefinedPolicyPropertiesFormatInternal

    {
        /// <summary>Ssl cipher suites to be enabled in the specified order for application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get; set; }

    }
}