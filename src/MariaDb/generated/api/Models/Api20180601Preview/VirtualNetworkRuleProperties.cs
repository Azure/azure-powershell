namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Properties of a virtual network rule.</summary>
    public partial class VirtualNetworkRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal
    {

        /// <summary>Backing field for <see cref="IgnoreMissingVnetServiceEndpoint" /> property.</summary>
        private bool? _ignoreMissingVnetServiceEndpoint;

        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public bool? IgnoreMissingVnetServiceEndpoint { get => this._ignoreMissingVnetServiceEndpoint; set => this._ignoreMissingVnetServiceEndpoint = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? _state;

        /// <summary>Virtual Network Rule State</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? State { get => this._state; }

        /// <summary>Backing field for <see cref="VirtualNetworkSubnetId" /> property.</summary>
        private string _virtualNetworkSubnetId;

        /// <summary>The ARM resource id of the virtual network subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string VirtualNetworkSubnetId { get => this._virtualNetworkSubnetId; set => this._virtualNetworkSubnetId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkRuleProperties" /> instance.</summary>
        public VirtualNetworkRuleProperties()
        {

        }
    }
    /// Properties of a virtual network rule.
    public partial interface IVirtualNetworkRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Create firewall rule before the virtual network has vnet service endpoint enabled.",
        SerializedName = @"ignoreMissingVnetServiceEndpoint",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreMissingVnetServiceEndpoint { get; set; }
        /// <summary>Virtual Network Rule State</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual Network Rule State",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? State { get;  }
        /// <summary>The ARM resource id of the virtual network subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ARM resource id of the virtual network subnet.",
        SerializedName = @"virtualNetworkSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkSubnetId { get; set; }

    }
    /// Properties of a virtual network rule.
    internal partial interface IVirtualNetworkRulePropertiesInternal

    {
        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
        /// </summary>
        bool? IgnoreMissingVnetServiceEndpoint { get; set; }
        /// <summary>Virtual Network Rule State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? State { get; set; }
        /// <summary>The ARM resource id of the virtual network subnet.</summary>
        string VirtualNetworkSubnetId { get; set; }

    }
}