// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell;

    /// <summary>Describes the base virtual machine profile for fleet</summary>
    [System.ComponentModel.TypeConverter(typeof(BaseVirtualMachineProfileTypeConverter))]
    public partial class BaseVirtualMachineProfile
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BaseVirtualMachineProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NetworkProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile) content.GetValueForProperty("SecurityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("DiagnosticsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile) content.GetValueForProperty("DiagnosticsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.DiagnosticsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ExtensionProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScheduledEventsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile) content.GetValueForProperty("ScheduledEventsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ScheduledEventsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservation = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile) content.GetValueForProperty("CapacityReservation",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservation, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.CapacityReservationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ApplicationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile) content.GetValueForProperty("ApplicationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApplicationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("HardwareProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile) content.GetValueForProperty("HardwareProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetHardwareProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ServiceArtifactReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReference = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference) content.GetValueForProperty("ServiceArtifactReference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReference, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ServiceArtifactReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityPostureReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReference = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference) content.GetValueForProperty("SecurityPostureReference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReference, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityPostureReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("LicenseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).LicenseType = (string) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).LicenseType, global::System.Convert.ToString);
            }
            if (content.Contains("UserData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UserData = (string) content.GetValueForProperty("UserData",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UserData, global::System.Convert.ToString);
            }
            if (content.Contains("TimeCreated"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TimeCreated = (global::System.DateTime?) content.GetValueForProperty("TimeCreated",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TimeCreated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("OSProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileUefiSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileUefiSetting = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IUefiSettings) content.GetValueForProperty("SecurityProfileUefiSetting",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileUefiSetting, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.UefiSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileEncryptionIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionIdentity = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IEncryptionIdentity) content.GetValueForProperty("SecurityProfileEncryptionIdentity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionIdentity, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.EncryptionIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("DiagnosticProfileBootDiagnostic"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticProfileBootDiagnostic = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBootDiagnostics) content.GetValueForProperty("DiagnosticProfileBootDiagnostic",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticProfileBootDiagnostic, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BootDiagnosticsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ApplicationProfileGalleryApplication"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfileGalleryApplication = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication>) content.GetValueForProperty("ApplicationProfileGalleryApplication",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfileGalleryApplication, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMGalleryApplicationTypeConverter.ConvertFrom));
            }
            if (content.Contains("ServiceArtifactReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReferenceId = (string) content.GetValueForProperty("ServiceArtifactReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkProfileHealthProbe"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileHealthProbe = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApiEntityReference) content.GetValueForProperty("NetworkProfileHealthProbe",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileHealthProbe, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApiEntityReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("NetworkProfileNetworkInterfaceConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkInterfaceConfiguration = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration>) content.GetValueForProperty("NetworkProfileNetworkInterfaceConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkInterfaceConfiguration, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("NetworkProfileNetworkApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkApiVersion = (string) content.GetValueForProperty("NetworkProfileNetworkApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("HealthProbeId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HealthProbeId = (string) content.GetValueForProperty("HealthProbeId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HealthProbeId, global::System.Convert.ToString);
            }
            if (content.Contains("SecurityProfileProxyAgentSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileProxyAgentSetting = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IProxyAgentSettings) content.GetValueForProperty("SecurityProfileProxyAgentSetting",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileProxyAgentSetting, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ProxyAgentSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileEncryptionAtHost"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionAtHost = (bool?) content.GetValueForProperty("SecurityProfileEncryptionAtHost",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionAtHost, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SecurityProfileSecurityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileSecurityType = (string) content.GetValueForProperty("SecurityProfileSecurityType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileSecurityType, global::System.Convert.ToString);
            }
            if (content.Contains("ProxyAgentSettingMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingMode = (string) content.GetValueForProperty("ProxyAgentSettingMode",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingMode, global::System.Convert.ToString);
            }
            if (content.Contains("ExtensionProfileExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtension = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension>) content.GetValueForProperty("ExtensionProfileExtension",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtension, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionTypeConverter.ConvertFrom));
            }
            if (content.Contains("ExtensionProfileExtensionsTimeBudget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtensionsTimeBudget = (string) content.GetValueForProperty("ExtensionProfileExtensionsTimeBudget",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtensionsTimeBudget, global::System.Convert.ToString);
            }
            if (content.Contains("ScheduledEventProfileTerminateNotificationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileTerminateNotificationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITerminateNotificationProfile) content.GetValueForProperty("ScheduledEventProfileTerminateNotificationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileTerminateNotificationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.TerminateNotificationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScheduledEventProfileOSImageNotificationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileOSImageNotificationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IOSImageNotificationProfile) content.GetValueForProperty("ScheduledEventProfileOSImageNotificationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileOSImageNotificationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.OSImageNotificationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservationGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroup = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource) content.GetValueForProperty("CapacityReservationGroup",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroup, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SubResourceTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservationGroupId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroupId = (string) content.GetValueForProperty("CapacityReservationGroupId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroupId, global::System.Convert.ToString);
            }
            if (content.Contains("HardwareProfileVMSizeProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfileVMSizeProperty = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProperties) content.GetValueForProperty("HardwareProfileVMSizeProperty",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfileVMSizeProperty, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityPostureReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceId = (string) content.GetValueForProperty("SecurityPostureReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("SecurityPostureReferenceExcludeExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceExcludeExtension = (System.Collections.Generic.List<string>) content.GetValueForProperty("SecurityPostureReferenceExcludeExtension",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceExcludeExtension, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecurityPostureReferenceIsOverridable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceIsOverridable = (bool?) content.GetValueForProperty("SecurityPostureReferenceIsOverridable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceIsOverridable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UefiSettingSecureBootEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingSecureBootEnabled = (bool?) content.GetValueForProperty("UefiSettingSecureBootEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingSecureBootEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UefiSettingVTpmEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingVTpmEnabled = (bool?) content.GetValueForProperty("UefiSettingVTpmEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingVTpmEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("EncryptionIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).EncryptionIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("EncryptionIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).EncryptionIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ProxyAgentSettingEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingEnabled = (bool?) content.GetValueForProperty("ProxyAgentSettingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("ProxyAgentSettingKeyIncarnationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingKeyIncarnationId = (int?) content.GetValueForProperty("ProxyAgentSettingKeyIncarnationId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingKeyIncarnationId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BootDiagnosticEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticEnabled = (bool?) content.GetValueForProperty("BootDiagnosticEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("BootDiagnosticStorageUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticStorageUri = (string) content.GetValueForProperty("BootDiagnosticStorageUri",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticStorageUri, global::System.Convert.ToString);
            }
            if (content.Contains("TerminateNotificationProfileNotBeforeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileNotBeforeTimeout = (string) content.GetValueForProperty("TerminateNotificationProfileNotBeforeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileNotBeforeTimeout, global::System.Convert.ToString);
            }
            if (content.Contains("TerminateNotificationProfileEnable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileEnable = (bool?) content.GetValueForProperty("TerminateNotificationProfileEnable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileEnable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OSImageNotificationProfileNotBeforeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileNotBeforeTimeout = (string) content.GetValueForProperty("OSImageNotificationProfileNotBeforeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileNotBeforeTimeout, global::System.Convert.ToString);
            }
            if (content.Contains("OSImageNotificationProfileEnable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileEnable = (bool?) content.GetValueForProperty("OSImageNotificationProfileEnable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileEnable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("VMSizePropertyVcpUsAvailable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsAvailable = (int?) content.GetValueForProperty("VMSizePropertyVcpUsAvailable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsAvailable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("VMSizePropertyVcpUsPerCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsPerCore = (int?) content.GetValueForProperty("VMSizePropertyVcpUsPerCore",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsPerCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BaseVirtualMachineProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NetworkProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityProfile) content.GetValueForProperty("SecurityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("DiagnosticsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IDiagnosticsProfile) content.GetValueForProperty("DiagnosticsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.DiagnosticsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ExtensionProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtensionProfile) content.GetValueForProperty("ExtensionProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScheduledEventsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IScheduledEventsProfile) content.GetValueForProperty("ScheduledEventsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ScheduledEventsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservation = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ICapacityReservationProfile) content.GetValueForProperty("CapacityReservation",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservation, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.CapacityReservationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ApplicationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApplicationProfile) content.GetValueForProperty("ApplicationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApplicationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("HardwareProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetHardwareProfile) content.GetValueForProperty("HardwareProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetHardwareProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ServiceArtifactReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReference = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IServiceArtifactReference) content.GetValueForProperty("ServiceArtifactReference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReference, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ServiceArtifactReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityPostureReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReference = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISecurityPostureReference) content.GetValueForProperty("SecurityPostureReference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReference, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SecurityPostureReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("LicenseType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).LicenseType = (string) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).LicenseType, global::System.Convert.ToString);
            }
            if (content.Contains("UserData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UserData = (string) content.GetValueForProperty("UserData",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UserData, global::System.Convert.ToString);
            }
            if (content.Contains("TimeCreated"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TimeCreated = (global::System.DateTime?) content.GetValueForProperty("TimeCreated",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TimeCreated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("OSProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileUefiSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileUefiSetting = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IUefiSettings) content.GetValueForProperty("SecurityProfileUefiSetting",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileUefiSetting, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.UefiSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileEncryptionIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionIdentity = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IEncryptionIdentity) content.GetValueForProperty("SecurityProfileEncryptionIdentity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionIdentity, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.EncryptionIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("DiagnosticProfileBootDiagnostic"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticProfileBootDiagnostic = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBootDiagnostics) content.GetValueForProperty("DiagnosticProfileBootDiagnostic",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).DiagnosticProfileBootDiagnostic, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BootDiagnosticsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ApplicationProfileGalleryApplication"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfileGalleryApplication = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication>) content.GetValueForProperty("ApplicationProfileGalleryApplication",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ApplicationProfileGalleryApplication, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMGalleryApplication>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMGalleryApplicationTypeConverter.ConvertFrom));
            }
            if (content.Contains("ServiceArtifactReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReferenceId = (string) content.GetValueForProperty("ServiceArtifactReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ServiceArtifactReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkProfileHealthProbe"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileHealthProbe = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IApiEntityReference) content.GetValueForProperty("NetworkProfileHealthProbe",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileHealthProbe, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ApiEntityReferenceTypeConverter.ConvertFrom);
            }
            if (content.Contains("NetworkProfileNetworkInterfaceConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkInterfaceConfiguration = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration>) content.GetValueForProperty("NetworkProfileNetworkInterfaceConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkInterfaceConfiguration, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("NetworkProfileNetworkApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkApiVersion = (string) content.GetValueForProperty("NetworkProfileNetworkApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).NetworkProfileNetworkApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("HealthProbeId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HealthProbeId = (string) content.GetValueForProperty("HealthProbeId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HealthProbeId, global::System.Convert.ToString);
            }
            if (content.Contains("SecurityProfileProxyAgentSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileProxyAgentSetting = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IProxyAgentSettings) content.GetValueForProperty("SecurityProfileProxyAgentSetting",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileProxyAgentSetting, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ProxyAgentSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityProfileEncryptionAtHost"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionAtHost = (bool?) content.GetValueForProperty("SecurityProfileEncryptionAtHost",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileEncryptionAtHost, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SecurityProfileSecurityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileSecurityType = (string) content.GetValueForProperty("SecurityProfileSecurityType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityProfileSecurityType, global::System.Convert.ToString);
            }
            if (content.Contains("ProxyAgentSettingMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingMode = (string) content.GetValueForProperty("ProxyAgentSettingMode",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingMode, global::System.Convert.ToString);
            }
            if (content.Contains("ExtensionProfileExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtension = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension>) content.GetValueForProperty("ExtensionProfileExtension",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtension, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetExtensionTypeConverter.ConvertFrom));
            }
            if (content.Contains("ExtensionProfileExtensionsTimeBudget"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtensionsTimeBudget = (string) content.GetValueForProperty("ExtensionProfileExtensionsTimeBudget",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ExtensionProfileExtensionsTimeBudget, global::System.Convert.ToString);
            }
            if (content.Contains("ScheduledEventProfileTerminateNotificationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileTerminateNotificationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITerminateNotificationProfile) content.GetValueForProperty("ScheduledEventProfileTerminateNotificationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileTerminateNotificationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.TerminateNotificationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScheduledEventProfileOSImageNotificationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileOSImageNotificationProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IOSImageNotificationProfile) content.GetValueForProperty("ScheduledEventProfileOSImageNotificationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ScheduledEventProfileOSImageNotificationProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.OSImageNotificationProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservationGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroup = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource) content.GetValueForProperty("CapacityReservationGroup",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroup, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SubResourceTypeConverter.ConvertFrom);
            }
            if (content.Contains("CapacityReservationGroupId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroupId = (string) content.GetValueForProperty("CapacityReservationGroupId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).CapacityReservationGroupId, global::System.Convert.ToString);
            }
            if (content.Contains("HardwareProfileVMSizeProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfileVMSizeProperty = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProperties) content.GetValueForProperty("HardwareProfileVMSizeProperty",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).HardwareProfileVMSizeProperty, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SecurityPostureReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceId = (string) content.GetValueForProperty("SecurityPostureReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("SecurityPostureReferenceExcludeExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceExcludeExtension = (System.Collections.Generic.List<string>) content.GetValueForProperty("SecurityPostureReferenceExcludeExtension",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceExcludeExtension, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SecurityPostureReferenceIsOverridable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceIsOverridable = (bool?) content.GetValueForProperty("SecurityPostureReferenceIsOverridable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).SecurityPostureReferenceIsOverridable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UefiSettingSecureBootEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingSecureBootEnabled = (bool?) content.GetValueForProperty("UefiSettingSecureBootEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingSecureBootEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("UefiSettingVTpmEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingVTpmEnabled = (bool?) content.GetValueForProperty("UefiSettingVTpmEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).UefiSettingVTpmEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("EncryptionIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).EncryptionIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("EncryptionIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).EncryptionIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ProxyAgentSettingEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingEnabled = (bool?) content.GetValueForProperty("ProxyAgentSettingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("ProxyAgentSettingKeyIncarnationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingKeyIncarnationId = (int?) content.GetValueForProperty("ProxyAgentSettingKeyIncarnationId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).ProxyAgentSettingKeyIncarnationId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BootDiagnosticEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticEnabled = (bool?) content.GetValueForProperty("BootDiagnosticEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("BootDiagnosticStorageUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticStorageUri = (string) content.GetValueForProperty("BootDiagnosticStorageUri",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).BootDiagnosticStorageUri, global::System.Convert.ToString);
            }
            if (content.Contains("TerminateNotificationProfileNotBeforeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileNotBeforeTimeout = (string) content.GetValueForProperty("TerminateNotificationProfileNotBeforeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileNotBeforeTimeout, global::System.Convert.ToString);
            }
            if (content.Contains("TerminateNotificationProfileEnable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileEnable = (bool?) content.GetValueForProperty("TerminateNotificationProfileEnable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).TerminateNotificationProfileEnable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OSImageNotificationProfileNotBeforeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileNotBeforeTimeout = (string) content.GetValueForProperty("OSImageNotificationProfileNotBeforeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileNotBeforeTimeout, global::System.Convert.ToString);
            }
            if (content.Contains("OSImageNotificationProfileEnable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileEnable = (bool?) content.GetValueForProperty("OSImageNotificationProfileEnable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).OSImageNotificationProfileEnable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("VMSizePropertyVcpUsAvailable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsAvailable = (int?) content.GetValueForProperty("VMSizePropertyVcpUsAvailable",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsAvailable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("VMSizePropertyVcpUsPerCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsPerCore = (int?) content.GetValueForProperty("VMSizePropertyVcpUsPerCore",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfileInternal)this).VMSizePropertyVcpUsPerCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BaseVirtualMachineProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BaseVirtualMachineProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BaseVirtualMachineProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="BaseVirtualMachineProfile" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Describes the base virtual machine profile for fleet
    [System.ComponentModel.TypeConverter(typeof(BaseVirtualMachineProfileTypeConverter))]
    public partial interface IBaseVirtualMachineProfile

    {

    }
}