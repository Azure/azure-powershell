namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// A container holding only the Tags for a resource, allowing the user to update the tags on a WebTest instance.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(TagsResourceTypeConverter))]
    public partial class TagsResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TagsResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TagsResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TagsResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TagsResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResourceTagsTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TagsResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ITagsResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.TagsResourceTagsTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A container holding only the Tags for a resource, allowing the user to update the tags on a WebTest instance.
    [System.ComponentModel.TypeConverter(typeof(TagsResourceTypeConverter))]
    public partial interface ITagsResource

    {

    }
}