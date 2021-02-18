namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Publishing options for requested profile.</summary>
    [System.ComponentModel.TypeConverter(typeof(CsmPublishingProfileOptionsTypeConverter))]
    public partial class CsmPublishingProfileOptions
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingProfileOptions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CsmPublishingProfileOptions(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).IncludeDisasterRecoveryEndpoint = (bool?) content.GetValueForProperty("IncludeDisasterRecoveryEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).IncludeDisasterRecoveryEndpoint, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingProfileOptions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CsmPublishingProfileOptions(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).Format = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat?) content.GetValueForProperty("Format",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).Format, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublishingProfileFormat.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).IncludeDisasterRecoveryEndpoint = (bool?) content.GetValueForProperty("IncludeDisasterRecoveryEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptionsInternal)this).IncludeDisasterRecoveryEndpoint, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingProfileOptions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CsmPublishingProfileOptions(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingProfileOptions"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CsmPublishingProfileOptions(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CsmPublishingProfileOptions" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingProfileOptions FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Publishing options for requested profile.
    [System.ComponentModel.TypeConverter(typeof(CsmPublishingProfileOptionsTypeConverter))]
    public partial interface ICsmPublishingProfileOptions

    {

    }
}