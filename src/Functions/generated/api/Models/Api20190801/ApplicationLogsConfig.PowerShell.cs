namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Application logs configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationLogsConfigTypeConverter))]
    public partial class ApplicationLogsConfig
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationLogsConfig(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig) content.GetValueForProperty("AzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig) content.GetValueForProperty("AzureTableStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig) content.GetValueForProperty("FileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureBlobStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("AzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageSasUrl = (string) content.GetValueForProperty("AzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureTableStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageSasUrl = (string) content.GetValueForProperty("AzureTableStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystemLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("FileSystemLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystemLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationLogsConfig(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig) content.GetValueForProperty("AzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig) content.GetValueForProperty("AzureTableStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig) content.GetValueForProperty("FileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureBlobStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("AzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageSasUrl = (string) content.GetValueForProperty("AzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureTableStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageSasUrl = (string) content.GetValueForProperty("AzureTableStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).AzureTableStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystemLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("FileSystemLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfigInternal)this).FileSystemLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationLogsConfig(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationLogsConfig(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationLogsConfig" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Application logs configuration.
    [System.ComponentModel.TypeConverter(typeof(ApplicationLogsConfigTypeConverter))]
    public partial interface IApplicationLogsConfig

    {

    }
}