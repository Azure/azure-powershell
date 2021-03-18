namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerForCreate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerForCreate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerForCreate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreate"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ResourceIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForCreateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).InfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption?) content.GetValueForProperty("InfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).InfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreate"
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
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ResourceIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesForCreate) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPropertiesForCreateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerForCreateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).InfrastructureEncryption = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption?) content.GetValueForProperty("InfrastructureEncryption",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).InfrastructureEncryption, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).CreateMode = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode) content.GetValueForProperty("CreateMode",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).CreateMode, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.CreateMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Represents a server to be created.
    [System.ComponentModel.TypeConverter(typeof(ServerForCreateTypeConverter))]
    public partial interface IServerForCreate

    {

    }
}