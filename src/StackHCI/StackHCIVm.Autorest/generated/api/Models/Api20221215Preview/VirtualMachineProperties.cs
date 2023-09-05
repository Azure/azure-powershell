namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the virtual machine resource</summary>
    public partial class VirtualMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal
    {

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMaximumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigMaximumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigMaximumMemoryMb = value ?? default(long); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMinimumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigMinimumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigMinimumMemoryMb = value ?? default(long); }

        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? DynamicMemoryConfigTargetMemoryBuffer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigTargetMemoryBuffer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfigTargetMemoryBuffer = value ?? default(int); }

        /// <summary>Backing field for <see cref="GuestAgentProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfile _guestAgentProfile;

        /// <summary>Guest agent status properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfile GuestAgentProfile { get => (this._guestAgentProfile = this._guestAgentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GuestAgentProfile()); set => this._guestAgentProfile = value; }

        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string GuestAgentProfileAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).AgentVersion; }

        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] GuestAgentProfileErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).ErrorDetail; }

        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public global::System.DateTime? GuestAgentProfileLastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).LastStatusChange; }

        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? GuestAgentProfileStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).Status; }

        /// <summary>Specifies the VM's unique SMBIOS ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string GuestAgentProfileVMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).VMUuid; }

        /// <summary>Backing field for <see cref="HardwareProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile _hardwareProfile;

        /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesHardwareProfile()); set => this._hardwareProfile = value; }

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? HardwareProfileMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).MemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).MemoryMb = value ?? default(long); }

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? HardwareProfileProcessor { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).Processor; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).Processor = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).VMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum)""); }

        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ImageReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).ImageReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).ImageReferenceId = value ?? null; }

        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationDisablePasswordAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationDisablePasswordAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationDisablePasswordAuthentication = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationProvisionVMAgent = value ?? default(bool); }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationSshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationSshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for GuestAgentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfile { get => (this._guestAgentProfile = this._guestAgentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GuestAgentProfile()); set { {_guestAgentProfile = value;} } }

        /// <summary>Internal Acessors for GuestAgentProfileAgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfileAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).AgentVersion = value; }

        /// <summary>Internal Acessors for GuestAgentProfileErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfileErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).ErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).ErrorDetail = value; }

        /// <summary>Internal Acessors for GuestAgentProfileLastStatusChange</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfileLastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).LastStatusChange; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).LastStatusChange = value; }

        /// <summary>Internal Acessors for GuestAgentProfileStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfileStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).Status = value; }

        /// <summary>Internal Acessors for GuestAgentProfileVMUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.GuestAgentProfileVMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).VMUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfileInternal)GuestAgentProfile).VMUuid = value; }

        /// <summary>Internal Acessors for HardwareProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesHardwareProfile()); set { {_hardwareProfile = value;} } }

        /// <summary>Internal Acessors for HardwareProfileDynamicMemoryConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.HardwareProfileDynamicMemoryConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileInternal)HardwareProfile).DynamicMemoryConfig = value; }

        /// <summary>Internal Acessors for LinuxConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.LinuxConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfigurationSsh = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesNetworkProfile()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for OSProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile()); set { {_oSProfile = value;} } }

        /// <summary>Internal Acessors for OSProfileLinuxConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.OSProfileLinuxConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).LinuxConfiguration = value; }

        /// <summary>Internal Acessors for OSProfileWindowsConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.OSProfileWindowsConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowsConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowsConfiguration = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SecurityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.SecurityProfile { get => (this._securityProfile = this._securityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile()); set { {_securityProfile = value;} } }

        /// <summary>Internal Acessors for SecurityProfileUefiSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.SecurityProfileUefiSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).UefiSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).UefiSetting = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineStatus()); set { {_status = value;} } }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatus = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfile()); set { {_storageProfile = value;} } }

        /// <summary>Internal Acessors for StorageProfileImageReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.StorageProfileImageReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).ImageReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).ImageReference = value; }

        /// <summary>Internal Acessors for StorageProfileOSDisk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.StorageProfileOSDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).OSDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).OSDisk = value; }

        /// <summary>Internal Acessors for VMId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.VMId { get => this._vMId; set { {_vMId = value;} } }

        /// <summary>Internal Acessors for WindowConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal.WindowConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationSsh = value; }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile _networkProfile;

        /// <summary>NetworkProfile - describes the network configuration the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesNetworkProfile()); set => this._networkProfile = value; }

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileInternal)NetworkProfile).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileInternal)NetworkProfile).NetworkInterface = value ?? null /* arrayOf */; }

        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSDiskId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).OSDiskId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).OSDiskId = value ?? null; }

        /// <summary>Backing field for <see cref="OSProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile _oSProfile;

        /// <summary>
        /// OsProfile - describes the configuration of the operating system and sets login data
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfile()); set => this._oSProfile = value; }

        /// <summary>AdminPassword - admin password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileAdminPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).AdminPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).AdminPassword = value ?? null; }

        /// <summary>AdminUsername - admin username</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).AdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).AdminUsername = value ?? null; }

        /// <summary>ComputerName - name of the compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).ComputerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).ComputerName = value ?? null; }

        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSProfileOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).OSType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum)""); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? _provisioningState;

        /// <summary>Provisioning state of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// The status of the operation performed on the virtual machine [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatusStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatusStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ProvisioningStatusOperationId = value ?? null; }

        /// <summary>Backing field for <see cref="SecurityProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile _securityProfile;

        /// <summary>SecurityProfile - Specifies the security settings for the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile SecurityProfile { get => (this._securityProfile = this._securityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfile()); set => this._securityProfile = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? SecurityProfileEnableTpm { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).EnableTpm; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).EnableTpm = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatus _status;

        /// <summary>The observed state of virtual machines</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatus Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineStatus()); }

        /// <summary>VirtualMachine provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).ErrorMessage = value ?? null; }

        /// <summary>The power state of the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum? StatusPowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).PowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusInternal)Status).PowerState = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum)""); }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile _storageProfile;

        /// <summary>
        /// StorageProfile - contains information about the disks and storage information for the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesStorageProfile()); set => this._storageProfile = value; }

        /// <summary>adds data disks to the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] StorageProfileDataDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).DataDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).DataDisk = value ?? null /* arrayOf */; }

        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StorageProfileVMConfigStoragePathId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).VMConfigStoragePathId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileInternal)StorageProfile).VMConfigStoragePathId = value ?? null; }

        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? UefiSettingSecureBootEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).UefiSettingSecureBootEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal)SecurityProfile).UefiSettingSecureBootEnabled = value ?? default(bool); }

        /// <summary>Backing field for <see cref="VMId" /> property.</summary>
        private string _vMId;

        /// <summary>Unique identifier for the vm resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string VMId { get => this._vMId; }

        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationEnableAutomaticUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationEnableAutomaticUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationEnableAutomaticUpdate = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationProvisionVMAgent = value ?? default(bool); }

        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string WindowConfigurationTimeZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationTimeZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowConfigurationTimeZone = value ?? null; }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowsConfigurationSshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal)OSProfile).WindowsConfigurationSshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="VirtualMachineProperties" /> instance.</summary>
        public VirtualMachineProperties()
        {

        }
    }
    /// Properties under the virtual machine resource
    public partial interface IVirtualMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maximumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DynamicMemoryConfigMaximumMemoryMb { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"minimumMemoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? DynamicMemoryConfigMinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled. This property can be in the range of 5 to 2000.",
        SerializedName = @"targetMemoryBuffer",
        PossibleTypes = new [] { typeof(int) })]
        int? DynamicMemoryConfigTargetMemoryBuffer { get; set; }
        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hybrid machine agent full version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string GuestAgentProfileAgentVersion { get;  }
        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Details about the error state.",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] GuestAgentProfileErrorDetail { get;  }
        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time of the last status change.",
        SerializedName = @"lastStatusChange",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? GuestAgentProfileLastStatusChange { get;  }
        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the hybrid machine agent.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? GuestAgentProfileStatus { get;  }
        /// <summary>Specifies the VM's unique SMBIOS ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the VM's unique SMBIOS ID.",
        SerializedName = @"vmUuid",
        PossibleTypes = new [] { typeof(string) })]
        string GuestAgentProfileVMUuid { get;  }
        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"RAM in MB for the virtual machine",
        SerializedName = @"memoryMB",
        PossibleTypes = new [] { typeof(long) })]
        long? HardwareProfileMemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"number of processors for the virtual machine",
        SerializedName = @"processors",
        PossibleTypes = new [] { typeof(int) })]
        int? HardwareProfileProcessor { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get; set; }
        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the image",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ImageReferenceId { get; set; }
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DisablePasswordAuthentication - whether password authentication should be disabled",
        SerializedName = @"disablePasswordAuthentication",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.",
        SerializedName = @"provisionVMAgent",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LinuxConfigurationProvisionVMAgent { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get; set; }
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"NetworkInterfaces - list of network interfaces to be attached to the virtual machine",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the OS disk",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string OSDiskId { get; set; }
        /// <summary>AdminPassword - admin password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AdminPassword - admin password",
        SerializedName = @"adminPassword",
        PossibleTypes = new [] { typeof(string) })]
        string OSProfileAdminPassword { get; set; }
        /// <summary>AdminUsername - admin username</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AdminUsername - admin username",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string OSProfileAdminUsername { get; set; }
        /// <summary>ComputerName - name of the compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ComputerName - name of the compute",
        SerializedName = @"computerName",
        PossibleTypes = new [] { typeof(string) })]
        string OSProfileComputerName { get; set; }
        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OsType - string specifying whether the OS is Linux or Windows",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSProfileOstype { get; set; }
        /// <summary>Provisioning state of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the virtual machine.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get;  }
        /// <summary>
        /// The status of the operation performed on the virtual machine [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the virtual machine [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the virtual machine",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableTPM",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecurityProfileEnableTpm { get; set; }
        /// <summary>VirtualMachine provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VirtualMachine provisioning error code",
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
        /// <summary>The power state of the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The power state of the virtual machine",
        SerializedName = @"powerState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum? StatusPowerState { get; set; }
        /// <summary>adds data disks to the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"adds data disks to the virtual machine",
        SerializedName = @"dataDisks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] StorageProfileDataDisk { get; set; }
        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Id of the storage container that hosts the VM configuration file",
        SerializedName = @"vmConfigStoragePathId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageProfileVMConfigStoragePathId { get; set; }
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether secure boot should be enabled on the virtual machine.",
        SerializedName = @"secureBootEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UefiSettingSecureBootEnabled { get; set; }
        /// <summary>Unique identifier for the vm resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unique identifier for the vm resource.",
        SerializedName = @"vmId",
        PossibleTypes = new [] { typeof(string) })]
        string VMId { get;  }
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to EnableAutomaticUpdates on the machine",
        SerializedName = @"enableAutomaticUpdates",
        PossibleTypes = new [] { typeof(bool) })]
        bool? WindowConfigurationEnableAutomaticUpdate { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.",
        SerializedName = @"provisionVMAgent",
        PossibleTypes = new [] { typeof(bool) })]
        bool? WindowConfigurationProvisionVMAgent { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"TimeZone for the virtual machine",
        SerializedName = @"timeZone",
        PossibleTypes = new [] { typeof(string) })]
        string WindowConfigurationTimeZone { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get; set; }

    }
    /// Properties under the virtual machine resource
    internal partial interface IVirtualMachinePropertiesInternal

    {
        long? DynamicMemoryConfigMaximumMemoryMb { get; set; }

        long? DynamicMemoryConfigMinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        int? DynamicMemoryConfigTargetMemoryBuffer { get; set; }
        /// <summary>Guest agent status properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfile GuestAgentProfile { get; set; }
        /// <summary>The hybrid machine agent full version.</summary>
        string GuestAgentProfileAgentVersion { get; set; }
        /// <summary>Details about the error state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] GuestAgentProfileErrorDetail { get; set; }
        /// <summary>The time of the last status change.</summary>
        global::System.DateTime? GuestAgentProfileLastStatusChange { get; set; }
        /// <summary>The status of the hybrid machine agent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? GuestAgentProfileStatus { get; set; }
        /// <summary>Specifies the VM's unique SMBIOS ID.</summary>
        string GuestAgentProfileVMUuid { get; set; }
        /// <summary>HardwareProfile - Specifies the hardware settings for the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile HardwareProfile { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig HardwareProfileDynamicMemoryConfig { get; set; }
        /// <summary>RAM in MB for the virtual machine</summary>
        long? HardwareProfileMemoryMb { get; set; }
        /// <summary>number of processors for the virtual machine</summary>
        int? HardwareProfileProcessor { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get; set; }
        /// <summary>Resource ID of the image</summary>
        string ImageReferenceId { get; set; }
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? LinuxConfigurationProvisionVMAgent { get; set; }
        /// <summary>SSH - contains settings related to ssh configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh LinuxConfigurationSsh { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get; set; }
        /// <summary>NetworkProfile - describes the network configuration the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>Resource ID of the OS disk</summary>
        string OSDiskId { get; set; }
        /// <summary>
        /// OsProfile - describes the configuration of the operating system and sets login data
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile OSProfile { get; set; }
        /// <summary>AdminPassword - admin password</summary>
        string OSProfileAdminPassword { get; set; }
        /// <summary>AdminUsername - admin username</summary>
        string OSProfileAdminUsername { get; set; }
        /// <summary>ComputerName - name of the compute</summary>
        string OSProfileComputerName { get; set; }
        /// <summary>
        /// LinuxConfiguration - linux specific configuration values for the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration OSProfileLinuxConfiguration { get; set; }
        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSProfileOstype { get; set; }
        /// <summary>Windows Configuration for the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration OSProfileWindowsConfiguration { get; set; }
        /// <summary>Provisioning state of the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get; set; }
        /// <summary>
        /// The status of the operation performed on the virtual machine [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the virtual machine</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>SecurityProfile - Specifies the security settings for the virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile SecurityProfile { get; set; }

        bool? SecurityProfileEnableTpm { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings SecurityProfileUefiSetting { get; set; }
        /// <summary>The observed state of virtual machines</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatus Status { get; set; }
        /// <summary>VirtualMachine provisioning error code</summary>
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string StatusErrorMessage { get; set; }
        /// <summary>The power state of the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum? StatusPowerState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusProvisioningStatus StatusProvisioningStatus { get; set; }
        /// <summary>
        /// StorageProfile - contains information about the disks and storage information for the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile StorageProfile { get; set; }
        /// <summary>adds data disks to the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] StorageProfileDataDisk { get; set; }
        /// <summary>Which Image to use for the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference StorageProfileImageReference { get; set; }
        /// <summary>VHD to attach as OS disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk StorageProfileOSDisk { get; set; }
        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        string StorageProfileVMConfigStoragePathId { get; set; }
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        bool? UefiSettingSecureBootEnabled { get; set; }
        /// <summary>Unique identifier for the vm resource.</summary>
        string VMId { get; set; }
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        bool? WindowConfigurationEnableAutomaticUpdate { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? WindowConfigurationProvisionVMAgent { get; set; }
        /// <summary>SSH Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh WindowConfigurationSsh { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        string WindowConfigurationTimeZone { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get; set; }

    }
}