namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Site Extension Information.</summary>
    [System.ComponentModel.TypeConverter(typeof(SiteExtensionInfoTypeConverter))]
    public partial class SiteExtensionInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SiteExtensionInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SiteExtensionInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SiteExtensionInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SiteExtensionInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstallerCommandLineParam = (string) content.GetValueForProperty("InstallerCommandLineParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstallerCommandLineParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Comment = (string) content.GetValueForProperty("Comment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Comment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).DownloadCount = (int?) content.GetValueForProperty("DownloadCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).DownloadCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionId = (string) content.GetValueForProperty("ExtensionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType?) content.GetValueForProperty("ExtensionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionUrl = (string) content.GetValueForProperty("ExtensionUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).FeedUrl = (string) content.GetValueForProperty("FeedUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).FeedUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).IconUrl = (string) content.GetValueForProperty("IconUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).IconUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstalledDateTime = (global::System.DateTime?) content.GetValueForProperty("InstalledDateTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstalledDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Author = (string[]) content.GetValueForProperty("Author",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Author, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LicenseUrl = (string) content.GetValueForProperty("LicenseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LicenseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalIsLatestVersion = (bool?) content.GetValueForProperty("LocalIsLatestVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalIsLatestVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalPath = (string) content.GetValueForProperty("LocalPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProjectUrl = (string) content.GetValueForProperty("ProjectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProjectUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).PublishedDateTime = (global::System.DateTime?) content.GetValueForProperty("PublishedDateTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).PublishedDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Summary = (string) content.GetValueForProperty("Summary",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Summary, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Title = (string) content.GetValueForProperty("Title",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Title, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Version, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SiteExtensionInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteExtensionInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstallerCommandLineParam = (string) content.GetValueForProperty("InstallerCommandLineParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstallerCommandLineParam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Comment = (string) content.GetValueForProperty("Comment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Comment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).DownloadCount = (int?) content.GetValueForProperty("DownloadCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).DownloadCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionId = (string) content.GetValueForProperty("ExtensionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType?) content.GetValueForProperty("ExtensionType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteExtensionType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionUrl = (string) content.GetValueForProperty("ExtensionUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ExtensionUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).FeedUrl = (string) content.GetValueForProperty("FeedUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).FeedUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).IconUrl = (string) content.GetValueForProperty("IconUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).IconUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstalledDateTime = (global::System.DateTime?) content.GetValueForProperty("InstalledDateTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).InstalledDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Author = (string[]) content.GetValueForProperty("Author",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Author, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LicenseUrl = (string) content.GetValueForProperty("LicenseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LicenseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalIsLatestVersion = (bool?) content.GetValueForProperty("LocalIsLatestVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalIsLatestVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalPath = (string) content.GetValueForProperty("LocalPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).LocalPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProjectUrl = (string) content.GetValueForProperty("ProjectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProjectUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).PublishedDateTime = (global::System.DateTime?) content.GetValueForProperty("PublishedDateTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).PublishedDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Summary = (string) content.GetValueForProperty("Summary",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Summary, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Title = (string) content.GetValueForProperty("Title",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Title, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Version = (string) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteExtensionInfoInternal)this).Version, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Site Extension Information.
    [System.ComponentModel.TypeConverter(typeof(SiteExtensionInfoTypeConverter))]
    public partial interface ISiteExtensionInfo

    {

    }
}