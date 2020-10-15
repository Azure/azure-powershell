namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.PowerShell;

    /// <summary>Represents a server to be created.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerForCreateTypeConverter))]
    public partial class ServerForCreate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerForCreate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerForCreate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerForCreate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerForCreate(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForCreateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerForCreate(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesForCreate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForCreateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Represents a server to be created.
    [System.ComponentModel.TypeConverter(typeof(ServerForCreateTypeConverter))]
    public partial interface IServerForCreate

    {

    }
}