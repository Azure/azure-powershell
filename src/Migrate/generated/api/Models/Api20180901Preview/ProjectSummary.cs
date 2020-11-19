namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The project summary class.</summary>
    public partial class ProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal
    {

        /// <summary>Backing field for <see cref="ExtendedSummary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary _extendedSummary;

        /// <summary>Gets or sets the extended summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary ExtendedSummary { get => (this._extendedSummary = this._extendedSummary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ProjectSummaryExtendedSummary()); set => this._extendedSummary = value; }

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Backing field for <see cref="LastSummaryRefreshedTime" /> property.</summary>
        private global::System.DateTime? _lastSummaryRefreshedTime;

        /// <summary>Gets or sets the time when summary was last refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastSummaryRefreshedTime { get => this._lastSummaryRefreshedTime; set => this._lastSummaryRefreshedTime = value; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Backing field for <see cref="RefreshSummaryState" /> property.</summary>
        private string _refreshSummaryState;

        /// <summary>Gets or sets the state of refresh summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RefreshSummaryState { get => this._refreshSummaryState; set => this._refreshSummaryState = value; }

        /// <summary>Creates an new <see cref="ProjectSummary" /> instance.</summary>
        public ProjectSummary()
        {

        }
    }
    /// The project summary class.
    public partial interface IProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the extended summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the extended summary.",
        SerializedName = @"extendedSummary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary ExtendedSummary { get; set; }
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }
        /// <summary>Gets or sets the time when summary was last refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time when summary was last refreshed.",
        SerializedName = @"lastSummaryRefreshedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastSummaryRefreshedTime { get; set; }
        /// <summary>Gets or sets the state of refresh summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the state of refresh summary.",
        SerializedName = @"refreshSummaryState",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshSummaryState { get; set; }

    }
    /// The project summary class.
    internal partial interface IProjectSummaryInternal

    {
        /// <summary>Gets or sets the extended summary.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary ExtendedSummary { get; set; }
        /// <summary>Gets the Instance type.</summary>
        string InstanceType { get; set; }
        /// <summary>Gets or sets the time when summary was last refreshed.</summary>
        global::System.DateTime? LastSummaryRefreshedTime { get; set; }
        /// <summary>Gets or sets the state of refresh summary.</summary>
        string RefreshSummaryState { get; set; }

    }
}