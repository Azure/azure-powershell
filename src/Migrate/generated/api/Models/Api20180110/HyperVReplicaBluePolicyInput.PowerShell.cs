namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>HyperV Replica Blue policy input.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaBluePolicyInputTypeConverter))]
    public partial class HyperVReplicaBluePolicyInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaBluePolicyInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVReplicaBluePolicyInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaBluePolicyInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVReplicaBluePolicyInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVReplicaBluePolicyInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaBluePolicyInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVReplicaBluePolicyInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationFrequencyInSecond = (int?) content.GetValueForProperty("ReplicationFrequencyInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationFrequencyInSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).RecoveryPoint = (int?) content.GetValueForProperty("RecoveryPoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).RecoveryPoint, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ApplicationConsistentSnapshotFrequencyInHour = (int?) content.GetValueForProperty("ApplicationConsistentSnapshotFrequencyInHour",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ApplicationConsistentSnapshotFrequencyInHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).Compression = (string) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).Compression, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).InitialReplicationMethod = (string) content.GetValueForProperty("InitialReplicationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).InitialReplicationMethod, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OnlineReplicationStartTime = (string) content.GetValueForProperty("OnlineReplicationStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OnlineReplicationStartTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationImportPath = (string) content.GetValueForProperty("OfflineReplicationImportPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationImportPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationExportPath = (string) content.GetValueForProperty("OfflineReplicationExportPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationExportPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationPort = (int?) content.GetValueForProperty("ReplicationPort",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).AllowedAuthenticationType = (int?) content.GetValueForProperty("AllowedAuthenticationType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).AllowedAuthenticationType, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicaDeletion = (string) content.GetValueForProperty("ReplicaDeletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicaDeletion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaBluePolicyInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVReplicaBluePolicyInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationFrequencyInSecond = (int?) content.GetValueForProperty("ReplicationFrequencyInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationFrequencyInSecond, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).RecoveryPoint = (int?) content.GetValueForProperty("RecoveryPoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).RecoveryPoint, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ApplicationConsistentSnapshotFrequencyInHour = (int?) content.GetValueForProperty("ApplicationConsistentSnapshotFrequencyInHour",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ApplicationConsistentSnapshotFrequencyInHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).Compression = (string) content.GetValueForProperty("Compression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).Compression, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).InitialReplicationMethod = (string) content.GetValueForProperty("InitialReplicationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).InitialReplicationMethod, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OnlineReplicationStartTime = (string) content.GetValueForProperty("OnlineReplicationStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OnlineReplicationStartTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationImportPath = (string) content.GetValueForProperty("OfflineReplicationImportPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationImportPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationExportPath = (string) content.GetValueForProperty("OfflineReplicationExportPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).OfflineReplicationExportPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationPort = (int?) content.GetValueForProperty("ReplicationPort",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicationPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).AllowedAuthenticationType = (int?) content.GetValueForProperty("AllowedAuthenticationType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).AllowedAuthenticationType, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicaDeletion = (string) content.GetValueForProperty("ReplicaDeletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaBluePolicyInputInternal)this).ReplicaDeletion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// HyperV Replica Blue policy input.
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaBluePolicyInputTypeConverter))]
    public partial interface IHyperVReplicaBluePolicyInput

    {

    }
}