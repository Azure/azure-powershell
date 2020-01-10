namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Effective network security rules.</summary>
    public partial class EffectiveNetworkSecurityRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal
    {

        /// <summary>Backing field for <see cref="Access" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? _access;

        /// <summary>Whether network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? Access { get => this._access; set => this._access = value; }

        /// <summary>Backing field for <see cref="DestinationAddressPrefix" /> property.</summary>
        private string _destinationAddressPrefix;

        /// <summary>The destination address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DestinationAddressPrefix { get => this._destinationAddressPrefix; set => this._destinationAddressPrefix = value; }

        /// <summary>Backing field for <see cref="DestinationAddressPrefixes" /> property.</summary>
        private string[] _destinationAddressPrefixes;

        /// <summary>
        /// The destination address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DestinationAddressPrefixes { get => this._destinationAddressPrefixes; set => this._destinationAddressPrefixes = value; }

        /// <summary>Backing field for <see cref="DestinationPortRange" /> property.</summary>
        private string _destinationPortRange;

        /// <summary>The destination port or range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DestinationPortRange { get => this._destinationPortRange; set => this._destinationPortRange = value; }

        /// <summary>Backing field for <see cref="DestinationPortRanges" /> property.</summary>
        private string[] _destinationPortRanges;

        /// <summary>
        /// The destination port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator
        /// (e.g. 100-400), or an asterisk (*)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DestinationPortRanges { get => this._destinationPortRanges; set => this._destinationPortRanges = value; }

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection? _direction;

        /// <summary>The direction of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection? Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="ExpandedDestinationAddressPrefix" /> property.</summary>
        private string[] _expandedDestinationAddressPrefix;

        /// <summary>Expanded destination address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] ExpandedDestinationAddressPrefix { get => this._expandedDestinationAddressPrefix; set => this._expandedDestinationAddressPrefix = value; }

        /// <summary>Backing field for <see cref="ExpandedSourceAddressPrefix" /> property.</summary>
        private string[] _expandedSourceAddressPrefix;

        /// <summary>The expanded source address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] ExpandedSourceAddressPrefix { get => this._expandedSourceAddressPrefix; set => this._expandedSourceAddressPrefix = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the security rule specified by the user (if created by the user).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private int? _priority;

        /// <summary>The priority of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol? _protocol;

        /// <summary>
        /// The network protocol this rule applies to. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="SourceAddressPrefix" /> property.</summary>
        private string _sourceAddressPrefix;

        /// <summary>The source address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourceAddressPrefix { get => this._sourceAddressPrefix; set => this._sourceAddressPrefix = value; }

        /// <summary>Backing field for <see cref="SourceAddressPrefixes" /> property.</summary>
        private string[] _sourceAddressPrefixes;

        /// <summary>
        /// The source address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] SourceAddressPrefixes { get => this._sourceAddressPrefixes; set => this._sourceAddressPrefixes = value; }

        /// <summary>Backing field for <see cref="SourcePortRange" /> property.</summary>
        private string _sourcePortRange;

        /// <summary>The source port or range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourcePortRange { get => this._sourcePortRange; set => this._sourcePortRange = value; }

        /// <summary>Backing field for <see cref="SourcePortRanges" /> property.</summary>
        private string[] _sourcePortRanges;

        /// <summary>
        /// The source port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g.
        /// 100-400), or an asterisk (*)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] SourcePortRanges { get => this._sourcePortRanges; set => this._sourcePortRanges = value; }

        /// <summary>Creates an new <see cref="EffectiveNetworkSecurityRule" /> instance.</summary>
        public EffectiveNetworkSecurityRule()
        {

        }
    }
    /// Effective network security rules.
    public partial interface IEffectiveNetworkSecurityRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Whether network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether network traffic is allowed or denied.",
        SerializedName = @"access",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? Access { get; set; }
        /// <summary>The destination address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination address prefix.",
        SerializedName = @"destinationAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationAddressPrefix { get; set; }
        /// <summary>
        /// The destination address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer, Internet), System Tags, and the asterisk (*).",
        SerializedName = @"destinationAddressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] DestinationAddressPrefixes { get; set; }
        /// <summary>The destination port or range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination port or range.",
        SerializedName = @"destinationPortRange",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationPortRange { get; set; }
        /// <summary>
        /// The destination port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator
        /// (e.g. 100-400), or an asterisk (*)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The destination port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g. 100-400), or an asterisk (*)",
        SerializedName = @"destinationPortRanges",
        PossibleTypes = new [] { typeof(string) })]
        string[] DestinationPortRanges { get; set; }
        /// <summary>The direction of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The direction of the rule.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection? Direction { get; set; }
        /// <summary>Expanded destination address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Expanded destination address prefix.",
        SerializedName = @"expandedDestinationAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExpandedDestinationAddressPrefix { get; set; }
        /// <summary>The expanded source address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The expanded source address prefix.",
        SerializedName = @"expandedSourceAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExpandedSourceAddressPrefix { get; set; }
        /// <summary>The name of the security rule specified by the user (if created by the user).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the security rule specified by the user (if created by the user).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The priority of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The priority of the rule.",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(int) })]
        int? Priority { get; set; }
        /// <summary>
        /// The network protocol this rule applies to. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network protocol this rule applies to. Possible values are: 'Tcp', 'Udp', and 'All'.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol? Protocol { get; set; }
        /// <summary>The source address prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source address prefix.",
        SerializedName = @"sourceAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string SourceAddressPrefix { get; set; }
        /// <summary>
        /// The source address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer, Internet), System Tags, and the asterisk (*).",
        SerializedName = @"sourceAddressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] SourceAddressPrefixes { get; set; }
        /// <summary>The source port or range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source port or range.",
        SerializedName = @"sourcePortRange",
        PossibleTypes = new [] { typeof(string) })]
        string SourcePortRange { get; set; }
        /// <summary>
        /// The source port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g.
        /// 100-400), or an asterisk (*)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g. 100-400), or an asterisk (*)",
        SerializedName = @"sourcePortRanges",
        PossibleTypes = new [] { typeof(string) })]
        string[] SourcePortRanges { get; set; }

    }
    /// Effective network security rules.
    internal partial interface IEffectiveNetworkSecurityRuleInternal

    {
        /// <summary>Whether network traffic is allowed or denied.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? Access { get; set; }
        /// <summary>The destination address prefix.</summary>
        string DestinationAddressPrefix { get; set; }
        /// <summary>
        /// The destination address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        string[] DestinationAddressPrefixes { get; set; }
        /// <summary>The destination port or range.</summary>
        string DestinationPortRange { get; set; }
        /// <summary>
        /// The destination port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator
        /// (e.g. 100-400), or an asterisk (*)
        /// </summary>
        string[] DestinationPortRanges { get; set; }
        /// <summary>The direction of the rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection? Direction { get; set; }
        /// <summary>Expanded destination address prefix.</summary>
        string[] ExpandedDestinationAddressPrefix { get; set; }
        /// <summary>The expanded source address prefix.</summary>
        string[] ExpandedSourceAddressPrefix { get; set; }
        /// <summary>The name of the security rule specified by the user (if created by the user).</summary>
        string Name { get; set; }
        /// <summary>The priority of the rule.</summary>
        int? Priority { get; set; }
        /// <summary>
        /// The network protocol this rule applies to. Possible values are: 'Tcp', 'Udp', and 'All'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol? Protocol { get; set; }
        /// <summary>The source address prefix.</summary>
        string SourceAddressPrefix { get; set; }
        /// <summary>
        /// The source address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer,
        /// Internet), System Tags, and the asterisk (*).
        /// </summary>
        string[] SourceAddressPrefixes { get; set; }
        /// <summary>The source port or range.</summary>
        string SourcePortRange { get; set; }
        /// <summary>
        /// The source port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g.
        /// 100-400), or an asterisk (*)
        /// </summary>
        string[] SourcePortRanges { get; set; }

    }
}