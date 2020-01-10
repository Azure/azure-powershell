namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A web application firewall rule.</summary>
    public partial class ApplicationGatewayFirewallRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the web application firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="RuleId" /> property.</summary>
        private int _ruleId;

        /// <summary>The identifier of the web application firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int RuleId { get => this._ruleId; set => this._ruleId = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayFirewallRule" /> instance.</summary>
        public ApplicationGatewayFirewallRule()
        {

        }
    }
    /// A web application firewall rule.
    public partial interface IApplicationGatewayFirewallRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The description of the web application firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the web application firewall rule.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The identifier of the web application firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The identifier of the web application firewall rule.",
        SerializedName = @"ruleId",
        PossibleTypes = new [] { typeof(int) })]
        int RuleId { get; set; }

    }
    /// A web application firewall rule.
    internal partial interface IApplicationGatewayFirewallRuleInternal

    {
        /// <summary>The description of the web application firewall rule.</summary>
        string Description { get; set; }
        /// <summary>The identifier of the web application firewall rule.</summary>
        int RuleId { get; set; }

    }
}