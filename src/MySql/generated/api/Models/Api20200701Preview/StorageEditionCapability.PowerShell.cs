namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

    /// <summary>storage edition capability</summary>
    [System.ComponentModel.TypeConverter(typeof(StorageEditionCapabilityTypeConverter))]
    public partial class StorageEditionCapability
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StorageEditionCapability(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StorageEditionCapability(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StorageEditionCapability" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StorageEditionCapability(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSize = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability) content.GetValueForProperty("MinStorageSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSize, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapabilityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSize = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability) content.GetValueForProperty("MaxStorageSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSize, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapabilityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinBackupRetentionDay = (long?) content.GetValueForProperty("MinBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinBackupRetentionDay, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxBackupRetentionDay = (long?) content.GetValueForProperty("MaxBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxBackupRetentionDay, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeName = (string) content.GetValueForProperty("MinStorageSizeName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeMb = (long?) content.GetValueForProperty("MinStorageSizeMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeName = (string) content.GetValueForProperty("MaxStorageSizeName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeMb = (long?) content.GetValueForProperty("MaxStorageSizeMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StorageEditionCapability(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSize = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability) content.GetValueForProperty("MinStorageSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSize, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapabilityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSize = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability) content.GetValueForProperty("MaxStorageSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSize, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapabilityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinBackupRetentionDay = (long?) content.GetValueForProperty("MinBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinBackupRetentionDay, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxBackupRetentionDay = (long?) content.GetValueForProperty("MaxBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxBackupRetentionDay, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeName = (string) content.GetValueForProperty("MinStorageSizeName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeMb = (long?) content.GetValueForProperty("MinStorageSizeMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MinStorageSizeMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeName = (string) content.GetValueForProperty("MaxStorageSizeName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeMb = (long?) content.GetValueForProperty("MaxStorageSizeMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal)this).MaxStorageSizeMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// storage edition capability
    [System.ComponentModel.TypeConverter(typeof(StorageEditionCapabilityTypeConverter))]
    public partial interface IStorageEditionCapability

    {

    }
}