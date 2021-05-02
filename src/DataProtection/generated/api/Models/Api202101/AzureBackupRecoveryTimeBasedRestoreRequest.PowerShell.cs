namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>AzureBackup RecoveryPointTime Based Restore Request</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureBackupRecoveryTimeBasedRestoreRequestTypeConverter))]
    public partial class AzureBackupRecoveryTimeBasedRestoreRequest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureBackupRecoveryTimeBasedRestoreRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequestInternal)this).RecoveryPointTime = (string) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequestInternal)this).RecoveryPointTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRecoveryOption = (string) content.GetValueForProperty("RestoreTargetInfoRecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoObjectType = (string) content.GetValueForProperty("RestoreTargetInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRestoreLocation = (string) content.GetValueForProperty("RestoreTargetInfoRestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBase) content.GetValueForProperty("RestoreTargetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreTargetInfoBaseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType) content.GetValueForProperty("SourceDataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureBackupRecoveryTimeBasedRestoreRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequestInternal)this).RecoveryPointTime = (string) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequestInternal)this).RecoveryPointTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRecoveryOption = (string) content.GetValueForProperty("RestoreTargetInfoRecoveryOption",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRecoveryOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoObjectType = (string) content.GetValueForProperty("RestoreTargetInfoObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRestoreLocation = (string) content.GetValueForProperty("RestoreTargetInfoRestoreLocation",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfoRestoreLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBase) content.GetValueForProperty("RestoreTargetInfo",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).RestoreTargetInfo, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RestoreTargetInfoBaseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).ObjectType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType) content.GetValueForProperty("SourceDataStoreType",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRestoreRequestInternal)this).SourceDataStoreType, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureBackupRecoveryTimeBasedRestoreRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureBackupRecoveryTimeBasedRestoreRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureBackupRecoveryTimeBasedRestoreRequest" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryTimeBasedRestoreRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// AzureBackup RecoveryPointTime Based Restore Request
    [System.ComponentModel.TypeConverter(typeof(AzureBackupRecoveryTimeBasedRestoreRequestTypeConverter))]
    public partial interface IAzureBackupRecoveryTimeBasedRestoreRequest

    {

    }
}