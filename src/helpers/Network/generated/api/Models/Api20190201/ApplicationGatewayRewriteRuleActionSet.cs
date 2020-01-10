namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Set of actions in the Rewrite Rule in Application Gateway.</summary>
    public partial class ApplicationGatewayRewriteRuleActionSet :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSet,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleActionSetInternal
    {

        /// <summary>Backing field for <see cref="RequestHeaderConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] _requestHeaderConfiguration;

        /// <summary>Request Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] RequestHeaderConfiguration { get => this._requestHeaderConfiguration; set => this._requestHeaderConfiguration = value; }

        /// <summary>Backing field for <see cref="ResponseHeaderConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] _responseHeaderConfiguration;

        /// <summary>Response Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ResponseHeaderConfiguration { get => this._responseHeaderConfiguration; set => this._responseHeaderConfiguration = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayRewriteRuleActionSet" /> instance.</summary>
        public ApplicationGatewayRewriteRuleActionSet()
        {

        }
    }
    /// Set of actions in the Rewrite Rule in Application Gateway.
    public partial interface IApplicationGatewayRewriteRuleActionSet :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Request Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Header Actions in the Action Set",
        SerializedName = @"requestHeaderConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] RequestHeaderConfiguration { get; set; }
        /// <summary>Response Header Actions in the Action Set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Response Header Actions in the Action Set",
        SerializedName = @"responseHeaderConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ResponseHeaderConfiguration { get; set; }

    }
    /// Set of actions in the Rewrite Rule in Application Gateway.
    internal partial interface IApplicationGatewayRewriteRuleActionSetInternal

    {
        /// <summary>Request Header Actions in the Action Set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] RequestHeaderConfiguration { get; set; }
        /// <summary>Response Header Actions in the Action Set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration[] ResponseHeaderConfiguration { get; set; }

    }
}