namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>A virtual network rule.</summary>
    public partial class VirtualNetworkRule :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRule,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ProxyResource();

        /// <summary>Resource ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Id; }

        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public bool? IgnoreMissingVnetServiceEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).IgnoreMissingVnetServiceEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).IgnoreMissingVnetServiceEndpoint = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleProperties Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.VirtualNetworkRuleProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).State = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleProperties _property;

        /// <summary>Resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.VirtualNetworkRuleProperties()); set => this._property = value; }

        /// <summary>Virtual Network Rule State</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).State; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal)__proxyResource).Type; }

        /// <summary>The ARM resource id of the virtual network subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public string VirtualNetworkSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).VirtualNetworkSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRulePropertiesInternal)Property).VirtualNetworkSubnetId = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }

        /// <summary>Creates an new <see cref="VirtualNetworkRule" /> instance.</summary>
        public VirtualNetworkRule()
        {

        }
    }
    /// A virtual network rule.
    public partial interface IVirtualNetworkRule :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResource
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
    /// A virtual network rule.
    internal partial interface IVirtualNetworkRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IProxyResourceInternal
    {
        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
        /// </summary>
        bool? IgnoreMissingVnetServiceEndpoint { get; set; }
        /// <summary>Resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IVirtualNetworkRuleProperties Property { get; set; }
        /// <summary>Virtual Network Rule State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.VirtualNetworkRuleState? State { get; set; }
        /// <summary>The ARM resource id of the virtual network subnet.</summary>
        string VirtualNetworkSubnetId { get; set; }

    }
}