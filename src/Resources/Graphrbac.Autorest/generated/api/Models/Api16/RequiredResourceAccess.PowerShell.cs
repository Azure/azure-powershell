namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>
    /// Specifies the set of OAuth 2.0 permission scopes and app roles under the specified resource that an application requires
    /// access to. The specified OAuth 2.0 permission scopes may be requested by client applications (through the requiredResourceAccess
    /// collection) when calling a resource application. The requiredResourceAccess property of the Application entity is a collection
    /// of RequiredResourceAccess.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(RequiredResourceAccessTypeConverter))]
    public partial class RequiredResourceAccess
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccess"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RequiredResourceAccess(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccess"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RequiredResourceAccess(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RequiredResourceAccess" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccess"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RequiredResourceAccess(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[]) content.GetValueForProperty("ResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAppId = (string) content.GetValueForProperty("ResourceAppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAppId, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccess"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RequiredResourceAccess(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAccess = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess[]) content.GetValueForProperty("ResourceAccess",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAccess, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IResourceAccess>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ResourceAccessTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAppId = (string) content.GetValueForProperty("ResourceAppId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccessInternal)this).ResourceAppId, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Specifies the set of OAuth 2.0 permission scopes and app roles under the specified resource that an application requires
    /// access to. The specified OAuth 2.0 permission scopes may be requested by client applications (through the requiredResourceAccess
    /// collection) when calling a resource application. The requiredResourceAccess property of the Application entity is a collection
    /// of RequiredResourceAccess.
    [System.ComponentModel.TypeConverter(typeof(RequiredResourceAccessTypeConverter))]
    public partial interface IRequiredResourceAccess

    {

    }
}