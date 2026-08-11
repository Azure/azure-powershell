// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>Details of the Compute Fleet.</summary>
    public partial class FleetProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal
    {

        /// <summary>The list of location profiles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile> AdditionalLocationProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfileInternal)AdditionalLocationsProfile).LocationProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfileInternal)AdditionalLocationsProfile).LocationProfile = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="AdditionalLocationsProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile _additionalLocationsProfile;

        /// <summary>
        /// Represents the configuration for additional locations where Fleet resources may be deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile AdditionalLocationsProfile { get => (this._additionalLocationsProfile = this._additionalLocationsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalLocationsProfile()); set => this._additionalLocationsProfile = value; }

        /// <summary>The flag that enables or disables hibernation capability on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? AdditionalVirtualMachineCapabilityHibernationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapabilityHibernationEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapabilityHibernationEnabled = value ?? default(bool); }

        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account
        /// type on the VM or VMSS.
        /// Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only
        /// if this property is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? AdditionalVirtualMachineCapabilityUltraSsdEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapabilityUltraSsdEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapabilityUltraSsdEnabled = value ?? default(bool); }

        /// <summary>Backing field for <see cref="CapacityType" /> property.</summary>
        private string _capacityType;

        /// <summary>
        /// Specifies capacity type for Fleet Regular and Spot priority profiles.
        /// capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.
        /// Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string CapacityType { get => this._capacityType; set => this._capacityType = value; }

        /// <summary>Backing field for <see cref="ComputeProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile _computeProfile;

        /// <summary>Compute Profile to use for running user's workloads.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile ComputeProfile { get => (this._computeProfile = this._computeProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ComputeProfile()); set => this._computeProfile = value; }

        /// <summary>
        /// Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile ComputeProfileBaseVirtualMachineProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).BaseVirtualMachineProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).BaseVirtualMachineProfile = value ; }

        /// <summary>
        /// Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.
        /// The default value will be the latest supported computeApiVersion by Compute Fleet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ComputeProfileComputeApiVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).ComputeApiVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).ComputeApiVersion = value ?? null; }

        /// <summary>
        /// Specifies the number of fault domains to use when creating the underlying VMSS.
        /// A fault domain is a logical group of hardware within an Azure datacenter.
        /// VMs in the same fault domain share a common power source and network switch.
        /// If not specified, defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).
        /// This property cannot be updated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? ComputeProfilePlatformFaultDomainCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).PlatformFaultDomainCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).PlatformFaultDomainCount = value ?? default(int); }

        /// <summary>Internal Acessors for AdditionalLocationsProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.AdditionalLocationsProfile { get => (this._additionalLocationsProfile = this._additionalLocationsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalLocationsProfile()); set { {_additionalLocationsProfile = value;} } }

        /// <summary>Internal Acessors for ComputeProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.ComputeProfile { get => (this._computeProfile = this._computeProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ComputeProfile()); set { {_computeProfile = value;} } }

        /// <summary>Internal Acessors for ComputeProfileAdditionalVirtualMachineCapability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalCapabilities Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.ComputeProfileAdditionalVirtualMachineCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapability; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfileInternal)ComputeProfile).AdditionalVirtualMachineCapability = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RegularPriorityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.RegularPriorityProfile { get => (this._regularPriorityProfile = this._regularPriorityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.RegularPriorityProfile()); set { {_regularPriorityProfile = value;} } }

        /// <summary>Internal Acessors for SpotPriorityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.SpotPriorityProfile { get => (this._spotPriorityProfile = this._spotPriorityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SpotPriorityProfile()); set { {_spotPriorityProfile = value;} } }

        /// <summary>Internal Acessors for TimeCreated</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.TimeCreated { get => this._timeCreated; set { {_timeCreated = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.UniqueId { get => this._uniqueId; set { {_uniqueId = value;} } }

        /// <summary>Internal Acessors for ZoneAllocationPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal.ZoneAllocationPolicy { get => (this._zoneAllocationPolicy = this._zoneAllocationPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZoneAllocationPolicy()); set { {_zoneAllocationPolicy = value;} } }

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private string _mode;

        /// <summary>Mode of the Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RegularPriorityProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile _regularPriorityProfile;

        /// <summary>Configuration Options for Regular instances in Compute Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile RegularPriorityProfile { get => (this._regularPriorityProfile = this._regularPriorityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.RegularPriorityProfile()); set => this._regularPriorityProfile = value; }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string RegularPriorityProfileAllocationStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).AllocationStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).AllocationStrategy = value ?? null; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? RegularPriorityProfileCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).Capacity = value ?? default(int); }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? RegularPriorityProfileMinCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).MinCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfileInternal)RegularPriorityProfile).MinCapacity = value ?? default(int); }

        /// <summary>Backing field for <see cref="SpotPriorityProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile _spotPriorityProfile;

        /// <summary>Configuration Options for Spot instances in Compute Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile SpotPriorityProfile { get => (this._spotPriorityProfile = this._spotPriorityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SpotPriorityProfile()); set => this._spotPriorityProfile = value; }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SpotPriorityProfileAllocationStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).AllocationStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).AllocationStrategy = value ?? null; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? SpotPriorityProfileCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).Capacity = value ?? default(int); }

        /// <summary>Eviction Policy to follow when evicting Spot VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SpotPriorityProfileEvictionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).EvictionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).EvictionPolicy = value ?? null; }

        /// <summary>
        /// Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.
        /// If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)
        /// or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint)
        /// in order to achieve the desired capacity.
        /// Maintain is enabled by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? SpotPriorityProfileMaintain { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).Maintain; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).Maintain = value ?? default(bool); }

        /// <summary>Price per hour of each Spot VM will never exceed this.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public float? SpotPriorityProfileMaxPricePerVM { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).MaxPricePerVM; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).MaxPricePerVM = value ?? default(float); }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? SpotPriorityProfileMinCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).MinCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfileInternal)SpotPriorityProfile).MinCapacity = value ?? default(int); }

        /// <summary>Backing field for <see cref="TimeCreated" /> property.</summary>
        private global::System.DateTime? _timeCreated;

        /// <summary>Specifies the time at which the Compute Fleet is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeCreated { get => this._timeCreated; }

        /// <summary>Backing field for <see cref="UniqueId" /> property.</summary>
        private string _uniqueId;

        /// <summary>Specifies the ID which uniquely identifies a Compute Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string UniqueId { get => this._uniqueId; }

        /// <summary>Backing field for <see cref="VMAttribute" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes _vMAttribute;

        /// <summary>Attribute based Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes VMAttribute { get => (this._vMAttribute = this._vMAttribute ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMAttributes()); set => this._vMAttribute = value; }

        /// <summary>Backing field for <see cref="VMNamePrefix" /> property.</summary>
        private string _vMNamePrefix;

        /// <summary>
        /// VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string VMNamePrefix { get => this._vMNamePrefix; set => this._vMNamePrefix = value; }

        /// <summary>Backing field for <see cref="VMSizesProfile" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> _vMSizesProfile;

        /// <summary>List of VM sizes supported for Compute Fleet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> VMSizesProfile { get => this._vMSizesProfile; set => this._vMSizesProfile = value; }

        /// <summary>Backing field for <see cref="ZoneAllocationPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy _zoneAllocationPolicy;

        /// <summary>Zone Allocation Policy for Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy ZoneAllocationPolicy { get => (this._zoneAllocationPolicy = this._zoneAllocationPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZoneAllocationPolicy()); set => this._zoneAllocationPolicy = value; }

        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ZoneAllocationPolicyDistributionStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicyInternal)ZoneAllocationPolicy).DistributionStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicyInternal)ZoneAllocationPolicy).DistributionStrategy = value ?? null; }

        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZoneAllocationPolicyZonePreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicyInternal)ZoneAllocationPolicy).ZonePreference; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicyInternal)ZoneAllocationPolicy).ZonePreference = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="FleetProperties" /> instance.</summary>
        public FleetProperties()
        {

        }
    }
    /// Details of the Compute Fleet.
    public partial interface IFleetProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable
    {
        /// <summary>The list of location profiles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of location profiles.",
        SerializedName = @"locationProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile> AdditionalLocationProfile { get; set; }
        /// <summary>The flag that enables or disables hibernation capability on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The flag that enables or disables hibernation capability on the VM.",
        SerializedName = @"hibernationEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AdditionalVirtualMachineCapabilityHibernationEnabled { get; set; }
        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account
        /// type on the VM or VMSS.
        /// Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only
        /// if this property is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.
        Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.",
        SerializedName = @"ultraSSDEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AdditionalVirtualMachineCapabilityUltraSsdEnabled { get; set; }
        /// <summary>
        /// Specifies capacity type for Fleet Regular and Spot priority profiles.
        /// capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.
        /// Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies capacity type for Fleet Regular and Spot priority profiles.
        capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.
        Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.",
        SerializedName = @"capacityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("VM", "VCpu")]
        string CapacityType { get; set; }
        /// <summary>
        /// Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Base Virtual Machine Profile Properties to be specified according to ""specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile""",
        SerializedName = @"baseVirtualMachineProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile ComputeProfileBaseVirtualMachineProfile { get; set; }
        /// <summary>
        /// Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.
        /// The default value will be the latest supported computeApiVersion by Compute Fleet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.
        The default value will be the latest supported computeApiVersion by Compute Fleet.",
        SerializedName = @"computeApiVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ComputeProfileComputeApiVersion { get; set; }
        /// <summary>
        /// Specifies the number of fault domains to use when creating the underlying VMSS.
        /// A fault domain is a logical group of hardware within an Azure datacenter.
        /// VMs in the same fault domain share a common power source and network switch.
        /// If not specified, defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).
        /// This property cannot be updated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the number of fault domains to use when creating the underlying VMSS.
        A fault domain is a logical group of hardware within an Azure datacenter.
        VMs in the same fault domain share a common power source and network switch.
        If not specified, defaults to 1, which represents ""Max Spreading"" (using as many fault domains as possible).
        This property cannot be updated.",
        SerializedName = @"platformFaultDomainCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ComputeProfilePlatformFaultDomainCount { get; set; }
        /// <summary>Mode of the Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Mode of the Fleet.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Managed", "Launch")]
        string Mode { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Creating", "Updating", "Deleting", "Migrating")]
        string ProvisioningState { get;  }
        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.",
        SerializedName = @"allocationStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("LowestPrice", "Prioritized")]
        string RegularPriorityProfileAllocationStrategy { get; set; }
        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Total capacity to achieve. It is currently in terms of number of VMs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? RegularPriorityProfileCapacity { get; set; }
        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Minimum capacity to achieve which cannot be updated. If we will not be able to ""guarantee"" minimum capacity, we will reject the request in the sync path itself.",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? RegularPriorityProfileMinCapacity { get; set; }
        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.",
        SerializedName = @"allocationStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("PriceCapacityOptimized", "LowestPrice", "CapacityOptimized")]
        string SpotPriorityProfileAllocationStrategy { get; set; }
        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Total capacity to achieve. It is currently in terms of number of VMs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SpotPriorityProfileCapacity { get; set; }
        /// <summary>Eviction Policy to follow when evicting Spot VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Eviction Policy to follow when evicting Spot VMs.",
        SerializedName = @"evictionPolicy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Delete", "Deallocate")]
        string SpotPriorityProfileEvictionPolicy { get; set; }
        /// <summary>
        /// Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.
        /// If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)
        /// or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint)
        /// in order to achieve the desired capacity.
        /// Maintain is enabled by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.
        If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)
        or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint) in order to achieve the desired capacity.
        Maintain is enabled by default.",
        SerializedName = @"maintain",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SpotPriorityProfileMaintain { get; set; }
        /// <summary>Price per hour of each Spot VM will never exceed this.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Price per hour of each Spot VM will never exceed this.",
        SerializedName = @"maxPricePerVM",
        PossibleTypes = new [] { typeof(float) })]
        float? SpotPriorityProfileMaxPricePerVM { get; set; }
        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Minimum capacity to achieve which cannot be updated. If we will not be able to ""guarantee"" minimum capacity, we will reject the request in the sync path itself.",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SpotPriorityProfileMinCapacity { get; set; }
        /// <summary>Specifies the time at which the Compute Fleet is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Specifies the time at which the Compute Fleet is created.",
        SerializedName = @"timeCreated",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeCreated { get;  }
        /// <summary>Specifies the ID which uniquely identifies a Compute Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Specifies the ID which uniquely identifies a Compute Fleet.",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }
        /// <summary>Attribute based Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Attribute based Fleet.",
        SerializedName = @"vmAttributes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes VMAttribute { get; set; }
        /// <summary>
        /// VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.",
        SerializedName = @"vmNamePrefix",
        PossibleTypes = new [] { typeof(string) })]
        string VMNamePrefix { get; set; }
        /// <summary>List of VM sizes supported for Compute Fleet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of VM sizes supported for Compute Fleet",
        SerializedName = @"vmSizesProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> VMSizesProfile { get; set; }
        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Distribution strategy used for zone allocation policy.",
        SerializedName = @"distributionStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        string ZoneAllocationPolicyDistributionStrategy { get; set; }
        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Zone preferences, required when zone distribution strategy is Prioritized.",
        SerializedName = @"zonePreferences",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZoneAllocationPolicyZonePreference { get; set; }

    }
    /// Details of the Compute Fleet.
    internal partial interface IFleetPropertiesInternal

    {
        /// <summary>The list of location profiles.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile> AdditionalLocationProfile { get; set; }
        /// <summary>
        /// Represents the configuration for additional locations where Fleet resources may be deployed.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile AdditionalLocationsProfile { get; set; }
        /// <summary>The flag that enables or disables hibernation capability on the VM.</summary>
        bool? AdditionalVirtualMachineCapabilityHibernationEnabled { get; set; }
        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account
        /// type on the VM or VMSS.
        /// Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only
        /// if this property is enabled.
        /// </summary>
        bool? AdditionalVirtualMachineCapabilityUltraSsdEnabled { get; set; }
        /// <summary>
        /// Specifies capacity type for Fleet Regular and Spot priority profiles.
        /// capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.
        /// Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("VM", "VCpu")]
        string CapacityType { get; set; }
        /// <summary>Compute Profile to use for running user's workloads.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile ComputeProfile { get; set; }
        /// <summary>
        /// Specifies VMSS and VM API entity models support two additional capabilities as of today: ultraSSDEnabled and hibernationEnabled.
        /// ultraSSDEnabled: Enables UltraSSD_LRS storage account type on the VMSS VMs.
        /// hibernationEnabled: Enables the hibernation capability on the VMSS VMs.
        /// Default value is null if not specified. This property cannot be updated once set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalCapabilities ComputeProfileAdditionalVirtualMachineCapability { get; set; }
        /// <summary>
        /// Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile ComputeProfileBaseVirtualMachineProfile { get; set; }
        /// <summary>
        /// Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.
        /// The default value will be the latest supported computeApiVersion by Compute Fleet.
        /// </summary>
        string ComputeProfileComputeApiVersion { get; set; }
        /// <summary>
        /// Specifies the number of fault domains to use when creating the underlying VMSS.
        /// A fault domain is a logical group of hardware within an Azure datacenter.
        /// VMs in the same fault domain share a common power source and network switch.
        /// If not specified, defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).
        /// This property cannot be updated.
        /// </summary>
        int? ComputeProfilePlatformFaultDomainCount { get; set; }
        /// <summary>Mode of the Fleet.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Managed", "Launch")]
        string Mode { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Creating", "Updating", "Deleting", "Migrating")]
        string ProvisioningState { get; set; }
        /// <summary>Configuration Options for Regular instances in Compute Fleet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile RegularPriorityProfile { get; set; }
        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("LowestPrice", "Prioritized")]
        string RegularPriorityProfileAllocationStrategy { get; set; }
        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        int? RegularPriorityProfileCapacity { get; set; }
        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        int? RegularPriorityProfileMinCapacity { get; set; }
        /// <summary>Configuration Options for Spot instances in Compute Fleet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile SpotPriorityProfile { get; set; }
        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("PriceCapacityOptimized", "LowestPrice", "CapacityOptimized")]
        string SpotPriorityProfileAllocationStrategy { get; set; }
        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        int? SpotPriorityProfileCapacity { get; set; }
        /// <summary>Eviction Policy to follow when evicting Spot VMs.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Delete", "Deallocate")]
        string SpotPriorityProfileEvictionPolicy { get; set; }
        /// <summary>
        /// Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.
        /// If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)
        /// or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint)
        /// in order to achieve the desired capacity.
        /// Maintain is enabled by default.
        /// </summary>
        bool? SpotPriorityProfileMaintain { get; set; }
        /// <summary>Price per hour of each Spot VM will never exceed this.</summary>
        float? SpotPriorityProfileMaxPricePerVM { get; set; }
        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        int? SpotPriorityProfileMinCapacity { get; set; }
        /// <summary>Specifies the time at which the Compute Fleet is created.</summary>
        global::System.DateTime? TimeCreated { get; set; }
        /// <summary>Specifies the ID which uniquely identifies a Compute Fleet.</summary>
        string UniqueId { get; set; }
        /// <summary>Attribute based Fleet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes VMAttribute { get; set; }
        /// <summary>
        /// VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.
        /// </summary>
        string VMNamePrefix { get; set; }
        /// <summary>List of VM sizes supported for Compute Fleet</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> VMSizesProfile { get; set; }
        /// <summary>Zone Allocation Policy for Fleet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy ZoneAllocationPolicy { get; set; }
        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        string ZoneAllocationPolicyDistributionStrategy { get; set; }
        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZoneAllocationPolicyZonePreference { get; set; }

    }
}