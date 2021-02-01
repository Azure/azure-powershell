namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(OAuth2PermissionGrantTypeConverter))]
    public partial class OAuth2PermissionGrant
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionGrant"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OAuth2PermissionGrant(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionGrant"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OAuth2PermissionGrant(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OAuth2PermissionGrant" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionGrant"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OAuth2PermissionGrant(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ConsentType = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType?) content.GetValueForProperty("ConsentType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ConsentType, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ExpiryTime = (string) content.GetValueForProperty("ExpiryTime",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ExpiryTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).OdataType = (string) content.GetValueForProperty("OdataType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).OdataType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).Scope, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).StartTime = (string) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).StartTime, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2PermissionGrant"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OAuth2PermissionGrant(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ConsentType = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType?) content.GetValueForProperty("ConsentType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ConsentType, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ExpiryTime = (string) content.GetValueForProperty("ExpiryTime",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ExpiryTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).OdataType = (string) content.GetValueForProperty("OdataType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).OdataType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).Scope, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).StartTime = (string) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal)this).StartTime, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(OAuth2PermissionGrantTypeConverter))]
    public partial interface IOAuth2PermissionGrant

    {

    }
}