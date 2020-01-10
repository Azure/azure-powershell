namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of a NAT rule.</summary>
    public partial class AzureFirewallNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DestinationAddress" /> property.</summary>
        private string[] _destinationAddress;

        /// <summary>
        /// List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DestinationAddress { get => this._destinationAddress; set => this._destinationAddress = value; }

        /// <summary>Backing field for <see cref="DestinationPort" /> property.</summary>
        private string[] _destinationPort;

        /// <summary>List of destination ports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DestinationPort { get => this._destinationPort; set => this._destinationPort = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNetworkRuleProtocol[] _protocol;

        /// <summary>Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNetworkRuleProtocol[] Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="SourceAddress" /> property.</summary>
        private string[] _sourceAddress;

        /// <summary>List of source IP addresses for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] SourceAddress { get => this._sourceAddress; set => this._sourceAddress = value; }

        /// <summary>Backing field for <see cref="TranslatedAddress" /> property.</summary>
        private string _translatedAddress;

        /// <summary>The translated address for this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TranslatedAddress { get => this._translatedAddress; set => this._translatedAddress = value; }

        /// <summary>Backing field for <see cref="TranslatedPort" /> property.</summary>
        private string _translatedPort;

        /// <summary>The translated port for this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TranslatedPort { get => this._translatedPort; set => this._translatedPort = value; }

        /// <summary>Creates an new <see cref="AzureFirewallNatRule" /> instance.</summary>
        public AzureFirewallNatRule()
        {

        }
    }
    /// Properties of a NAT rule.
    public partial interface IAzureFirewallNatRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the rule.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.",
        SerializedName = @"destinationAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] DestinationAddress { get; set; }
        /// <summary>List of destination ports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of destination ports.",
        SerializedName = @"destinationPorts",
        PossibleTypes = new [] { typeof(string) })]
        string[] DestinationPort { get; set; }
        /// <summary>Name of the NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the NAT rule.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.",
        SerializedName = @"protocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNetworkRuleProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNetworkRuleProtocol[] Protocol { get; set; }
        /// <summary>List of source IP addresses for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of source IP addresses for this rule.",
        SerializedName = @"sourceAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] SourceAddress { get; set; }
        /// <summary>The translated address for this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The translated address for this NAT rule.",
        SerializedName = @"translatedAddress",
        PossibleTypes = new [] { typeof(string) })]
        string TranslatedAddress { get; set; }
        /// <summary>The translated port for this NAT rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The translated port for this NAT rule.",
        SerializedName = @"translatedPort",
        PossibleTypes = new [] { typeof(string) })]
        string TranslatedPort { get; set; }

    }
    /// Properties of a NAT rule.
    internal partial interface IAzureFirewallNatRuleInternal

    {
        /// <summary>Description of the rule.</summary>
        string Description { get; set; }
        /// <summary>
        /// List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.
        /// </summary>
        string[] DestinationAddress { get; set; }
        /// <summary>List of destination ports.</summary>
        string[] DestinationPort { get; set; }
        /// <summary>Name of the NAT rule.</summary>
        string Name { get; set; }
        /// <summary>Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNetworkRuleProtocol[] Protocol { get; set; }
        /// <summary>List of source IP addresses for this rule.</summary>
        string[] SourceAddress { get; set; }
        /// <summary>The translated address for this NAT rule.</summary>
        string TranslatedAddress { get; set; }
        /// <summary>The translated port for this NAT rule.</summary>
        string TranslatedPort { get; set; }

    }
}