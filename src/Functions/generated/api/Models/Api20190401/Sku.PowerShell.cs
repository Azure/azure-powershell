namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>The SKU of the storage account.</summary>
    [System.ComponentModel.TypeConverter(typeof(SkuTypeConverter))]
    public partial class Sku
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Sku(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Sku(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Sku" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Sku(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Name = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Name, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Tier = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier?) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Tier, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.SkuCapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Restriction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[]) content.GetValueForProperty("Restriction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Restriction, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.RestrictionTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Sku(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Name = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Name, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Tier = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier?) content.GetValueForProperty("Tier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Tier, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Location = (string[]) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Location, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.SkuCapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Restriction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[]) content.GetValueForProperty("Restriction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)this).Restriction, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.RestrictionTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The SKU of the storage account.
    [System.ComponentModel.TypeConverter(typeof(SkuTypeConverter))]
    public partial interface ISku

    {

    }
}