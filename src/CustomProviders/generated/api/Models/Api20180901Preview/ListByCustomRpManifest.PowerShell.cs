namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.PowerShell;

    /// <summary>List of custom resource providers.</summary>
    [System.ComponentModel.TypeConverter(typeof(ListByCustomRpManifestTypeConverter))]
    public partial class ListByCustomRpManifest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ListByCustomRpManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ListByCustomRpManifest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ListByCustomRpManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ListByCustomRpManifest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ListByCustomRpManifest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ListByCustomRpManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ListByCustomRpManifest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest>(__y, Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.CustomRpManifestTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ListByCustomRpManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ListByCustomRpManifest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IListByCustomRpManifestInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest>(__y, Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.CustomRpManifestTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// List of custom resource providers.
    [System.ComponentModel.TypeConverter(typeof(ListByCustomRpManifestTypeConverter))]
    public partial interface IListByCustomRpManifest

    {

    }
}