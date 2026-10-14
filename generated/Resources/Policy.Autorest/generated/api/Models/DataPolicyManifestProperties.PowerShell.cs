// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The properties of the data policy manifest.</summary>
    [System.ComponentModel.TypeConverter(typeof(DataPolicyManifestPropertiesTypeConverter))]
    public partial class DataPolicyManifestProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DataPolicyManifestProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ResourceFunction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunction = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition) content.GetValueForProperty("ResourceFunction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunction, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestResourceFunctionsDefinitionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Namespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Namespace = (System.Collections.Generic.List<string>) content.GetValueForProperty("Namespace",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Namespace, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("PolicyMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).PolicyMode = (string) content.GetValueForProperty("PolicyMode",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).PolicyMode, global::System.Convert.ToString);
            }
            if (content.Contains("IsBuiltInOnly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).IsBuiltInOnly = (bool?) content.GetValueForProperty("IsBuiltInOnly",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).IsBuiltInOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("ResourceTypeAlias"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceTypeAlias = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases>) content.GetValueForProperty("ResourceTypeAlias",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceTypeAlias, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceTypeAliasesTypeConverter.ConvertFrom));
            }
            if (content.Contains("Effect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Effect = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect>) content.GetValueForProperty("Effect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Effect, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataEffectTypeConverter.ConvertFrom));
            }
            if (content.Contains("FieldValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).FieldValue = (System.Collections.Generic.List<string>) content.GetValueForProperty("FieldValue",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).FieldValue, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ResourceFunctionStandard"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionStandard = (System.Collections.Generic.List<string>) content.GetValueForProperty("ResourceFunctionStandard",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionStandard, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ResourceFunctionCustom"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionCustom = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition>) content.GetValueForProperty("ResourceFunctionCustom",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionCustom, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinitionTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DataPolicyManifestProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ResourceFunction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunction = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition) content.GetValueForProperty("ResourceFunction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunction, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestResourceFunctionsDefinitionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Namespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Namespace = (System.Collections.Generic.List<string>) content.GetValueForProperty("Namespace",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Namespace, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("PolicyMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).PolicyMode = (string) content.GetValueForProperty("PolicyMode",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).PolicyMode, global::System.Convert.ToString);
            }
            if (content.Contains("IsBuiltInOnly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).IsBuiltInOnly = (bool?) content.GetValueForProperty("IsBuiltInOnly",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).IsBuiltInOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("ResourceTypeAlias"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceTypeAlias = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases>) content.GetValueForProperty("ResourceTypeAlias",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceTypeAlias, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceTypeAliasesTypeConverter.ConvertFrom));
            }
            if (content.Contains("Effect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Effect = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect>) content.GetValueForProperty("Effect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).Effect, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataEffectTypeConverter.ConvertFrom));
            }
            if (content.Contains("FieldValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).FieldValue = (System.Collections.Generic.List<string>) content.GetValueForProperty("FieldValue",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).FieldValue, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ResourceFunctionStandard"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionStandard = (System.Collections.Generic.List<string>) content.GetValueForProperty("ResourceFunctionStandard",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionStandard, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ResourceFunctionCustom"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionCustom = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition>) content.GetValueForProperty("ResourceFunctionCustom",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal)this).ResourceFunctionCustom, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinitionTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DataPolicyManifestProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataPolicyManifestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DataPolicyManifestProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataPolicyManifestProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DataPolicyManifestProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of the data policy manifest.
    [System.ComponentModel.TypeConverter(typeof(DataPolicyManifestPropertiesTypeConverter))]
    public partial interface IDataPolicyManifestProperties

    {

    }
}