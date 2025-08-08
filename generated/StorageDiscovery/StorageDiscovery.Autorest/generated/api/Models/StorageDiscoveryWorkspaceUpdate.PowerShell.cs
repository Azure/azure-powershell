// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.PowerShell;

    /// <summary>The template for adding updateable properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(StorageDiscoveryWorkspaceUpdateTypeConverter))]
    public partial class StorageDiscoveryWorkspaceUpdate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StorageDiscoveryWorkspaceUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StorageDiscoveryWorkspaceUpdate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StorageDiscoveryWorkspaceUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="StorageDiscoveryWorkspaceUpdate" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StorageDiscoveryWorkspaceUpdate(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspacePropertiesUpdateTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkspaceRoot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).WorkspaceRoot = (System.Collections.Generic.List<string>) content.GetValueForProperty("WorkspaceRoot",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).WorkspaceRoot, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Scope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Scope = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope>) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Scope, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope>(__y, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryScopeTypeConverter.ConvertFrom));
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Sku, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Description, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspaceUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StorageDiscoveryWorkspaceUpdate(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspacePropertiesUpdateTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkspaceRoot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).WorkspaceRoot = (System.Collections.Generic.List<string>) content.GetValueForProperty("WorkspaceRoot",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).WorkspaceRoot, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Scope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Scope = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope>) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Scope, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope>(__y, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryScopeTypeConverter.ConvertFrom));
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Sku, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal)this).Description, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The template for adding updateable properties.
    [System.ComponentModel.TypeConverter(typeof(StorageDiscoveryWorkspaceUpdateTypeConverter))]
    public partial interface IStorageDiscoveryWorkspaceUpdate

    {

    }
}