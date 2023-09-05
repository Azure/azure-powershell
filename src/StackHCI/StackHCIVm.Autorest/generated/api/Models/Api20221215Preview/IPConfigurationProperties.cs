namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>InterfaceIPConfigurationPropertiesFormat properties of IP configuration.</summary>
    public partial class IPConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Gateway" /> property.</summary>
        private string _gateway;

        /// <summary>Gateway for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Gateway { get => this._gateway; set => this._gateway = value; }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal.Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationPropertiesSubnet()); set { {_subnet = value;} } }

        /// <summary>Backing field for <see cref="PrefixLength" /> property.</summary>
        private string _prefixLength;

        /// <summary>prefixLength for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string PrefixLength { get => this._prefixLength; set => this._prefixLength = value; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Backing field for <see cref="PrivateIPAllocationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? _privateIPAllocationMethod;

        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? PrivateIPAllocationMethod { get => this._privateIPAllocationMethod; set => this._privateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet _subnet;

        /// <summary>Subnet - Name of Subnet bound to the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationPropertiesSubnet()); set => this._subnet = value; }

        /// <summary>
        /// ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnetInternal)Subnet).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnetInternal)Subnet).Id = value ?? null; }

        /// <summary>Creates an new <see cref="IPConfigurationProperties" /> instance.</summary>
        public IPConfigurationProperties()
        {

        }
    }
    /// InterfaceIPConfigurationPropertiesFormat properties of IP configuration.
    public partial interface IIPConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Gateway for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gateway for network interface",
        SerializedName = @"gateway",
        PossibleTypes = new [] { typeof(string) })]
        string Gateway { get; set; }
        /// <summary>prefixLength for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"prefixLength for network interface",
        SerializedName = @"prefixLength",
        PossibleTypes = new [] { typeof(string) })]
        string PrefixLength { get; set; }
        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PrivateIPAddress - Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// InterfaceIPConfigurationPropertiesFormat properties of IP configuration.
    internal partial interface IIPConfigurationPropertiesInternal

    {
        /// <summary>Gateway for network interface</summary>
        string Gateway { get; set; }
        /// <summary>prefixLength for network interface</summary>
        string PrefixLength { get; set; }
        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? PrivateIPAllocationMethod { get; set; }
        /// <summary>Subnet - Name of Subnet bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet Subnet { get; set; }
        /// <summary>
        /// ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string SubnetId { get; set; }

    }
}