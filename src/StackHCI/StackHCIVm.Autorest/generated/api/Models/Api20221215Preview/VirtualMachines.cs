namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The virtual machine resource definition.</summary>
    public partial class VirtualMachines :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachines,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.TrackedResource();

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMaximumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigMaximumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigMaximumMemoryMb = value ?? default(long); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? DynamicMemoryConfigMinimumMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigMinimumMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigMinimumMemoryMb = value ?? default(long); }

        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? DynamicMemoryConfigTargetMemoryBuffer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigTargetMemoryBuffer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).DynamicMemoryConfigTargetMemoryBuffer = value ?? default(int); }

        /// <summary>Backing field for <see cref="ExtendedLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation _extendedLocation;

        /// <summary>The extendedLocation of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation ExtendedLocation { get => (this._extendedLocation = this._extendedLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocation()); set => this._extendedLocation = value; }

        /// <summary>The name of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ExtendedLocationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Name = value ?? null; }

        /// <summary>The type of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes)""); }

        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string GuestAgentProfileAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileAgentVersion; }

        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] GuestAgentProfileErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileErrorDetail; }

        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public global::System.DateTime? GuestAgentProfileLastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileLastStatusChange; }

        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? GuestAgentProfileStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileStatus; }

        /// <summary>Specifies the VM's unique SMBIOS ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string GuestAgentProfileVMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileVMUuid; }

        /// <summary>RAM in MB for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? HardwareProfileMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileMemoryMb = value ?? default(long); }

        /// <summary>number of processors for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public int? HardwareProfileProcessor { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileProcessor; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileProcessor = value ?? default(int); }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum? HardwareProfileVMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileVMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileVMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum)""); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentity _identity;

        /// <summary>Identity for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.Identity()); set => this._identity = value; }

        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).PrincipalId; }

        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).TenantId; }

        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType)""); }

        /// <summary>Resource ID of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ImageReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ImageReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ImageReferenceId = value ?? null; }

        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationDisablePasswordAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationDisablePasswordAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationDisablePasswordAuthentication = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationProvisionVMAgent = value ?? default(bool); }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationSshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationSshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for ExtendedLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.ExtendedLocation { get => (this._extendedLocation = this._extendedLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocation()); set { {_extendedLocation = value;} } }

        /// <summary>Internal Acessors for GuestAgentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfile = value; }

        /// <summary>Internal Acessors for GuestAgentProfileAgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfileAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileAgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileAgentVersion = value; }

        /// <summary>Internal Acessors for GuestAgentProfileErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IErrorDetail[] Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfileErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileErrorDetail = value; }

        /// <summary>Internal Acessors for GuestAgentProfileLastStatusChange</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfileLastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileLastStatusChange; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileLastStatusChange = value; }

        /// <summary>Internal Acessors for GuestAgentProfileStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusTypes? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfileStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileStatus = value; }

        /// <summary>Internal Acessors for GuestAgentProfileVMUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.GuestAgentProfileVMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileVMUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).GuestAgentProfileVMUuid = value; }

        /// <summary>Internal Acessors for HardwareProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.HardwareProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfile = value; }

        /// <summary>Internal Acessors for HardwareProfileDynamicMemoryConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesHardwareProfileDynamicMemoryConfig Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.HardwareProfileDynamicMemoryConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileDynamicMemoryConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).HardwareProfileDynamicMemoryConfig = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentity Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.Identity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for LinuxConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.LinuxConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).LinuxConfigurationSsh = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for OSProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.OSProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfile = value; }

        /// <summary>Internal Acessors for OSProfileLinuxConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.OSProfileLinuxConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileLinuxConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileLinuxConfiguration = value; }

        /// <summary>Internal Acessors for OSProfileWindowsConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.OSProfileWindowsConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileWindowsConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileWindowsConfiguration = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for SecurityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.SecurityProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfile = value; }

        /// <summary>Internal Acessors for SecurityProfileUefiSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.SecurityProfileUefiSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfileUefiSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfileUefiSetting = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusProvisioningStatus = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfile Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfile = value; }

        /// <summary>Internal Acessors for StorageProfileImageReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileImageReference Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.StorageProfileImageReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileImageReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileImageReference = value; }

        /// <summary>Internal Acessors for StorageProfileOSDisk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileOSDisk Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.StorageProfileOSDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileOSDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileOSDisk = value; }

        /// <summary>Internal Acessors for VMId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.VMId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).VMId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).VMId = value; }

        /// <summary>Internal Acessors for WindowConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinesInternal.WindowConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationSsh = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// NetworkInterfaces - list of network interfaces to be attached to the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).NetworkProfileNetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).NetworkProfileNetworkInterface = value ?? null /* arrayOf */; }

        /// <summary>Resource ID of the OS disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSDiskId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSDiskId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSDiskId = value ?? null; }

        /// <summary>AdminPassword - admin password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileAdminPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileAdminPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileAdminPassword = value ?? null; }

        /// <summary>AdminUsername - admin username</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileAdminUsername = value ?? null; }

        /// <summary>ComputerName - name of the compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileComputerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileComputerName = value ?? null; }

        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSProfileOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileOstype; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).OSProfileOstype = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum)""); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineProperties _property;

        /// <summary>Properties under the virtual machine resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachineProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The status of the operation performed on the virtual machine [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).ProvisioningStatusOperationId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? SecurityProfileEnableTpm { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfileEnableTpm; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).SecurityProfileEnableTpm = value ?? default(bool); }

        /// <summary>VirtualMachine provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusErrorMessage = value ?? null; }

        /// <summary>The power state of the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum? StatusPowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusPowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StatusPowerState = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PowerStateEnum)""); }

        /// <summary>adds data disks to the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[] StorageProfileDataDisk { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileDataDisk; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileDataDisk = value ?? null /* arrayOf */; }

        /// <summary>Id of the storage container that hosts the VM configuration file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StorageProfileVMConfigStoragePathId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileVMConfigStoragePathId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).StorageProfileVMConfigStoragePathId = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedAt = value; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedBy = value; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedByType = value; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type; }

        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? UefiSettingSecureBootEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).UefiSettingSecureBootEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).UefiSettingSecureBootEnabled = value ?? default(bool); }

        /// <summary>Unique identifier for the vm resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string VMId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).VMId; }

        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationEnableAutomaticUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationEnableAutomaticUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationEnableAutomaticUpdate = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationProvisionVMAgent = value ?? default(bool); }

        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string WindowConfigurationTimeZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationTimeZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowConfigurationTimeZone = value ?? null; }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowsConfigurationSshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesInternal)Property).WindowsConfigurationSshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }

        /// <summary>Creates an new <see cref="VirtualMachines" /> instance.</summary>
        public VirtualMachines()
        {

        }
    }
    /// The virtual machine resource definition.
    public partial interface IVirtualMachines :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource
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
        /// <summary>The name of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the extended location.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedLocationName { get; set; }
        /// <summary>The type of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the extended location.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get; set; }
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
        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal ID of resource identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant ID of resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType? IdentityType { get; set; }
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
    /// The virtual machine resource definition.
    internal partial interface IVirtualMachinesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal
    {
        long? DynamicMemoryConfigMaximumMemoryMb { get; set; }

        long? DynamicMemoryConfigMinimumMemoryMb { get; set; }
        /// <summary>
        /// Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total
        /// memory that the virtual machine is thought to need. This only applies to virtual systems with dynamic memory enabled.
        /// This property can be in the range of 5 to 2000.
        /// </summary>
        int? DynamicMemoryConfigTargetMemoryBuffer { get; set; }
        /// <summary>The extendedLocation of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation ExtendedLocation { get; set; }
        /// <summary>The name of the extended location.</summary>
        string ExtendedLocationName { get; set; }
        /// <summary>The type of the extended location.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get; set; }
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
        /// <summary>Identity for the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IIdentity Identity { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType? IdentityType { get; set; }
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
        /// <summary>Properties under the virtual machine resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachineProperties Property { get; set; }
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