namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ResourceProviderManifestTypeConverter))]
    public partial class ResourceProviderManifest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceProviderManifest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceProviderManifest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceProviderManifest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceProviderManifest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthenticationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeaturesRule = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule) content.GetValueForProperty("FeaturesRule",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeaturesRule, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRuleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOption = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions) content.GetValueForProperty("RequestHeaderOption",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOption, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Management = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement) content.GetValueForProperty("Management",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Management, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManagementTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadata = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata) content.GetValueForProperty("ReRegisterSubscriptionMetadata",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadata, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ReRegisterSubscriptionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Namespace = (string) content.GetValueForProperty("Namespace",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Namespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderVersion = (string) content.GetValueForProperty("ProviderVersion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType?) content.GetValueForProperty("ProviderType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderType, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequiredFeature = (string[]) content.GetValueForProperty("RequiredFeature",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequiredFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ResourceType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType[]) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ResourceType, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderCapabilitiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).GlobalNotificationEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[]) content.GetValueForProperty("GlobalNotificationEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).GlobalNotificationEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderEndpointTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthenticationAllowedAudience = (string[]) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeatureRuleRequiredFeaturesPolicy = (string) content.GetValueForProperty("FeatureRuleRequiredFeaturesPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeatureRuleRequiredFeaturesPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOptionOptInHeader = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType?) content.GetValueForProperty("RequestHeaderOptionOptInHeader",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOptionOptInHeader, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementSchemaOwner = (string[]) content.GetValueForProperty("ManagementSchemaOwner",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementSchemaOwner, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementManifestOwner = (string[]) content.GetValueForProperty("ManagementManifestOwner",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementManifestOwner, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingService = (string) content.GetValueForProperty("ManagementIncidentRoutingService",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingTeam = (string) content.GetValueForProperty("ManagementIncidentRoutingTeam",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingTeam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentContactEmail = (string) content.GetValueForProperty("ManagementIncidentContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentContactEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementServiceTreeInfo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]) content.GetValueForProperty("ManagementServiceTreeInfo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementServiceTreeInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ServiceTreeInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessPolicy = (string) content.GetValueForProperty("ManagementResourceAccessPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessRole = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]) content.GetValueForProperty("ManagementResourceAccessRole",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.AnyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataEnabled = (bool) content.GetValueForProperty("ReRegisterSubscriptionMetadataEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataConcurrencyLimit = (int?) content.GetValueForProperty("ReRegisterSubscriptionMetadataConcurrencyLimit",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataConcurrencyLimit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManifest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceProviderManifest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthentication = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthentication) content.GetValueForProperty("ProviderAuthentication",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthentication, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthenticationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeaturesRule = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IFeaturesRule) content.GetValueForProperty("FeaturesRule",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeaturesRule, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.FeaturesRuleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOption = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRequestHeaderOptions) content.GetValueForProperty("RequestHeaderOption",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOption, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.RequestHeaderOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Management = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManagement) content.GetValueForProperty("Management",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Management, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderManagementTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadata = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IReRegisterSubscriptionMetadata) content.GetValueForProperty("ReRegisterSubscriptionMetadata",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadata, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ReRegisterSubscriptionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthorization = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]) content.GetValueForProperty("ProviderAuthorization",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthorization, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderAuthorizationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Namespace = (string) content.GetValueForProperty("Namespace",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Namespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderVersion = (string) content.GetValueForProperty("ProviderVersion",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType?) content.GetValueForProperty("ProviderType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderType, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequiredFeature = (string[]) content.GetValueForProperty("RequiredFeature",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequiredFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ResourceType = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType[]) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ResourceType, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceType>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceTypeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Capability = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[]) content.GetValueForProperty("Capability",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Capability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderCapabilitiesTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).GlobalNotificationEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint[]) content.GetValueForProperty("GlobalNotificationEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).GlobalNotificationEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ResourceProviderEndpointTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthenticationAllowedAudience = (string[]) content.GetValueForProperty("ProviderAuthenticationAllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ProviderAuthenticationAllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeatureRuleRequiredFeaturesPolicy = (string) content.GetValueForProperty("FeatureRuleRequiredFeaturesPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).FeatureRuleRequiredFeaturesPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOptionOptInHeader = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType?) content.GetValueForProperty("RequestHeaderOptionOptInHeader",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).RequestHeaderOptionOptInHeader, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementSchemaOwner = (string[]) content.GetValueForProperty("ManagementSchemaOwner",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementSchemaOwner, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementManifestOwner = (string[]) content.GetValueForProperty("ManagementManifestOwner",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementManifestOwner, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingService = (string) content.GetValueForProperty("ManagementIncidentRoutingService",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingTeam = (string) content.GetValueForProperty("ManagementIncidentRoutingTeam",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentRoutingTeam, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentContactEmail = (string) content.GetValueForProperty("ManagementIncidentContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementIncidentContactEmail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementServiceTreeInfo = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]) content.GetValueForProperty("ManagementServiceTreeInfo",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementServiceTreeInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ServiceTreeInfoTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessPolicy = (string) content.GetValueForProperty("ManagementResourceAccessPolicy",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessRole = (Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]) content.GetValueForProperty("ManagementResourceAccessRole",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ManagementResourceAccessRole, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny>(__y, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.AnyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataEnabled = (bool) content.GetValueForProperty("ReRegisterSubscriptionMetadataEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataConcurrencyLimit = (int?) content.GetValueForProperty("ReRegisterSubscriptionMetadataConcurrencyLimit",((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifestInternal)this).ReRegisterSubscriptionMetadataConcurrencyLimit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ResourceProviderManifestTypeConverter))]
    public partial interface IResourceProviderManifest

    {

    }
}