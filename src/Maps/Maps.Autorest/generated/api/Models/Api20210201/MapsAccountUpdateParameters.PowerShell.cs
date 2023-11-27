namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.PowerShell;

    /// <summary>Parameters used to update an existing Maps Account.</summary>
    [System.ComponentModel.TypeConverter(typeof(MapsAccountUpdateParametersTypeConverter))]
    public partial class MapsAccountUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MapsAccountUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MapsAccountUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MapsAccountUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MapsAccountUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).UniqueId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).DisableLocalAuth = (bool?) content.GetValueForProperty("DisableLocalAuth",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).DisableLocalAuth, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).ProvisioningState, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MapsAccountUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).UniqueId = (string) content.GetValueForProperty("UniqueId",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).UniqueId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).DisableLocalAuth = (bool?) content.GetValueForProperty("DisableLocalAuth",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).DisableLocalAuth, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal)this).ProvisioningState, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters used to update an existing Maps Account.
    [System.ComponentModel.TypeConverter(typeof(MapsAccountUpdateParametersTypeConverter))]
    public partial interface IMapsAccountUpdateParameters

    {

    }
}