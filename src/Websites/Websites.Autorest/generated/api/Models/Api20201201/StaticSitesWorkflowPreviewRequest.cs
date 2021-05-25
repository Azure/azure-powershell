namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Request entity for previewing the Static Site workflow</summary>
    public partial class StaticSitesWorkflowPreviewRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ProxyOnlyResource();

        /// <summary>The target branch in the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Branch { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).Branch; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).Branch = value ?? null; }

        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyApiBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyApiBuildCommand = value ?? null; }

        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyApiLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyApiLocation = value ?? null; }

        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppArtifactLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppArtifactLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppArtifactLocation = value ?? null; }

        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppBuildCommand = value ?? null; }

        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyAppLocation = value ?? null; }

        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyGithubActionSecretNameOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyGithubActionSecretNameOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyGithubActionSecretNameOverride = value ?? null; }

        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyOutputLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyOutputLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertyOutputLocation = value ?? null; }

        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? BuildPropertySkipGithubActionWorkflowGeneration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertySkipGithubActionWorkflowGeneration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildPropertySkipGithubActionWorkflowGeneration = value ?? default(bool); }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for BuildProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestInternal.BuildProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).BuildProperty = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties _property;

        /// <summary>StaticSitesWorkflowPreviewRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSitesWorkflowPreviewRequestProperties()); set => this._property = value; }

        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string RepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).RepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal)Property).RepositoryUrl = value ?? null; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="StaticSitesWorkflowPreviewRequest" /> instance.</summary>
        public StaticSitesWorkflowPreviewRequest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Request entity for previewing the Static Site workflow
    public partial interface IStaticSitesWorkflowPreviewRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource
    {
        /// <summary>The target branch in the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target branch in the repository.",
        SerializedName = @"branch",
        PossibleTypes = new [] { typeof(string) })]
        string Branch { get; set; }
        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A custom command to run during deployment of the Azure Functions API application.",
        SerializedName = @"apiBuildCommand",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyApiBuildCommand { get; set; }
        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the api code within the repository.",
        SerializedName = @"apiLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyApiLocation { get; set; }
        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)",
        SerializedName = @"appArtifactLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyAppArtifactLocation { get; set; }
        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A custom command to run during deployment of the static content application.",
        SerializedName = @"appBuildCommand",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyAppBuildCommand { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the app code within the repository.",
        SerializedName = @"appLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyAppLocation { get; set; }
        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Github Action secret name override.",
        SerializedName = @"githubActionSecretNameOverride",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyGithubActionSecretNameOverride { get; set; }
        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The output path of the app after building.",
        SerializedName = @"outputLocation",
        PossibleTypes = new [] { typeof(string) })]
        string BuildPropertyOutputLocation { get; set; }
        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Skip Github Action workflow generation.",
        SerializedName = @"skipGithubActionWorkflowGeneration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BuildPropertySkipGithubActionWorkflowGeneration { get; set; }
        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL for the repository of the static site.",
        SerializedName = @"repositoryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryUrl { get; set; }

    }
    /// Request entity for previewing the Static Site workflow
    internal partial interface IStaticSitesWorkflowPreviewRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal
    {
        /// <summary>The target branch in the repository.</summary>
        string Branch { get; set; }
        /// <summary>Build properties to configure on the repository.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties BuildProperty { get; set; }
        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        string BuildPropertyApiBuildCommand { get; set; }
        /// <summary>The path to the api code within the repository.</summary>
        string BuildPropertyApiLocation { get; set; }
        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        string BuildPropertyAppArtifactLocation { get; set; }
        /// <summary>A custom command to run during deployment of the static content application.</summary>
        string BuildPropertyAppBuildCommand { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        string BuildPropertyAppLocation { get; set; }
        /// <summary>Github Action secret name override.</summary>
        string BuildPropertyGithubActionSecretNameOverride { get; set; }
        /// <summary>The output path of the app after building.</summary>
        string BuildPropertyOutputLocation { get; set; }
        /// <summary>Skip Github Action workflow generation.</summary>
        bool? BuildPropertySkipGithubActionWorkflowGeneration { get; set; }
        /// <summary>StaticSitesWorkflowPreviewRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties Property { get; set; }
        /// <summary>URL for the repository of the static site.</summary>
        string RepositoryUrl { get; set; }

    }
}