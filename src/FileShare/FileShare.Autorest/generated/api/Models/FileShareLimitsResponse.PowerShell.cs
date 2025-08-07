// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.PowerShell;

    /// <summary>Response structure for file share limits API.</summary>
    [System.ComponentModel.TypeConverter(typeof(FileShareLimitsResponseTypeConverter))]
    public partial class FileShareLimitsResponse
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FileShareLimitsResponse(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FileShareLimitsResponse(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FileShareLimitsResponse(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsOutputTypeConverter.ConvertFrom);
            }
            if (content.Contains("Limit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Limit = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Limit, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningConstant"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstant = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants) content.GetValueForProperty("ProvisioningConstant",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstant, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningConstantsTypeConverter.ConvertFrom);
            }
            if (content.Contains("LimitMaxFileShare"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShare = (int) content.GetValueForProperty("LimitMaxFileShare",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShare, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileShareSnapshot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSnapshot = (int) content.GetValueForProperty("LimitMaxFileShareSnapshot",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSnapshot, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileShareSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSubnet = (int) content.GetValueForProperty("LimitMaxFileShareSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSubnet, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileSharePrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileSharePrivateEndpointConnection = (int) content.GetValueForProperty("LimitMaxFileSharePrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileSharePrivateEndpointConnection, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedStorageGiB = (int) content.GetValueForProperty("LimitMinProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedStorageGiB = (int) content.GetValueForProperty("LimitMaxProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedIoPerSec = (int) content.GetValueForProperty("LimitMinProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedIoPerSec = (int) content.GetValueForProperty("LimitMaxProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("LimitMinProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("LimitMaxProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantBaseIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseIoPerSec = (int) content.GetValueForProperty("ProvisioningConstantBaseIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantScalarIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarIoPerSec = (double) content.GetValueForProperty("ProvisioningConstantScalarIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarIoPerSec, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("ProvisioningConstantBaseThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseThroughputMiBPerSec = (int) content.GetValueForProperty("ProvisioningConstantBaseThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantScalarThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarThroughputMiBPerSec = (double) content.GetValueForProperty("ProvisioningConstantScalarThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarThroughputMiBPerSec, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FileShareLimitsResponse(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsOutput) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsOutputTypeConverter.ConvertFrom);
            }
            if (content.Contains("Limit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Limit = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimits) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).Limit, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareLimitsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningConstant"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstant = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningConstants) content.GetValueForProperty("ProvisioningConstant",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstant, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProvisioningConstantsTypeConverter.ConvertFrom);
            }
            if (content.Contains("LimitMaxFileShare"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShare = (int) content.GetValueForProperty("LimitMaxFileShare",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShare, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileShareSnapshot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSnapshot = (int) content.GetValueForProperty("LimitMaxFileShareSnapshot",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSnapshot, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileShareSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSubnet = (int) content.GetValueForProperty("LimitMaxFileShareSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileShareSubnet, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxFileSharePrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileSharePrivateEndpointConnection = (int) content.GetValueForProperty("LimitMaxFileSharePrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxFileSharePrivateEndpointConnection, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedStorageGiB = (int) content.GetValueForProperty("LimitMinProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedStorageGiB = (int) content.GetValueForProperty("LimitMaxProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedIoPerSec = (int) content.GetValueForProperty("LimitMinProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedIoPerSec = (int) content.GetValueForProperty("LimitMaxProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMinProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("LimitMinProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMinProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("LimitMaxProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedThroughputMiBPerSec = (int) content.GetValueForProperty("LimitMaxProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).LimitMaxProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantBaseIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseIoPerSec = (int) content.GetValueForProperty("ProvisioningConstantBaseIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantScalarIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarIoPerSec = (double) content.GetValueForProperty("ProvisioningConstantScalarIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarIoPerSec, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("ProvisioningConstantBaseThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseThroughputMiBPerSec = (int) content.GetValueForProperty("ProvisioningConstantBaseThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantBaseThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningConstantScalarThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarThroughputMiBPerSec = (double) content.GetValueForProperty("ProvisioningConstantScalarThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponseInternal)this).ProvisioningConstantScalarThroughputMiBPerSec, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FileShareLimitsResponse" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="FileShareLimitsResponse" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareLimitsResponse FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Response structure for file share limits API.
    [System.ComponentModel.TypeConverter(typeof(FileShareLimitsResponseTypeConverter))]
    public partial interface IFileShareLimitsResponse

    {

    }
}