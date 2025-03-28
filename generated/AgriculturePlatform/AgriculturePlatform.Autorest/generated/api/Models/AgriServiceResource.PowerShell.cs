// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>
    /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceTypeConverter))]
    public partial class AgriServiceResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgriServiceResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourcePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfiguration) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedOnBehalfOfConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.UserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgriServiceResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourcePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfiguration) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedOnBehalfOfConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.UserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgriServiceResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgriServiceResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgriServiceResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="AgriServiceResource" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceTypeConverter))]
    public partial interface IAgriServiceResource

    {

    }
}