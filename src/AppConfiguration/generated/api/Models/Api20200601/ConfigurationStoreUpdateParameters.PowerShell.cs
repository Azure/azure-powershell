namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.PowerShell;

    /// <summary>The parameters for updating a configuration store.</summary>
    [System.ComponentModel.TypeConverter(typeof(ConfigurationStoreUpdateParametersTypeConverter))]
    public partial class ConfigurationStoreUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConfigurationStoreUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStorePropertiesUpdateParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.EncryptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).EncryptionKeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties) content.GetValueForProperty("EncryptionKeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).EncryptionKeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyKeyIdentifier = (string) content.GetValueForProperty("KeyVaultPropertyKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyIdentityClientId = (string) content.GetValueForProperty("KeyVaultPropertyIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyIdentityClientId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConfigurationStoreUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStorePropertiesUpdateParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.EncryptionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).EncryptionKeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties) content.GetValueForProperty("EncryptionKeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).EncryptionKeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyKeyIdentifier = (string) content.GetValueForProperty("KeyVaultPropertyKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyKeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyIdentityClientId = (string) content.GetValueForProperty("KeyVaultPropertyIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal)this).KeyVaultPropertyIdentityClientId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConfigurationStoreUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConfigurationStoreUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationStoreUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters for updating a configuration store.
    [System.ComponentModel.TypeConverter(typeof(ConfigurationStoreUpdateParametersTypeConverter))]
    public partial interface IConfigurationStoreUpdateParameters

    {

    }
}