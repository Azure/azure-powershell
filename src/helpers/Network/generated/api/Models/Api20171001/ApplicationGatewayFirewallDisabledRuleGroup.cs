namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Allows to disable rules within a rule group or an entire rule group.</summary>
    public partial class ApplicationGatewayFirewallDisabledRuleGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroupInternal
    {

        /// <summary>Backing field for <see cref="Rule" /> property.</summary>
        private int[] _rule;

        /// <summary>
        /// The list of rules that will be disabled. If null, all rules of the rule group will be disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int[] Rule { get => this._rule; set => this._rule = value; }

        /// <summary>Backing field for <see cref="RuleGroupName" /> property.</summary>
        private string _ruleGroupName;

        /// <summary>The name of the rule group that will be disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleGroupName { get => this._ruleGroupName; set => this._ruleGroupName = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayFirewallDisabledRuleGroup" /> instance.
        /// </summary>
        public ApplicationGatewayFirewallDisabledRuleGroup()
        {

        }
    }
    /// Allows to disable rules within a rule group or an entire rule group.
    public partial interface IApplicationGatewayFirewallDisabledRuleGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The list of rules that will be disabled. If null, all rules of the rule group will be disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of rules that will be disabled. If null, all rules of the rule group will be disabled.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(int) })]
        int[] Rule { get; set; }
        /// <summary>The name of the rule group that will be disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the rule group that will be disabled.",
        SerializedName = @"ruleGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleGroupName { get; set; }

    }
    /// Allows to disable rules within a rule group or an entire rule group.
    internal partial interface IApplicationGatewayFirewallDisabledRuleGroupInternal

    {
        /// <summary>
        /// The list of rules that will be disabled. If null, all rules of the rule group will be disabled.
        /// </summary>
        int[] Rule { get; set; }
        /// <summary>The name of the rule group that will be disabled.</summary>
        string RuleGroupName { get; set; }

    }
}