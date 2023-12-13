namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.PowerShell;

    /// <summary>Describes an Azure Data Lake Store output data source.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureDataLakeStoreOutputDataSourceTypeConverter))]
    public partial class AzureDataLakeStoreOutputDataSource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureDataLakeStoreOutputDataSource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).RefreshToken = (string) content.GetValueForProperty("RefreshToken",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).RefreshToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserPrincipalName = (string) content.GetValueForProperty("TokenUserPrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserPrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserDisplayName = (string) content.GetValueForProperty("TokenUserDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).FilePathPrefix = (string) content.GetValueForProperty("FilePathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).FilePathPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).DateFormat = (string) content.GetValueForProperty("DateFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).DateFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TimeFormat = (string) content.GetValueForProperty("TimeFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TimeFormat, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureDataLakeStoreOutputDataSource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourcePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).RefreshToken = (string) content.GetValueForProperty("RefreshToken",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).RefreshToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserPrincipalName = (string) content.GetValueForProperty("TokenUserPrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserPrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserDisplayName = (string) content.GetValueForProperty("TokenUserDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TokenUserDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).FilePathPrefix = (string) content.GetValueForProperty("FilePathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).FilePathPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).DateFormat = (string) content.GetValueForProperty("DateFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).DateFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TimeFormat = (string) content.GetValueForProperty("TimeFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal)this).TimeFormat, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureDataLakeStoreOutputDataSource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureDataLakeStoreOutputDataSource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureDataLakeStoreOutputDataSource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes an Azure Data Lake Store output data source.
    [System.ComponentModel.TypeConverter(typeof(AzureDataLakeStoreOutputDataSourceTypeConverter))]
    public partial interface IAzureDataLakeStoreOutputDataSource

    {

    }
}