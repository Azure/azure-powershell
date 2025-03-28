// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>The type used for update operations of the AgriServiceResource.</summary>
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceUpdateTypeConverter))]
    public partial class AgriServiceResourceUpdate
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgriServiceResourceUpdate(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.UserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgriServiceResourceUpdate(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.UserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgriServiceResourceUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgriServiceResourceUpdate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgriServiceResourceUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="AgriServiceResourceUpdate" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The type used for update operations of the AgriServiceResource.
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceUpdateTypeConverter))]
    public partial interface IAgriServiceResourceUpdate

    {

    }
}