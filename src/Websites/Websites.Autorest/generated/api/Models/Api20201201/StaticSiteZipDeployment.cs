namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>A static site zip deployment.</summary>
    public partial class StaticSiteZipDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteZipDeployment,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteZipDeploymentInternal
    {

        /// <summary>Backing field for <see cref="ApiZipUrl" /> property.</summary>
        private string _apiZipUrl;

        /// <summary>URL for the zipped api content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ApiZipUrl { get => this._apiZipUrl; set => this._apiZipUrl = value; }

        /// <summary>Backing field for <see cref="AppZipUrl" /> property.</summary>
        private string _appZipUrl;

        /// <summary>URL for the zipped app content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string AppZipUrl { get => this._appZipUrl; set => this._appZipUrl = value; }

        /// <summary>Backing field for <see cref="DeploymentTitle" /> property.</summary>
        private string _deploymentTitle;

        /// <summary>A title to label the deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string DeploymentTitle { get => this._deploymentTitle; set => this._deploymentTitle = value; }

        /// <summary>Backing field for <see cref="FunctionLanguage" /> property.</summary>
        private string _functionLanguage;

        /// <summary>The language of the api content, if it exists</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string FunctionLanguage { get => this._functionLanguage; set => this._functionLanguage = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>The provider submitting this deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Creates an new <see cref="StaticSiteZipDeployment" /> instance.</summary>
        public StaticSiteZipDeployment()
        {

        }
    }
    /// A static site zip deployment.
    public partial interface IStaticSiteZipDeployment :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>URL for the zipped api content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL for the zipped api content",
        SerializedName = @"apiZipUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ApiZipUrl { get; set; }
        /// <summary>URL for the zipped app content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL for the zipped app content",
        SerializedName = @"appZipUrl",
        PossibleTypes = new [] { typeof(string) })]
        string AppZipUrl { get; set; }
        /// <summary>A title to label the deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A title to label the deployment",
        SerializedName = @"deploymentTitle",
        PossibleTypes = new [] { typeof(string) })]
        string DeploymentTitle { get; set; }
        /// <summary>The language of the api content, if it exists</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The language of the api content, if it exists",
        SerializedName = @"functionLanguage",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionLanguage { get; set; }
        /// <summary>The provider submitting this deployment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provider submitting this deployment",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }

    }
    /// A static site zip deployment.
    internal partial interface IStaticSiteZipDeploymentInternal

    {
        /// <summary>URL for the zipped api content</summary>
        string ApiZipUrl { get; set; }
        /// <summary>URL for the zipped app content</summary>
        string AppZipUrl { get; set; }
        /// <summary>A title to label the deployment</summary>
        string DeploymentTitle { get; set; }
        /// <summary>The language of the api content, if it exists</summary>
        string FunctionLanguage { get; set; }
        /// <summary>The provider submitting this deployment</summary>
        string Provider { get; set; }

    }
}