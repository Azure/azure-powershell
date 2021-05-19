namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSitesWorkflowPreview resource specific properties</summary>
    public partial class StaticSitesWorkflowPreviewProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private string _content;

        /// <summary>The contents for the workflow file to be generated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Content { get => this._content; }

        /// <summary>Internal Acessors for Content</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewPropertiesInternal.Content { get => this._content; set { {_content = value;} } }

        /// <summary>Internal Acessors for Path</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSitesWorkflowPreviewPropertiesInternal.Path { get => this._path; set { {_path = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path for the workflow file to be generated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Path { get => this._path; }

        /// <summary>Creates an new <see cref="StaticSitesWorkflowPreviewProperties" /> instance.</summary>
        public StaticSitesWorkflowPreviewProperties()
        {

        }
    }
    /// StaticSitesWorkflowPreview resource specific properties
    public partial interface IStaticSitesWorkflowPreviewProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>The contents for the workflow file to be generated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The contents for the workflow file to be generated",
        SerializedName = @"contents",
        PossibleTypes = new [] { typeof(string) })]
        string Content { get;  }
        /// <summary>The path for the workflow file to be generated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The path for the workflow file to be generated",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get;  }

    }
    /// StaticSitesWorkflowPreview resource specific properties
    internal partial interface IStaticSitesWorkflowPreviewPropertiesInternal

    {
        /// <summary>The contents for the workflow file to be generated</summary>
        string Content { get; set; }
        /// <summary>The path for the workflow file to be generated</summary>
        string Path { get; set; }

    }
}