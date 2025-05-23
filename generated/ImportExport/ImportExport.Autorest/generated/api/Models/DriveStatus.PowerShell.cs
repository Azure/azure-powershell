// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.PowerShell;

    /// <summary>Provides information about the drive's status</summary>
    [System.ComponentModel.TypeConverter(typeof(DriveStatusTypeConverter))]
    public partial class DriveStatus
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DriveStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DriveStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DriveStatus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DriveId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveId = (string) content.GetValueForProperty("DriveId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveId, global::System.Convert.ToString);
            }
            if (content.Contains("BitLockerKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BitLockerKey = (string) content.GetValueForProperty("BitLockerKey",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BitLockerKey, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestFile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestFile = (string) content.GetValueForProperty("ManifestFile",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestFile, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestHash = (string) content.GetValueForProperty("ManifestHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestHash, global::System.Convert.ToString);
            }
            if (content.Contains("DriveHeaderHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveHeaderHash = (string) content.GetValueForProperty("DriveHeaderHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveHeaderHash, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("CopyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).CopyStatus = (string) content.GetValueForProperty("CopyStatus",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).CopyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PercentComplete"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).PercentComplete = (long?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).PercentComplete, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("VerboseLogUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).VerboseLogUri = (string) content.GetValueForProperty("VerboseLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).VerboseLogUri, global::System.Convert.ToString);
            }
            if (content.Contains("ErrorLogUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ErrorLogUri = (string) content.GetValueForProperty("ErrorLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ErrorLogUri, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestUri = (string) content.GetValueForProperty("ManifestUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestUri, global::System.Convert.ToString);
            }
            if (content.Contains("BytesSucceeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BytesSucceeded = (long?) content.GetValueForProperty("BytesSucceeded",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BytesSucceeded, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DriveStatus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DriveId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveId = (string) content.GetValueForProperty("DriveId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveId, global::System.Convert.ToString);
            }
            if (content.Contains("BitLockerKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BitLockerKey = (string) content.GetValueForProperty("BitLockerKey",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BitLockerKey, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestFile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestFile = (string) content.GetValueForProperty("ManifestFile",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestFile, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestHash = (string) content.GetValueForProperty("ManifestHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestHash, global::System.Convert.ToString);
            }
            if (content.Contains("DriveHeaderHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveHeaderHash = (string) content.GetValueForProperty("DriveHeaderHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).DriveHeaderHash, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("CopyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).CopyStatus = (string) content.GetValueForProperty("CopyStatus",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).CopyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PercentComplete"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).PercentComplete = (long?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).PercentComplete, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("VerboseLogUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).VerboseLogUri = (string) content.GetValueForProperty("VerboseLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).VerboseLogUri, global::System.Convert.ToString);
            }
            if (content.Contains("ErrorLogUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ErrorLogUri = (string) content.GetValueForProperty("ErrorLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ErrorLogUri, global::System.Convert.ToString);
            }
            if (content.Contains("ManifestUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestUri = (string) content.GetValueForProperty("ManifestUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).ManifestUri, global::System.Convert.ToString);
            }
            if (content.Contains("BytesSucceeded"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BytesSucceeded = (long?) content.GetValueForProperty("BytesSucceeded",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatusInternal)this).BytesSucceeded, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DriveStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DriveStatus" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IDriveStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Provides information about the drive's status
    [System.ComponentModel.TypeConverter(typeof(DriveStatusTypeConverter))]
    public partial interface IDriveStatus

    {

    }
}