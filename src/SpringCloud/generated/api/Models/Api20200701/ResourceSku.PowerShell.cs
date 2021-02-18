namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Describes an available Azure Spring Cloud SKU.</summary>
    [System.ComponentModel.TypeConverter(typeof(ResourceSkuTypeConverter))]
    public partial class ResourceSku
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceSku(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceSku(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceSku" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSku FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceSku(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).LocationInfo = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[]) content.GetValueForProperty("LocationInfo",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).LocationInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuLocationInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Restriction = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[]) content.GetValueForProperty("Restriction",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Restriction, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictionsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMinimum = (int) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityScaleType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType?) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityScaleType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceSku(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Capacity = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISkuCapacity) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Capacity, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).LocationInfo = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo[]) content.GetValueForProperty("LocationInfo",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).LocationInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuLocationInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuLocationInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Restriction = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions[]) content.GetValueForProperty("Restriction",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).Restriction, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictionsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMinimum = (int) content.GetValueForProperty("CapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMaximum = (int?) content.GetValueForProperty("CapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityDefault = (int?) content.GetValueForProperty("CapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityScaleType = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType?) content.GetValueForProperty("CapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuInternal)this).CapacityScaleType, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SkuScaleType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes an available Azure Spring Cloud SKU.
    [System.ComponentModel.TypeConverter(typeof(ResourceSkuTypeConverter))]
    public partial interface IResourceSku

    {

    }
}