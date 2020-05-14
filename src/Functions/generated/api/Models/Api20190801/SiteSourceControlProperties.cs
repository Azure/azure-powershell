namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteSourceControl resource specific properties</summary>
    public partial class SiteSourceControlProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteSourceControlProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteSourceControlPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Branch" /> property.</summary>
        private string _branch;

        /// <summary>Name of branch to use for deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Branch { get => this._branch; set => this._branch = value; }

        /// <summary>Backing field for <see cref="DeploymentRollbackEnabled" /> property.</summary>
        private bool? _deploymentRollbackEnabled;

        /// <summary><code>true</code> to enable deployment rollback; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? DeploymentRollbackEnabled { get => this._deploymentRollbackEnabled; set => this._deploymentRollbackEnabled = value; }

        /// <summary>Backing field for <see cref="IsManualIntegration" /> property.</summary>
        private bool? _isManualIntegration;

        /// <summary>
        /// <code>true</code> to limit to manual integration; <code>false</code> to enable continuous integration (which configures
        /// webhooks into online repos like GitHub).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsManualIntegration { get => this._isManualIntegration; set => this._isManualIntegration = value; }

        /// <summary>Backing field for <see cref="IsMercurial" /> property.</summary>
        private bool? _isMercurial;

        /// <summary>
        /// <code>true</code> for a Mercurial repository; <code>false</code> for a Git repository.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsMercurial { get => this._isMercurial; set => this._isMercurial = value; }

        /// <summary>Backing field for <see cref="RepoUrl" /> property.</summary>
        private string _repoUrl;

        /// <summary>Repository or source control URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RepoUrl { get => this._repoUrl; set => this._repoUrl = value; }

        /// <summary>Creates an new <see cref="SiteSourceControlProperties" /> instance.</summary>
        public SiteSourceControlProperties()
        {

        }
    }
    /// SiteSourceControl resource specific properties
    public partial interface ISiteSourceControlProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of branch to use for deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of branch to use for deployment.",
        SerializedName = @"branch",
        PossibleTypes = new [] { typeof(string) })]
        string Branch { get; set; }
        /// <summary><code>true</code> to enable deployment rollback; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to enable deployment rollback; otherwise, <code>false</code>.",
        SerializedName = @"deploymentRollbackEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DeploymentRollbackEnabled { get; set; }
        /// <summary>
        /// <code>true</code> to limit to manual integration; <code>false</code> to enable continuous integration (which configures
        /// webhooks into online repos like GitHub).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to limit to manual integration; <code>false</code> to enable continuous integration (which configures webhooks into online repos like GitHub).",
        SerializedName = @"isManualIntegration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsManualIntegration { get; set; }
        /// <summary>
        /// <code>true</code> for a Mercurial repository; <code>false</code> for a Git repository.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> for a Mercurial repository; <code>false</code> for a Git repository.",
        SerializedName = @"isMercurial",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsMercurial { get; set; }
        /// <summary>Repository or source control URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repository or source control URL.",
        SerializedName = @"repoUrl",
        PossibleTypes = new [] { typeof(string) })]
        string RepoUrl { get; set; }

    }
    /// SiteSourceControl resource specific properties
    internal partial interface ISiteSourceControlPropertiesInternal

    {
        /// <summary>Name of branch to use for deployment.</summary>
        string Branch { get; set; }
        /// <summary><code>true</code> to enable deployment rollback; otherwise, <code>false</code>.</summary>
        bool? DeploymentRollbackEnabled { get; set; }
        /// <summary>
        /// <code>true</code> to limit to manual integration; <code>false</code> to enable continuous integration (which configures
        /// webhooks into online repos like GitHub).
        /// </summary>
        bool? IsManualIntegration { get; set; }
        /// <summary>
        /// <code>true</code> for a Mercurial repository; <code>false</code> for a Git repository.
        /// </summary>
        bool? IsMercurial { get; set; }
        /// <summary>Repository or source control URL.</summary>
        string RepoUrl { get; set; }

    }
}