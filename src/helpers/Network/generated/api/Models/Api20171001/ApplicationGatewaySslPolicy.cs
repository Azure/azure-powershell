namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Application Gateway Ssl policy.</summary>
    public partial class ApplicationGatewaySslPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySslPolicyInternal
    {

        /// <summary>Backing field for <see cref="CipherSuite" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] _cipherSuite;

        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get => this._cipherSuite; set => this._cipherSuite = value; }

        /// <summary>Backing field for <see cref="DisabledSslProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] _disabledSslProtocol;

        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] DisabledSslProtocol { get => this._disabledSslProtocol; set => this._disabledSslProtocol = value; }

        /// <summary>Backing field for <see cref="MinProtocolVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? _minProtocolVersion;

        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get => this._minProtocolVersion; set => this._minProtocolVersion = value; }

        /// <summary>Backing field for <see cref="PolicyName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? _policyName;

        /// <summary>Name of Ssl predefined policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? PolicyName { get => this._policyName; set => this._policyName = value; }

        /// <summary>Backing field for <see cref="PolicyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? _policyType;

        /// <summary>Type of Ssl Policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? PolicyType { get => this._policyType; set => this._policyType = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewaySslPolicy" /> instance.</summary>
        public ApplicationGatewaySslPolicy()
        {

        }
    }
    /// Application Gateway Ssl policy.
    public partial interface IApplicationGatewaySslPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl cipher suites to be enabled in the specified order to application gateway.",
        SerializedName = @"cipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get; set; }
        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ssl protocols to be disabled on application gateway.",
        SerializedName = @"disabledSslProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] DisabledSslProtocol { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum version of Ssl protocol to be supported on application gateway.",
        SerializedName = @"minProtocolVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get; set; }
        /// <summary>Name of Ssl predefined policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Ssl predefined policy",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? PolicyName { get; set; }
        /// <summary>Type of Ssl Policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of Ssl Policy",
        SerializedName = @"policyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? PolicyType { get; set; }

    }
    /// Application Gateway Ssl policy.
    internal partial interface IApplicationGatewaySslPolicyInternal

    {
        /// <summary>Ssl cipher suites to be enabled in the specified order to application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] CipherSuite { get; set; }
        /// <summary>Ssl protocols to be disabled on application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] DisabledSslProtocol { get; set; }
        /// <summary>Minimum version of Ssl protocol to be supported on application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol? MinProtocolVersion { get; set; }
        /// <summary>Name of Ssl predefined policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? PolicyName { get; set; }
        /// <summary>Type of Ssl Policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType? PolicyType { get; set; }

    }
}