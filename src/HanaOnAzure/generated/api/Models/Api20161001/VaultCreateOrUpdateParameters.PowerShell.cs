namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.PowerShell;

    /// <summary>Parameters for creating or updating a vault</summary>
    [System.ComponentModel.TypeConverter(typeof(VaultCreateOrUpdateParametersTypeConverter))]
    public partial class VaultCreateOrUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VaultCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VaultCreateOrUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VaultCreateOrUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VaultCreateOrUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode?) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).AccessPolicy = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[]) content.GetValueForProperty("AccessPolicy",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).AccessPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry>(__y, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.AccessPolicyEntryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnablePurgeProtection = (bool?) content.GetValueForProperty("EnablePurgeProtection",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnablePurgeProtection, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnableSoftDelete = (bool?) content.GetValueForProperty("EnableSoftDelete",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnableSoftDelete, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDeployment = (bool?) content.GetValueForProperty("EnabledForDeployment",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDeployment, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDiskEncryption = (bool?) content.GetValueForProperty("EnabledForDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForTemplateDeployment = (bool?) content.GetValueForProperty("EnabledForTemplateDeployment",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForTemplateDeployment, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).VaultUri = (string) content.GetValueForProperty("VaultUri",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).VaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuFamily, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VaultCreateOrUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParametersTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode?) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).AccessPolicy = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[]) content.GetValueForProperty("AccessPolicy",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).AccessPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry>(__y, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.AccessPolicyEntryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnablePurgeProtection = (bool?) content.GetValueForProperty("EnablePurgeProtection",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnablePurgeProtection, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnableSoftDelete = (bool?) content.GetValueForProperty("EnableSoftDelete",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnableSoftDelete, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDeployment = (bool?) content.GetValueForProperty("EnabledForDeployment",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDeployment, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDiskEncryption = (bool?) content.GetValueForProperty("EnabledForDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForTemplateDeployment = (bool?) content.GetValueForProperty("EnabledForTemplateDeployment",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).EnabledForTemplateDeployment, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).VaultUri = (string) content.GetValueForProperty("VaultUri",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).VaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal)this).SkuFamily, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters for creating or updating a vault
    [System.ComponentModel.TypeConverter(typeof(VaultCreateOrUpdateParametersTypeConverter))]
    public partial interface IVaultCreateOrUpdateParameters

    {

    }
}