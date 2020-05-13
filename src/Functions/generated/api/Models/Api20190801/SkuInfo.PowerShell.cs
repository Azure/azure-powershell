namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>SKU discovery information.</summary>
    [System.ComponentModel.TypeConverter(typeof(SkuInfoTypeConverter))]
    public partial class SkuInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SkuInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SkuInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SkuInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SkuInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMinimum = (int?) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityScaleType = (string) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Schemas576Capacity = (int?) content.GetValueForProperty("Schemas576Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Schemas576Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SkuInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMinimum = (int?) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityScaleType = (string) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Schemas576Capacity = (int?) content.GetValueForProperty("Schemas576Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).Schemas576Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfoInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// SKU discovery information.
    [System.ComponentModel.TypeConverter(typeof(SkuInfoTypeConverter))]
    public partial interface ISkuInfo

    {

    }
}