namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Actions are applied to the filtered blobs when the execution condition is met.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagementPolicyActionTypeConverter))]
    public partial class ManagementPolicyAction
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagementPolicyAction(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagementPolicyAction(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagementPolicyAction" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyAction FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagementPolicyAction(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob) content.GetValueForProperty("BaseBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlobTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).Snapshot = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot) content.GetValueForProperty("Snapshot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).Snapshot, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySnapShotTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobDelete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobDelete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobDelete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToArchive = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobTierToArchive",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToArchive, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToCool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobTierToCool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToCool, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).SnapshotDelete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation) content.GetValueForProperty("SnapshotDelete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).SnapshotDelete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterCreationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToArchiveDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToArchiveDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToArchiveDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToCoolDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToCoolDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToCoolDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterCreationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterCreationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterCreationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyAction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagementPolicyAction(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob) content.GetValueForProperty("BaseBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlobTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).Snapshot = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicySnapShot) content.GetValueForProperty("Snapshot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).Snapshot, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicySnapShotTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobDelete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobDelete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobDelete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToArchive = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobTierToArchive",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToArchive, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToCool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("BaseBlobTierToCool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).BaseBlobTierToCool, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).SnapshotDelete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterCreation) content.GetValueForProperty("SnapshotDelete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).SnapshotDelete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterCreationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToArchiveDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToArchiveDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToArchiveDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToCoolDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToCoolDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).TierToCoolDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterCreationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterCreationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyActionInternal)this).DeleteDaysAfterCreationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Actions are applied to the filtered blobs when the execution condition is met.
    [System.ComponentModel.TypeConverter(typeof(ManagementPolicyActionTypeConverter))]
    public partial interface IManagementPolicyAction

    {

    }
}