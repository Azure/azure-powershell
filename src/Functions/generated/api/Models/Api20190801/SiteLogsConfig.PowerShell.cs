namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Configuration of App Service site logs.</summary>
    [System.ComponentModel.TypeConverter(typeof(SiteLogsConfigTypeConverter))]
    public partial class SiteLogsConfig
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SiteLogsConfig(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SiteLogsConfig(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SiteLogsConfig" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfig FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SiteLogsConfig(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfigPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLog = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig) content.GetValueForProperty("ApplicationLog",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLog, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig) content.GetValueForProperty("DetailedErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLog = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig) content.GetValueForProperty("HttpLog",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLog, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestsTracing = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig) content.GetValueForProperty("FailedRequestsTracing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestsTracing, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig) content.GetValueForProperty("ApplicationLogAzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessageEnabled = (bool?) content.GetValueForProperty("DetailedErrorMessageEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessageEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogFileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig) content.GetValueForProperty("HttpLogFileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogFileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemHttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogAzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig) content.GetValueForProperty("HttpLogAzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogAzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageHttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestTracingEnabled = (bool?) content.GetValueForProperty("FailedRequestTracingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestTracingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureTableStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig) content.GetValueForProperty("ApplicationLogAzureTableStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureTableStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogFileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig) content.GetValueForProperty("ApplicationLogFileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogFileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInMb = (int?) content.GetValueForProperty("FileSystemRetentionInMb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageSasUrl = (string) content.GetValueForProperty("AzureTableStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureTableStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageSasUrl = (string) content.GetValueForProperty("ApplicationLogsAzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("ApplicationLogsAzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureBlobStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("FileSystemLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("HttpLogsAzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageSasUrl = (string) content.GetValueForProperty("HttpLogsAzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemEnabled = (bool?) content.GetValueForProperty("FileSystemEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInDay = (int?) content.GetValueForProperty("FileSystemRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageEnabled = (bool?) content.GetValueForProperty("AzureBlobStorageEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SiteLogsConfig(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLogsConfigPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLog = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationLogsConfig) content.GetValueForProperty("ApplicationLog",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLog, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig) content.GetValueForProperty("DetailedErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLog = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHttpLogsConfig) content.GetValueForProperty("HttpLog",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLog, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestsTracing = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig) content.GetValueForProperty("FailedRequestsTracing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestsTracing, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EnabledConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageApplicationLogsConfig) content.GetValueForProperty("ApplicationLogAzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessageEnabled = (bool?) content.GetValueForProperty("DetailedErrorMessageEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).DetailedErrorMessageEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogFileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemHttpLogsConfig) content.GetValueForProperty("HttpLogFileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogFileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemHttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogAzureBlobStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig) content.GetValueForProperty("HttpLogAzureBlobStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogAzureBlobStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureBlobStorageHttpLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestTracingEnabled = (bool?) content.GetValueForProperty("FailedRequestTracingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FailedRequestTracingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureTableStorage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureTableStorageApplicationLogsConfig) content.GetValueForProperty("ApplicationLogAzureTableStorage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogAzureTableStorage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AzureTableStorageApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogFileSystem = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFileSystemApplicationLogsConfig) content.GetValueForProperty("ApplicationLogFileSystem",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogFileSystem, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FileSystemApplicationLogsConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInMb = (int?) content.GetValueForProperty("FileSystemRetentionInMb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageSasUrl = (string) content.GetValueForProperty("AzureTableStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureTableStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureTableStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageSasUrl = (string) content.GetValueForProperty("ApplicationLogsAzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("ApplicationLogsAzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).ApplicationLogsAzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("AzureBlobStorageLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemLevel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel?) content.GetValueForProperty("FileSystemLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemLevel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LogLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageRetentionInDay = (int?) content.GetValueForProperty("HttpLogsAzureBlobStorageRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageSasUrl = (string) content.GetValueForProperty("HttpLogsAzureBlobStorageSasUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).HttpLogsAzureBlobStorageSasUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemEnabled = (bool?) content.GetValueForProperty("FileSystemEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInDay = (int?) content.GetValueForProperty("FileSystemRetentionInDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).FileSystemRetentionInDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageEnabled = (bool?) content.GetValueForProperty("AzureBlobStorageEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLogsConfigInternal)this).AzureBlobStorageEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Configuration of App Service site logs.
    [System.ComponentModel.TypeConverter(typeof(SiteLogsConfigTypeConverter))]
    public partial interface ISiteLogsConfig

    {

    }
}