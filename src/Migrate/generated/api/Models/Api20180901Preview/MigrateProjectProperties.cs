namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for migrate project properties.</summary>
    public partial class MigrateProjectProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LastSummaryRefreshedTime" /> property.</summary>
        private global::System.DateTime? _lastSummaryRefreshedTime;

        /// <summary>Gets the last time the project summary was refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastSummaryRefreshedTime { get => this._lastSummaryRefreshedTime; }

        /// <summary>Internal Acessors for LastSummaryRefreshedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesInternal.LastSummaryRefreshedTime { get => this._lastSummaryRefreshedTime; set { {_lastSummaryRefreshedTime = value;} } }

        /// <summary>Internal Acessors for RefreshSummaryState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesInternal.RefreshSummaryState { get => this._refreshSummaryState; set { {_refreshSummaryState = value;} } }

        /// <summary>Internal Acessors for Summary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesInternal.Summary { get => (this._summary = this._summary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateProjectPropertiesSummary()); set { {_summary = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RefreshSummaryState" /> property.</summary>
        private string _refreshSummaryState;

        /// <summary>Gets the refresh summary state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RefreshSummaryState { get => this._refreshSummaryState; }

        /// <summary>Backing field for <see cref="RegisteredTool" /> property.</summary>
        private string[] _registeredTool;

        /// <summary>Gets or sets the list of tools registered with the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] RegisteredTool { get => this._registeredTool; set => this._registeredTool = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary _summary;

        /// <summary>Gets the summary of the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary Summary { get => (this._summary = this._summary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateProjectPropertiesSummary()); }

        /// <summary>Creates an new <see cref="MigrateProjectProperties" /> instance.</summary>
        public MigrateProjectProperties()
        {

        }
    }
    /// Class for migrate project properties.
    public partial interface IMigrateProjectProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the last time the project summary was refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the last time the project summary was refreshed.",
        SerializedName = @"lastSummaryRefreshedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastSummaryRefreshedTime { get;  }
        /// <summary>Provisioning state of the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the migrate project.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets the refresh summary state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the refresh summary state.",
        SerializedName = @"refreshSummaryState",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshSummaryState { get;  }
        /// <summary>Gets or sets the list of tools registered with the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of tools registered with the migrate project.",
        SerializedName = @"registeredTools",
        PossibleTypes = new [] { typeof(string) })]
        string[] RegisteredTool { get; set; }
        /// <summary>Gets the summary of the migrate project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the summary of the migrate project.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary Summary { get;  }

    }
    /// Class for migrate project properties.
    internal partial interface IMigrateProjectPropertiesInternal

    {
        /// <summary>Gets the last time the project summary was refreshed.</summary>
        global::System.DateTime? LastSummaryRefreshedTime { get; set; }
        /// <summary>Provisioning state of the migrate project.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets the refresh summary state.</summary>
        string RefreshSummaryState { get; set; }
        /// <summary>Gets or sets the list of tools registered with the migrate project.</summary>
        string[] RegisteredTool { get; set; }
        /// <summary>Gets the summary of the migrate project.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectPropertiesSummary Summary { get; set; }

    }
}