namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>InterfaceIPConfiguration iPConfiguration in a network interface.</summary>
    public partial class IPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationInternal
    {

        /// <summary>Gateway for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string Gateway { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).Gateway; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).Gateway = value ?? null; }

        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrivateIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrivateIPAddress = value ?? null; }

        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? IPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrivateIPAllocationMethod = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum)""); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationInternal.Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).Subnet = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>prefixLength for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string PrefixLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrefixLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).PrefixLength = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationProperties _property;

        /// <summary>InterfaceIPConfigurationPropertiesFormat properties of IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfigurationProperties()); set => this._property = value; }

        /// <summary>
        /// ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesInternal)Property).SubnetId = value ?? null; }

        /// <summary>Creates an new <see cref="IPConfiguration" /> instance.</summary>
        public IPConfiguration()
        {

        }
    }
    /// InterfaceIPConfiguration iPConfiguration in a network interface.
    public partial interface IIPConfiguration :
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
        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PrivateIPAddress - Private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? IPAllocationMethod { get; set; }
        /// <summary>
        /// Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>prefixLength for network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"prefixLength for network interface",
        SerializedName = @"prefixLength",
        PossibleTypes = new [] { typeof(string) })]
        string PrefixLength { get; set; }
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
    /// InterfaceIPConfiguration iPConfiguration in a network interface.
    internal partial interface IIPConfigurationInternal

    {
        /// <summary>Gateway for network interface</summary>
        string Gateway { get; set; }
        /// <summary>PrivateIPAddress - Private IP address of the IP configuration.</summary>
        string IPAddress { get; set; }
        /// <summary>
        /// PrivateIPAllocationMethod - The private IP address allocation method. Possible values include: 'Static', 'Dynamic'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateIPAllocationMethodEnum? IPAllocationMethod { get; set; }
        /// <summary>
        /// Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>prefixLength for network interface</summary>
        string PrefixLength { get; set; }
        /// <summary>InterfaceIPConfigurationPropertiesFormat properties of IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationProperties Property { get; set; }
        /// <summary>Subnet - Name of Subnet bound to the IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfigurationPropertiesSubnet Subnet { get; set; }
        /// <summary>
        /// ID - The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string SubnetId { get; set; }

    }
}