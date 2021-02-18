namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>A2A protected disk details.</summary>
    [System.ComponentModel.TypeConverter(typeof(A2AProtectedDiskDetailsTypeConverter))]
    public partial class A2AProtectedDiskDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal A2AProtectedDiskDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskUri = (string) content.GetValueForProperty("DiskUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryAzureStorageAccountId = (string) content.GetValueForProperty("RecoveryAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryDiskAzureStorageAccountId = (string) content.GetValueForProperty("PrimaryDiskAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryDiskAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryDiskUri = (string) content.GetValueForProperty("RecoveryDiskUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryDiskUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskName = (string) content.GetValueForProperty("DiskName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskCapacityInByte = (long?) content.GetValueForProperty("DiskCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryStagingAzureStorageAccountId = (string) content.GetValueForProperty("PrimaryStagingAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryStagingAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskType = (string) content.GetValueForProperty("DiskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringPercentageCompletion = (int?) content.GetValueForProperty("MonitoringPercentageCompletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringPercentageCompletion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringJobType = (string) content.GetValueForProperty("MonitoringJobType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringJobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingInStagingStorageAccountInMb = (double?) content.GetValueForProperty("DataPendingInStagingStorageAccountInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingInStagingStorageAccountInMb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingAtSourceAgentInMb = (double?) content.GetValueForProperty("DataPendingAtSourceAgentInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingAtSourceAgentInMb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskEncrypted = (bool?) content.GetValueForProperty("IsDiskEncrypted",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskEncrypted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).SecretIdentifier = (string) content.GetValueForProperty("SecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).SecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DekKeyVaultArmId = (string) content.GetValueForProperty("DekKeyVaultArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DekKeyVaultArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskKeyEncrypted = (bool?) content.GetValueForProperty("IsDiskKeyEncrypted",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskKeyEncrypted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KeyIdentifier = (string) content.GetValueForProperty("KeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KekKeyVaultArmId = (string) content.GetValueForProperty("KekKeyVaultArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KekKeyVaultArmId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal A2AProtectedDiskDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskUri = (string) content.GetValueForProperty("DiskUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryAzureStorageAccountId = (string) content.GetValueForProperty("RecoveryAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryDiskAzureStorageAccountId = (string) content.GetValueForProperty("PrimaryDiskAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryDiskAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryDiskUri = (string) content.GetValueForProperty("RecoveryDiskUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).RecoveryDiskUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskName = (string) content.GetValueForProperty("DiskName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskCapacityInByte = (long?) content.GetValueForProperty("DiskCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryStagingAzureStorageAccountId = (string) content.GetValueForProperty("PrimaryStagingAzureStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).PrimaryStagingAzureStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskType = (string) content.GetValueForProperty("DiskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DiskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringPercentageCompletion = (int?) content.GetValueForProperty("MonitoringPercentageCompletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringPercentageCompletion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringJobType = (string) content.GetValueForProperty("MonitoringJobType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).MonitoringJobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingInStagingStorageAccountInMb = (double?) content.GetValueForProperty("DataPendingInStagingStorageAccountInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingInStagingStorageAccountInMb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingAtSourceAgentInMb = (double?) content.GetValueForProperty("DataPendingAtSourceAgentInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DataPendingAtSourceAgentInMb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskEncrypted = (bool?) content.GetValueForProperty("IsDiskEncrypted",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskEncrypted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).SecretIdentifier = (string) content.GetValueForProperty("SecretIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).SecretIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DekKeyVaultArmId = (string) content.GetValueForProperty("DekKeyVaultArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).DekKeyVaultArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskKeyEncrypted = (bool?) content.GetValueForProperty("IsDiskKeyEncrypted",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).IsDiskKeyEncrypted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KeyIdentifier = (string) content.GetValueForProperty("KeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KeyIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KekKeyVaultArmId = (string) content.GetValueForProperty("KekKeyVaultArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetailsInternal)this).KekKeyVaultArmId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new A2AProtectedDiskDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new A2AProtectedDiskDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="A2AProtectedDiskDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A2A protected disk details.
    [System.ComponentModel.TypeConverter(typeof(A2AProtectedDiskDetailsTypeConverter))]
    public partial interface IA2AProtectedDiskDetails

    {

    }
}