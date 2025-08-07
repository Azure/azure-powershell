// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.PowerShell;

    /// <summary>The type used for update operations of the FileShare.</summary>
    [System.ComponentModel.TypeConverter(typeof(FileShareUpdateTypeConverter))]
    public partial class FileShareUpdate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FileShareUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FileShareUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FileShareUpdate(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("NfsProtocolProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfsProtocolProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties) content.GetValueForProperty("NfsProtocolProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfsProtocolProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PublicAccessProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties) content.GetValueForProperty("PublicAccessProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedStorageGiB = (int?) content.GetValueForProperty("ProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedIoPerSec = (int?) content.GetValueForProperty("ProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedThroughputMiBPerSec = (int?) content.GetValueForProperty("ProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PublicAccessPropertyAllowedSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessPropertyAllowedSubnet = (System.Collections.Generic.List<string>) content.GetValueForProperty("PublicAccessPropertyAllowedSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessPropertyAllowedSubnet, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("NfProtocolPropertyRootSquash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfProtocolPropertyRootSquash = (string) content.GetValueForProperty("NfProtocolPropertyRootSquash",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfProtocolPropertyRootSquash, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FileShareUpdate(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ITags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.TagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("NfsProtocolProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfsProtocolProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties) content.GetValueForProperty("NfsProtocolProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfsProtocolProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PublicAccessProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties) content.GetValueForProperty("PublicAccessProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedStorageGiB = (int?) content.GetValueForProperty("ProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedIoPerSec = (int?) content.GetValueForProperty("ProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedThroughputMiBPerSec = (int?) content.GetValueForProperty("ProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).ProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PublicAccessPropertyAllowedSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessPropertyAllowedSubnet = (System.Collections.Generic.List<string>) content.GetValueForProperty("PublicAccessPropertyAllowedSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).PublicAccessPropertyAllowedSubnet, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("NfProtocolPropertyRootSquash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfProtocolPropertyRootSquash = (string) content.GetValueForProperty("NfProtocolPropertyRootSquash",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdateInternal)this).NfProtocolPropertyRootSquash, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FileShareUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="FileShareUpdate" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The type used for update operations of the FileShare.
    [System.ComponentModel.TypeConverter(typeof(FileShareUpdateTypeConverter))]
    public partial interface IFileShareUpdate

    {

    }
}