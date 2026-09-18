// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.PowerShell;

    /// <summary>File share-related limits in the specified subscription/location.</summary>
    [System.ComponentModel.TypeConverter(typeof(FileShareLimitsTypeConverter))]
    public partial class FileShareLimits
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FileShareLimits(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FileShareLimits(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FileShareLimits(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MaxFileShare"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShare = (int) content.GetValueForProperty("MaxFileShare",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShare, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileShareSnapshot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSnapshot = (int) content.GetValueForProperty("MaxFileShareSnapshot",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSnapshot, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileShareSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSubnet = (int) content.GetValueForProperty("MaxFileShareSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSubnet, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileSharePrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileSharePrivateEndpointConnection = (int) content.GetValueForProperty("MaxFileSharePrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileSharePrivateEndpointConnection, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedStorageGiB = (int) content.GetValueForProperty("MinProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedStorageGiB = (int) content.GetValueForProperty("MaxProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedIoPerSec = (int) content.GetValueForProperty("MinProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedIoPerSec = (int) content.GetValueForProperty("MaxProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("MinProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("MaxProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimits"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FileShareLimits(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MaxFileShare"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShare = (int) content.GetValueForProperty("MaxFileShare",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShare, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileShareSnapshot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSnapshot = (int) content.GetValueForProperty("MaxFileShareSnapshot",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSnapshot, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileShareSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSubnet = (int) content.GetValueForProperty("MaxFileShareSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileShareSubnet, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxFileSharePrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileSharePrivateEndpointConnection = (int) content.GetValueForProperty("MaxFileSharePrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxFileSharePrivateEndpointConnection, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedStorageGiB = (int) content.GetValueForProperty("MinProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedStorageGiB = (int) content.GetValueForProperty("MaxProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedIoPerSec = (int) content.GetValueForProperty("MinProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedIoPerSec = (int) content.GetValueForProperty("MaxProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MinProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("MinProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MinProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("MaxProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsInternal)this).MaxProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FileShareLimits" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="FileShareLimits" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// File share-related limits in the specified subscription/location.
    [System.ComponentModel.TypeConverter(typeof(FileShareLimitsTypeConverter))]
    public partial interface IFileShareLimits

    {

    }
}