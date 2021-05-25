namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.PowerShell;

    /// <summary>StaticSitesWorkflowPreviewRequest resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(StaticSitesWorkflowPreviewRequestPropertiesTypeConverter))]
    public partial class StaticSitesWorkflowPreviewRequestProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StaticSitesWorkflowPreviewRequestProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StaticSitesWorkflowPreviewRequestProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StaticSitesWorkflowPreviewRequestProperties" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StaticSitesWorkflowPreviewRequestProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StaticSitesWorkflowPreviewRequestProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyOutputLocation = (string) content.GetValueForProperty("BuildPropertyOutputLocation",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyOutputLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppBuildCommand = (string) content.GetValueForProperty("BuildPropertyAppBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyAppBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiBuildCommand = (string) content.GetValueForProperty("BuildPropertyApiBuildCommand",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyApiBuildCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertySkipGithubActionWorkflowGeneration = (bool?) content.GetValueForProperty("BuildPropertySkipGithubActionWorkflowGeneration",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertySkipGithubActionWorkflowGeneration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyGithubActionSecretNameOverride = (string) content.GetValueForProperty("BuildPropertyGithubActionSecretNameOverride",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)this).BuildPropertyGithubActionSecretNameOverride, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// StaticSitesWorkflowPreviewRequest resource specific properties
    [System.ComponentModel.TypeConverter(typeof(StaticSitesWorkflowPreviewRequestPropertiesTypeConverter))]
    public partial interface IStaticSitesWorkflowPreviewRequestProperties

    {

    }
}