namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of an application rule.</summary>
    public partial class AzureFirewallApplicationRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="FqdnTag" /> property.</summary>
        private string[] _fqdnTag;

        /// <summary>List of FQDN Tags for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] FqdnTag { get => this._fqdnTag; set => this._fqdnTag = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the application rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol[] _protocol;

        /// <summary>Array of ApplicationRuleProtocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol[] Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="SourceAddress" /> property.</summary>
        private string[] _sourceAddress;

        /// <summary>List of source IP addresses for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] SourceAddress { get => this._sourceAddress; set => this._sourceAddress = value; }

        /// <summary>Backing field for <see cref="TargetFqdn" /> property.</summary>
        private string[] _targetFqdn;

        /// <summary>List of FQDNs for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] TargetFqdn { get => this._targetFqdn; set => this._targetFqdn = value; }

        /// <summary>Creates an new <see cref="AzureFirewallApplicationRule" /> instance.</summary>
        public AzureFirewallApplicationRule()
        {

        }
    }
    /// Properties of an application rule.
    public partial interface IAzureFirewallApplicationRule :
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
        /// <summary>List of FQDN Tags for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of FQDN Tags for this rule.",
        SerializedName = @"fqdnTags",
        PossibleTypes = new [] { typeof(string) })]
        string[] FqdnTag { get; set; }
        /// <summary>Name of the application rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the application rule.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Array of ApplicationRuleProtocols.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of ApplicationRuleProtocols.",
        SerializedName = @"protocols",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol[] Protocol { get; set; }
        /// <summary>List of source IP addresses for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of source IP addresses for this rule.",
        SerializedName = @"sourceAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] SourceAddress { get; set; }
        /// <summary>List of FQDNs for this rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of FQDNs for this rule.",
        SerializedName = @"targetFqdns",
        PossibleTypes = new [] { typeof(string) })]
        string[] TargetFqdn { get; set; }

    }
    /// Properties of an application rule.
    internal partial interface IAzureFirewallApplicationRuleInternal

    {
        /// <summary>Description of the rule.</summary>
        string Description { get; set; }
        /// <summary>List of FQDN Tags for this rule.</summary>
        string[] FqdnTag { get; set; }
        /// <summary>Name of the application rule.</summary>
        string Name { get; set; }
        /// <summary>Array of ApplicationRuleProtocols.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol[] Protocol { get; set; }
        /// <summary>List of source IP addresses for this rule.</summary>
        string[] SourceAddress { get; set; }
        /// <summary>List of FQDNs for this rule.</summary>
        string[] TargetFqdn { get; set; }

    }
}