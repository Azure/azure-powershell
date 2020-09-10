namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>The properties of a storage account’s Blob service.</summary>
    [System.ComponentModel.TypeConverter(typeof(BlobServicePropertiesTypeConverter))]
    public partial class BlobServiceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BlobServiceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServiceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1) content.GetValueForProperty("BlobServiceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServiceProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties1TypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyChangeFeed = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed) content.GetValueForProperty("BlobServicePropertyChangeFeed",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyChangeFeed, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ChangeFeedTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyCor = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules) content.GetValueForProperty("BlobServicePropertyCor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyCor, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDeleteRetentionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy) content.GetValueForProperty("BlobServicePropertyDeleteRetentionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDeleteRetentionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DeleteRetentionPolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyAutomaticSnapshotPolicyEnabled = (bool?) content.GetValueForProperty("BlobServicePropertyAutomaticSnapshotPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyAutomaticSnapshotPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDefaultServiceVersion = (string) content.GetValueForProperty("BlobServicePropertyDefaultServiceVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDefaultServiceVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).CorCorsRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[]) content.GetValueForProperty("CorCorsRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).CorCorsRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).ChangeFeedEnabled = (bool?) content.GetValueForProperty("ChangeFeedEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).ChangeFeedEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyDay = (int?) content.GetValueForProperty("DeleteRetentionPolicyDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyEnabled = (bool?) content.GetValueForProperty("DeleteRetentionPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BlobServiceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServiceProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1) content.GetValueForProperty("BlobServiceProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServiceProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties1TypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyChangeFeed = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed) content.GetValueForProperty("BlobServicePropertyChangeFeed",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyChangeFeed, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ChangeFeedTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyCor = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules) content.GetValueForProperty("BlobServicePropertyCor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyCor, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRulesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDeleteRetentionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy) content.GetValueForProperty("BlobServicePropertyDeleteRetentionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDeleteRetentionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DeleteRetentionPolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyAutomaticSnapshotPolicyEnabled = (bool?) content.GetValueForProperty("BlobServicePropertyAutomaticSnapshotPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyAutomaticSnapshotPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDefaultServiceVersion = (string) content.GetValueForProperty("BlobServicePropertyDefaultServiceVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).BlobServicePropertyDefaultServiceVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).CorCorsRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[]) content.GetValueForProperty("CorCorsRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).CorCorsRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).ChangeFeedEnabled = (bool?) content.GetValueForProperty("ChangeFeedEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).ChangeFeedEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyDay = (int?) content.GetValueForProperty("DeleteRetentionPolicyDay",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyEnabled = (bool?) content.GetValueForProperty("DeleteRetentionPolicyEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServicePropertiesInternal)this).DeleteRetentionPolicyEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BlobServiceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.BlobServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BlobServiceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BlobServiceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of a storage account’s Blob service.
    [System.ComponentModel.TypeConverter(typeof(BlobServicePropertiesTypeConverter))]
    public partial interface IBlobServiceProperties

    {

    }
}