namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Set of conditions in the Rewrite Rule in Application Gateway.</summary>
    public partial class ApplicationGatewayRewriteRuleCondition :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleCondition,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleConditionInternal
    {

        /// <summary>Backing field for <see cref="IgnoreCase" /> property.</summary>
        private bool? _ignoreCase;

        /// <summary>
        /// Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IgnoreCase { get => this._ignoreCase; set => this._ignoreCase = value; }

        /// <summary>Backing field for <see cref="Negate" /> property.</summary>
        private bool? _negate;

        /// <summary>
        /// Setting this value as truth will force to check the negation of the condition given by the user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? Negate { get => this._negate; set => this._negate = value; }

        /// <summary>Backing field for <see cref="Pattern" /> property.</summary>
        private string _pattern;

        /// <summary>
        /// The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Pattern { get => this._pattern; set => this._pattern = value; }

        /// <summary>Backing field for <see cref="Variable" /> property.</summary>
        private string _variable;

        /// <summary>The condition parameter of the RewriteRuleCondition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Variable { get => this._variable; set => this._variable = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayRewriteRuleCondition" /> instance.</summary>
        public ApplicationGatewayRewriteRuleCondition()
        {

        }
    }
    /// Set of conditions in the Rewrite Rule in Application Gateway.
    public partial interface IApplicationGatewayRewriteRuleCondition :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.",
        SerializedName = @"ignoreCase",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreCase { get; set; }
        /// <summary>
        /// Setting this value as truth will force to check the negation of the condition given by the user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Setting this value as truth will force to check the negation of the condition given by the user.",
        SerializedName = @"negate",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Negate { get; set; }
        /// <summary>
        /// The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition",
        SerializedName = @"pattern",
        PossibleTypes = new [] { typeof(string) })]
        string Pattern { get; set; }
        /// <summary>The condition parameter of the RewriteRuleCondition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The condition parameter of the RewriteRuleCondition.",
        SerializedName = @"variable",
        PossibleTypes = new [] { typeof(string) })]
        string Variable { get; set; }

    }
    /// Set of conditions in the Rewrite Rule in Application Gateway.
    internal partial interface IApplicationGatewayRewriteRuleConditionInternal

    {
        /// <summary>
        /// Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.
        /// </summary>
        bool? IgnoreCase { get; set; }
        /// <summary>
        /// Setting this value as truth will force to check the negation of the condition given by the user.
        /// </summary>
        bool? Negate { get; set; }
        /// <summary>
        /// The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition
        /// </summary>
        string Pattern { get; set; }
        /// <summary>The condition parameter of the RewriteRuleCondition.</summary>
        string Variable { get; set; }

    }
}