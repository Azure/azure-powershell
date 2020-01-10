namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the web application firewall rule set.</summary>
    public partial class ApplicationGatewayFirewallRuleSetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RuleGroup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[] _ruleGroup;

        /// <summary>The rule groups of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[] RuleGroup { get => this._ruleGroup; set => this._ruleGroup = value; }

        /// <summary>Backing field for <see cref="RuleSetType" /> property.</summary>
        private string _ruleSetType;

        /// <summary>The type of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleSetType { get => this._ruleSetType; set => this._ruleSetType = value; }

        /// <summary>Backing field for <see cref="RuleSetVersion" /> property.</summary>
        private string _ruleSetVersion;

        /// <summary>The version of the web application firewall rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleSetVersion { get => this._ruleSetVersion; set => this._ruleSetVersion = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayFirewallRuleSetPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayFirewallRuleSetPropertiesFormat()
        {

        }
    }
    /// Properties of the web application firewall rule set.
    public partial interface IApplicationGatewayFirewallRuleSetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The provisioning state of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the web application firewall rule set.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The rule groups of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The rule groups of the web application firewall rule set.",
        SerializedName = @"ruleGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[] RuleGroup { get; set; }
        /// <summary>The type of the web application firewall rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the web application firewall rule set.",
        SerializedName = @"ruleSetType",
        PossibleTypes = new [] { typeof(string) })]
        string RuleSetType { get; set; }
        /// <summary>The version of the web application firewall rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the web application firewall rule set type.",
        SerializedName = @"ruleSetVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuleSetVersion { get; set; }

    }
    /// Properties of the web application firewall rule set.
    internal partial interface IApplicationGatewayFirewallRuleSetPropertiesFormatInternal

    {
        /// <summary>The provisioning state of the web application firewall rule set.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The rule groups of the web application firewall rule set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[] RuleGroup { get; set; }
        /// <summary>The type of the web application firewall rule set.</summary>
        string RuleSetType { get; set; }
        /// <summary>The version of the web application firewall rule set type.</summary>
        string RuleSetVersion { get; set; }

    }
}