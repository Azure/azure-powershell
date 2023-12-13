namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.PowerShell;

    /// <summary>The properties that are associated with an Azure Data Lake Store.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureDataLakeStoreOutputDataSourcePropertiesTypeConverter))]
    public partial class AzureDataLakeStoreOutputDataSourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureDataLakeStoreOutputDataSourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).FilePathPrefix = (string) content.GetValueForProperty("FilePathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).FilePathPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).DateFormat = (string) content.GetValueForProperty("DateFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).DateFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TimeFormat = (string) content.GetValueForProperty("TimeFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TimeFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).RefreshToken = (string) content.GetValueForProperty("RefreshToken",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).RefreshToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserPrincipalName = (string) content.GetValueForProperty("TokenUserPrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserPrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserDisplayName = (string) content.GetValueForProperty("TokenUserDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserDisplayName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureDataLakeStoreOutputDataSourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AccountName = (string) content.GetValueForProperty("AccountName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).FilePathPrefix = (string) content.GetValueForProperty("FilePathPrefix",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).FilePathPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).DateFormat = (string) content.GetValueForProperty("DateFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).DateFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TimeFormat = (string) content.GetValueForProperty("TimeFormat",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).TimeFormat, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AuthenticationMode = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode?) content.GetValueForProperty("AuthenticationMode",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)this).AuthenticationMode, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).RefreshToken = (string) content.GetValueForProperty("RefreshToken",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).RefreshToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserPrincipalName = (string) content.GetValueForProperty("TokenUserPrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserPrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserDisplayName = (string) content.GetValueForProperty("TokenUserDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)this).TokenUserDisplayName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureDataLakeStoreOutputDataSourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureDataLakeStoreOutputDataSourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureDataLakeStoreOutputDataSourceProperties" />, deserializing the content from
        /// a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties that are associated with an Azure Data Lake Store.
    [System.ComponentModel.TypeConverter(typeof(AzureDataLakeStoreOutputDataSourcePropertiesTypeConverter))]
    public partial interface IAzureDataLakeStoreOutputDataSourceProperties

    {

    }
}