namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Description of a SKU for a scalable resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(SkuDescriptionTypeConverter))]
    public partial class SkuDescription
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SkuDescription(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SkuDescription(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SkuDescription" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SkuDescription(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Family = (string) content.GetValueForProperty("Family",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Family, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Size = (string) content.GetValueForProperty("Size",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Size, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescription"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SkuDescription(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Family = (string) content.GetValueForProperty("Family",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Family, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Size = (string) content.GetValueForProperty("Size",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Size, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Tier = (string) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).Tier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescriptionInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Description of a SKU for a scalable resource.
    [System.ComponentModel.TypeConverter(typeof(SkuDescriptionTypeConverter))]
    public partial interface ISkuDescription

    {

    }
}