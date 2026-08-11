// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Properties of a server.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerTypeConverter))]
    public partial class Server
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Server"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Server(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Server"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Server(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Server" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Server" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Server"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Server(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("MinorVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MinorVersion = (string) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MinorVersion, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).FullyQualifiedDomainName = (string) content.GetValueForProperty("FullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).FullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("SourceServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SourceServerResourceId = (string) content.GetValueForProperty("SourceServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SourceServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("PointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("PointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("Capacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Server"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Server(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("Storage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Storage = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage) content.GetValueForProperty("Storage",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Storage, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfig = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig) content.GetValueForProperty("AuthConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfig, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfigTypeConverter.ConvertFrom);
            }
            if (content.Contains("DataEncryption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryption = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption) content.GetValueForProperty("DataEncryption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryption, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryptionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Backup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Backup = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup) content.GetValueForProperty("Backup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Backup, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupTypeConverter.ConvertFrom);
            }
            if (content.Contains("Network"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Network = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork) content.GetValueForProperty("Network",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Network, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.NetworkTypeConverter.ConvertFrom);
            }
            if (content.Contains("HighAvailability"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailability = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability) content.GetValueForProperty("HighAvailability",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailability, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailabilityTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaintenanceWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindow = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow) content.GetValueForProperty("MaintenanceWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindow, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindowTypeConverter.ConvertFrom);
            }
            if (content.Contains("Replica"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Replica = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica) content.GetValueForProperty("Replica",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Replica, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ReplicaTypeConverter.ConvertFrom);
            }
            if (content.Contains("Cluster"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Cluster = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster) content.GetValueForProperty("Cluster",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Cluster, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ClusterTypeConverter.ConvertFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("CreateMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).CreateMode = (string) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).CreateMode, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuTier, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLogin"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLogin = (string) content.GetValueForProperty("AdministratorLogin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLogin, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Version, global::System.Convert.ToString);
            }
            if (content.Contains("MinorVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MinorVersion = (string) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MinorVersion, global::System.Convert.ToString);
            }
            if (content.Contains("State"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).State, global::System.Convert.ToString);
            }
            if (content.Contains("FullyQualifiedDomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).FullyQualifiedDomainName = (string) content.GetValueForProperty("FullyQualifiedDomainName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).FullyQualifiedDomainName, global::System.Convert.ToString);
            }
            if (content.Contains("SourceServerResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SourceServerResourceId = (string) content.GetValueForProperty("SourceServerResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SourceServerResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("PointInTimeUtc"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PointInTimeUtc = (global::System.DateTime?) content.GetValueForProperty("PointInTimeUtc",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PointInTimeUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AvailabilityZone = (string) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaCapacity = (int?) content.GetValueForProperty("ReplicaCapacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("StorageAutoGrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageAutoGrow = (string) content.GetValueForProperty("StorageAutoGrow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageAutoGrow, global::System.Convert.ToString);
            }
            if (content.Contains("StorageType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageType = (string) content.GetValueForProperty("StorageType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageType, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionType = (string) content.GetValueForProperty("DataEncryptionType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionType, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityState = (string) content.GetValueForProperty("HighAvailabilityState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityState, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaReplicationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaReplicationState = (string) content.GetValueForProperty("ReplicaReplicationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaReplicationState, global::System.Convert.ToString);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("StorageSizeGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageSizeGb = (int?) content.GetValueForProperty("StorageSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageTier = (string) content.GetValueForProperty("StorageTier",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageTier, global::System.Convert.ToString);
            }
            if (content.Contains("StorageIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageIop = (int?) content.GetValueForProperty("StorageIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageThroughput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageThroughput = (int?) content.GetValueForProperty("StorageThroughput",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).StorageThroughput, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AuthConfigActiveDirectoryAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigActiveDirectoryAuth = (string) content.GetValueForProperty("AuthConfigActiveDirectoryAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigActiveDirectoryAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigPasswordAuth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigPasswordAuth = (string) content.GetValueForProperty("AuthConfigPasswordAuth",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigPasswordAuth, global::System.Convert.ToString);
            }
            if (content.Contains("AuthConfigTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigTenantId = (string) content.GetValueForProperty("AuthConfigTenantId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).AuthConfigTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryKeyUri = (string) content.GetValueForProperty("DataEncryptionPrimaryKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionPrimaryUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupKeyUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupKeyUri = (string) content.GetValueForProperty("DataEncryptionGeoBackupKeyUri",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupKeyUri, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupUserAssignedIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId = (string) content.GetValueForProperty("DataEncryptionGeoBackupUserAssignedIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupUserAssignedIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionPrimaryEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionPrimaryEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionPrimaryEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DataEncryptionGeoBackupEncryptionKeyStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus = (string) content.GetValueForProperty("DataEncryptionGeoBackupEncryptionKeyStatus",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).DataEncryptionGeoBackupEncryptionKeyStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupRetentionDay = (int?) content.GetValueForProperty("BackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BackupGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupGeoRedundantBackup = (string) content.GetValueForProperty("BackupGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupGeoRedundantBackup, global::System.Convert.ToString);
            }
            if (content.Contains("BackupEarliestRestoreDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupEarliestRestoreDate = (global::System.DateTime?) content.GetValueForProperty("BackupEarliestRestoreDate",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).BackupEarliestRestoreDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("NetworkPublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPublicNetworkAccess = (string) content.GetValueForProperty("NetworkPublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkDelegatedSubnetResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkDelegatedSubnetResourceId = (string) content.GetValueForProperty("NetworkDelegatedSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkDelegatedSubnetResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("NetworkPrivateDnsZoneArmResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPrivateDnsZoneArmResourceId = (string) content.GetValueForProperty("NetworkPrivateDnsZoneArmResourceId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).NetworkPrivateDnsZoneArmResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityMode = (string) content.GetValueForProperty("HighAvailabilityMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityMode, global::System.Convert.ToString);
            }
            if (content.Contains("HighAvailabilityStandbyAvailabilityZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityStandbyAvailabilityZone = (string) content.GetValueForProperty("HighAvailabilityStandbyAvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).HighAvailabilityStandbyAvailabilityZone, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowCustomWindow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowCustomWindow = (string) content.GetValueForProperty("MaintenanceWindowCustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowCustomWindow, global::System.Convert.ToString);
            }
            if (content.Contains("MaintenanceWindowStartHour"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartHour = (int?) content.GetValueForProperty("MaintenanceWindowStartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowStartMinute"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartMinute = (int?) content.GetValueForProperty("MaintenanceWindowStartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowStartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MaintenanceWindowDayOfWeek"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowDayOfWeek = (int?) content.GetValueForProperty("MaintenanceWindowDayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).MaintenanceWindowDayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaRole = (string) content.GetValueForProperty("ReplicaRole",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaRole, global::System.Convert.ToString);
            }
            if (content.Contains("Capacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ReplicaPromoteMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteMode = (string) content.GetValueForProperty("ReplicaPromoteMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteMode, global::System.Convert.ToString);
            }
            if (content.Contains("ReplicaPromoteOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteOption = (string) content.GetValueForProperty("ReplicaPromoteOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ReplicaPromoteOption, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterSize = (int?) content.GetValueForProperty("ClusterSize",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterSize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ClusterDefaultDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterDefaultDatabaseName = (string) content.GetValueForProperty("ClusterDefaultDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerInternal)this).ClusterDefaultDatabaseName, global::System.Convert.ToString);
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
    [System.ComponentModel.TypeConverter(typeof(ServerTypeConverter))]
    public partial interface IServer

    {

    }
}