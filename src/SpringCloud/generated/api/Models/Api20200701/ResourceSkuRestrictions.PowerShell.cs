namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Restrictions where the SKU cannot be used</summary>
    [System.ComponentModel.TypeConverter(typeof(ResourceSkuRestrictionsTypeConverter))]
    public partial class ResourceSkuRestrictions
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceSkuRestrictions(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceSkuRestrictions(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceSkuRestrictions" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictions FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceSkuRestrictions(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfo = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionInfo) content.GetValueForProperty("RestrictionInfo",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfo, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Value = (string[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).ReasonCode = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode?) content.GetValueForProperty("ReasonCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).ReasonCode, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoLocation = (string[]) content.GetValueForProperty("RestrictionInfoLocation",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoZone = (string[]) content.GetValueForProperty("RestrictionInfoZone",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceSkuRestrictions(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfo = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionInfo) content.GetValueForProperty("RestrictionInfo",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfo, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ResourceSkuRestrictionInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Value = (string[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).ReasonCode = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode?) content.GetValueForProperty("ReasonCode",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).ReasonCode, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoLocation = (string[]) content.GetValueForProperty("RestrictionInfoLocation",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoZone = (string[]) content.GetValueForProperty("RestrictionInfoZone",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionsInternal)this).RestrictionInfoZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Restrictions where the SKU cannot be used
    [System.ComponentModel.TypeConverter(typeof(ResourceSkuRestrictionsTypeConverter))]
    public partial interface IResourceSkuRestrictions

    {

    }
}