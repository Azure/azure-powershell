namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>StaticSiteBuildARMResource resource specific properties</summary>
    public partial class StaticSiteBuildArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="BuildId" /> property.</summary>
        private string _buildId;

        /// <summary>An identifier for the static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string BuildId { get => this._buildId; }

        /// <summary>Backing field for <see cref="CreatedTimeUtc" /> property.</summary>
        private global::System.DateTime? _createdTimeUtc;

        /// <summary>When this build was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTimeUtc { get => this._createdTimeUtc; }

        /// <summary>Backing field for <see cref="Hostname" /> property.</summary>
        private string _hostname;

        /// <summary>The hostname for a static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Hostname { get => this._hostname; }

        /// <summary>Backing field for <see cref="LastUpdatedOn" /> property.</summary>
        private global::System.DateTime? _lastUpdatedOn;

        /// <summary>When this build was updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedOn { get => this._lastUpdatedOn; }

        /// <summary>Internal Acessors for BuildId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.BuildId { get => this._buildId; set { {_buildId = value;} } }

        /// <summary>Internal Acessors for CreatedTimeUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.CreatedTimeUtc { get => this._createdTimeUtc; set { {_createdTimeUtc = value;} } }

        /// <summary>Internal Acessors for Hostname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.Hostname { get => this._hostname; set { {_hostname = value;} } }

        /// <summary>Internal Acessors for LastUpdatedOn</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.LastUpdatedOn { get => this._lastUpdatedOn; set { {_lastUpdatedOn = value;} } }

        /// <summary>Internal Acessors for PullRequestTitle</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.PullRequestTitle { get => this._pullRequestTitle; set { {_pullRequestTitle = value;} } }

        /// <summary>Internal Acessors for SourceBranch</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.SourceBranch { get => this._sourceBranch; set { {_sourceBranch = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for UserProvidedFunctionApp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteBuildArmResourcePropertiesInternal.UserProvidedFunctionApp { get => this._userProvidedFunctionApp; set { {_userProvidedFunctionApp = value;} } }

        /// <summary>Backing field for <see cref="PullRequestTitle" /> property.</summary>
        private string _pullRequestTitle;

        /// <summary>The title of a pull request that a static site build is related to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string PullRequestTitle { get => this._pullRequestTitle; }

        /// <summary>Backing field for <see cref="SourceBranch" /> property.</summary>
        private string _sourceBranch;

        /// <summary>The source branch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string SourceBranch { get => this._sourceBranch; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus? _status;

        /// <summary>The status of the static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus? Status { get => this._status; }

        /// <summary>Backing field for <see cref="UserProvidedFunctionApp" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] _userProvidedFunctionApp;

        /// <summary>User provided function apps registered with the static site build</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get => this._userProvidedFunctionApp; }

        /// <summary>Creates an new <see cref="StaticSiteBuildArmResourceProperties" /> instance.</summary>
        public StaticSiteBuildArmResourceProperties()
        {

        }
    }
    /// StaticSiteBuildARMResource resource specific properties
    public partial interface IStaticSiteBuildArmResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>An identifier for the static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An identifier for the static site build.",
        SerializedName = @"buildId",
        PossibleTypes = new [] { typeof(string) })]
        string BuildId { get;  }
        /// <summary>When this build was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"When this build was created.",
        SerializedName = @"createdTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTimeUtc { get;  }
        /// <summary>The hostname for a static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hostname for a static site build.",
        SerializedName = @"hostname",
        PossibleTypes = new [] { typeof(string) })]
        string Hostname { get;  }
        /// <summary>When this build was updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"When this build was updated.",
        SerializedName = @"lastUpdatedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedOn { get;  }
        /// <summary>The title of a pull request that a static site build is related to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The title of a pull request that a static site build is related to.",
        SerializedName = @"pullRequestTitle",
        PossibleTypes = new [] { typeof(string) })]
        string PullRequestTitle { get;  }
        /// <summary>The source branch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source branch.",
        SerializedName = @"sourceBranch",
        PossibleTypes = new [] { typeof(string) })]
        string SourceBranch { get;  }
        /// <summary>The status of the static site build.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the static site build.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus? Status { get;  }
        /// <summary>User provided function apps registered with the static site build</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"User provided function apps registered with the static site build",
        SerializedName = @"userProvidedFunctionApps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get;  }

    }
    /// StaticSiteBuildARMResource resource specific properties
    internal partial interface IStaticSiteBuildArmResourcePropertiesInternal

    {
        /// <summary>An identifier for the static site build.</summary>
        string BuildId { get; set; }
        /// <summary>When this build was created.</summary>
        global::System.DateTime? CreatedTimeUtc { get; set; }
        /// <summary>The hostname for a static site build.</summary>
        string Hostname { get; set; }
        /// <summary>When this build was updated.</summary>
        global::System.DateTime? LastUpdatedOn { get; set; }
        /// <summary>The title of a pull request that a static site build is related to.</summary>
        string PullRequestTitle { get; set; }
        /// <summary>The source branch.</summary>
        string SourceBranch { get; set; }
        /// <summary>The status of the static site build.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.BuildStatus? Status { get; set; }
        /// <summary>User provided function apps registered with the static site build</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[] UserProvidedFunctionApp { get; set; }

    }
}