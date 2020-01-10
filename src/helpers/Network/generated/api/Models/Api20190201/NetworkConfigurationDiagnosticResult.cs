namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network configuration diagnostic result corresponded to provided traffic query.</summary>
    public partial class NetworkConfigurationDiagnosticResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal
    {

        /// <summary>Internal Acessors for NsgResult</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal.NsgResult { get => (this._nsgResult = this._nsgResult ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroupResult()); set { {_nsgResult = value;} } }

        /// <summary>Internal Acessors for NsgResultEvaluatedNsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal.NsgResultEvaluatedNsg { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal)NsgResult).EvaluatedNsg; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal)NsgResult).EvaluatedNsg = value; }

        /// <summary>Internal Acessors for Profile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticResultInternal.Profile { get => (this._profile = this._profile ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticProfile()); set { {_profile = value;} } }

        /// <summary>Backing field for <see cref="NsgResult" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult _nsgResult;

        /// <summary>Network security group result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult NsgResult { get => (this._nsgResult = this._nsgResult ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroupResult()); set => this._nsgResult = value; }

        /// <summary>List of results network security groups diagnostic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] NsgResultEvaluatedNsg { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal)NsgResult).EvaluatedNsg; }

        /// <summary>The network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? NsgResultSecurityRuleAccessResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal)NsgResult).SecurityRuleAccessResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal)NsgResult).SecurityRuleAccessResult = value; }

        /// <summary>Backing field for <see cref="Profile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile _profile;

        /// <summary>Network configuration diagnostic profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile Profile { get => (this._profile = this._profile ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkConfigurationDiagnosticProfile()); set => this._profile = value; }

        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProfileDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Destination; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Destination = value; }

        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProfileDestinationPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).DestinationPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).DestinationPort = value; }

        /// <summary>The direction of the traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction ProfileDirection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Direction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Direction = value; }

        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProfileProtocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Protocol = value; }

        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProfileSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfileInternal)Profile).Source = value; }

        /// <summary>Creates an new <see cref="NetworkConfigurationDiagnosticResult" /> instance.</summary>
        public NetworkConfigurationDiagnosticResult()
        {

        }
    }
    /// Network configuration diagnostic result corresponded to provided traffic query.
    public partial interface INetworkConfigurationDiagnosticResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of results network security groups diagnostic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of results network security groups diagnostic.",
        SerializedName = @"evaluatedNetworkSecurityGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] NsgResultEvaluatedNsg { get;  }
        /// <summary>The network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network traffic is allowed or denied.",
        SerializedName = @"securityRuleAccessResult",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? NsgResultSecurityRuleAccessResult { get; set; }
        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.",
        SerializedName = @"destination",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileDestination { get; set; }
        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).",
        SerializedName = @"destinationPort",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileDestinationPort { get; set; }
        /// <summary>The direction of the traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The direction of the traffic.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction ProfileDirection { get; set; }
        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Protocol to be verified on. Accepted values are '*', TCP, UDP.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileProtocol { get; set; }
        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileSource { get; set; }

    }
    /// Network configuration diagnostic result corresponded to provided traffic query.
    internal partial interface INetworkConfigurationDiagnosticResultInternal

    {
        /// <summary>Network security group result.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult NsgResult { get; set; }
        /// <summary>List of results network security groups diagnostic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] NsgResultEvaluatedNsg { get; set; }
        /// <summary>The network traffic is allowed or denied.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? NsgResultSecurityRuleAccessResult { get; set; }
        /// <summary>Network configuration diagnostic profile.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkConfigurationDiagnosticProfile Profile { get; set; }
        /// <summary>Traffic destination. Accepted values are: '*', IP Address/CIDR, Service Tag.</summary>
        string ProfileDestination { get; set; }
        /// <summary>
        /// Traffic destination port. Accepted values are '*', port (for example, 3389) and port range (for example, 80-100).
        /// </summary>
        string ProfileDestinationPort { get; set; }
        /// <summary>The direction of the traffic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction ProfileDirection { get; set; }
        /// <summary>Protocol to be verified on. Accepted values are '*', TCP, UDP.</summary>
        string ProfileProtocol { get; set; }
        /// <summary>Traffic source. Accepted values are '*', IP Address/CIDR, Service Tag.</summary>
        string ProfileSource { get; set; }

    }
}