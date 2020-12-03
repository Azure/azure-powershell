namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

    /// <summary>The properties to create a new replica.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesForReplicaTypeConverter))]
    public partial class ServerPropertiesForReplica
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForReplica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplica" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplica DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerPropertiesForReplica(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForReplica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplica" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplica DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerPropertiesForReplica(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerPropertiesForReplica" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplica FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForReplica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerPropertiesForReplica(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplicaInternal)this).SourceServerId = (string) content.GetValueForProperty("SourceServerId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplicaInternal)this).SourceServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).InfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption?) content.GetValueForProperty("InfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).InfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForReplica"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerPropertiesForReplica(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplicaInternal)this).SourceServerId = (string) content.GetValueForProperty("SourceServerId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForReplicaInternal)this).SourceServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).InfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption?) content.GetValueForProperty("InfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).InfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties to create a new replica.
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesForReplicaTypeConverter))]
    public partial interface IServerPropertiesForReplica

    {

    }
}