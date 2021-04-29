namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ProviderRegistrationPropertiesProviderHubMetadataTypeConverter))]
    public partial class ProviderRegistrationPropertiesProviderHubMetadata
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProviderRegistrationPropertiesProviderHubMetadata(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProviderRegistrationPropertiesProviderHubMetadata(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProviderRegistrationPropertiesProviderHubMetadata" />, deserializing the content
        /// from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistrationPropertiesProviderHubMetadata FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProviderRegistrationPropertiesProviderHubMetadata(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]) content.GetValueForProperty("ThirdPartyProviderAuthorizationAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LightHouseAuthorizationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience = (string[]) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId = (string) content.GetValueForProperty("ThirdPartyProviderAuthorizationManagedByTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthenticationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization) content.GetValueForProperty("ThirdPartyProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThirdPartyProviderAuthorizationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProviderRegistrationPropertiesProviderHubMetadata(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]) content.GetValueForProperty("ThirdPartyProviderAuthorizationAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LightHouseAuthorizationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience = (string[]) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId = (string) content.GetValueForProperty("ThirdPartyProviderAuthorizationManagedByTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthenticationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThirdPartyProviderAuthorization) content.GetValueForProperty("ThirdPartyProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ThirdPartyProviderAuthorizationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderHubMetadataInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ProviderRegistrationPropertiesProviderHubMetadataTypeConverter))]
    public partial interface IProviderRegistrationPropertiesProviderHubMetadata

    {

    }
}