namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the network interface resource</summary>
    public partial class NetworkInterfaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DnsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings _dnsSetting;

        /// <summary>DNS Settings for the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.InterfaceDnsSettings()); set => this._dnsSetting = value; }

        /// <summary>List of DNS server IP Addresses for the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string[] DnsSettingDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettingsInternal)DnsSetting).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettingsInternal)DnsSetting).DnsServer = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[] _iPConfiguration;

        /// <summary>IPConfigurations - A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>MacAddress - The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal.DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.InterfaceDnsSettings()); set { {_dnsSetting = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal.Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatus()); set { {_status = value;} } }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfacePropertiesInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatus = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? _provisioningState;

        /// <summary>Provisioning state of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// The status of the operation performed on the network interface [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatusStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatusStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ProvisioningStatusOperationId = value ?? null; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus _status;

        /// <summary>The observed state of network interfaces</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatus()); }

        /// <summary>NetworkInterface provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusInternal)Status).ErrorMessage = value ?? null; }

        /// <summary>Creates an new <see cref="NetworkInterfaceProperties" /> instance.</summary>
        public NetworkInterfaceProperties()
        {

        }
    }
    /// Properties under the network interface resource
    public partial interface INetworkInterfaceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>List of DNS server IP Addresses for the interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of DNS server IP Addresses for the interface",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsSettingDnsServer { get; set; }
        /// <summary>IPConfigurations - A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IPConfigurations - A list of IPConfigurations of the network interface.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>MacAddress - The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MacAddress - The MAC address of the network interface.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get; set; }
        /// <summary>Provisioning state of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the network interface.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get;  }
        /// <summary>
        /// The status of the operation performed on the network interface [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the network interface [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the network interface</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the network interface",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>NetworkInterface provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NetworkInterface provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorMessage { get; set; }

    }
    /// Properties under the network interface resource
    internal partial interface INetworkInterfacePropertiesInternal

    {
        /// <summary>DNS Settings for the interface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IInterfaceDnsSettings DnsSetting { get; set; }
        /// <summary>List of DNS server IP Addresses for the interface</summary>
        string[] DnsSettingDnsServer { get; set; }
        /// <summary>IPConfigurations - A list of IPConfigurations of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>MacAddress - The MAC address of the network interface.</summary>
        string MacAddress { get; set; }
        /// <summary>Provisioning state of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get; set; }
        /// <summary>
        /// The status of the operation performed on the network interface [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the network interface</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>The observed state of network interfaces</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatus Status { get; set; }
        /// <summary>NetworkInterface provisioning error code</summary>
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string StatusErrorMessage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceStatusProvisioningStatus StatusProvisioningStatus { get; set; }

    }
}