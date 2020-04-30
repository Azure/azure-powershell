namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.PowerShell;

    /// <summary>The properties used to create a new server by restoring from a backup.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesForRestoreTypeConverter))]
    public partial class ServerPropertiesForRestore
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestore"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestore DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerPropertiesForRestore(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestore"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestore DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerPropertiesForRestore(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerPropertiesForRestore" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestore FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerPropertiesForRestore(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).RestorePointInTime = (global::System.DateTime) content.GetValueForProperty("RestorePointInTime",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).RestorePointInTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).SourceServerId = (string) content.GetValueForProperty("SourceServerId",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).SourceServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerPropertiesForRestore(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).RestorePointInTime = (global::System.DateTime) content.GetValueForProperty("RestorePointInTime",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).RestorePointInTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).SourceServerId = (string) content.GetValueForProperty("SourceServerId",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForRestoreInternal)this).SourceServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties used to create a new server by restoring from a backup.
    [System.ComponentModel.TypeConverter(typeof(ServerPropertiesForRestoreTypeConverter))]
    public partial interface IServerPropertiesForRestore

    {

    }
}