namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the Azure Firewall.</summary>
    public partial class AzureFirewallPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="ApplicationRuleCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[] _applicationRuleCollection;

        /// <summary>Collection of application rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[] ApplicationRuleCollection { get => this._applicationRuleCollection; set => this._applicationRuleCollection = value; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[] _iPConfiguration;

        /// <summary>IP configuration of the Azure Firewall resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Backing field for <see cref="NatRuleCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[] _natRuleCollection;

        /// <summary>Collection of NAT rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[] NatRuleCollection { get => this._natRuleCollection; set => this._natRuleCollection = value; }

        /// <summary>Backing field for <see cref="NetworkRuleCollection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[] _networkRuleCollection;

        /// <summary>Collection of network rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[] NetworkRuleCollection { get => this._networkRuleCollection; set => this._networkRuleCollection = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="ThreatIntelMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode? _threatIntelMode;

        /// <summary>The operation mode for Threat Intelligence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode? ThreatIntelMode { get => this._threatIntelMode; set => this._threatIntelMode = value; }

        /// <summary>Creates an new <see cref="AzureFirewallPropertiesFormat" /> instance.</summary>
        public AzureFirewallPropertiesFormat()
        {

        }
    }
    /// Properties of the Azure Firewall.
    public partial interface IAzureFirewallPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Collection of application rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of application rule collections used by Azure Firewall.",
        SerializedName = @"applicationRuleCollections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[] ApplicationRuleCollection { get; set; }
        /// <summary>IP configuration of the Azure Firewall resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP configuration of the Azure Firewall resource.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Collection of NAT rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of NAT rule collections used by Azure Firewall.",
        SerializedName = @"natRuleCollections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[] NatRuleCollection { get; set; }
        /// <summary>Collection of network rule collections used by Azure Firewall.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of network rule collections used by Azure Firewall.",
        SerializedName = @"networkRuleCollections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[] NetworkRuleCollection { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The operation mode for Threat Intelligence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The operation mode for Threat Intelligence.",
        SerializedName = @"threatIntelMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode? ThreatIntelMode { get; set; }

    }
    /// Properties of the Azure Firewall.
    internal partial interface IAzureFirewallPropertiesFormatInternal

    {
        /// <summary>Collection of application rule collections used by Azure Firewall.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[] ApplicationRuleCollection { get; set; }
        /// <summary>IP configuration of the Azure Firewall resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Collection of NAT rule collections used by Azure Firewall.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[] NatRuleCollection { get; set; }
        /// <summary>Collection of network rule collections used by Azure Firewall.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[] NetworkRuleCollection { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The operation mode for Threat Intelligence.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode? ThreatIntelMode { get; set; }

    }
}