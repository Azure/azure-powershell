namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Allow to exclude some variable satisfy the condition for the WAF check</summary>
    public partial class ApplicationGatewayFirewallExclusion :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusionInternal
    {

        /// <summary>Backing field for <see cref="MatchVariable" /> property.</summary>
        private string _matchVariable;

        /// <summary>The variable to be excluded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MatchVariable { get => this._matchVariable; set => this._matchVariable = value; }

        /// <summary>Backing field for <see cref="Selector" /> property.</summary>
        private string _selector;

        /// <summary>
        /// When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Selector { get => this._selector; set => this._selector = value; }

        /// <summary>Backing field for <see cref="SelectorMatchOperator" /> property.</summary>
        private string _selectorMatchOperator;

        /// <summary>
        /// When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion
        /// applies to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SelectorMatchOperator { get => this._selectorMatchOperator; set => this._selectorMatchOperator = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayFirewallExclusion" /> instance.</summary>
        public ApplicationGatewayFirewallExclusion()
        {

        }
    }
    /// Allow to exclude some variable satisfy the condition for the WAF check
    public partial interface IApplicationGatewayFirewallExclusion :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The variable to be excluded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The variable to be excluded.",
        SerializedName = @"matchVariable",
        PossibleTypes = new [] { typeof(string) })]
        string MatchVariable { get; set; }
        /// <summary>
        /// When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.",
        SerializedName = @"selector",
        PossibleTypes = new [] { typeof(string) })]
        string Selector { get; set; }
        /// <summary>
        /// When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion
        /// applies to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.",
        SerializedName = @"selectorMatchOperator",
        PossibleTypes = new [] { typeof(string) })]
        string SelectorMatchOperator { get; set; }

    }
    /// Allow to exclude some variable satisfy the condition for the WAF check
    internal partial interface IApplicationGatewayFirewallExclusionInternal

    {
        /// <summary>The variable to be excluded.</summary>
        string MatchVariable { get; set; }
        /// <summary>
        /// When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
        /// </summary>
        string Selector { get; set; }
        /// <summary>
        /// When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion
        /// applies to.
        /// </summary>
        string SelectorMatchOperator { get; set; }

    }
}