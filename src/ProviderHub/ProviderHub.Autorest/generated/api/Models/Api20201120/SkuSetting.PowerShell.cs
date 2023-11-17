namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(SkuSettingTypeConverter))]
    public partial class SkuSetting
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SkuSetting(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SkuSetting(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SkuSetting" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SkuSetting(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Size = (string) content.GetValueForProperty("Size",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Size, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Family = (string) content.GetValueForProperty("Family",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Family, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).LocationInfo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuLocationInfo[]) content.GetValueForProperty("LocationInfo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).LocationInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuLocationInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuLocationInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredQuotaId = (string[]) content.GetValueForProperty("RequiredQuotaId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredQuotaId, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredFeature = (string[]) content.GetValueForProperty("RequiredFeature",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Cost = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCost[]) content.GetValueForProperty("Cost",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Cost, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCost>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCostTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMinimum = (int) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityScaleType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SkuScaleType?) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityScaleType, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SkuScaleType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SkuSetting(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Size = (string) content.GetValueForProperty("Size",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Size, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Family = (string) content.GetValueForProperty("Family",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Family, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).LocationInfo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuLocationInfo[]) content.GetValueForProperty("LocationInfo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).LocationInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuLocationInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuLocationInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredQuotaId = (string[]) content.GetValueForProperty("RequiredQuotaId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredQuotaId, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredFeature = (string[]) content.GetValueForProperty("RequiredFeature",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).RequiredFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Cost = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCost[]) content.GetValueForProperty("Cost",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Cost, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCost>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCostTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuCapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMinimum = (int) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityScaleType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SkuScaleType?) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSettingInternal)this).CapacityScaleType, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SkuScaleType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(SkuSettingTypeConverter))]
    public partial interface ISkuSetting

    {

    }
}