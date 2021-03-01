namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Security Rule data model for Network Security Groups.</summary>
    public partial class NsgSecurityRule :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal
    {

        /// <summary>Backing field for <see cref="Access" /> property.</summary>
        private string _access;

        /// <summary>
        /// Gets or sets whether network traffic is allowed or denied.
        /// Possible values are “Allow” and “Deny”.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Access { get => this._access; set => this._access = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Gets or sets a description for this rule. Restricted to 140 chars.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DestinationAddressPrefix" /> property.</summary>
        private string _destinationAddressPrefix;

        /// <summary>
        /// Gets or sets destination address prefix. CIDR or source IP range.
        /// A “*” can also be used to match all source IPs. Default tags such
        /// as ‘VirtualNetwork’, ‘AzureLoadBalancer’ and ‘Internet’ can also be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string DestinationAddressPrefix { get => this._destinationAddressPrefix; set => this._destinationAddressPrefix = value; }

        /// <summary>Backing field for <see cref="DestinationPortRange" /> property.</summary>
        private string _destinationPortRange;

        /// <summary>
        /// Gets or sets Destination Port or Range. Integer or range between
        /// 0 and 65535. A “*” can also be used to match all ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string DestinationPortRange { get => this._destinationPortRange; set => this._destinationPortRange = value; }

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private string _direction;

        /// <summary>
        /// Gets or sets the direction of the rule.InBound or Outbound. The
        /// direction specifies if rule will be evaluated on incoming or outgoing traffic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the Security rule name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private int? _priority;

        /// <summary>
        /// Gets or sets the priority of the rule. The value can be between
        /// 100 and 4096. The priority number must be unique for each rule in the collection.
        /// The lower the priority number, the higher the priority of the rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public int? Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private string _protocol;

        /// <summary>Gets or sets Network protocol this rule applies to. Can be Tcp, Udp or All(*).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="SourceAddressPrefix" /> property.</summary>
        private string _sourceAddressPrefix;

        /// <summary>
        /// Gets or sets source address prefix. CIDR or source IP range. A
        /// “*” can also be used to match all source IPs. Default tags such as ‘VirtualNetwork’,
        /// ‘AzureLoadBalancer’ and ‘Internet’ can also be used. If this is an ingress
        /// rule, specifies where network traffic originates from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourceAddressPrefix { get => this._sourceAddressPrefix; set => this._sourceAddressPrefix = value; }

        /// <summary>Backing field for <see cref="SourcePortRange" /> property.</summary>
        private string _sourcePortRange;

        /// <summary>
        /// Gets or sets Source Port or Range. Integer or range between 0 and
        /// 65535. A “*” can also be used to match all ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourcePortRange { get => this._sourcePortRange; set => this._sourcePortRange = value; }

        /// <summary>Creates an new <see cref="NsgSecurityRule" /> instance.</summary>
        public NsgSecurityRule()
        {

        }
    }
    /// Security Rule data model for Network Security Groups.
    public partial interface INsgSecurityRule :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets whether network traffic is allowed or denied.
        /// Possible values are “Allow” and “Deny”.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets whether network traffic is allowed or denied.
        Possible values are “Allow” and “Deny”.",
        SerializedName = @"access",
        PossibleTypes = new [] { typeof(string) })]
        string Access { get; set; }
        /// <summary>Gets or sets a description for this rule. Restricted to 140 chars.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a description for this rule. Restricted to 140 chars.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// Gets or sets destination address prefix. CIDR or source IP range.
        /// A “*” can also be used to match all source IPs. Default tags such
        /// as ‘VirtualNetwork’, ‘AzureLoadBalancer’ and ‘Internet’ can also be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets destination address prefix. CIDR or source IP range.
         A “*” can also be used to match all source IPs. Default tags such
        as ‘VirtualNetwork’, ‘AzureLoadBalancer’ and ‘Internet’ can also be used.",
        SerializedName = @"destinationAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationAddressPrefix { get; set; }
        /// <summary>
        /// Gets or sets Destination Port or Range. Integer or range between
        /// 0 and 65535. A “*” can also be used to match all ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Destination Port or Range. Integer or range between
        0 and 65535. A “*” can also be used to match all ports.",
        SerializedName = @"destinationPortRange",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationPortRange { get; set; }
        /// <summary>
        /// Gets or sets the direction of the rule.InBound or Outbound. The
        /// direction specifies if rule will be evaluated on incoming or outgoing traffic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the direction of the rule.InBound or Outbound. The
        direction specifies if rule will be evaluated on incoming or outgoing traffic.",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(string) })]
        string Direction { get; set; }
        /// <summary>Gets or sets the Security rule name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Security rule name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the priority of the rule. The value can be between
        /// 100 and 4096. The priority number must be unique for each rule in the collection.
        /// The lower the priority number, the higher the priority of the rule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the priority of the rule. The value can be between
        100 and 4096. The priority number must be unique for each rule in the collection.
        The lower the priority number, the higher the priority of the rule.",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(int) })]
        int? Priority { get; set; }
        /// <summary>Gets or sets Network protocol this rule applies to. Can be Tcp, Udp or All(*).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Network protocol this rule applies to. Can be Tcp, Udp or All(*).",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(string) })]
        string Protocol { get; set; }
        /// <summary>
        /// Gets or sets source address prefix. CIDR or source IP range. A
        /// “*” can also be used to match all source IPs. Default tags such as ‘VirtualNetwork’,
        /// ‘AzureLoadBalancer’ and ‘Internet’ can also be used. If this is an ingress
        /// rule, specifies where network traffic originates from.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets source address prefix. CIDR or source IP range. A
        “*” can also be used to match all source IPs.  Default tags such as ‘VirtualNetwork’,
        ‘AzureLoadBalancer’ and ‘Internet’ can also be used. If this is an ingress
        rule, specifies where network traffic originates from.",
        SerializedName = @"sourceAddressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string SourceAddressPrefix { get; set; }
        /// <summary>
        /// Gets or sets Source Port or Range. Integer or range between 0 and
        /// 65535. A “*” can also be used to match all ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Source Port or Range. Integer or range between 0 and
        65535. A “*” can also be used to match all ports.",
        SerializedName = @"sourcePortRange",
        PossibleTypes = new [] { typeof(string) })]
        string SourcePortRange { get; set; }

    }
    /// Security Rule data model for Network Security Groups.
    internal partial interface INsgSecurityRuleInternal

    {
        /// <summary>
        /// Gets or sets whether network traffic is allowed or denied.
        /// Possible values are “Allow” and “Deny”.
        /// </summary>
        string Access { get; set; }
        /// <summary>Gets or sets a description for this rule. Restricted to 140 chars.</summary>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets destination address prefix. CIDR or source IP range.
        /// A “*” can also be used to match all source IPs. Default tags such
        /// as ‘VirtualNetwork’, ‘AzureLoadBalancer’ and ‘Internet’ can also be used.
        /// </summary>
        string DestinationAddressPrefix { get; set; }
        /// <summary>
        /// Gets or sets Destination Port or Range. Integer or range between
        /// 0 and 65535. A “*” can also be used to match all ports.
        /// </summary>
        string DestinationPortRange { get; set; }
        /// <summary>
        /// Gets or sets the direction of the rule.InBound or Outbound. The
        /// direction specifies if rule will be evaluated on incoming or outgoing traffic.
        /// </summary>
        string Direction { get; set; }
        /// <summary>Gets or sets the Security rule name.</summary>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the priority of the rule. The value can be between
        /// 100 and 4096. The priority number must be unique for each rule in the collection.
        /// The lower the priority number, the higher the priority of the rule.
        /// </summary>
        int? Priority { get; set; }
        /// <summary>Gets or sets Network protocol this rule applies to. Can be Tcp, Udp or All(*).</summary>
        string Protocol { get; set; }
        /// <summary>
        /// Gets or sets source address prefix. CIDR or source IP range. A
        /// “*” can also be used to match all source IPs. Default tags such as ‘VirtualNetwork’,
        /// ‘AzureLoadBalancer’ and ‘Internet’ can also be used. If this is an ingress
        /// rule, specifies where network traffic originates from.
        /// </summary>
        string SourceAddressPrefix { get; set; }
        /// <summary>
        /// Gets or sets Source Port or Range. Integer or range between 0 and
        /// 65535. A “*” can also be used to match all ports.
        /// </summary>
        string SourcePortRange { get; set; }

    }
}