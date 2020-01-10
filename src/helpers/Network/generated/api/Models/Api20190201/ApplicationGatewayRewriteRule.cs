namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Rewrite rule of an application gateway.</summary>
    public partial class ApplicationGatewayRewriteRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleInternal
    {

        /// <summary>Backing field for <see cref="ActionSet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSet _actionSet;

        /// <summary>Set of actions to be done as part of the rewrite Rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSet ActionSet { get => (this._actionSet = this._actionSet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRewriteRuleActionSet()); set => this._actionSet = value; }

        /// <summary>Request Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetRequestHeaderConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSetInternal)ActionSet).RequestHeaderConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSetInternal)ActionSet).RequestHeaderConfiguration = value; }

        /// <summary>Response Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetResponseHeaderConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSetInternal)ActionSet).ResponseHeaderConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSetInternal)ActionSet).ResponseHeaderConfiguration = value; }

        /// <summary>Backing field for <see cref="Condition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition[] _condition;

        /// <summary>Conditions based on which the action set execution will be evaluated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition[] Condition { get => this._condition; set => this._condition = value; }

        /// <summary>Internal Acessors for ActionSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSet Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleInternal.ActionSet { get => (this._actionSet = this._actionSet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayRewriteRuleActionSet()); set { {_actionSet = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the rewrite rule that is unique within an Application Gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="RuleSequence" /> property.</summary>
        private int? _ruleSequence;

        /// <summary>
        /// Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? RuleSequence { get => this._ruleSequence; set => this._ruleSequence = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayRewriteRule" /> instance.</summary>
        public ApplicationGatewayRewriteRule()
        {

        }
    }
    /// Rewrite rule of an application gateway.
    public partial interface IApplicationGatewayRewriteRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Request Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Header Actions in the Action Set",
        SerializedName = @"requestHeaderConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetRequestHeaderConfiguration { get; set; }
        /// <summary>Response Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Response Header Actions in the Action Set",
        SerializedName = @"responseHeaderConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetResponseHeaderConfiguration { get; set; }
        /// <summary>Conditions based on which the action set execution will be evaluated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Conditions based on which the action set execution will be evaluated.",
        SerializedName = @"conditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition[] Condition { get; set; }
        /// <summary>Name of the rewrite rule that is unique within an Application Gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the rewrite rule that is unique within an Application Gateway.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.",
        SerializedName = @"ruleSequence",
        PossibleTypes = new [] { typeof(int) })]
        int? RuleSequence { get; set; }

    }
    /// Rewrite rule of an application gateway.
    internal partial interface IApplicationGatewayRewriteRuleInternal

    {
        /// <summary>Set of actions to be done as part of the rewrite Rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSet ActionSet { get; set; }
        /// <summary>Request Header Actions in the Action Set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetRequestHeaderConfiguration { get; set; }
        /// <summary>Response Header Actions in the Action Set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ActionSetResponseHeaderConfiguration { get; set; }
        /// <summary>Conditions based on which the action set execution will be evaluated.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition[] Condition { get; set; }
        /// <summary>Name of the rewrite rule that is unique within an Application Gateway.</summary>
        string Name { get; set; }
        /// <summary>
        /// Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.
        /// </summary>
        int? RuleSequence { get; set; }

    }
}