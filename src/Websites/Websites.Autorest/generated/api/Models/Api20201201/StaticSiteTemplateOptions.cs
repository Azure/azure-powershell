namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Template Options for the static site.</summary>
    public partial class StaticSiteTemplateOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteTemplateOptionsInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="IsPrivate" /> property.</summary>
        private bool? _isPrivate;

        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public bool? IsPrivate { get => this._isPrivate; set => this._isPrivate = value; }

        /// <summary>Backing field for <see cref="Owner" /> property.</summary>
        private string _owner;

        /// <summary>Owner of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Owner { get => this._owner; set => this._owner = value; }

        /// <summary>Backing field for <see cref="RepositoryName" /> property.</summary>
        private string _repositoryName;

        /// <summary>Name of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string RepositoryName { get => this._repositoryName; set => this._repositoryName = value; }

        /// <summary>Backing field for <see cref="TemplateRepositoryUrl" /> property.</summary>
        private string _templateRepositoryUrl;

        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string TemplateRepositoryUrl { get => this._templateRepositoryUrl; set => this._templateRepositoryUrl = value; }

        /// <summary>Creates an new <see cref="StaticSiteTemplateOptions" /> instance.</summary>
        public StaticSiteTemplateOptions()
        {

        }
    }
    /// Template Options for the static site.
    public partial interface IStaticSiteTemplateOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Description of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the newly generated repository.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).",
        SerializedName = @"isPrivate",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPrivate { get; set; }
        /// <summary>Owner of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Owner of the newly generated repository.",
        SerializedName = @"owner",
        PossibleTypes = new [] { typeof(string) })]
        string Owner { get; set; }
        /// <summary>Name of the newly generated repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the newly generated repository.",
        SerializedName = @"repositoryName",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryName { get; set; }
        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL of the template repository. The newly generated repository will be based on this one.",
        SerializedName = @"templateRepositoryUrl",
        PossibleTypes = new [] { typeof(string) })]
        string TemplateRepositoryUrl { get; set; }

    }
    /// Template Options for the static site.
    internal partial interface IStaticSiteTemplateOptionsInternal

    {
        /// <summary>Description of the newly generated repository.</summary>
        string Description { get; set; }
        /// <summary>
        /// Whether or not the newly generated repository is a private repository. Defaults to false (i.e. public).
        /// </summary>
        bool? IsPrivate { get; set; }
        /// <summary>Owner of the newly generated repository.</summary>
        string Owner { get; set; }
        /// <summary>Name of the newly generated repository.</summary>
        string RepositoryName { get; set; }
        /// <summary>
        /// URL of the template repository. The newly generated repository will be based on this one.
        /// </summary>
        string TemplateRepositoryUrl { get; set; }

    }
}