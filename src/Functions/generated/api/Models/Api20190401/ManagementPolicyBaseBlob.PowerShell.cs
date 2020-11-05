namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Management policy action for base blob.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagementPolicyBaseBlobTypeConverter))]
    public partial class ManagementPolicyBaseBlob
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagementPolicyBaseBlob(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagementPolicyBaseBlob(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagementPolicyBaseBlob" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlob FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagementPolicyBaseBlob(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("TierToCool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCool, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchive = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("TierToArchive",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchive, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).Delete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("Delete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).Delete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCoolDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToCoolDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCoolDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchiveDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToArchiveDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchiveDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).DeleteDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).DeleteDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ManagementPolicyBaseBlob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagementPolicyBaseBlob(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("TierToCool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCool, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchive = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("TierToArchive",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchive, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).Delete = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDateAfterModification) content.GetValueForProperty("Delete",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).Delete, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DateAfterModificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCoolDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToCoolDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToCoolDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchiveDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("TierToArchiveDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).TierToArchiveDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).DeleteDaysAfterModificationGreaterThan = (float) content.GetValueForProperty("DeleteDaysAfterModificationGreaterThan",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IManagementPolicyBaseBlobInternal)this).DeleteDaysAfterModificationGreaterThan, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Management policy action for base blob.
    [System.ComponentModel.TypeConverter(typeof(ManagementPolicyBaseBlobTypeConverter))]
    public partial interface IManagementPolicyBaseBlob

    {

    }
}