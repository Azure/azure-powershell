namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DriveStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DriveStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BitLockerKey = (string) content.GetValueForProperty("BitLockerKey",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BitLockerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BytesSucceeded = (long?) content.GetValueForProperty("BytesSucceeded",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BytesSucceeded, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).CopyStatus = (string) content.GetValueForProperty("CopyStatus",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).CopyStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveHeaderHash = (string) content.GetValueForProperty("DriveHeaderHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveHeaderHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveId = (string) content.GetValueForProperty("DriveId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ErrorLogUri = (string) content.GetValueForProperty("ErrorLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ErrorLogUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestFile = (string) content.GetValueForProperty("ManifestFile",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestFile, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestHash = (string) content.GetValueForProperty("ManifestHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestUri = (string) content.GetValueForProperty("ManifestUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).PercentComplete = (int?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).PercentComplete, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).VerboseLogUri = (string) content.GetValueForProperty("VerboseLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).VerboseLogUri, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.DriveStatus"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BitLockerKey = (string) content.GetValueForProperty("BitLockerKey",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BitLockerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BytesSucceeded = (long?) content.GetValueForProperty("BytesSucceeded",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).BytesSucceeded, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).CopyStatus = (string) content.GetValueForProperty("CopyStatus",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).CopyStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveHeaderHash = (string) content.GetValueForProperty("DriveHeaderHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveHeaderHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveId = (string) content.GetValueForProperty("DriveId",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).DriveId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ErrorLogUri = (string) content.GetValueForProperty("ErrorLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ErrorLogUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestFile = (string) content.GetValueForProperty("ManifestFile",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestFile, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestHash = (string) content.GetValueForProperty("ManifestHash",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestHash, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestUri = (string) content.GetValueForProperty("ManifestUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).ManifestUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).PercentComplete = (int?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).PercentComplete, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Support.DriveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).VerboseLogUri = (string) content.GetValueForProperty("VerboseLogUri",((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatusInternal)this).VerboseLogUri, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DriveStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Provides information about the drive's status
    [System.ComponentModel.TypeConverter(typeof(DriveStatusTypeConverter))]
    public partial interface IDriveStatus

    {

    }
}