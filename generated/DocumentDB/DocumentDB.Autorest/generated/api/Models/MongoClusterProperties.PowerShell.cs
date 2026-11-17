// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell;

    /// <summary>The properties of a mongo cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(MongoClusterPropertiesTypeConverter))]
    public partial class MongoClusterProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MongoClusterProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MongoClusterProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MongoClusterProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="MongoClusterProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MongoClusterProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RestoreParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters) content.GetValueForProperty("RestoreParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterRestoreParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicaParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters) content.GetValueForProperty("ReplicaParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterReplicaParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Administrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Administrator = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties) content.GetValueForProperty("Administrator",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Administrator, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StoragePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sharding"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Sharding = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties) content.GetValueForProperty("Sharding",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Sharding, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Compute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Compute = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties) content.GetValueForProperty("Compute",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Compute, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataApi"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApi = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties) content.GetValueForProperty("DataApi",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApi, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ReplicationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Encryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("ServerVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ServerVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionString"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ConnectionString = (string) content.GetValueForProperty("ConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ConnectionString, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ClusterStatus = (string) content.GetValueForProperty("ClusterStatus",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ClusterStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PreviewFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PreviewFeature = (System.Collections.Generic.List<string>) content.GetValueForProperty("PreviewFeature",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PreviewFeature, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("InfrastructureVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).InfrastructureVersion = (string) content.GetValueForProperty("InfrastructureVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).InfrastructureVersion, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkBypassMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).NetworkBypassMode = (string) content.GetValueForProperty("NetworkBypassMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).NetworkBypassMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageSizeGb = (long?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageSizeGb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("ShardingShardCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ShardingShardCount = (int?) content.GetValueForProperty("ShardingShardCount",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ShardingShardCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DataApiMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApiMode = (string) content.GetValueForProperty("DataApiMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApiMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameterPointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterPointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("RestoreParameterPointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterPointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RestoreParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterSourceResourceId = (string) content.GetValueForProperty("RestoreParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceResourceId = (string) content.GetValueForProperty("ReplicaParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaParameterSourceLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceLocation = (string) content.GetValueForProperty("ReplicaParameterSourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceLocation, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorUserName = (string) content.GetValueForProperty("AdministratorUserName",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorUserName, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorPassword",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("HighAvailabilityTargetMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailabilityTargetMode = (string) content.GetValueForProperty("HighAvailabilityTargetMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailabilityTargetMode, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ComputeTier = (string) content.GetValueForProperty("ComputeTier",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ComputeTier, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).BackupEarliestRestoreTime = (string) content.GetValueForProperty("BackupEarliestRestoreTime",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).BackupEarliestRestoreTime, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaSourceResourceId = (string) content.GetValueForProperty("ReplicaSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigAllowedMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfigAllowedMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("AuthConfigAllowedMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfigAllowedMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EncryptionCustomerManagedKeyEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).EncryptionCustomerManagedKeyEncryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties) content.GetValueForProperty("EncryptionCustomerManagedKeyEncryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).EncryptionCustomerManagedKeyEncryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyIdentity = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyIdentity",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyIdentity, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.KeyEncryptionKeyIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyUrl = (string) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyUrl",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyUrl, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityType = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MongoClusterProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RestoreParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters) content.GetValueForProperty("RestoreParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterRestoreParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicaParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters) content.GetValueForProperty("ReplicaParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterReplicaParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Administrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Administrator = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties) content.GetValueForProperty("Administrator",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Administrator, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StoragePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sharding"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Sharding = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties) content.GetValueForProperty("Sharding",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Sharding, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Compute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Compute = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties) content.GetValueForProperty("Compute",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Compute, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataApi"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApi = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties) content.GetValueForProperty("DataApi",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApi, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ReplicationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Encryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("ServerVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ServerVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionString"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ConnectionString = (string) content.GetValueForProperty("ConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ConnectionString, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ClusterStatus = (string) content.GetValueForProperty("ClusterStatus",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ClusterStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PreviewFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PreviewFeature = (System.Collections.Generic.List<string>) content.GetValueForProperty("PreviewFeature",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).PreviewFeature, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("InfrastructureVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).InfrastructureVersion = (string) content.GetValueForProperty("InfrastructureVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).InfrastructureVersion, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkBypassMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).NetworkBypassMode = (string) content.GetValueForProperty("NetworkBypassMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).NetworkBypassMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageSizeGb = (long?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageSizeGb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("ShardingShardCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ShardingShardCount = (int?) content.GetValueForProperty("ShardingShardCount",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ShardingShardCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DataApiMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApiMode = (string) content.GetValueForProperty("DataApiMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).DataApiMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameterPointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterPointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("RestoreParameterPointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterPointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RestoreParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterSourceResourceId = (string) content.GetValueForProperty("RestoreParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).RestoreParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceResourceId = (string) content.GetValueForProperty("ReplicaParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaParameterSourceLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceLocation = (string) content.GetValueForProperty("ReplicaParameterSourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaParameterSourceLocation, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorUserName = (string) content.GetValueForProperty("AdministratorUserName",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorUserName, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorPassword",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AdministratorPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("HighAvailabilityTargetMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailabilityTargetMode = (string) content.GetValueForProperty("HighAvailabilityTargetMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).HighAvailabilityTargetMode, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ComputeTier = (string) content.GetValueForProperty("ComputeTier",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ComputeTier, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).BackupEarliestRestoreTime = (string) content.GetValueForProperty("BackupEarliestRestoreTime",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).BackupEarliestRestoreTime, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaSourceResourceId = (string) content.GetValueForProperty("ReplicaSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigAllowedMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfigAllowedMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("AuthConfigAllowedMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).AuthConfigAllowedMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EncryptionCustomerManagedKeyEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).EncryptionCustomerManagedKeyEncryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties) content.GetValueForProperty("EncryptionCustomerManagedKeyEncryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).EncryptionCustomerManagedKeyEncryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyIdentity = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyIdentity",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyIdentity, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.KeyEncryptionKeyIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyUrl = (string) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyUrl",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).CustomerManagedKeyEncryptionKeyUrl, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityType = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The properties of a mongo cluster.
    [System.ComponentModel.TypeConverter(typeof(MongoClusterPropertiesTypeConverter))]
    public partial interface IMongoClusterProperties

    {

    }
}