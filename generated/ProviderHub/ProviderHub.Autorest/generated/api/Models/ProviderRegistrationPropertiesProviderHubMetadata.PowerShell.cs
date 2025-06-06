// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProviderRegistrationPropertiesProviderHubMetadata(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProviderRegistrationPropertiesProviderHubMetadata(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProviderRegistrationPropertiesProviderHubMetadata" />, deserializing the content
        /// from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="ProviderRegistrationPropertiesProviderHubMetadata" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistrationPropertiesProviderHubMetadata FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderRegistrationPropertiesProviderHubMetadata"
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
            if (content.Contains("ThirdPartyProviderAuthorizationAuthorizations"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorizations = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization>) content.GetValueForProperty("ThirdPartyProviderAuthorizationAuthorizations",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorizations, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.LightHouseAuthorizationTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProviderAuthenticationAllowedAudience"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience = (System.Collections.Generic.List<string>) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ThirdPartyProviderAuthorizationManagedByTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId = (string) content.GetValueForProperty("ThirdPartyProviderAuthorizationManagedByTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("ProviderAuthentication"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderHubMetadataProviderAuthenticationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ThirdPartyProviderAuthorization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataThirdPartyProviderAuthorization) content.GetValueForProperty("ThirdPartyProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderHubMetadataThirdPartyProviderAuthorizationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProviderAuthorization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthorization = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization>) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderRegistrationPropertiesProviderHubMetadata"
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
            if (content.Contains("ThirdPartyProviderAuthorizationAuthorizations"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorizations = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization>) content.GetValueForProperty("ThirdPartyProviderAuthorizationAuthorizations",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationAuthorizations, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.LightHouseAuthorizationTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProviderAuthenticationAllowedAudience"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience = (System.Collections.Generic.List<string>) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ThirdPartyProviderAuthorizationManagedByTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId = (string) content.GetValueForProperty("ThirdPartyProviderAuthorizationManagedByTenantId",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorizationManagedByTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("ProviderAuthentication"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderHubMetadataProviderAuthenticationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ThirdPartyProviderAuthorization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataThirdPartyProviderAuthorization) content.GetValueForProperty("ThirdPartyProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ThirdPartyProviderAuthorization, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ProviderHubMetadataThirdPartyProviderAuthorizationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProviderAuthorization"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthorization = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization>) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubMetadataInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    [System.ComponentModel.TypeConverter(typeof(ProviderRegistrationPropertiesProviderHubMetadataTypeConverter))]
    public partial interface IProviderRegistrationPropertiesProviderHubMetadata

    {

    }
}