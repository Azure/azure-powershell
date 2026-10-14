// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>An Compute Fleet resource</summary>
    public partial class Fleet :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.TrackedResource();

        /// <summary>The list of location profiles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile> AdditionalLocationProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalLocationProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalLocationProfile = value ?? null /* arrayOf */; }

        /// <summary>The flag that enables or disables hibernation capability on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? AdditionalVirtualMachineCapabilityHibernationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalVirtualMachineCapabilityHibernationEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalVirtualMachineCapabilityHibernationEnabled = value ?? default(bool); }

        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account
        /// type on the VM or VMSS.
        /// Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only
        /// if this property is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? AdditionalVirtualMachineCapabilityUltraSsdEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalVirtualMachineCapabilityUltraSsdEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalVirtualMachineCapabilityUltraSsdEnabled = value ?? default(bool); }

        /// <summary>
        /// Specifies capacity type for Fleet Regular and Spot priority profiles.
        /// capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.
        /// Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string CapacityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).CapacityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).CapacityType = value ?? null; }

        /// <summary>
        /// Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile ComputeProfileBaseVirtualMachineProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileBaseVirtualMachineProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileBaseVirtualMachineProfile = value ?? null /* model class */; }

        /// <summary>
        /// Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.
        /// The default value will be the latest supported computeApiVersion by Compute Fleet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ComputeProfileComputeApiVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileComputeApiVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileComputeApiVersion = value ?? null; }

        /// <summary>
        /// Specifies the number of fault domains to use when creating the underlying VMSS.
        /// A fault domain is a logical group of hardware within an Azure datacenter.
        /// VMs in the same fault domain share a common power source and network switch.
        /// If not specified, defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).
        /// This property cannot be updated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? ComputeProfilePlatformFaultDomainCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfilePlatformFaultDomainCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfilePlatformFaultDomainCount = value ?? default(int); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentity _identity;

        /// <summary>The managed service identities assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ManagedServiceIdentity()); set => this._identity = value; }

        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for AdditionalLocationsProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.AdditionalLocationsProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalLocationsProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).AdditionalLocationsProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ComputeProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.ComputeProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ComputeProfileAdditionalVirtualMachineCapability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalCapabilities Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.ComputeProfileAdditionalVirtualMachineCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileAdditionalVirtualMachineCapability; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ComputeProfileAdditionalVirtualMachineCapability = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ManagedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityInternal)Identity).TenantId = value ?? null; }

        /// <summary>Internal Acessors for Plan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlan Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.Plan()); set { {_plan = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for RegularPriorityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.RegularPriorityProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SpotPriorityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.SpotPriorityProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TimeCreated</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.TimeCreated { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).TimeCreated; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).TimeCreated = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).UniqueId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).UniqueId = value ?? null; }

        /// <summary>Internal Acessors for ZoneAllocationPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetInternal.ZoneAllocationPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicy = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>Mode of the Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string Mode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).Mode = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Plan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlan _plan;

        /// <summary>Details of the resource plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlan Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.Plan()); set => this._plan = value; }

        /// <summary>A user defined name of the 3rd Party Artifact that is being procured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string PlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Name = value ?? null; }

        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at
        /// the time of Data Market onboarding.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string PlanProduct { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Product = value ?? null; }

        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string PlanPromotionCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).PromotionCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).PromotionCode = value ?? null; }

        /// <summary>The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string PlanPublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Publisher = value ?? null; }

        /// <summary>The version of the desired product/artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string PlanVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlanInternal)Plan).Version = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string RegularPriorityProfileAllocationStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileAllocationStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileAllocationStrategy = value ?? null; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? RegularPriorityProfileCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileCapacity = value ?? default(int); }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? RegularPriorityProfileMinCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileMinCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).RegularPriorityProfileMinCapacity = value ?? default(int); }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SpotPriorityProfileAllocationStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileAllocationStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileAllocationStrategy = value ?? null; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? SpotPriorityProfileCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileCapacity = value ?? default(int); }

        /// <summary>Eviction Policy to follow when evicting Spot VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SpotPriorityProfileEvictionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileEvictionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileEvictionPolicy = value ?? null; }

        /// <summary>
        /// Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.
        /// If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)
        /// or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint)
        /// in order to achieve the desired capacity.
        /// Maintain is enabled by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? SpotPriorityProfileMaintain { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMaintain; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMaintain = value ?? default(bool); }

        /// <summary>Price per hour of each Spot VM will never exceed this.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public float? SpotPriorityProfileMaxPricePerVM { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMaxPricePerVM; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMaxPricePerVM = value ?? default(float); }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? SpotPriorityProfileMinCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMinCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).SpotPriorityProfileMinCapacity = value ?? default(int); }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>Specifies the time at which the Compute Fleet is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimeCreated { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).TimeCreated; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Specifies the ID which uniquely identifies a Compute Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).UniqueId; }

        /// <summary>Attribute based Fleet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes VMAttribute { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMAttribute; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMAttribute = value ?? null /* model class */; }

        /// <summary>
        /// VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string VMNamePrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMNamePrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMNamePrefix = value ?? null; }

        /// <summary>List of VM sizes supported for Compute Fleet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> VMSizesProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMSizesProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).VMSizesProfile = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private System.Collections.Generic.List<string> _zone;

        /// <summary>Zones in which the Compute Fleet is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ZoneAllocationPolicyDistributionStrategy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicyDistributionStrategy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicyDistributionStrategy = value ?? null; }

        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZoneAllocationPolicyZonePreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicyZonePreference; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)Property).ZoneAllocationPolicyZonePreference = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="Fleet" /> instance.</summary>
        public Fleet()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// An Compute Fleet resource
    public partial interface IFleet :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResource
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
        Required = false,
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
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of managed identity assigned to this resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The identities assigned to this resource by the user.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>A user defined name of the 3rd Party Artifact that is being procured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A user defined name of the 3rd Party Artifact that is being procured.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PlanName { get; set; }
        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at
        /// the time of Data Market onboarding.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string PlanProduct { get; set; }
        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A publisher provided promotion code as provisioned in Data Market for the said product/artifact.",
        SerializedName = @"promotionCode",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPromotionCode { get; set; }
        /// <summary>The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPublisher { get; set; }
        /// <summary>The version of the desired product/artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The version of the desired product/artifact.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string PlanVersion { get; set; }
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
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of VM sizes supported for Compute Fleet",
        SerializedName = @"vmSizesProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile> VMSizesProfile { get; set; }
        /// <summary>Zones in which the Compute Fleet is available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Zones in which the Compute Fleet is available",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Zone { get; set; }
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
    /// An Compute Fleet resource
    internal partial interface IFleetInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceInternal
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
        /// <summary>The managed service identities assigned to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentity Identity { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Mode of the Fleet.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Managed", "Launch")]
        string Mode { get; set; }
        /// <summary>Details of the resource plan.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IPlan Plan { get; set; }
        /// <summary>A user defined name of the 3rd Party Artifact that is being procured.</summary>
        string PlanName { get; set; }
        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at
        /// the time of Data Market onboarding.
        /// </summary>
        string PlanProduct { get; set; }
        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        string PlanPromotionCode { get; set; }
        /// <summary>The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic</summary>
        string PlanPublisher { get; set; }
        /// <summary>The version of the desired product/artifact.</summary>
        string PlanVersion { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties Property { get; set; }
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
        /// <summary>Zones in which the Compute Fleet is available</summary>
        System.Collections.Generic.List<string> Zone { get; set; }
        /// <summary>Zone Allocation Policy for Fleet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy ZoneAllocationPolicy { get; set; }
        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        string ZoneAllocationPolicyDistributionStrategy { get; set; }
        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference> ZoneAllocationPolicyZonePreference { get; set; }

    }
}