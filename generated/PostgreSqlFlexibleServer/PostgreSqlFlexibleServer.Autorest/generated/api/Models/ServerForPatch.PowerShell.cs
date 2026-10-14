// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Represents a server to be updated.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerForPatchTypeConverter))]
    public partial class ServerForPatch
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerForPatch(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerForPatch(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerForPatch" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ServerForPatch" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerForPatch(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatchTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatch) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatch) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowForPatch) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigForPatch) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatch"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerForPatch(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatchTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatch) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatch) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowForPatch) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigForPatch) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigForPatchTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
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
    /// Represents a server to be updated.
    [System.ComponentModel.TypeConverter(typeof(ServerForPatchTypeConverter))]
    public partial interface IServerForPatch

    {

    }
}