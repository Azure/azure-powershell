namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>
    /// Represents an OAuth 2.0 delegated permission scope. The specified OAuth 2.0 delegated permission scopes may be requested
    /// by client applications (through the requiredResourceAccess collection on the Application object) when calling a resource
    /// application. The oauth2Permissions property of the ServicePrincipal entity and of the Application entity is a collection
    /// of OAuth2Permission.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(OAuth2PermissionTypeConverter))]
    public partial class OAuth2Permission
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OAuth2Permission(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OAuth2Permission(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OAuth2Permission" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OAuth2Permission(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDescription = (string) content.GetValueForProperty("AdminConsentDescription",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDisplayName = (string) content.GetValueForProperty("AdminConsentDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDescription = (string) content.GetValueForProperty("UserConsentDescription",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDisplayName = (string) content.GetValueForProperty("UserConsentDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Value, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OAuth2Permission(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDescription = (string) content.GetValueForProperty("AdminConsentDescription",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDisplayName = (string) content.GetValueForProperty("AdminConsentDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).AdminConsentDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDescription = (string) content.GetValueForProperty("UserConsentDescription",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDisplayName = (string) content.GetValueForProperty("UserConsentDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).UserConsentDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionInternal)this).Value, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Represents an OAuth 2.0 delegated permission scope. The specified OAuth 2.0 delegated permission scopes may be requested
    /// by client applications (through the requiredResourceAccess collection on the Application object) when calling a resource
    /// application. The oauth2Permissions property of the ServicePrincipal entity and of the Application entity is a collection
    /// of OAuth2Permission.
    [System.ComponentModel.TypeConverter(typeof(OAuth2PermissionTypeConverter))]
    public partial interface IOAuth2Permission

    {

    }
}