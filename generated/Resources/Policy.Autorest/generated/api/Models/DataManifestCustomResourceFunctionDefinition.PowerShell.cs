// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The custom resource function definition.</summary>
    [System.ComponentModel.TypeConverter(typeof(DataManifestCustomResourceFunctionDefinitionTypeConverter))]
    public partial class DataManifestCustomResourceFunctionDefinition
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DataManifestCustomResourceFunctionDefinition(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedResourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).FullyQualifiedResourceType = (string) content.GetValueForProperty("FullyQualifiedResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).FullyQualifiedResourceType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).DefaultProperty = (System.Collections.Generic.List<string>) content.GetValueForProperty("DefaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).DefaultProperty, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("AllowCustomProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).AllowCustomProperty = (bool?) content.GetValueForProperty("AllowCustomProperty",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).AllowCustomProperty, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DataManifestCustomResourceFunctionDefinition(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedResourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).FullyQualifiedResourceType = (string) content.GetValueForProperty("FullyQualifiedResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).FullyQualifiedResourceType, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).DefaultProperty = (System.Collections.Generic.List<string>) content.GetValueForProperty("DefaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).DefaultProperty, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("AllowCustomProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).AllowCustomProperty = (bool?) content.GetValueForProperty("AllowCustomProperty",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal)this).AllowCustomProperty, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DataManifestCustomResourceFunctionDefinition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DataManifestCustomResourceFunctionDefinition(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataManifestCustomResourceFunctionDefinition" />, deserializing the content from
        /// a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="DataManifestCustomResourceFunctionDefinition" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The custom resource function definition.
    [System.ComponentModel.TypeConverter(typeof(DataManifestCustomResourceFunctionDefinitionTypeConverter))]
    public partial interface IDataManifestCustomResourceFunctionDefinition

    {

    }
}