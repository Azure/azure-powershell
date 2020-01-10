namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A web application firewall rule group.</summary>
    public partial class ApplicationGatewayFirewallRuleGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleGroupInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Rule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule[] _rule;

        /// <summary>The rules of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule[] Rule { get => this._rule; set => this._rule = value; }

        /// <summary>Backing field for <see cref="RuleGroupName" /> property.</summary>
        private string _ruleGroupName;

        /// <summary>The name of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleGroupName { get => this._ruleGroupName; set => this._ruleGroupName = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayFirewallRuleGroup" /> instance.</summary>
        public ApplicationGatewayFirewallRuleGroup()
        {

        }
    }
    /// A web application firewall rule group.
    public partial interface IApplicationGatewayFirewallRuleGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The description of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the web application firewall rule group.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The rules of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The rules of the web application firewall rule group.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule[] Rule { get; set; }
        /// <summary>The name of the web application firewall rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the web application firewall rule group.",
        SerializedName = @"ruleGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleGroupName { get; set; }

    }
    /// A web application firewall rule group.
    internal partial interface IApplicationGatewayFirewallRuleGroupInternal

    {
        /// <summary>The description of the web application firewall rule group.</summary>
        string Description { get; set; }
        /// <summary>The rules of the web application firewall rule group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule[] Rule { get; set; }
        /// <summary>The name of the web application firewall rule group.</summary>
        string RuleGroupName { get; set; }

    }
}