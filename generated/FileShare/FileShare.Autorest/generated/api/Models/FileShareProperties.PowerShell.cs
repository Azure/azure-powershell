// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.PowerShell;

    /// <summary>File share properties</summary>
    [System.ComponentModel.TypeConverter(typeof(FileSharePropertiesTypeConverter))]
    public partial class FileShareProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FileShareProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FileShareProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FileShareProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NfsProtocolProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfsProtocolProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties) content.GetValueForProperty("NfsProtocolProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfsProtocolProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PublicAccessProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties) content.GetValueForProperty("PublicAccessProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("MountName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MountName = (string) content.GetValueForProperty("MountName",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MountName, global::System.Convert.ToString);
            }
            if (content.Contains("HostName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).HostName, global::System.Convert.ToString);
            }
            if (content.Contains("MediaTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MediaTier = (string) content.GetValueForProperty("MediaTier",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MediaTier, global::System.Convert.ToString);
            }
            if (content.Contains("Redundancy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Redundancy = (string) content.GetValueForProperty("Redundancy",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Redundancy, global::System.Convert.ToString);
            }
            if (content.Contains("Protocol"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Protocol = (string) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Protocol, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageGiB = (int?) content.GetValueForProperty("ProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedStorageNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedStorageNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSec = (int?) content.GetValueForProperty("ProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedIoPerSecNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSecNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedIoPerSecNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSecNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputMiBPerSec = (int?) content.GetValueForProperty("ProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedThroughputNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedThroughputNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("IncludedBurstIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).IncludedBurstIoPerSec = (int?) content.GetValueForProperty("IncludedBurstIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).IncludedBurstIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxBurstIoPerSecCredit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MaxBurstIoPerSecCredit = (long?) content.GetValueForProperty("MaxBurstIoPerSecCredit",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MaxBurstIoPerSecCredit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicAccessPropertyAllowedSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessPropertyAllowedSubnet = (System.Collections.Generic.List<string>) content.GetValueForProperty("PublicAccessPropertyAllowedSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessPropertyAllowedSubnet, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("NfProtocolPropertyRootSquash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfProtocolPropertyRootSquash = (string) content.GetValueForProperty("NfProtocolPropertyRootSquash",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfProtocolPropertyRootSquash, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FileShareProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("NfsProtocolProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfsProtocolProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties) content.GetValueForProperty("NfsProtocolProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfsProtocolProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.NfsProtocolPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PublicAccessProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessProperty = (Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties) content.GetValueForProperty("PublicAccessProperty",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessProperty, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PublicAccessPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("MountName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MountName = (string) content.GetValueForProperty("MountName",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MountName, global::System.Convert.ToString);
            }
            if (content.Contains("HostName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).HostName, global::System.Convert.ToString);
            }
            if (content.Contains("MediaTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MediaTier = (string) content.GetValueForProperty("MediaTier",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MediaTier, global::System.Convert.ToString);
            }
            if (content.Contains("Redundancy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Redundancy = (string) content.GetValueForProperty("Redundancy",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Redundancy, global::System.Convert.ToString);
            }
            if (content.Contains("Protocol"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Protocol = (string) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).Protocol, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisionedStorageGiB"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageGiB = (int?) content.GetValueForProperty("ProvisionedStorageGiB",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageGiB, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedStorageNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedStorageNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedStorageNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ProvisionedIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSec = (int?) content.GetValueForProperty("ProvisionedIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedIoPerSecNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSecNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedIoPerSecNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedIoPerSecNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ProvisionedThroughputMiBPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputMiBPerSec = (int?) content.GetValueForProperty("ProvisionedThroughputMiBPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputMiBPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisionedThroughputNextAllowedDowngrade"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputNextAllowedDowngrade = (global::System.DateTime?) content.GetValueForProperty("ProvisionedThroughputNextAllowedDowngrade",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisionedThroughputNextAllowedDowngrade, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("IncludedBurstIoPerSec"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).IncludedBurstIoPerSec = (int?) content.GetValueForProperty("IncludedBurstIoPerSec",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).IncludedBurstIoPerSec, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaxBurstIoPerSecCredit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MaxBurstIoPerSecCredit = (long?) content.GetValueForProperty("MaxBurstIoPerSecCredit",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).MaxBurstIoPerSecCredit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicAccessPropertyAllowedSubnet"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessPropertyAllowedSubnet = (System.Collections.Generic.List<string>) content.GetValueForProperty("PublicAccessPropertyAllowedSubnet",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).PublicAccessPropertyAllowedSubnet, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("NfProtocolPropertyRootSquash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfProtocolPropertyRootSquash = (string) content.GetValueForProperty("NfProtocolPropertyRootSquash",((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileSharePropertiesInternal)this).NfProtocolPropertyRootSquash, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FileShareProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="FileShareProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// File share properties
    [System.ComponentModel.TypeConverter(typeof(FileSharePropertiesTypeConverter))]
    public partial interface IFileShareProperties

    {

    }
}