namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Enable protection input properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(EnableProtectionInputPropertiesTypeConverter))]
    public partial class EnableProtectionInputProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EnableProtectionInputProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EnableProtectionInputProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EnableProtectionInputProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProtectableItemId = (string) content.GetValueForProperty("ProtectableItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProtectableItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionInputProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EnableProtectionInputProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProtectableItemId = (string) content.GetValueForProperty("ProtectableItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProtectableItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputPropertiesInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EnableProtectionInputProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionInputProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Enable protection input properties.
    [System.ComponentModel.TypeConverter(typeof(EnableProtectionInputPropertiesTypeConverter))]
    public partial interface IEnableProtectionInputProperties

    {

    }
}