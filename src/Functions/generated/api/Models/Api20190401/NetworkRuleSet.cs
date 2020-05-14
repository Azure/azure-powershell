namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Network rule set</summary>
    public partial class NetworkRuleSet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal
    {

        /// <summary>Backing field for <see cref="Bypass" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? _bypass;

        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? Bypass { get => this._bypass; set => this._bypass = value; }

        /// <summary>Backing field for <see cref="DefaultAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction _defaultAction;

        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction DefaultAction { get => this._defaultAction; set => this._defaultAction = value; }

        /// <summary>Backing field for <see cref="IPRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] _iPRule;

        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] IPRule { get => this._iPRule; set => this._iPRule = value; }

        /// <summary>Backing field for <see cref="VirtualNetworkRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] _virtualNetworkRule;

        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] VirtualNetworkRule { get => this._virtualNetworkRule; set => this._virtualNetworkRule = value; }

        /// <summary>Creates an new <see cref="NetworkRuleSet" /> instance.</summary>
        public NetworkRuleSet()
        {

        }
    }
    /// Network rule set
    public partial interface INetworkRuleSet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, ""Logging, Metrics""), or None to bypass none of those traffics.",
        SerializedName = @"bypass",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? Bypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the default action of allow or deny when no other rules match.",
        SerializedName = @"defaultAction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction DefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the IP ACL rules",
        SerializedName = @"ipRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] IPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the virtual network rules",
        SerializedName = @"virtualNetworkRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] VirtualNetworkRule { get; set; }

    }
    /// Network rule set
    internal partial interface INetworkRuleSetInternal

    {
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? Bypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction DefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] IPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] VirtualNetworkRule { get; set; }

    }
}