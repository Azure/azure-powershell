namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.PowerShell;

    /// <summary>ARM resource for a static site when patching</summary>
    [System.ComponentModel.TypeConverter(typeof(StaticSitePatchResourceTypeConverter))]
    public partial class StaticSitePatchResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StaticSitePatchResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StaticSitePatchResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StaticSitePatchResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StaticSitePatchResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplateProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions) content.GetValueForProperty("TemplateProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplateProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).ContentDistributionEndpoint = (string) content.GetValueForProperty("ContentDistributionEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).ContentDistributionEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).KeyVaultReferenceIdentity = (string) content.GetValueForProperty("KeyVaultReferenceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).KeyVaultReferenceIdentity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).UserProvidedFunctionApp = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[]) content.GetValueForProperty("UserProvidedFunctionApp",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).UserProvidedFunctionApp, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).StagingEnvironmentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy?) content.GetValueForProperty("StagingEnvironmentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).StagingEnvironmentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).AllowConfigFileUpdate = (bool?) content.GetValueForProperty("AllowConfigFileUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).AllowConfigFileUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyTemplateRepositoryUrl = (string) content.GetValueForProperty("TemplatePropertyTemplateRepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyTemplateRepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyOwner = (string) content.GetValueForProperty("TemplatePropertyOwner",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyOwner, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyRepositoryName = (string) content.GetValueForProperty("TemplatePropertyRepositoryName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyRepositoryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyDescription = (string) content.GetValueForProperty("TemplatePropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyIsPrivate = (bool?) content.GetValueForProperty("TemplatePropertyIsPrivate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyIsPrivate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitePatchResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StaticSitePatchResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplateProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions) content.GetValueForProperty("TemplateProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplateProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptionsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).ContentDistributionEndpoint = (string) content.GetValueForProperty("ContentDistributionEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).ContentDistributionEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).KeyVaultReferenceIdentity = (string) content.GetValueForProperty("KeyVaultReferenceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).KeyVaultReferenceIdentity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).UserProvidedFunctionApp = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[]) content.GetValueForProperty("UserProvidedFunctionApp",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).UserProvidedFunctionApp, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp>(__y, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionAppTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).StagingEnvironmentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy?) content.GetValueForProperty("StagingEnvironmentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).StagingEnvironmentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).AllowConfigFileUpdate = (bool?) content.GetValueForProperty("AllowConfigFileUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).AllowConfigFileUpdate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyTemplateRepositoryUrl = (string) content.GetValueForProperty("TemplatePropertyTemplateRepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyTemplateRepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyOwner = (string) content.GetValueForProperty("TemplatePropertyOwner",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyOwner, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyRepositoryName = (string) content.GetValueForProperty("TemplatePropertyRepositoryName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyRepositoryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyDescription = (string) content.GetValueForProperty("TemplatePropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyIsPrivate = (bool?) content.GetValueForProperty("TemplatePropertyIsPrivate",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal)this).TemplatePropertyIsPrivate, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ARM resource for a static site when patching
    [System.ComponentModel.TypeConverter(typeof(StaticSitePatchResourceTypeConverter))]
    public partial interface IStaticSitePatchResource

    {

    }
}