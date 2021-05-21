namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSitesWorkflowPreviewRequest resource specific properties</summary>
    public partial class StaticSitesWorkflowPreviewRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Branch" /> property.</summary>
        private string _branch;

        /// <summary>The target branch in the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Branch { get => this._branch; set => this._branch = value; }

        /// <summary>Backing field for <see cref="BuildProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties _buildProperty;

        /// <summary>Build properties to configure on the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties BuildProperty { get => (this._buildProperty = this._buildProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildProperties()); set => this._buildProperty = value; }

        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).ApiBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).ApiBuildCommand = value ?? null; }

        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).ApiLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).ApiLocation = value ?? null; }

        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppArtifactLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppArtifactLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppArtifactLocation = value ?? null; }

        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppBuildCommand = value ?? null; }

        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).AppLocation = value ?? null; }

        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyGithubActionSecretNameOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).GithubActionSecretNameOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).GithubActionSecretNameOverride = value ?? null; }

        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyOutputLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).OutputLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).OutputLocation = value ?? null; }

        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? BuildPropertySkipGithubActionWorkflowGeneration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).SkipGithubActionWorkflowGeneration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal)BuildProperty).SkipGithubActionWorkflowGeneration = value ?? default(bool); }

        /// <summary>Internal Acessors for BuildProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewRequestPropertiesInternal.BuildProperty { get => (this._buildProperty = this._buildProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildProperties()); set { {_buildProperty = value;} } }

        /// <summary>Backing field for <see cref="RepositoryUrl" /> property.</summary>
        private string _repositoryUrl;

        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string RepositoryUrl { get => this._repositoryUrl; set => this._repositoryUrl = value; }

        /// <summary>
        /// Creates an new <see cref="StaticSitesWorkflowPreviewRequestProperties" /> instance.
        /// </summary>
        public StaticSitesWorkflowPreviewRequestProperties()
        {

        }
    }
    /// StaticSitesWorkflowPreviewRequest resource specific properties
    public partial interface IStaticSitesWorkflowPreviewRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
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
    /// StaticSitesWorkflowPreviewRequest resource specific properties
    internal partial interface IStaticSitesWorkflowPreviewRequestPropertiesInternal

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
        /// <summary>URL for the repository of the static site.</summary>
        string RepositoryUrl { get; set; }

    }
}