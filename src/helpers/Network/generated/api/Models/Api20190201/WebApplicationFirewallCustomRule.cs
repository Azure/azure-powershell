namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Defines contents of a web application rule</summary>
    public partial class WebApplicationFirewallCustomRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRuleInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction _action;

        /// <summary>Type of Actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>Backing field for <see cref="MatchCondition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition[] _matchCondition;

        /// <summary>List of match conditions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition[] MatchCondition { get => this._matchCondition; set => this._matchCondition = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRuleInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a policy. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private int _priority;

        /// <summary>
        /// Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher value
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="RuleType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType _ruleType;

        /// <summary>Describes type of rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType RuleType { get => this._ruleType; set => this._ruleType = value; }

        /// <summary>Creates an new <see cref="WebApplicationFirewallCustomRule" /> instance.</summary>
        public WebApplicationFirewallCustomRule()
        {

        }
    }
    /// Defines contents of a web application rule
    public partial interface IWebApplicationFirewallCustomRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Type of Actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of Actions",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Action { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>List of match conditions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of match conditions",
        SerializedName = @"matchConditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition[] MatchCondition { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a policy. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets name of the resource that is unique within a policy. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher value
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher value",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(int) })]
        int Priority { get; set; }
        /// <summary>Describes type of rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Describes type of rule",
        SerializedName = @"ruleType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType RuleType { get; set; }

    }
    /// Defines contents of a web application rule
    internal partial interface IWebApplicationFirewallCustomRuleInternal

    {
        /// <summary>Type of Actions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallAction Action { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>List of match conditions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition[] MatchCondition { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a policy. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Describes priority of the rule. Rules with a lower value will be evaluated before rules with a higher value
        /// </summary>
        int Priority { get; set; }
        /// <summary>Describes type of rule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallRuleType RuleType { get; set; }

    }
}