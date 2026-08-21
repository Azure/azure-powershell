// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Properties of a server.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesTypeConverter))]
    public partial class ServerProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ServerProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("MinorVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MinorVersion = (string) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MinorVersion, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).FullyQualifiedDomainName = (string) content.GetValueForProperty("FullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).FullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("SourceServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).SourceServerResourceId = (string) content.GetValueForProperty("SourceServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).SourceServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("PointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("PointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("Capacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("MinorVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MinorVersion = (string) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MinorVersion, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).FullyQualifiedDomainName = (string) content.GetValueForProperty("FullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).FullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("SourceServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).SourceServerResourceId = (string) content.GetValueForProperty("SourceServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).SourceServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("PointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("PointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("Capacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Properties of a server.
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesTypeConverter))]
    public partial interface IServerProperties

    {

    }
}