namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.PowerShell;

    /// <summary>
    /// Parameters supplied to the Create or Update Environment operation for a long-term environment.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(LongTermEnvironmentCreateOrUpdateParametersTypeConverter))]
    public partial class LongTermEnvironmentCreateOrUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LongTermEnvironmentCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LongTermEnvironmentCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LongTermEnvironmentCreateOrUpdateParameters" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LongTermEnvironmentCreateOrUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.CreateOrUpdateTrackedResourcePropertiesTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuCapacity = (int) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput) content.GetValueForProperty("StorageConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfiguration, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermStorageConfigurationInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties) content.GetValueForProperty("WarmStoreConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfiguration, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.WarmStoreConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).TimeSeriesIdProperty = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[]) content.GetValueForProperty("TimeSeriesIdProperty",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).TimeSeriesIdProperty, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.TimeSeriesIdPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationAccountName = (string) content.GetValueForProperty("StorageConfigurationAccountName",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationAccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationManagementKey = (string) content.GetValueForProperty("StorageConfigurationManagementKey",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationManagementKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfigurationDataRetention = (global::System.TimeSpan) content.GetValueForProperty("WarmStoreConfigurationDataRetention",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfigurationDataRetention, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LongTermEnvironmentCreateOrUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermEnvironmentCreationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.CreateOrUpdateTrackedResourcePropertiesTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuCapacity = (int) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermStorageConfigurationInput) content.GetValueForProperty("StorageConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfiguration, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.LongTermStorageConfigurationInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IWarmStoreConfigurationProperties) content.GetValueForProperty("WarmStoreConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfiguration, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.WarmStoreConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).TimeSeriesIdProperty = (Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty[]) content.GetValueForProperty("TimeSeriesIdProperty",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).TimeSeriesIdProperty, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ITimeSeriesIdProperty>(__y, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.TimeSeriesIdPropertyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationAccountName = (string) content.GetValueForProperty("StorageConfigurationAccountName",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationAccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationManagementKey = (string) content.GetValueForProperty("StorageConfigurationManagementKey",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).StorageConfigurationManagementKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfigurationDataRetention = (global::System.TimeSpan) content.GetValueForProperty("WarmStoreConfigurationDataRetention",((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ILongTermEnvironmentCreateOrUpdateParametersInternal)this).WarmStoreConfigurationDataRetention, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters supplied to the Create or Update Environment operation for a long-term environment.
    [System.ComponentModel.TypeConverter(typeof(LongTermEnvironmentCreateOrUpdateParametersTypeConverter))]
    public partial interface ILongTermEnvironmentCreateOrUpdateParameters

    {

    }
}