namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PowerShell;

    /// <summary>Default rollout definition.</summary>
    [System.ComponentModel.TypeConverter(typeof(DefaultRolloutTypeConverter))]
    public partial class DefaultRollout
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRollout"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DefaultRollout(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Specification = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification) content.GetValueForProperty("Specification",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Specification, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationProviderRegistration = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration) content.GetValueForProperty("SpecificationProviderRegistration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationProviderRegistration, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationCanary = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationCanary",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationCanary, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CanaryTrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationLowTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationLowTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationLowTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationMediumTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationMediumTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationMediumTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationHighTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationHighTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationHighTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupOne = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationRestOfTheWorldGroupOne",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupOne, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupTwo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationRestOfTheWorldGroupTwo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupTwo, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationResourceTypeRegistration = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]) content.GetValueForProperty("SpecificationResourceTypeRegistration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationResourceTypeRegistration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeRegistrationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusCompletedRegion = (string[]) content.GetValueForProperty("StatusCompletedRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusCompletedRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusFailedOrSkippedRegion = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions) content.GetValueForProperty("StatusFailedOrSkippedRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusFailedOrSkippedRegion, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RolloutStatusBaseFailedOrSkippedRegionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegion = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory?) content.GetValueForProperty("StatusNextTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegion, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegionScheduledTime = (global::System.DateTime?) content.GetValueForProperty("StatusNextTrafficRegionScheduledTime",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegionScheduledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusSubscriptionReregistrationResult = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult?) content.GetValueForProperty("StatusSubscriptionReregistrationResult",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusSubscriptionReregistrationResult, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanarySkipRegion = (string[]) content.GetValueForProperty("CanarySkipRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanarySkipRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanaryRegion = (string[]) content.GetValueForProperty("CanaryRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanaryRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficRegion = (string[]) content.GetValueForProperty("LowTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("LowTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficRegion = (string[]) content.GetValueForProperty("MediumTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("MediumTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficRegion = (string[]) content.GetValueForProperty("HighTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("HighTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneRegion = (string[]) content.GetValueForProperty("RestOfTheWorldGroupOneRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("RestOfTheWorldGroupOneWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoRegion = (string[]) content.GetValueForProperty("RestOfTheWorldGroupTwoRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("RestOfTheWorldGroupTwoWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRollout"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DefaultRollout(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Specification = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification) content.GetValueForProperty("Specification",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Specification, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationProviderRegistration = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration) content.GetValueForProperty("SpecificationProviderRegistration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationProviderRegistration, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationCanary = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationCanary",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationCanary, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.CanaryTrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationLowTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationLowTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationLowTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationMediumTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationMediumTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationMediumTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationHighTraffic = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationHighTraffic",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationHighTraffic, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupOne = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationRestOfTheWorldGroupOne",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupOne, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupTwo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration) content.GetValueForProperty("SpecificationRestOfTheWorldGroupTwo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationRestOfTheWorldGroupTwo, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.TrafficRegionRolloutConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationResourceTypeRegistration = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]) content.GetValueForProperty("SpecificationResourceTypeRegistration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).SpecificationResourceTypeRegistration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeRegistrationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusCompletedRegion = (string[]) content.GetValueForProperty("StatusCompletedRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusCompletedRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusFailedOrSkippedRegion = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions) content.GetValueForProperty("StatusFailedOrSkippedRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusFailedOrSkippedRegion, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RolloutStatusBaseFailedOrSkippedRegionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegion = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory?) content.GetValueForProperty("StatusNextTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegion, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegionScheduledTime = (global::System.DateTime?) content.GetValueForProperty("StatusNextTrafficRegionScheduledTime",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusNextTrafficRegionScheduledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusSubscriptionReregistrationResult = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult?) content.GetValueForProperty("StatusSubscriptionReregistrationResult",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).StatusSubscriptionReregistrationResult, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanarySkipRegion = (string[]) content.GetValueForProperty("CanarySkipRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanarySkipRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanaryRegion = (string[]) content.GetValueForProperty("CanaryRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).CanaryRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficRegion = (string[]) content.GetValueForProperty("LowTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("LowTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).LowTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficRegion = (string[]) content.GetValueForProperty("MediumTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("MediumTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).MediumTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficRegion = (string[]) content.GetValueForProperty("HighTrafficRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("HighTrafficWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).HighTrafficWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneRegion = (string[]) content.GetValueForProperty("RestOfTheWorldGroupOneRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("RestOfTheWorldGroupOneWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupOneWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoRegion = (string[]) content.GetValueForProperty("RestOfTheWorldGroupTwoRegion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoRegion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoWaitDuration = (global::System.TimeSpan?) content.GetValueForProperty("RestOfTheWorldGroupTwoWaitDuration",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutInternal)this).RestOfTheWorldGroupTwoWaitDuration, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRollout"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DefaultRollout(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRollout"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DefaultRollout(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DefaultRollout" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Default rollout definition.
    [System.ComponentModel.TypeConverter(typeof(DefaultRolloutTypeConverter))]
    public partial interface IDefaultRollout

    {

    }
}