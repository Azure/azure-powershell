namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ApplicationGatewayAvailableWafRuleSets API service call.</summary>
    public partial class ApplicationGatewayAvailableWafRuleSetsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableWafRuleSetsResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayAvailableWafRuleSetsResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleSet[] _value;

        /// <summary>The list of application gateway rule sets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleSet[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayAvailableWafRuleSetsResult" /> instance.
        /// </summary>
        public ApplicationGatewayAvailableWafRuleSetsResult()
        {

        }
    }
    /// Response for ApplicationGatewayAvailableWafRuleSets API service call.
    public partial interface IApplicationGatewayAvailableWafRuleSetsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The list of application gateway rule sets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of application gateway rule sets.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleSet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleSet[] Value { get; set; }

    }
    /// Response for ApplicationGatewayAvailableWafRuleSets API service call.
    internal partial interface IApplicationGatewayAvailableWafRuleSetsResultInternal

    {
        /// <summary>The list of application gateway rule sets.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallRuleSet[] Value { get; set; }

    }
}