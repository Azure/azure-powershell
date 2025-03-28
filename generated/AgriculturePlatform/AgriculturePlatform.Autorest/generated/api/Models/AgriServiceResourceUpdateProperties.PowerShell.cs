// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>The updatable properties of the AgriServiceResource.</summary>
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceUpdatePropertiesTypeConverter))]
    public partial class AgriServiceResourceUpdateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgriServiceResourceUpdateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgriServiceResourceUpdateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Config"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataConnectorCredentials"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).DataConnectorCredentials = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>) content.GetValueForProperty("DataConnectorCredentials",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).DataConnectorCredentials, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentialMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("InstalledSolution"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).InstalledSolution = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>) content.GetValueForProperty("InstalledSolution",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).InstalledSolution, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap>(__y, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMapTypeConverter.ConvertFrom));
            }
            if (content.Contains("ConfigInstanceUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigInstanceUri = (string) content.GetValueForProperty("ConfigInstanceUri",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigInstanceUri, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigVersion = (string) content.GetValueForProperty("ConfigVersion",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigAppServiceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigAppServiceResourceId = (string) content.GetValueForProperty("ConfigAppServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigAppServiceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigCosmosDbResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigCosmosDbResourceId = (string) content.GetValueForProperty("ConfigCosmosDbResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigCosmosDbResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigStorageAccountResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigStorageAccountResourceId = (string) content.GetValueForProperty("ConfigStorageAccountResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigStorageAccountResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigKeyVaultResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigKeyVaultResourceId = (string) content.GetValueForProperty("ConfigKeyVaultResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigKeyVaultResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigRedisCacheResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigRedisCacheResourceId = (string) content.GetValueForProperty("ConfigRedisCacheResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdatePropertiesInternal)this).ConfigRedisCacheResourceId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgriServiceResourceUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgriServiceResourceUpdateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgriServiceResourceUpdateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="AgriServiceResourceUpdateProperties" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceUpdateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// The updatable properties of the AgriServiceResource.
    [System.ComponentModel.TypeConverter(typeof(AgriServiceResourceUpdatePropertiesTypeConverter))]
    public partial interface IAgriServiceResourceUpdateProperties

    {

    }
}