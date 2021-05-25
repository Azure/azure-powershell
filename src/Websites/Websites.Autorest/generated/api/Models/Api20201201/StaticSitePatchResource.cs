namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>ARM resource for a static site when patching</summary>
    public partial class StaticSitePatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResource,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ProxyOnlyResource();

        /// <summary>
        /// <code>false</code> if config file is locked for this static web app; otherwise, <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? AllowConfigFileUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).AllowConfigFileUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).AllowConfigFileUpdate = value ?? default(bool); }

        /// <summary>The target branch in the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Branch { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).Branch; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).Branch = value ?? null; }

        /// <summary>
        /// A custom command to run during deployment of the Azure Functions API application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyApiBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyApiBuildCommand = value ?? null; }

        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyApiLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyApiLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyApiLocation = value ?? null; }

        /// <summary>
        /// Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppArtifactLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppArtifactLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppArtifactLocation = value ?? null; }

        /// <summary>A custom command to run during deployment of the static content application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppBuildCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppBuildCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppBuildCommand = value ?? null; }

        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyAppLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyAppLocation = value ?? null; }

        /// <summary>Github Action secret name override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyGithubActionSecretNameOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyGithubActionSecretNameOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyGithubActionSecretNameOverride = value ?? null; }

        /// <summary>The output path of the app after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string BuildPropertyOutputLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyOutputLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertyOutputLocation = value ?? null; }

        /// <summary>Skip Github Action workflow generation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? BuildPropertySkipGithubActionWorkflowGeneration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertySkipGithubActionWorkflowGeneration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildPropertySkipGithubActionWorkflowGeneration = value ?? default(bool); }

        /// <summary>The content distribution endpoint for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string ContentDistributionEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).ContentDistributionEndpoint; }

        /// <summary>The custom domains associated with this static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string[] CustomDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).CustomDomain; }

        /// <summary>The default autogenerated hostname for the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string DefaultHostname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).DefaultHostname; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Identity to use for Key Vault Reference authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string KeyVaultReferenceIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).KeyVaultReferenceIdentity; }

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
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildProperties Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.BuildProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).BuildProperty = value; }

        /// <summary>Internal Acessors for ContentDistributionEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.ContentDistributionEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).ContentDistributionEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).ContentDistributionEndpoint = value; }

        /// <summary>Internal Acessors for CustomDomain</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.CustomDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).CustomDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).CustomDomain = value; }

        /// <summary>Internal Acessors for DefaultHostname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.DefaultHostname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).DefaultHostname; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).DefaultHostname = value; }

        /// <summary>Internal Acessors for KeyVaultReferenceIdentity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.KeyVaultReferenceIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).KeyVaultReferenceIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).KeyVaultReferenceIdentity = value; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).PrivateEndpointConnection = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.Provider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).Provider = value; }

        /// <summary>Internal Acessors for TemplateProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.TemplateProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplateProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplateProperty = value; }

        /// <summary>Internal Acessors for UserProvidedFunctionApp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitePatchResourceInternal.UserProvidedFunctionApp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).UserProvidedFunctionApp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).UserProvidedFunctionApp = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Private endpoint connections</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[] PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).PrivateEndpointConnection; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSite()); set => this._property = value; }

        /// <summary>
        /// The provider that submitted the last deployment to the primary environment of the static site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string Provider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).Provider; }

        /// <summary>
        /// A user's github repository token. This is used to setup the Github Actions workflow file and API secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string RepositoryToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).RepositoryToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).RepositoryToken = value ?? null; }

        /// <summary>URL for the repository of the static site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string RepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).RepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).RepositoryUrl = value ?? null; }

        /// <summary>
        /// State indicating whether staging environments are allowed or not allowed for a static web app.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy? StagingEnvironmentPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).StagingEnvironmentPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).StagingEnvironmentPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy)""); }

        /// <summary>Description of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyDescription = value ?? null; }

        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public bool? TemplatePropertyIsPrivate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyIsPrivate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyIsPrivate = value ?? default(bool); }

        /// <summary>Owner of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyOwner = value ?? null; }

        /// <summary>Name of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyRepositoryName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyRepositoryName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyRepositoryName = value ?? null; }

        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public string TemplatePropertyTemplateRepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyTemplateRepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).TemplatePropertyTemplateRepositoryUrl = value ?? null; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>User provided function apps registered with the static site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteInternal)Property).UserProvidedFunctionApp; }

        /// <summary>Creates an new <see cref="StaticSitePatchResource" /> instance.</summary>
        public StaticSitePatchResource()
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
    /// ARM resource for a static site when patching
    public partial interface IStaticSitePatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResource
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
    /// ARM resource for a static site when patching
    internal partial interface IStaticSitePatchResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IProxyOnlyResourceInternal
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
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite Property { get; set; }
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