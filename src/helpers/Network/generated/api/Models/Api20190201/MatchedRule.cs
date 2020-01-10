namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Matched rule.</summary>
    public partial class MatchedRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRuleInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string _action;

        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        /// <summary>Name of the matched network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Creates an new <see cref="MatchedRule" /> instance.</summary>
        public MatchedRule()
        {

        }
    }
    /// Matched rule.
    public partial interface IMatchedRule :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string Action { get; set; }
        /// <summary>Name of the matched network security rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the matched network security rule.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }

    }
    /// Matched rule.
    internal partial interface IMatchedRuleInternal

    {
        /// <summary>
        /// The network traffic is allowed or denied. Possible values are 'Allow' and 'Deny'.
        /// </summary>
        string Action { get; set; }
        /// <summary>Name of the matched network security rule.</summary>
        string RuleName { get; set; }

    }
}