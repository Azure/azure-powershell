namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.PowerShell;

    /// <summary>A static site.</summary>
    [System.ComponentModel.TypeConverter(typeof(StaticSiteTypeConverter))]
    public partial class StaticSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StaticSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StaticSite(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StaticSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StaticSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplateProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions) content.GetValueForProperty("TemplateProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplateProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).ContentDistributionEndpoint = (string) content.GetValueForProperty("ContentDistributionEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).ContentDistributionEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).KeyVaultReferenceIdentity = (string) content.GetValueForProperty("KeyVaultReferenceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).KeyVaultReferenceIdentity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).UserProvidedFunctionApp = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[]) content.GetValueForProperty("UserProvidedFunctionApp",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).UserProvidedFunctionApp, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).StagingEnvironmentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy?) content.GetValueForProperty("StagingEnvironmentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).StagingEnvironmentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).AllowConfigFileUpdate = (bool?) content.GetValueForProperty("AllowConfigFileUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).AllowConfigFileUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyTemplateRepositoryUrl = (string) content.GetValueForProperty("TemplatePropertyTemplateRepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyTemplateRepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyOwner = (string) content.GetValueForProperty("TemplatePropertyOwner",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyOwner, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyRepositoryName = (string) content.GetValueForProperty("TemplatePropertyRepositoryName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyRepositoryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyDescription = (string) content.GetValueForProperty("TemplatePropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyIsPrivate = (bool?) content.GetValueForProperty("TemplatePropertyIsPrivate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyIsPrivate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StaticSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplateProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions) content.GetValueForProperty("TemplateProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplateProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).ContentDistributionEndpoint = (string) content.GetValueForProperty("ContentDistributionEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).ContentDistributionEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).KeyVaultReferenceIdentity = (string) content.GetValueForProperty("KeyVaultReferenceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).KeyVaultReferenceIdentity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).UserProvidedFunctionApp = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[]) content.GetValueForProperty("UserProvidedFunctionApp",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).UserProvidedFunctionApp, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).StagingEnvironmentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy?) content.GetValueForProperty("StagingEnvironmentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).StagingEnvironmentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).AllowConfigFileUpdate = (bool?) content.GetValueForProperty("AllowConfigFileUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).AllowConfigFileUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyTemplateRepositoryUrl = (string) content.GetValueForProperty("TemplatePropertyTemplateRepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyTemplateRepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyOwner = (string) content.GetValueForProperty("TemplatePropertyOwner",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyOwner, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyRepositoryName = (string) content.GetValueForProperty("TemplatePropertyRepositoryName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyRepositoryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyDescription = (string) content.GetValueForProperty("TemplatePropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyIsPrivate = (bool?) content.GetValueForProperty("TemplatePropertyIsPrivate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)this).TemplatePropertyIsPrivate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A static site.
    [System.ComponentModel.TypeConverter(typeof(StaticSiteTypeConverter))]
    public partial interface IStaticSite

    {

    }
}