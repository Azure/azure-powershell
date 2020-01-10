namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ApplicationGatewayAvailableSslOptions</summary>
    public partial class ApplicationGatewayAvailableSslOptionsPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableSslOptionsPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AvailableCipherSuite" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] _availableCipherSuite;

        /// <summary>List of available Ssl cipher suites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get => this._availableCipherSuite; set => this._availableCipherSuite = value; }

        /// <summary>Backing field for <see cref="AvailableProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] _availableProtocol;

        /// <summary>List of available Ssl protocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get => this._availableProtocol; set => this._availableProtocol = value; }

        /// <summary>Backing field for <see cref="DefaultPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? _defaultPolicy;

        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get => this._defaultPolicy; set => this._defaultPolicy = value; }

        /// <summary>Backing field for <see cref="PredefinedPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _predefinedPolicy;

        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PredefinedPolicy { get => this._predefinedPolicy; set => this._predefinedPolicy = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAvailableSslOptionsPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayAvailableSslOptionsPropertiesFormat()
        {

        }
    }
    /// Properties of ApplicationGatewayAvailableSslOptions
    public partial interface IApplicationGatewayAvailableSslOptionsPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of available Ssl cipher suites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl cipher suites.",
        SerializedName = @"availableCipherSuites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get; set; }
        /// <summary>List of available Ssl protocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl protocols.",
        SerializedName = @"availableProtocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get; set; }
        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Ssl predefined policy applied by default to application gateway",
        SerializedName = @"defaultPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available Ssl predefined policy.",
        SerializedName = @"predefinedPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PredefinedPolicy { get; set; }

    }
    /// Properties of ApplicationGatewayAvailableSslOptions
    internal partial interface IApplicationGatewayAvailableSslOptionsPropertiesFormatInternal

    {
        /// <summary>List of available Ssl cipher suites.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[] AvailableCipherSuite { get; set; }
        /// <summary>List of available Ssl protocols.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[] AvailableProtocol { get; set; }
        /// <summary>Name of the Ssl predefined policy applied by default to application gateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName? DefaultPolicy { get; set; }
        /// <summary>List of available Ssl predefined policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PredefinedPolicy { get; set; }

    }
}