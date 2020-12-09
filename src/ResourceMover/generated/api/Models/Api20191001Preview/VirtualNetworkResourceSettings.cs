namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the virtual network resource settings.</summary>
    public partial class VirtualNetworkResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IVirtualNetworkResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IVirtualNetworkResourceSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ResourceSettings();

        /// <summary>Backing field for <see cref="AddressSpace" /> property.</summary>
        private string[] _addressSpace;

        /// <summary>Gets or sets the address prefixes for the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string[] AddressSpace { get => this._addressSpace; set => this._addressSpace = value; }

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string[] _dnsServer;

        /// <summary>
        /// Gets or sets DHCPOptions that contains an array of DNS servers available to VMs
        /// deployed in the virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string[] DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Backing field for <see cref="EnableDdosProtection" /> property.</summary>
        private bool? _enableDdosProtection;

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets whether the
        /// DDOS protection should be switched on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public bool? EnableDdosProtection { get => this._enableDdosProtection; set => this._enableDdosProtection = value; }

        /// <summary>
        /// The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).ResourceType = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings[] _subnet;

        /// <summary>Gets or sets List of subnets in a VirtualNetwork.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings[] Subnet { get => this._subnet; set => this._subnet = value; }

        /// <summary>Gets or sets the target Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).TargetResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).TargetResourceName = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resourceSettings), __resourceSettings);
            await eventListener.AssertObjectIsValid(nameof(__resourceSettings), __resourceSettings);
        }

        /// <summary>Creates an new <see cref="VirtualNetworkResourceSettings" /> instance.</summary>
        public VirtualNetworkResourceSettings()
        {

        }
    }
    /// Defines the virtual network resource settings.
    public partial interface IVirtualNetworkResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings
    {
        /// <summary>Gets or sets the address prefixes for the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the address prefixes for the virtual network.",
        SerializedName = @"addressSpace",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressSpace { get; set; }
        /// <summary>
        /// Gets or sets DHCPOptions that contains an array of DNS servers available to VMs
        /// deployed in the virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets DHCPOptions that contains an array of DNS servers available to VMs
        deployed in the virtual network.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets whether the
        /// DDOS protection should be switched on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether gets or sets whether the
        DDOS protection should be switched on.",
        SerializedName = @"enableDdosProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDdosProtection { get; set; }
        /// <summary>Gets or sets List of subnets in a VirtualNetwork.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets List of subnets in a VirtualNetwork.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings[] Subnet { get; set; }

    }
    /// Defines the virtual network resource settings.
    internal partial interface IVirtualNetworkResourceSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal
    {
        /// <summary>Gets or sets the address prefixes for the virtual network.</summary>
        string[] AddressSpace { get; set; }
        /// <summary>
        /// Gets or sets DHCPOptions that contains an array of DNS servers available to VMs
        /// deployed in the virtual network.
        /// </summary>
        string[] DnsServer { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets whether the
        /// DDOS protection should be switched on.
        /// </summary>
        bool? EnableDdosProtection { get; set; }
        /// <summary>Gets or sets List of subnets in a VirtualNetwork.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings[] Subnet { get; set; }

    }
}