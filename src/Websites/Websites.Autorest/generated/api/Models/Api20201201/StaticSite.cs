namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>A static site.</summary>
    public partial class StaticSite :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal
    {

        /// <summary>Backing field for <see cref="AllowConfigFileUpdate" /> property.</summary>
        private bool? _allowConfigFileUpdate;

        /// <summary>
        /// <code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public bool? AllowConfigFileUpdate { get => this._allowConfigFileUpdate; set => this._allowConfigFileUpdate = value; }

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

        /// <summary>Backing field for <see cref="ContentDistributionEndpoint" /> property.</summary>
        private string _contentDistributionEndpoint;

        /// <summary>The content distribution endpoint for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ContentDistributionEndpoint { get => this._contentDistributionEndpoint; }

        /// <summary>Backing field for <see cref="CustomDomain" /> property.</summary>
        private string[] _customDomain;

        /// <summary>The custom domains associated with this static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string[] CustomDomain { get => this._customDomain; }

        /// <summary>Backing field for <see cref="DefaultHostname" /> property.</summary>
        private string _defaultHostname;

        /// <summary>The default autogenerated hostname for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string DefaultHostname { get => this._defaultHostname; }

        /// <summary>Backing field for <see cref="KeyVaultReferenceIdentity" /> property.</summary>
        private string _keyVaultReferenceIdentity;

        /// <summary>Identity to use for Key Vault Reference authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string KeyVaultReferenceIdentity { get => this._keyVaultReferenceIdentity; }

        /// <summary>Internal Acessors for BuildProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.BuildProperty { get => (this._buildProperty = this._buildProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildProperties()); set { {_buildProperty = value;} } }

        /// <summary>Internal Acessors for ContentDistributionEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.ContentDistributionEndpoint { get => this._contentDistributionEndpoint; set { {_contentDistributionEndpoint = value;} } }

        /// <summary>Internal Acessors for CustomDomain</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.CustomDomain { get => this._customDomain; set { {_customDomain = value;} } }

        /// <summary>Internal Acessors for DefaultHostname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.DefaultHostname { get => this._defaultHostname; set { {_defaultHostname = value;} } }

        /// <summary>Internal Acessors for KeyVaultReferenceIdentity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.KeyVaultReferenceIdentity { get => this._keyVaultReferenceIdentity; set { {_keyVaultReferenceIdentity = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for TemplateProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.TemplateProperty { get => (this._templateProperty = this._templateProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptions()); set { {_templateProperty = value;} } }

        /// <summary>Internal Acessors for UserProvidedFunctionApp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal.UserProvidedFunctionApp { get => this._userProvidedFunctionApp; set { {_userProvidedFunctionApp = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] _privateEndpointConnection;

        /// <summary>Private endpoint connections</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>
        /// The provider that submitted the last deployment to the primary environment of the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="RepositoryToken" /> property.</summary>
        private string _repositoryToken;

        /// <summary>
        /// A user's github repository token. This is used to setup the Github Actions workflow file and API secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string RepositoryToken { get => this._repositoryToken; set => this._repositoryToken = value; }

        /// <summary>Backing field for <see cref="RepositoryUrl" /> property.</summary>
        private string _repositoryUrl;

        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string RepositoryUrl { get => this._repositoryUrl; set => this._repositoryUrl = value; }

        /// <summary>Backing field for <see cref="StagingEnvironmentPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy? _stagingEnvironmentPolicy;

        /// <summary>
        /// State indicating whether staging environments are allowed or not allowed for a static web app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get => this._stagingEnvironmentPolicy; set => this._stagingEnvironmentPolicy = value; }

        /// <summary>Backing field for <see cref="TemplateProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions _templateProperty;

        /// <summary>Template options for generating a new repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions TemplateProperty { get => (this._templateProperty = this._templateProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptions()); set => this._templateProperty = value; }

        /// <summary>Description of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).Description = value ?? null; }

        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? TemplatePropertyIsPrivate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).IsPrivate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).IsPrivate = value ?? default(bool); }

        /// <summary>Owner of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).Owner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).Owner = value ?? null; }

        /// <summary>Name of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyRepositoryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).RepositoryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).RepositoryName = value ?? null; }

        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyTemplateRepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).TemplateRepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal)TemplateProperty).TemplateRepositoryUrl = value ?? null; }

        /// <summary>Backing field for <see cref="UserProvidedFunctionApp" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] _userProvidedFunctionApp;

        /// <summary>User provided function apps registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get => this._userProvidedFunctionApp; }

        /// <summary>Creates an new <see cref="StaticSite" /> instance.</summary>
        public StaticSite()
        {

        }
    }
    /// A static site.
    public partial interface IStaticSite :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>
        /// <code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.",
        SerializedName = @"allowConfigFileUpdates",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowConfigFileUpdate { get; set; }
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
        /// <summary>The content distribution endpoint for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The content distribution endpoint for the static site.",
        SerializedName = @"contentDistributionEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string ContentDistributionEndpoint { get;  }
        /// <summary>The custom domains associated with this static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The custom domains associated with this static site.",
        SerializedName = @"customDomains",
        PossibleTypes = new [] { typeof(string) })]
        string[] CustomDomain { get;  }
        /// <summary>The default autogenerated hostname for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The default autogenerated hostname for the static site.",
        SerializedName = @"defaultHostname",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultHostname { get;  }
        /// <summary>Identity to use for Key Vault Reference authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Identity to use for Key Vault Reference authentication.",
        SerializedName = @"keyVaultReferenceIdentity",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultReferenceIdentity { get;  }
        /// <summary>Private endpoint connections</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Private endpoint connections",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] PrivateEndpointConnection { get;  }
        /// <summary>
        /// The provider that submitted the last deployment to the primary environment of the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provider that submitted the last deployment to the primary environment of the static site.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
        /// <summary>
        /// A user's github repository token. This is used to setup the Github Actions workflow file and API secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A user's github repository token. This is used to setup the Github Actions workflow file and API secrets.",
        SerializedName = @"repositoryToken",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryToken { get; set; }
        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL for the repository of the static site.",
        SerializedName = @"repositoryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryUrl { get; set; }
        /// <summary>
        /// State indicating whether staging environments are allowed or not allowed for a static web app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State indicating whether staging environments are allowed or not allowed for a static web app.",
        SerializedName = @"stagingEnvironmentPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get; set; }
        /// <summary>Description of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the newly generated repository.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string TemplatePropertyDescription { get; set; }
        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).",
        SerializedName = @"isPrivate",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TemplatePropertyIsPrivate { get; set; }
        /// <summary>Owner of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Owner of the newly generated repository.",
        SerializedName = @"owner",
        PossibleTypes = new [] { typeof(string) })]
        string TemplatePropertyOwner { get; set; }
        /// <summary>Name of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the newly generated repository.",
        SerializedName = @"repositoryName",
        PossibleTypes = new [] { typeof(string) })]
        string TemplatePropertyRepositoryName { get; set; }
        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL of the template repository. The newly generated repository will be based on this one.",
        SerializedName = @"templateRepositoryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string TemplatePropertyTemplateRepositoryUrl { get; set; }
        /// <summary>User provided function apps registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"User provided function apps registered with the static site",
        SerializedName = @"userProvidedFunctionApps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get;  }

    }
    /// A static site.
    internal partial interface IStaticSiteInternal

    {
        /// <summary>
        /// <code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.
        /// </summary>
        bool? AllowConfigFileUpdate { get; set; }
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
        /// <summary>The content distribution endpoint for the static site.</summary>
        string ContentDistributionEndpoint { get; set; }
        /// <summary>The custom domains associated with this static site.</summary>
        string[] CustomDomain { get; set; }
        /// <summary>The default autogenerated hostname for the static site.</summary>
        string DefaultHostname { get; set; }
        /// <summary>Identity to use for Key Vault Reference authentication.</summary>
        string KeyVaultReferenceIdentity { get; set; }
        /// <summary>Private endpoint connections</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] PrivateEndpointConnection { get; set; }
        /// <summary>
        /// The provider that submitted the last deployment to the primary environment of the static site.
        /// </summary>
        string Provider { get; set; }
        /// <summary>
        /// A user's github repository token. This is used to setup the Github Actions workflow file and API secrets.
        /// </summary>
        string RepositoryToken { get; set; }
        /// <summary>URL for the repository of the static site.</summary>
        string RepositoryUrl { get; set; }
        /// <summary>
        /// State indicating whether staging environments are allowed or not allowed for a static web app.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get; set; }
        /// <summary>Template options for generating a new repository.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions TemplateProperty { get; set; }
        /// <summary>Description of the newly generated repository.</summary>
        string TemplatePropertyDescription { get; set; }
        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        bool? TemplatePropertyIsPrivate { get; set; }
        /// <summary>Owner of the newly generated repository.</summary>
        string TemplatePropertyOwner { get; set; }
        /// <summary>Name of the newly generated repository.</summary>
        string TemplatePropertyRepositoryName { get; set; }
        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        string TemplatePropertyTemplateRepositoryUrl { get; set; }
        /// <summary>User provided function apps registered with the static site</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get; set; }

    }
}