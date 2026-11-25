// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PowerShell;

    /// <summary>Represents a mongo cluster replica.</summary>
    [System.ComponentModel.TypeConverter(typeof(ReplicaTypeConverter))]
    public partial class Replica
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.Replica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Replica(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.Replica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Replica(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Replica" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Replica" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.Replica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Replica(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters) content.GetValueForProperty("RestoreParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterRestoreParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Parameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Parameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters) content.GetValueForProperty("Parameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Parameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterReplicaParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Administrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Administrator = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties) content.GetValueForProperty("Administrator",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Administrator, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StoragePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sharding"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Sharding = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties) content.GetValueForProperty("Sharding",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Sharding, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Compute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Compute = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties) content.GetValueForProperty("Compute",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Compute, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataApi"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApi = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties) content.GetValueForProperty("DataApi",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApi, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PropertiesReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PropertiesReplica = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties) content.GetValueForProperty("PropertiesReplica",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PropertiesReplica, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ReplicationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Encryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ServerVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ServerVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionString"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ConnectionString = (string) content.GetValueForProperty("ConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ConnectionString, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ClusterStatus = (string) content.GetValueForProperty("ClusterStatus",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ClusterStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PreviewFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PreviewFeature = (System.Collections.Generic.List<string>) content.GetValueForProperty("PreviewFeature",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PreviewFeature, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("InfrastructureVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).InfrastructureVersion = (string) content.GetValueForProperty("InfrastructureVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).InfrastructureVersion, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkBypassMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).NetworkBypassMode = (string) content.GetValueForProperty("NetworkBypassMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).NetworkBypassMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageSizeGb = (long?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageSizeGb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("ShardingShardCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ShardingShardCount = (int?) content.GetValueForProperty("ShardingShardCount",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ShardingShardCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DataApiMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApiMode = (string) content.GetValueForProperty("DataApiMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApiMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ReplicationState = (string) content.GetValueForProperty("ReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameterPointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterPointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("RestoreParameterPointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterPointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RestoreParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterSourceResourceId = (string) content.GetValueForProperty("RestoreParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceResourceId = (string) content.GetValueForProperty("ParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ParameterSourceLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceLocation = (string) content.GetValueForProperty("ParameterSourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceLocation, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorUserName = (string) content.GetValueForProperty("AdministratorUserName",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorUserName, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorPassword",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("HighAvailabilityTargetMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailabilityTargetMode = (string) content.GetValueForProperty("HighAvailabilityTargetMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailabilityTargetMode, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ComputeTier = (string) content.GetValueForProperty("ComputeTier",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ComputeTier, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).BackupEarliestRestoreTime = (string) content.GetValueForProperty("BackupEarliestRestoreTime",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).BackupEarliestRestoreTime, global::System.Convert.ToString);
            }
            if (content.Contains("SourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).SourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("Role"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Role = (string) content.GetValueForProperty("Role",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Role, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigAllowedMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfigAllowedMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("AuthConfigAllowedMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfigAllowedMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EncryptionCustomerManagedKeyEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).EncryptionCustomerManagedKeyEncryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties) content.GetValueForProperty("EncryptionCustomerManagedKeyEncryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).EncryptionCustomerManagedKeyEncryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyIdentity = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyIdentity",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyIdentity, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.KeyEncryptionKeyIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyUrl = (string) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyUrl",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyUrl, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityType = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.Replica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Replica(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters) content.GetValueForProperty("RestoreParameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterRestoreParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Parameter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Parameter = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters) content.GetValueForProperty("Parameter",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Parameter, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterReplicaParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Administrator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Administrator = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties) content.GetValueForProperty("Administrator",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Administrator, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StoragePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sharding"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Sharding = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties) content.GetValueForProperty("Sharding",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Sharding, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Compute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Compute = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties) content.GetValueForProperty("Compute",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Compute, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataApi"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApi = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties) content.GetValueForProperty("DataApi",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApi, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PropertiesReplica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PropertiesReplica = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties) content.GetValueForProperty("PropertiesReplica",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PropertiesReplica, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ReplicationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Encryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Encryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Encryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ServerVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ServerVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionString"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ConnectionString = (string) content.GetValueForProperty("ConnectionString",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ConnectionString, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ClusterStatus = (string) content.GetValueForProperty("ClusterStatus",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ClusterStatus, global::System.Convert.ToString);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PreviewFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PreviewFeature = (System.Collections.Generic.List<string>) content.GetValueForProperty("PreviewFeature",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).PreviewFeature, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("InfrastructureVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).InfrastructureVersion = (string) content.GetValueForProperty("InfrastructureVersion",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).InfrastructureVersion, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkBypassMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).NetworkBypassMode = (string) content.GetValueForProperty("NetworkBypassMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).NetworkBypassMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageSizeGb = (long?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageSizeGb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("ShardingShardCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ShardingShardCount = (int?) content.GetValueForProperty("ShardingShardCount",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ShardingShardCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DataApiMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApiMode = (string) content.GetValueForProperty("DataApiMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).DataApiMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ReplicationState = (string) content.GetValueForProperty("ReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("RestoreParameterPointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterPointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("RestoreParameterPointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterPointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RestoreParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterSourceResourceId = (string) content.GetValueForProperty("RestoreParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).RestoreParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ParameterSourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceResourceId = (string) content.GetValueForProperty("ParameterSourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ParameterSourceLocation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceLocation = (string) content.GetValueForProperty("ParameterSourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ParameterSourceLocation, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorUserName = (string) content.GetValueForProperty("AdministratorUserName",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorUserName, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorPassword",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AdministratorPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("HighAvailabilityTargetMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailabilityTargetMode = (string) content.GetValueForProperty("HighAvailabilityTargetMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).HighAvailabilityTargetMode, global::System.Convert.ToString);
            }
            if (content.Contains("ComputeTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ComputeTier = (string) content.GetValueForProperty("ComputeTier",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).ComputeTier, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).BackupEarliestRestoreTime = (string) content.GetValueForProperty("BackupEarliestRestoreTime",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).BackupEarliestRestoreTime, global::System.Convert.ToString);
            }
            if (content.Contains("SourceResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).SourceResourceId = (string) content.GetValueForProperty("SourceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).SourceResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("Role"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Role = (string) content.GetValueForProperty("Role",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).Role, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigAllowedMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfigAllowedMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("AuthConfigAllowedMode",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).AuthConfigAllowedMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EncryptionCustomerManagedKeyEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).EncryptionCustomerManagedKeyEncryption = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties) content.GetValueForProperty("EncryptionCustomerManagedKeyEncryption",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).EncryptionCustomerManagedKeyEncryption, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.CustomerManagedKeyEncryptionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyIdentity = (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyIdentity",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyIdentity, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.KeyEncryptionKeyIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKeyEncryptionKeyUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyUrl = (string) content.GetValueForProperty("CustomerManagedKeyEncryptionKeyUrl",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).CustomerManagedKeyEncryptionKeyUrl, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityType = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityType",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = (string) content.GetValueForProperty("KeyEncryptionKeyIdentityUserAssignedIdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal)this).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId, global::System.Convert.ToString);
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
    /// Represents a mongo cluster replica.
    [System.ComponentModel.TypeConverter(typeof(ReplicaTypeConverter))]
    public partial interface IReplica

    {

    }
}