namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Results of network security group evaluation.</summary>
    public partial class EvaluatedNetworkSecurityGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal
    {

        /// <summary>Backing field for <see cref="AppliedTo" /> property.</summary>
        private string _appliedTo;

        /// <summary>Resource ID of nic or subnet to which network security group is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AppliedTo { get => this._appliedTo; set => this._appliedTo = value; }

        /// <summary>Backing field for <see cref="MatchedRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule _matchedRule;

        /// <summary>Matched network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule MatchedRule { get => (this._matchedRule = this._matchedRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchedRule()); set => this._matchedRule = value; }

        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string MatchedRuleAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRuleInternal)MatchedRule).Action; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRuleInternal)MatchedRule).Action = value; }

        /// <summary>Name of the matched network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string MatchedRuleName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRuleInternal)MatchedRule).RuleName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRuleInternal)MatchedRule).RuleName = value; }

        /// <summary>Internal Acessors for MatchedRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal.MatchedRule { get => (this._matchedRule = this._matchedRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchedRule()); set { {_matchedRule = value;} } }

        /// <summary>Internal Acessors for RulesEvaluationResult</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal.RulesEvaluationResult { get => this._rulesEvaluationResult; set { {_rulesEvaluationResult = value;} } }

        /// <summary>Backing field for <see cref="NsgId" /> property.</summary>
        private string _nsgId;

        /// <summary>Network security group ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NsgId { get => this._nsgId; set => this._nsgId = value; }

        /// <summary>Backing field for <see cref="RulesEvaluationResult" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[] _rulesEvaluationResult;

        /// <summary>List of network security rules evaluation results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[] RulesEvaluationResult { get => this._rulesEvaluationResult; }

        /// <summary>Creates an new <see cref="EvaluatedNetworkSecurityGroup" /> instance.</summary>
        public EvaluatedNetworkSecurityGroup()
        {

        }
    }
    /// Results of network security group evaluation.
    public partial interface IEvaluatedNetworkSecurityGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID of nic or subnet to which network security group is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of nic or subnet to which network security group is applied.",
        SerializedName = @"appliedTo",
        PossibleTypes = new [] { typeof(string) })]
        string AppliedTo { get; set; }
        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string MatchedRuleAction { get; set; }
        /// <summary>Name of the matched network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the matched network security rule.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string MatchedRuleName { get; set; }
        /// <summary>Network security group ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network security group ID.",
        SerializedName = @"networkSecurityGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string NsgId { get; set; }
        /// <summary>List of network security rules evaluation results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of network security rules evaluation results.",
        SerializedName = @"rulesEvaluationResult",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[] RulesEvaluationResult { get;  }

    }
    /// Results of network security group evaluation.
    internal partial interface IEvaluatedNetworkSecurityGroupInternal

    {
        /// <summary>Resource ID of nic or subnet to which network security group is applied.</summary>
        string AppliedTo { get; set; }
        /// <summary>Matched network security rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule MatchedRule { get; set; }
        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        string MatchedRuleAction { get; set; }
        /// <summary>Name of the matched network security rule.</summary>
        string MatchedRuleName { get; set; }
        /// <summary>Network security group ID.</summary>
        string NsgId { get; set; }
        /// <summary>List of network security rules evaluation results.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[] RulesEvaluationResult { get; set; }

    }
}