// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell;

    /// <summary>Details of the Compute Fleet.</summary>
    [System.ComponentModel.TypeConverter(typeof(FleetPropertiesTypeConverter))]
    public partial class FleetProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FleetProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FleetProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FleetProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SpotPriorityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile) content.GetValueForProperty("SpotPriorityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SpotPriorityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("RegularPriorityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile) content.GetValueForProperty("RegularPriorityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.RegularPriorityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdditionalLocationsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile) content.GetValueForProperty("AdditionalLocationsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalLocationsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ComputeProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile) content.GetValueForProperty("ComputeProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ComputeProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ZoneAllocationPolicy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicy = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy) content.GetValueForProperty("ZoneAllocationPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicy, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZoneAllocationPolicyTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("VMSizesProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMSizesProfile = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile>) content.GetValueForProperty("VMSizesProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMSizesProfile, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfileTypeConverter.ConvertFrom));
            }
            if (content.Contains("TimeCreated"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).TimeCreated = (global::System.DateTime?) content.GetValueForProperty("TimeCreated",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).TimeCreated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UniqueId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).UniqueId, global::System.Convert.ToString);
            }
            if (content.Contains("Mode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).Mode = (string) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).Mode, global::System.Convert.ToString);
            }
            if (content.Contains("VMNamePrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMNamePrefix = (string) content.GetValueForProperty("VMNamePrefix",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMNamePrefix, global::System.Convert.ToString);
            }
            if (content.Contains("CapacityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).CapacityType = (string) content.GetValueForProperty("CapacityType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).CapacityType, global::System.Convert.ToString);
            }
            if (content.Contains("VMAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMAttribute = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes) content.GetValueForProperty("VMAttribute",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMAttribute, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMAttributesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SpotPriorityProfileEvictionPolicy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileEvictionPolicy = (string) content.GetValueForProperty("SpotPriorityProfileEvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileEvictionPolicy, global::System.Convert.ToString);
            }
            if (content.Contains("AdditionalLocationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationProfile = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile>) content.GetValueForProperty("AdditionalLocationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationProfile, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.LocationProfileTypeConverter.ConvertFrom));
            }
            if (content.Contains("ZoneAllocationPolicyZonePreference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyZonePreference = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference>) content.GetValueForProperty("ZoneAllocationPolicyZonePreference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyZonePreference, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZonePreferenceTypeConverter.ConvertFrom));
            }
            if (content.Contains("SpotPriorityProfileCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileCapacity = (int?) content.GetValueForProperty("SpotPriorityProfileCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SpotPriorityProfileMinCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMinCapacity = (int?) content.GetValueForProperty("SpotPriorityProfileMinCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMinCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SpotPriorityProfileMaxPricePerVM"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaxPricePerVM = (float?) content.GetValueForProperty("SpotPriorityProfileMaxPricePerVM",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaxPricePerVM, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            }
            if (content.Contains("SpotPriorityProfileAllocationStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileAllocationStrategy = (string) content.GetValueForProperty("SpotPriorityProfileAllocationStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileAllocationStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("SpotPriorityProfileMaintain"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaintain = (bool?) content.GetValueForProperty("SpotPriorityProfileMaintain",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaintain, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("RegularPriorityProfileCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileCapacity = (int?) content.GetValueForProperty("RegularPriorityProfileCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("RegularPriorityProfileMinCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileMinCapacity = (int?) content.GetValueForProperty("RegularPriorityProfileMinCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileMinCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("RegularPriorityProfileAllocationStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileAllocationStrategy = (string) content.GetValueForProperty("RegularPriorityProfileAllocationStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileAllocationStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeProfileAdditionalVirtualMachineCapability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileAdditionalVirtualMachineCapability = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalCapabilities) content.GetValueForProperty("ComputeProfileAdditionalVirtualMachineCapability",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileAdditionalVirtualMachineCapability, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalCapabilitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ComputeProfileComputeApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileComputeApiVersion = (string) content.GetValueForProperty("ComputeProfileComputeApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileComputeApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeProfilePlatformFaultDomainCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfilePlatformFaultDomainCount = (int?) content.GetValueForProperty("ComputeProfilePlatformFaultDomainCount",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfilePlatformFaultDomainCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ComputeProfileBaseVirtualMachineProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileBaseVirtualMachineProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile) content.GetValueForProperty("ComputeProfileBaseVirtualMachineProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileBaseVirtualMachineProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ZoneAllocationPolicyDistributionStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyDistributionStrategy = (string) content.GetValueForProperty("ZoneAllocationPolicyDistributionStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyDistributionStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("AdditionalVirtualMachineCapabilityUltraSsdEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityUltraSsdEnabled = (bool?) content.GetValueForProperty("AdditionalVirtualMachineCapabilityUltraSsdEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityUltraSsdEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AdditionalVirtualMachineCapabilityHibernationEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityHibernationEnabled = (bool?) content.GetValueForProperty("AdditionalVirtualMachineCapabilityHibernationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityHibernationEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.FleetProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FleetProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SpotPriorityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISpotPriorityProfile) content.GetValueForProperty("SpotPriorityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.SpotPriorityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("RegularPriorityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IRegularPriorityProfile) content.GetValueForProperty("RegularPriorityProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.RegularPriorityProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdditionalLocationsProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationsProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalLocationsProfile) content.GetValueForProperty("AdditionalLocationsProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationsProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalLocationsProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ComputeProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeProfile) content.GetValueForProperty("ComputeProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ComputeProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ZoneAllocationPolicy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicy = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZoneAllocationPolicy) content.GetValueForProperty("ZoneAllocationPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicy, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZoneAllocationPolicyTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("VMSizesProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMSizesProfile = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile>) content.GetValueForProperty("VMSizesProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMSizesProfile, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfileTypeConverter.ConvertFrom));
            }
            if (content.Contains("TimeCreated"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).TimeCreated = (global::System.DateTime?) content.GetValueForProperty("TimeCreated",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).TimeCreated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UniqueId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).UniqueId, global::System.Convert.ToString);
            }
            if (content.Contains("Mode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).Mode = (string) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).Mode, global::System.Convert.ToString);
            }
            if (content.Contains("VMNamePrefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMNamePrefix = (string) content.GetValueForProperty("VMNamePrefix",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMNamePrefix, global::System.Convert.ToString);
            }
            if (content.Contains("CapacityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).CapacityType = (string) content.GetValueForProperty("CapacityType",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).CapacityType, global::System.Convert.ToString);
            }
            if (content.Contains("VMAttribute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMAttribute = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes) content.GetValueForProperty("VMAttribute",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).VMAttribute, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMAttributesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SpotPriorityProfileEvictionPolicy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileEvictionPolicy = (string) content.GetValueForProperty("SpotPriorityProfileEvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileEvictionPolicy, global::System.Convert.ToString);
            }
            if (content.Contains("AdditionalLocationProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationProfile = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile>) content.GetValueForProperty("AdditionalLocationProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalLocationProfile, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.LocationProfileTypeConverter.ConvertFrom));
            }
            if (content.Contains("ZoneAllocationPolicyZonePreference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyZonePreference = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference>) content.GetValueForProperty("ZoneAllocationPolicyZonePreference",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyZonePreference, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference>(__y, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ZonePreferenceTypeConverter.ConvertFrom));
            }
            if (content.Contains("SpotPriorityProfileCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileCapacity = (int?) content.GetValueForProperty("SpotPriorityProfileCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SpotPriorityProfileMinCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMinCapacity = (int?) content.GetValueForProperty("SpotPriorityProfileMinCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMinCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SpotPriorityProfileMaxPricePerVM"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaxPricePerVM = (float?) content.GetValueForProperty("SpotPriorityProfileMaxPricePerVM",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaxPricePerVM, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            }
            if (content.Contains("SpotPriorityProfileAllocationStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileAllocationStrategy = (string) content.GetValueForProperty("SpotPriorityProfileAllocationStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileAllocationStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("SpotPriorityProfileMaintain"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaintain = (bool?) content.GetValueForProperty("SpotPriorityProfileMaintain",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).SpotPriorityProfileMaintain, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("RegularPriorityProfileCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileCapacity = (int?) content.GetValueForProperty("RegularPriorityProfileCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("RegularPriorityProfileMinCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileMinCapacity = (int?) content.GetValueForProperty("RegularPriorityProfileMinCapacity",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileMinCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("RegularPriorityProfileAllocationStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileAllocationStrategy = (string) content.GetValueForProperty("RegularPriorityProfileAllocationStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).RegularPriorityProfileAllocationStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeProfileAdditionalVirtualMachineCapability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileAdditionalVirtualMachineCapability = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IAdditionalCapabilities) content.GetValueForProperty("ComputeProfileAdditionalVirtualMachineCapability",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileAdditionalVirtualMachineCapability, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.AdditionalCapabilitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ComputeProfileComputeApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileComputeApiVersion = (string) content.GetValueForProperty("ComputeProfileComputeApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileComputeApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeProfilePlatformFaultDomainCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfilePlatformFaultDomainCount = (int?) content.GetValueForProperty("ComputeProfilePlatformFaultDomainCount",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfilePlatformFaultDomainCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ComputeProfileBaseVirtualMachineProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileBaseVirtualMachineProfile = (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile) content.GetValueForProperty("ComputeProfileBaseVirtualMachineProfile",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ComputeProfileBaseVirtualMachineProfile, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ZoneAllocationPolicyDistributionStrategy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyDistributionStrategy = (string) content.GetValueForProperty("ZoneAllocationPolicyDistributionStrategy",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).ZoneAllocationPolicyDistributionStrategy, global::System.Convert.ToString);
            }
            if (content.Contains("AdditionalVirtualMachineCapabilityUltraSsdEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityUltraSsdEnabled = (bool?) content.GetValueForProperty("AdditionalVirtualMachineCapabilityUltraSsdEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityUltraSsdEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AdditionalVirtualMachineCapabilityHibernationEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityHibernationEnabled = (bool?) content.GetValueForProperty("AdditionalVirtualMachineCapabilityHibernationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetPropertiesInternal)this).AdditionalVirtualMachineCapabilityHibernationEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FleetProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="FleetProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleetProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Details of the Compute Fleet.
    [System.ComponentModel.TypeConverter(typeof(FleetPropertiesTypeConverter))]
    public partial interface IFleetProperties

    {

    }
}