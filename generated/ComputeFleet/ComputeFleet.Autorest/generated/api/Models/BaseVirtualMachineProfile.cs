// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>Describes the base virtual machine profile for fleet</summary>
    public partial class BaseVirtualMachineProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal
    {

        /// <summary>Backing field for <see cref="ApplicationProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile _applicationProfile;

        /// <summary>Specifies the gallery applications that should be made available to the VM/VMSS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile ApplicationProfile { get => (this._applicationProfile = this._applicationProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApplicationProfile()); set => this._applicationProfile = value; }

        /// <summary>Specifies the gallery applications that should be made available to the VM/VMSS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication> ApplicationProfileGalleryApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfileInternal)ApplicationProfile).GalleryApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfileInternal)ApplicationProfile).GalleryApplication = value ?? null /* arrayOf */; }

        /// <summary>Whether boot diagnostics should be enabled on the Virtual Machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? BootDiagnosticEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnosticEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnosticEnabled = value ?? default(bool); }

        /// <summary>
        /// Uri of the storage account to use for placing the console output and
        /// screenshot. If storageUri is not specified while enabling boot diagnostics,
        /// managed storage will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string BootDiagnosticStorageUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnosticStorageUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnosticStorageUri = value ?? null; }

        /// <summary>Backing field for <see cref="CapacityReservation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile _capacityReservation;

        /// <summary>
        /// Specifies the capacity reservation related details of a scale set. Minimum
        /// api-version: 2021-04-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile CapacityReservation { get => (this._capacityReservation = this._capacityReservation ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.CapacityReservationProfile()); set => this._capacityReservation = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string CapacityReservationGroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfileInternal)CapacityReservation).CapacityReservationGroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfileInternal)CapacityReservation).CapacityReservationGroupId = value ?? null; }

        /// <summary>Backing field for <see cref="DiagnosticsProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile _diagnosticsProfile;

        /// <summary>Specifies the boot diagnostic settings state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile DiagnosticsProfile { get => (this._diagnosticsProfile = this._diagnosticsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.DiagnosticsProfile()); set => this._diagnosticsProfile = value; }

        /// <summary>Specifies ARM Resource ID of one of the user identities associated with the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string EncryptionIdentityUserAssignedIdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionIdentityUserAssignedIdentityResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionIdentityUserAssignedIdentityResourceId = value ?? null; }

        /// <summary>Backing field for <see cref="ExtensionProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile _extensionProfile;

        /// <summary>
        /// Specifies a collection of settings for extensions installed on virtual machines
        /// in the scale set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile ExtensionProfile { get => (this._extensionProfile = this._extensionProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile()); set => this._extensionProfile = value; }

        /// <summary>The virtual machine scale set child extension resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension> ExtensionProfileExtension { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfileInternal)ExtensionProfile).Extension; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfileInternal)ExtensionProfile).Extension = value ?? null /* arrayOf */; }

        /// <summary>
        /// Specifies the time alloted for all extensions to start. The time duration
        /// should be between 15 minutes and 120 minutes (inclusive) and should be
        /// specified in ISO 8601 format. The default value is 90 minutes (PT1H30M).
        /// Minimum api-version: 2020-06-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ExtensionProfileExtensionsTimeBudget { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfileInternal)ExtensionProfile).ExtensionsTimeBudget; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfileInternal)ExtensionProfile).ExtensionsTimeBudget = value ?? null; }

        /// <summary>Backing field for <see cref="HardwareProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile _hardwareProfile;

        /// <summary>
        /// Specifies the hardware profile related details of a scale set. Minimum
        /// api-version: 2021-11-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetHardwareProfile()); set => this._hardwareProfile = value; }

        /// <summary>
        /// The ARM resource id in the form of
        /// /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string HealthProbeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).HealthProbeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).HealthProbeId = value ?? null; }

        /// <summary>Backing field for <see cref="LicenseType" /> property.</summary>
        private string _licenseType;

        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises.
        /// <br><br> Possible values for Windows Server operating system are: <br><br>
        /// Windows_Client <br><br> Windows_Server <br><br> Possible values for Linux
        /// Server operating system are: <br><br> RHEL_BYOS (for RHEL) <br><br> SLES_BYOS
        /// (for SUSE) <br><br> For more information, see [Azure Hybrid Use Benefit for
        /// Windows
        /// Server](https://learn.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing)
        /// <br><br> [Azure Hybrid Use Benefit for Linux
        /// Server](https://learn.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux)
        /// <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string LicenseType { get => this._licenseType; set => this._licenseType = value; }

        /// <summary>Internal Acessors for ApplicationProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ApplicationProfile { get => (this._applicationProfile = this._applicationProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApplicationProfile()); set { {_applicationProfile = value;} } }

        /// <summary>Internal Acessors for CapacityReservation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.CapacityReservation { get => (this._capacityReservation = this._capacityReservation ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.CapacityReservationProfile()); set { {_capacityReservation = value;} } }

        /// <summary>Internal Acessors for CapacityReservationGroup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.CapacityReservationGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfileInternal)CapacityReservation).CapacityReservationGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfileInternal)CapacityReservation).CapacityReservationGroup = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DiagnosticProfileBootDiagnostic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBootDiagnostics Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.DiagnosticProfileBootDiagnostic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnostic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfileInternal)DiagnosticsProfile).BootDiagnostic = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DiagnosticsProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.DiagnosticsProfile { get => (this._diagnosticsProfile = this._diagnosticsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.DiagnosticsProfile()); set { {_diagnosticsProfile = value;} } }

        /// <summary>Internal Acessors for ExtensionProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ExtensionProfile { get => (this._extensionProfile = this._extensionProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile()); set { {_extensionProfile = value;} } }

        /// <summary>Internal Acessors for HardwareProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.HardwareProfile { get => (this._hardwareProfile = this._hardwareProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetHardwareProfile()); set { {_hardwareProfile = value;} } }

        /// <summary>Internal Acessors for HardwareProfileVMSizeProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProperties Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.HardwareProfileVMSizeProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizeProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizeProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for NetworkProfileHealthProbe</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApiEntityReference Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.NetworkProfileHealthProbe { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).HealthProbe; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).HealthProbe = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ScheduledEventProfileOSImageNotificationProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IOSImageNotificationProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ScheduledEventProfileOSImageNotificationProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ScheduledEventProfileTerminateNotificationProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITerminateNotificationProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ScheduledEventProfileTerminateNotificationProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfile = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ScheduledEventsProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ScheduledEventsProfile { get => (this._scheduledEventsProfile = this._scheduledEventsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ScheduledEventsProfile()); set { {_scheduledEventsProfile = value;} } }

        /// <summary>Internal Acessors for SecurityPostureReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.SecurityPostureReference { get => (this._securityPostureReference = this._securityPostureReference ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityPostureReference()); set { {_securityPostureReference = value;} } }

        /// <summary>Internal Acessors for SecurityProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.SecurityProfile { get => (this._securityProfile = this._securityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityProfile()); set { {_securityProfile = value;} } }

        /// <summary>Internal Acessors for SecurityProfileEncryptionIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IEncryptionIdentity Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.SecurityProfileEncryptionIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SecurityProfileProxyAgentSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IProxyAgentSettings Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.SecurityProfileProxyAgentSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSetting = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SecurityProfileUefiSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IUefiSettings Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.SecurityProfileUefiSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSetting = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ServiceArtifactReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.ServiceArtifactReference { get => (this._serviceArtifactReference = this._serviceArtifactReference ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ServiceArtifactReference()); set { {_serviceArtifactReference = value;} } }

        /// <summary>Internal Acessors for TimeCreated</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal.TimeCreated { get => this._timeCreated; set { {_timeCreated = value;} } }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile _networkProfile;

        /// <summary>
        /// Specifies properties of the network interfaces of the virtual machines in the
        /// scale set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile()); set => this._networkProfile = value; }

        /// <summary>
        /// specifies the Microsoft.Network API version used when creating networking
        /// resources in the Network Interface Configurations for Virtual Machine Scale Set
        /// with orchestration mode 'Flexible'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string NetworkProfileNetworkApiVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).NetworkApiVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).NetworkApiVersion = value ?? null; }

        /// <summary>The list of network configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration> NetworkProfileNetworkInterfaceConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).NetworkInterfaceConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfileInternal)NetworkProfile).NetworkInterfaceConfiguration = value ?? null /* arrayOf */; }

        /// <summary>Specifies whether the OS Image Scheduled event is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? OSImageNotificationProfileEnable { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfileEnable; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfileEnable = value ?? default(bool); }

        /// <summary>
        /// Length of time a Virtual Machine being reimaged or having its OS upgraded will
        /// have to potentially approve the OS Image Scheduled Event before the event is
        /// auto approved (timed out). The configuration is specified in ISO 8601 format,
        /// and the value must not exceed 15 minutes (PT15M)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string OSImageNotificationProfileNotBeforeTimeout { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfileNotBeforeTimeout; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).OSImageNotificationProfileNotBeforeTimeout = value ?? null; }

        /// <summary>Backing field for <see cref="OSProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile _oSProfile;

        /// <summary>
        /// Specifies the operating system settings for the virtual machines in the scale
        /// set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile()); set => this._oSProfile = value; }

        /// <summary>
        /// Specifies whether ProxyAgent feature should be enabled on the virtual machine
        /// or virtual machine scale set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? ProxyAgentSettingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingEnabled = value ?? default(bool); }

        /// <summary>
        /// Increase the value of this property allows user to reset the key used for
        /// securing communication channel between guest and host.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? ProxyAgentSettingKeyIncarnationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingKeyIncarnationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingKeyIncarnationId = value ?? default(int); }

        /// <summary>
        /// Specifies the mode that ProxyAgent will execute on if the feature is enabled.
        /// ProxyAgent will start to audit or monitor but not enforce access control over
        /// requests to host endpoints in Audit mode, while in Enforce mode it will enforce
        /// access control. The default value is Enforce mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ProxyAgentSettingMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).ProxyAgentSettingMode = value ?? null; }

        /// <summary>Backing field for <see cref="ScheduledEventsProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile _scheduledEventsProfile;

        /// <summary>Specifies Scheduled Event related configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile ScheduledEventsProfile { get => (this._scheduledEventsProfile = this._scheduledEventsProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ScheduledEventsProfile()); set => this._scheduledEventsProfile = value; }

        /// <summary>Backing field for <see cref="SecurityPostureReference" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference _securityPostureReference;

        /// <summary>
        /// Specifies the security posture to be used for all virtual machines in the scale
        /// set. Minimum api-version: 2023-03-01
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference SecurityPostureReference { get => (this._securityPostureReference = this._securityPostureReference ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityPostureReference()); set => this._securityPostureReference = value; }

        /// <summary>
        /// List of virtual machine extension names to exclude when applying the security
        /// posture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> SecurityPostureReferenceExcludeExtension { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).ExcludeExtension; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).ExcludeExtension = value ?? null /* arrayOf */; }

        /// <summary>
        /// The security posture reference id in the form of
        /// /CommunityGalleries/{communityGalleryName}/securityPostures/{securityPostureName}/versions/{major.minor.patch}|{major.*}|latest
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SecurityPostureReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).Id = value ?? null; }

        /// <summary>Whether the security posture can be overridden by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? SecurityPostureReferenceIsOverridable { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).IsOverridable; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReferenceInternal)SecurityPostureReference).IsOverridable = value ?? default(bool); }

        /// <summary>Backing field for <see cref="SecurityProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile _securityProfile;

        /// <summary>
        /// Specifies the Security related profile settings for the virtual machines in the
        /// scale set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile SecurityProfile { get => (this._securityProfile = this._securityProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityProfile()); set => this._securityProfile = value; }

        /// <summary>
        /// This property can be used by user in the request to enable or disable the Host
        /// Encryption for the virtual machine or virtual machine scale set. This will
        /// enable the encryption for all the disks including Resource/Temp disk at host
        /// itself. The default behavior is: The Encryption at host will be disabled unless
        /// this property is set to true for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? SecurityProfileEncryptionAtHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionAtHost; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).EncryptionAtHost = value ?? default(bool); }

        /// <summary>
        /// Specifies the SecurityType of the virtual machine. It has to be set to any
        /// specified value to enable UefiSettings. The default behavior is: UefiSettings
        /// will not be enabled unless this property is set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string SecurityProfileSecurityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).SecurityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).SecurityType = value ?? null; }

        /// <summary>Backing field for <see cref="ServiceArtifactReference" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference _serviceArtifactReference;

        /// <summary>
        /// Specifies the service artifact reference id used to set same image version for
        /// all virtual machines in the scale set when using 'latest' image version.
        /// Minimum api-version: 2022-11-01
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference ServiceArtifactReference { get => (this._serviceArtifactReference = this._serviceArtifactReference ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ServiceArtifactReference()); set => this._serviceArtifactReference = value; }

        /// <summary>
        /// The service artifact reference id in the form of
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/galleries/{galleryName}/serviceArtifacts/{serviceArtifactName}/vmArtifactsProfiles/{vmArtifactsProfilesName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string ServiceArtifactReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReferenceInternal)ServiceArtifactReference).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReferenceInternal)ServiceArtifactReference).Id = value ?? null; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile _storageProfile;

        /// <summary>Specifies the storage settings for the virtual machine disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile()); set => this._storageProfile = value; }

        /// <summary>Specifies whether the Terminate Scheduled event is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? TerminateNotificationProfileEnable { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfileEnable; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfileEnable = value ?? default(bool); }

        /// <summary>
        /// Configurable length of time a Virtual Machine being deleted will have to
        /// potentially approve the Terminate Scheduled Event before the event is auto
        /// approved (timed out). The configuration must be specified in ISO 8601 format,
        /// the default value is 5 minutes (PT5M)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string TerminateNotificationProfileNotBeforeTimeout { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfileNotBeforeTimeout; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfileInternal)ScheduledEventsProfile).TerminateNotificationProfileNotBeforeTimeout = value ?? null; }

        /// <summary>Backing field for <see cref="TimeCreated" /> property.</summary>
        private global::System.DateTime? _timeCreated;

        /// <summary>
        /// Specifies the time in which this VM profile for the Virtual Machine Scale Set
        /// was created. Minimum API version for this property is 2023-09-01. This value
        /// will be added to VMSS Flex VM tags when creating/updating the VMSS VM Profile
        /// with minimum api-version 2023-09-01. Examples: "2024-07-01T00:00:01.1234567+00:00"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeCreated { get => this._timeCreated; }

        /// <summary>
        /// Specifies whether secure boot should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? UefiSettingSecureBootEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSettingSecureBootEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSettingSecureBootEnabled = value ?? default(bool); }

        /// <summary>
        /// Specifies whether vTPM should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? UefiSettingVTpmEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSettingVTpmEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfileInternal)SecurityProfile).UefiSettingVTpmEnabled = value ?? default(bool); }

        /// <summary>Backing field for <see cref="UserData" /> property.</summary>
        private string _userData;

        /// <summary>
        /// UserData for the virtual machines in the scale set, which must be base-64
        /// encoded. Customer should not pass any secrets in here. Minimum api-version:
        /// 2021-03-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string UserData { get => this._userData; set => this._userData = value; }

        /// <summary>
        /// Specifies the number of vCPUs available for the VM. When this property is not
        /// specified in the request body the default behavior is to set it to the value of
        /// vCPUs available for that VM size exposed in api response of [List all available
        /// virtual machine sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? VMSizePropertyVcpUsAvailable { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizePropertyVcpUsAvailable; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizePropertyVcpUsAvailable = value ?? default(int); }

        /// <summary>
        /// Specifies the vCPU to physical core ratio. When this property is not specified
        /// in the request body the default behavior is set to the value of vCPUsPerCore
        /// for the VM Size exposed in api response of [List all available virtual machine
        /// sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// **Setting this property to 1 also means that hyper-threading is disabled.**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public int? VMSizePropertyVcpUsPerCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizePropertyVcpUsPerCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfileInternal)HardwareProfile).VMSizePropertyVcpUsPerCore = value ?? default(int); }

        /// <summary>Creates an new <see cref="BaseVirtualMachineProfile" /> instance.</summary>
        public BaseVirtualMachineProfile()
        {

        }
    }
    /// Describes the base virtual machine profile for fleet
    public partial interface IBaseVirtualMachineProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the gallery applications that should be made available to the VM/VMSS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the gallery applications that should be made available to the VM/VMSS",
        SerializedName = @"galleryApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication> ApplicationProfileGalleryApplication { get; set; }
        /// <summary>Whether boot diagnostics should be enabled on the Virtual Machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether boot diagnostics should be enabled on the Virtual Machine.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BootDiagnosticEnabled { get; set; }
        /// <summary>
        /// Uri of the storage account to use for placing the console output and
        /// screenshot. If storageUri is not specified while enabling boot diagnostics,
        /// managed storage will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Uri of the storage account to use for placing the console output and
        screenshot. If storageUri is not specified while enabling boot diagnostics,
        managed storage will be used.",
        SerializedName = @"storageUri",
        PossibleTypes = new [] { typeof(string) })]
        string BootDiagnosticStorageUri { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string CapacityReservationGroupId { get; set; }
        /// <summary>Specifies ARM Resource ID of one of the user identities associated with the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies ARM Resource ID of one of the user identities associated with the VM.",
        SerializedName = @"userAssignedIdentityResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionIdentityUserAssignedIdentityResourceId { get; set; }
        /// <summary>The virtual machine scale set child extension resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The virtual machine scale set child extension resources.",
        SerializedName = @"extensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension> ExtensionProfileExtension { get; set; }
        /// <summary>
        /// Specifies the time alloted for all extensions to start. The time duration
        /// should be between 15 minutes and 120 minutes (inclusive) and should be
        /// specified in ISO 8601 format. The default value is 90 minutes (PT1H30M).
        /// Minimum api-version: 2020-06-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the time alloted for all extensions to start. The time duration
        should be between 15 minutes and 120 minutes (inclusive) and should be
        specified in ISO 8601 format. The default value is 90 minutes (PT1H30M).
        Minimum api-version: 2020-06-01.",
        SerializedName = @"extensionsTimeBudget",
        PossibleTypes = new [] { typeof(string) })]
        string ExtensionProfileExtensionsTimeBudget { get; set; }
        /// <summary>
        /// The ARM resource id in the form of
        /// /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ARM resource id in the form of
        /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string HealthProbeId { get; set; }
        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises.
        /// <br><br> Possible values for Windows Server operating system are: <br><br>
        /// Windows_Client <br><br> Windows_Server <br><br> Possible values for Linux
        /// Server operating system are: <br><br> RHEL_BYOS (for RHEL) <br><br> SLES_BYOS
        /// (for SUSE) <br><br> For more information, see [Azure Hybrid Use Benefit for
        /// Windows
        /// Server](https://learn.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing)
        /// <br><br> [Azure Hybrid Use Benefit for Linux
        /// Server](https://learn.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux)
        /// <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies that the image or disk that is being used was licensed on-premises.
        <br><br> Possible values for Windows Server operating system are: <br><br>
        Windows_Client <br><br> Windows_Server <br><br> Possible values for Linux
        Server operating system are: <br><br> RHEL_BYOS (for RHEL) <br><br> SLES_BYOS
        (for SUSE) <br><br> For more information, see [Azure Hybrid Use Benefit for
        Windows
        Server](https://learn.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing)
        <br><br> [Azure Hybrid Use Benefit for Linux
        Server](https://learn.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux)
        <br><br> Minimum api-version: 2015-06-15",
        SerializedName = @"licenseType",
        PossibleTypes = new [] { typeof(string) })]
        string LicenseType { get; set; }
        /// <summary>
        /// specifies the Microsoft.Network API version used when creating networking
        /// resources in the Network Interface Configurations for Virtual Machine Scale Set
        /// with orchestration mode 'Flexible'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"specifies the Microsoft.Network API version used when creating networking
        resources in the Network Interface Configurations for Virtual Machine Scale Set
        with orchestration mode 'Flexible'",
        SerializedName = @"networkApiVersion",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("2020-11-01")]
        string NetworkProfileNetworkApiVersion { get; set; }
        /// <summary>The list of network configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of network configurations.",
        SerializedName = @"networkInterfaceConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration> NetworkProfileNetworkInterfaceConfiguration { get; set; }
        /// <summary>Specifies whether the OS Image Scheduled event is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the OS Image Scheduled event is enabled or disabled.",
        SerializedName = @"enable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? OSImageNotificationProfileEnable { get; set; }
        /// <summary>
        /// Length of time a Virtual Machine being reimaged or having its OS upgraded will
        /// have to potentially approve the OS Image Scheduled Event before the event is
        /// auto approved (timed out). The configuration is specified in ISO 8601 format,
        /// and the value must not exceed 15 minutes (PT15M)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Length of time a Virtual Machine being reimaged or having its OS upgraded will
        have to potentially approve the OS Image Scheduled Event before the event is
        auto approved (timed out). The configuration is specified in ISO 8601 format,
        and the value must not exceed 15 minutes (PT15M)",
        SerializedName = @"notBeforeTimeout",
        PossibleTypes = new [] { typeof(string) })]
        string OSImageNotificationProfileNotBeforeTimeout { get; set; }
        /// <summary>
        /// Specifies the operating system settings for the virtual machines in the scale
        /// set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the operating system settings for the virtual machines in the scale
        set.",
        SerializedName = @"osProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile OSProfile { get; set; }
        /// <summary>
        /// Specifies whether ProxyAgent feature should be enabled on the virtual machine
        /// or virtual machine scale set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether ProxyAgent feature should be enabled on the virtual machine
        or virtual machine scale set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ProxyAgentSettingEnabled { get; set; }
        /// <summary>
        /// Increase the value of this property allows user to reset the key used for
        /// securing communication channel between guest and host.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Increase the value of this property allows user to reset the key used for
        securing communication channel between guest and host.",
        SerializedName = @"keyIncarnationId",
        PossibleTypes = new [] { typeof(int) })]
        int? ProxyAgentSettingKeyIncarnationId { get; set; }
        /// <summary>
        /// Specifies the mode that ProxyAgent will execute on if the feature is enabled.
        /// ProxyAgent will start to audit or monitor but not enforce access control over
        /// requests to host endpoints in Audit mode, while in Enforce mode it will enforce
        /// access control. The default value is Enforce mode.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the mode that ProxyAgent will execute on if the feature is enabled.
        ProxyAgent will start to audit or monitor but not enforce access control over
        requests to host endpoints in Audit mode, while in Enforce mode it will enforce
        access control. The default value is Enforce mode.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Audit", "Enforce")]
        string ProxyAgentSettingMode { get; set; }
        /// <summary>
        /// List of virtual machine extension names to exclude when applying the security
        /// posture.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of virtual machine extension names to exclude when applying the security
        posture.",
        SerializedName = @"excludeExtensions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SecurityPostureReferenceExcludeExtension { get; set; }
        /// <summary>
        /// The security posture reference id in the form of
        /// /CommunityGalleries/{communityGalleryName}/securityPostures/{securityPostureName}/versions/{major.minor.patch}|{major.*}|latest
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The security posture reference id in the form of
        /CommunityGalleries/{communityGalleryName}/securityPostures/{securityPostureName}/versions/{major.minor.patch}|{major.*}|latest",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SecurityPostureReferenceId { get; set; }
        /// <summary>Whether the security posture can be overridden by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether the security posture can be overridden by the user.",
        SerializedName = @"isOverridable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecurityPostureReferenceIsOverridable { get; set; }
        /// <summary>
        /// This property can be used by user in the request to enable or disable the Host
        /// Encryption for the virtual machine or virtual machine scale set. This will
        /// enable the encryption for all the disks including Resource/Temp disk at host
        /// itself. The default behavior is: The Encryption at host will be disabled unless
        /// this property is set to true for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This property can be used by user in the request to enable or disable the Host
        Encryption for the virtual machine or virtual machine scale set. This will
        enable the encryption for all the disks including Resource/Temp disk at host
        itself. The default behavior is: The Encryption at host will be disabled unless
        this property is set to true for the resource.",
        SerializedName = @"encryptionAtHost",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecurityProfileEncryptionAtHost { get; set; }
        /// <summary>
        /// Specifies the SecurityType of the virtual machine. It has to be set to any
        /// specified value to enable UefiSettings. The default behavior is: UefiSettings
        /// will not be enabled unless this property is set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the SecurityType of the virtual machine. It has to be set to any
        specified value to enable UefiSettings. The default behavior is: UefiSettings
        will not be enabled unless this property is set.",
        SerializedName = @"securityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("TrustedLaunch", "ConfidentialVM")]
        string SecurityProfileSecurityType { get; set; }
        /// <summary>
        /// The service artifact reference id in the form of
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/galleries/{galleryName}/serviceArtifacts/{serviceArtifactName}/vmArtifactsProfiles/{vmArtifactsProfilesName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The service artifact reference id in the form of
        /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/galleries/{galleryName}/serviceArtifacts/{serviceArtifactName}/vmArtifactsProfiles/{vmArtifactsProfilesName}",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceArtifactReferenceId { get; set; }
        /// <summary>Specifies the storage settings for the virtual machine disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the storage settings for the virtual machine disks.",
        SerializedName = @"storageProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile StorageProfile { get; set; }
        /// <summary>Specifies whether the Terminate Scheduled event is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the Terminate Scheduled event is enabled or disabled.",
        SerializedName = @"enable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TerminateNotificationProfileEnable { get; set; }
        /// <summary>
        /// Configurable length of time a Virtual Machine being deleted will have to
        /// potentially approve the Terminate Scheduled Event before the event is auto
        /// approved (timed out). The configuration must be specified in ISO 8601 format,
        /// the default value is 5 minutes (PT5M)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Configurable length of time a Virtual Machine being deleted will have to
        potentially approve the Terminate Scheduled Event before the event is auto
        approved (timed out). The configuration must be specified in ISO 8601 format,
        the default value is 5 minutes (PT5M)",
        SerializedName = @"notBeforeTimeout",
        PossibleTypes = new [] { typeof(string) })]
        string TerminateNotificationProfileNotBeforeTimeout { get; set; }
        /// <summary>
        /// Specifies the time in which this VM profile for the Virtual Machine Scale Set
        /// was created. Minimum API version for this property is 2023-09-01. This value
        /// will be added to VMSS Flex VM tags when creating/updating the VMSS VM Profile
        /// with minimum api-version 2023-09-01. Examples: "2024-07-01T00:00:01.1234567+00:00"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Specifies the time in which this VM profile for the Virtual Machine Scale Set
        was created. Minimum API version for this property is 2023-09-01. This value
        will be added to VMSS Flex VM tags when creating/updating the VMSS VM Profile
        with minimum api-version 2023-09-01. Examples: ""2024-07-01T00:00:01.1234567+00:00""",
        SerializedName = @"timeCreated",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeCreated { get;  }
        /// <summary>
        /// Specifies whether secure boot should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether secure boot should be enabled on the virtual machine. Minimum
        api-version: 2020-12-01.",
        SerializedName = @"secureBootEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UefiSettingSecureBootEnabled { get; set; }
        /// <summary>
        /// Specifies whether vTPM should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether vTPM should be enabled on the virtual machine. Minimum
        api-version: 2020-12-01.",
        SerializedName = @"vTpmEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UefiSettingVTpmEnabled { get; set; }
        /// <summary>
        /// UserData for the virtual machines in the scale set, which must be base-64
        /// encoded. Customer should not pass any secrets in here. Minimum api-version:
        /// 2021-03-01.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"UserData for the virtual machines in the scale set, which must be base-64
        encoded. Customer should not pass any secrets in here. Minimum api-version:
        2021-03-01.",
        SerializedName = @"userData",
        PossibleTypes = new [] { typeof(string) })]
        string UserData { get; set; }
        /// <summary>
        /// Specifies the number of vCPUs available for the VM. When this property is not
        /// specified in the request body the default behavior is to set it to the value of
        /// vCPUs available for that VM size exposed in api response of [List all available
        /// virtual machine sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the number of vCPUs available for the VM. When this property is not
        specified in the request body the default behavior is to set it to the value of
        vCPUs available for that VM size exposed in api response of [List all available
        virtual machine sizes in a
        region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).",
        SerializedName = @"vCPUsAvailable",
        PossibleTypes = new [] { typeof(int) })]
        int? VMSizePropertyVcpUsAvailable { get; set; }
        /// <summary>
        /// Specifies the vCPU to physical core ratio. When this property is not specified
        /// in the request body the default behavior is set to the value of vCPUsPerCore
        /// for the VM Size exposed in api response of [List all available virtual machine
        /// sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// **Setting this property to 1 also means that hyper-threading is disabled.**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the vCPU to physical core ratio. When this property is not specified
        in the request body the default behavior is set to the value of vCPUsPerCore
        for the VM Size exposed in api response of [List all available virtual machine
        sizes in a
        region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        **Setting this property to 1 also means that hyper-threading is disabled.**",
        SerializedName = @"vCPUsPerCore",
        PossibleTypes = new [] { typeof(int) })]
        int? VMSizePropertyVcpUsPerCore { get; set; }

    }
    /// Describes the base virtual machine profile for fleet
    internal partial interface IBaseVirtualMachineProfileInternal

    {
        /// <summary>Specifies the gallery applications that should be made available to the VM/VMSS</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile ApplicationProfile { get; set; }
        /// <summary>Specifies the gallery applications that should be made available to the VM/VMSS</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication> ApplicationProfileGalleryApplication { get; set; }
        /// <summary>Whether boot diagnostics should be enabled on the Virtual Machine.</summary>
        bool? BootDiagnosticEnabled { get; set; }
        /// <summary>
        /// Uri of the storage account to use for placing the console output and
        /// screenshot. If storageUri is not specified while enabling boot diagnostics,
        /// managed storage will be used.
        /// </summary>
        string BootDiagnosticStorageUri { get; set; }
        /// <summary>
        /// Specifies the capacity reservation related details of a scale set. Minimum
        /// api-version: 2021-04-01.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile CapacityReservation { get; set; }
        /// <summary>
        /// Specifies the capacity reservation group resource id that should be used for
        /// allocating the virtual machine or scaleset vm instances provided enough
        /// capacity has been reserved. Please refer to https://aka.ms/CapacityReservation
        /// for more details.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource CapacityReservationGroup { get; set; }
        /// <summary>Resource Id</summary>
        string CapacityReservationGroupId { get; set; }
        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output
        /// and Screenshot to diagnose VM status. **NOTE**: If storageUri is being
        /// specified then ensure that the storage account is in the same region and
        /// subscription as the VM. You can easily view the output of your console log.
        /// Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBootDiagnostics DiagnosticProfileBootDiagnostic { get; set; }
        /// <summary>Specifies the boot diagnostic settings state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile DiagnosticsProfile { get; set; }
        /// <summary>Specifies ARM Resource ID of one of the user identities associated with the VM.</summary>
        string EncryptionIdentityUserAssignedIdentityResourceId { get; set; }
        /// <summary>
        /// Specifies a collection of settings for extensions installed on virtual machines
        /// in the scale set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile ExtensionProfile { get; set; }
        /// <summary>The virtual machine scale set child extension resources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension> ExtensionProfileExtension { get; set; }
        /// <summary>
        /// Specifies the time alloted for all extensions to start. The time duration
        /// should be between 15 minutes and 120 minutes (inclusive) and should be
        /// specified in ISO 8601 format. The default value is 90 minutes (PT1H30M).
        /// Minimum api-version: 2020-06-01.
        /// </summary>
        string ExtensionProfileExtensionsTimeBudget { get; set; }
        /// <summary>
        /// Specifies the hardware profile related details of a scale set. Minimum
        /// api-version: 2021-11-01.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile HardwareProfile { get; set; }
        /// <summary>
        /// Specifies the properties for customizing the size of the virtual machine.
        /// Minimum api-version: 2021-11-01. Please follow the instructions in [VM
        /// Customization](https://aka.ms/vmcustomization) for more details.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProperties HardwareProfileVMSizeProperty { get; set; }
        /// <summary>
        /// The ARM resource id in the form of
        /// /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string HealthProbeId { get; set; }
        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises.
        /// <br><br> Possible values for Windows Server operating system are: <br><br>
        /// Windows_Client <br><br> Windows_Server <br><br> Possible values for Linux
        /// Server operating system are: <br><br> RHEL_BYOS (for RHEL) <br><br> SLES_BYOS
        /// (for SUSE) <br><br> For more information, see [Azure Hybrid Use Benefit for
        /// Windows
        /// Server](https://learn.microsoft.com/azure/virtual-machines/windows/hybrid-use-benefit-licensing)
        /// <br><br> [Azure Hybrid Use Benefit for Linux
        /// Server](https://learn.microsoft.com/azure/virtual-machines/linux/azure-hybrid-benefit-linux)
        /// <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        string LicenseType { get; set; }
        /// <summary>
        /// Specifies properties of the network interfaces of the virtual machines in the
        /// scale set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// A reference to a load balancer probe used to determine the health of an
        /// instance in the virtual machine scale set. The reference will be in the form:
        /// '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApiEntityReference NetworkProfileHealthProbe { get; set; }
        /// <summary>
        /// specifies the Microsoft.Network API version used when creating networking
        /// resources in the Network Interface Configurations for Virtual Machine Scale Set
        /// with orchestration mode 'Flexible'
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("2020-11-01")]
        string NetworkProfileNetworkApiVersion { get; set; }
        /// <summary>The list of network configurations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration> NetworkProfileNetworkInterfaceConfiguration { get; set; }
        /// <summary>Specifies whether the OS Image Scheduled event is enabled or disabled.</summary>
        bool? OSImageNotificationProfileEnable { get; set; }
        /// <summary>
        /// Length of time a Virtual Machine being reimaged or having its OS upgraded will
        /// have to potentially approve the OS Image Scheduled Event before the event is
        /// auto approved (timed out). The configuration is specified in ISO 8601 format,
        /// and the value must not exceed 15 minutes (PT15M)
        /// </summary>
        string OSImageNotificationProfileNotBeforeTimeout { get; set; }
        /// <summary>
        /// Specifies the operating system settings for the virtual machines in the scale
        /// set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile OSProfile { get; set; }
        /// <summary>
        /// Specifies whether ProxyAgent feature should be enabled on the virtual machine
        /// or virtual machine scale set.
        /// </summary>
        bool? ProxyAgentSettingEnabled { get; set; }
        /// <summary>
        /// Increase the value of this property allows user to reset the key used for
        /// securing communication channel between guest and host.
        /// </summary>
        int? ProxyAgentSettingKeyIncarnationId { get; set; }
        /// <summary>
        /// Specifies the mode that ProxyAgent will execute on if the feature is enabled.
        /// ProxyAgent will start to audit or monitor but not enforce access control over
        /// requests to host endpoints in Audit mode, while in Enforce mode it will enforce
        /// access control. The default value is Enforce mode.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Audit", "Enforce")]
        string ProxyAgentSettingMode { get; set; }
        /// <summary>Specifies OS Image Scheduled Event related configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IOSImageNotificationProfile ScheduledEventProfileOSImageNotificationProfile { get; set; }
        /// <summary>Specifies Terminate Scheduled Event related configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITerminateNotificationProfile ScheduledEventProfileTerminateNotificationProfile { get; set; }
        /// <summary>Specifies Scheduled Event related configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile ScheduledEventsProfile { get; set; }
        /// <summary>
        /// Specifies the security posture to be used for all virtual machines in the scale
        /// set. Minimum api-version: 2023-03-01
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference SecurityPostureReference { get; set; }
        /// <summary>
        /// List of virtual machine extension names to exclude when applying the security
        /// posture.
        /// </summary>
        System.Collections.Generic.List<string> SecurityPostureReferenceExcludeExtension { get; set; }
        /// <summary>
        /// The security posture reference id in the form of
        /// /CommunityGalleries/{communityGalleryName}/securityPostures/{securityPostureName}/versions/{major.minor.patch}|{major.*}|latest
        /// </summary>
        string SecurityPostureReferenceId { get; set; }
        /// <summary>Whether the security posture can be overridden by the user.</summary>
        bool? SecurityPostureReferenceIsOverridable { get; set; }
        /// <summary>
        /// Specifies the Security related profile settings for the virtual machines in the
        /// scale set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile SecurityProfile { get; set; }
        /// <summary>
        /// This property can be used by user in the request to enable or disable the Host
        /// Encryption for the virtual machine or virtual machine scale set. This will
        /// enable the encryption for all the disks including Resource/Temp disk at host
        /// itself. The default behavior is: The Encryption at host will be disabled unless
        /// this property is set to true for the resource.
        /// </summary>
        bool? SecurityProfileEncryptionAtHost { get; set; }
        /// <summary>
        /// Specifies the Managed Identity used by ADE to get access token for keyvault
        /// operations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IEncryptionIdentity SecurityProfileEncryptionIdentity { get; set; }
        /// <summary>
        /// Specifies ProxyAgent settings while creating the virtual machine. Minimum
        /// api-version: 2023-09-01.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IProxyAgentSettings SecurityProfileProxyAgentSetting { get; set; }
        /// <summary>
        /// Specifies the SecurityType of the virtual machine. It has to be set to any
        /// specified value to enable UefiSettings. The default behavior is: UefiSettings
        /// will not be enabled unless this property is set.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("TrustedLaunch", "ConfidentialVM")]
        string SecurityProfileSecurityType { get; set; }
        /// <summary>
        /// Specifies the security settings like secure boot and vTPM used while creating
        /// the virtual machine. Minimum api-version: 2020-12-01.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IUefiSettings SecurityProfileUefiSetting { get; set; }
        /// <summary>
        /// Specifies the service artifact reference id used to set same image version for
        /// all virtual machines in the scale set when using 'latest' image version.
        /// Minimum api-version: 2022-11-01
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference ServiceArtifactReference { get; set; }
        /// <summary>
        /// The service artifact reference id in the form of
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/galleries/{galleryName}/serviceArtifacts/{serviceArtifactName}/vmArtifactsProfiles/{vmArtifactsProfilesName}
        /// </summary>
        string ServiceArtifactReferenceId { get; set; }
        /// <summary>Specifies the storage settings for the virtual machine disks.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile StorageProfile { get; set; }
        /// <summary>Specifies whether the Terminate Scheduled event is enabled or disabled.</summary>
        bool? TerminateNotificationProfileEnable { get; set; }
        /// <summary>
        /// Configurable length of time a Virtual Machine being deleted will have to
        /// potentially approve the Terminate Scheduled Event before the event is auto
        /// approved (timed out). The configuration must be specified in ISO 8601 format,
        /// the default value is 5 minutes (PT5M)
        /// </summary>
        string TerminateNotificationProfileNotBeforeTimeout { get; set; }
        /// <summary>
        /// Specifies the time in which this VM profile for the Virtual Machine Scale Set
        /// was created. Minimum API version for this property is 2023-09-01. This value
        /// will be added to VMSS Flex VM tags when creating/updating the VMSS VM Profile
        /// with minimum api-version 2023-09-01. Examples: "2024-07-01T00:00:01.1234567+00:00"
        /// </summary>
        global::System.DateTime? TimeCreated { get; set; }
        /// <summary>
        /// Specifies whether secure boot should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        bool? UefiSettingSecureBootEnabled { get; set; }
        /// <summary>
        /// Specifies whether vTPM should be enabled on the virtual machine. Minimum
        /// api-version: 2020-12-01.
        /// </summary>
        bool? UefiSettingVTpmEnabled { get; set; }
        /// <summary>
        /// UserData for the virtual machines in the scale set, which must be base-64
        /// encoded. Customer should not pass any secrets in here. Minimum api-version:
        /// 2021-03-01.
        /// </summary>
        string UserData { get; set; }
        /// <summary>
        /// Specifies the number of vCPUs available for the VM. When this property is not
        /// specified in the request body the default behavior is to set it to the value of
        /// vCPUs available for that VM size exposed in api response of [List all available
        /// virtual machine sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// </summary>
        int? VMSizePropertyVcpUsAvailable { get; set; }
        /// <summary>
        /// Specifies the vCPU to physical core ratio. When this property is not specified
        /// in the request body the default behavior is set to the value of vCPUsPerCore
        /// for the VM Size exposed in api response of [List all available virtual machine
        /// sizes in a
        /// region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).
        /// **Setting this property to 1 also means that hyper-threading is disabled.**
        /// </summary>
        int? VMSizePropertyVcpUsPerCore { get; set; }

    }
}