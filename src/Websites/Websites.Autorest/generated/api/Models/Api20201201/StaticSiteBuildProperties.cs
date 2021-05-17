namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Build properties for the static site.</summary>
    public partial class StaticSiteBuildProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiBuildCommand" /> property.</summary>
        private string _apiBuildCommand;

        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ApiBuildCommand { get => this._apiBuildCommand; set => this._apiBuildCommand = value; }

        /// <summary>Backing field for <see cref="ApiLocation" /> property.</summary>
        private string _apiLocation;

        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ApiLocation { get => this._apiLocation; set => this._apiLocation = value; }

        /// <summary>Backing field for <see cref="AppArtifactLocation" /> property.</summary>
        private string _appArtifactLocation;

        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string AppArtifactLocation { get => this._appArtifactLocation; set => this._appArtifactLocation = value; }

        /// <summary>Backing field for <see cref="AppBuildCommand" /> property.</summary>
        private string _appBuildCommand;

        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string AppBuildCommand { get => this._appBuildCommand; set => this._appBuildCommand = value; }

        /// <summary>Backing field for <see cref="AppLocation" /> property.</summary>
        private string _appLocation;

        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string AppLocation { get => this._appLocation; set => this._appLocation = value; }

        /// <summary>Backing field for <see cref="GithubActionSecretNameOverride" /> property.</summary>
        private string _githubActionSecretNameOverride;

        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string GithubActionSecretNameOverride { get => this._githubActionSecretNameOverride; set => this._githubActionSecretNameOverride = value; }

        /// <summary>Backing field for <see cref="OutputLocation" /> property.</summary>
        private string _outputLocation;

        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string OutputLocation { get => this._outputLocation; set => this._outputLocation = value; }

        /// <summary>Backing field for <see cref="SkipGithubActionWorkflowGeneration" /> property.</summary>
        private bool? _skipGithubActionWorkflowGeneration;

        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public bool? SkipGithubActionWorkflowGeneration { get => this._skipGithubActionWorkflowGeneration; set => this._skipGithubActionWorkflowGeneration = value; }

        /// <summary>Creates an new <see cref="StaticSiteBuildProperties" /> instance.</summary>
        public StaticSiteBuildProperties()
        {

        }
    }
    /// Build properties for the static site.
    public partial interface IStaticSiteBuildProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A custom command to run during deployment of the Azure Functions API application.",
        SerializedName = @"apiBuildCommand",
        PossibleTypes = new [] { typeof(string) })]
        string ApiBuildCommand { get; set; }
        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the api code within the repository.",
        SerializedName = @"apiLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ApiLocation { get; set; }
        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)",
        SerializedName = @"appArtifactLocation",
        PossibleTypes = new [] { typeof(string) })]
        string AppArtifactLocation { get; set; }
        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A custom command to run during deployment of the static content application.",
        SerializedName = @"appBuildCommand",
        PossibleTypes = new [] { typeof(string) })]
        string AppBuildCommand { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the app code within the repository.",
        SerializedName = @"appLocation",
        PossibleTypes = new [] { typeof(string) })]
        string AppLocation { get; set; }
        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Github Action secret name override.",
        SerializedName = @"githubActionSecretNameOverride",
        PossibleTypes = new [] { typeof(string) })]
        string GithubActionSecretNameOverride { get; set; }
        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The output path of the app after building.",
        SerializedName = @"outputLocation",
        PossibleTypes = new [] { typeof(string) })]
        string OutputLocation { get; set; }
        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Skip Github Action workflow generation.",
        SerializedName = @"skipGithubActionWorkflowGeneration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SkipGithubActionWorkflowGeneration { get; set; }

    }
    /// Build properties for the static site.
    internal partial interface IStaticSiteBuildPropertiesInternal

    {
        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        string ApiBuildCommand { get; set; }
        /// <summary>The path to the api code within the repository.</summary>
        string ApiLocation { get; set; }
        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        string AppArtifactLocation { get; set; }
        /// <summary>A custom command to run during deployment of the static content application.</summary>
        string AppBuildCommand { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        string AppLocation { get; set; }
        /// <summary>Github Action secret name override.</summary>
        string GithubActionSecretNameOverride { get; set; }
        /// <summary>The output path of the app after building.</summary>
        string OutputLocation { get; set; }
        /// <summary>Skip Github Action workflow generation.</summary>
        bool? SkipGithubActionWorkflowGeneration { get; set; }

    }
}