namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of rewrite rule set of the application gateway.</summary>
    public partial class ApplicationGatewayRewriteRuleSetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSetPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSetPropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSetPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the rewrite rule set resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RewriteRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule[] _rewriteRule;

        /// <summary>Rewrite rules in the rewrite rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule[] RewriteRule { get => this._rewriteRule; set => this._rewriteRule = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayRewriteRuleSetPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayRewriteRuleSetPropertiesFormat()
        {

        }
    }
    /// Properties of rewrite rule set of the application gateway.
    public partial interface IApplicationGatewayRewriteRuleSetPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Provisioning state of the rewrite rule set resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the rewrite rule set resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Rewrite rules in the rewrite rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rewrite rules in the rewrite rule set.",
        SerializedName = @"rewriteRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule[] RewriteRule { get; set; }

    }
    /// Properties of rewrite rule set of the application gateway.
    internal partial interface IApplicationGatewayRewriteRuleSetPropertiesFormatInternal

    {
        /// <summary>
        /// Provisioning state of the rewrite rule set resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Rewrite rules in the rewrite rule set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRule[] RewriteRule { get; set; }

    }
}