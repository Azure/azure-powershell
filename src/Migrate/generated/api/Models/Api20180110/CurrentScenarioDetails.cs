namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Current scenario details of the protected entity.</summary>
    public partial class CurrentScenarioDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal
    {

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; set => this._jobId = value; }

        /// <summary>Backing field for <see cref="ScenarioName" /> property.</summary>
        private string _scenarioName;

        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ScenarioName { get => this._scenarioName; set => this._scenarioName = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="CurrentScenarioDetails" /> instance.</summary>
        public CurrentScenarioDetails()
        {

        }
    }
    /// Current scenario details of the protected entity.
    public partial interface ICurrentScenarioDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM Id of the job being executed.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get; set; }
        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scenario name.",
        SerializedName = @"scenarioName",
        PossibleTypes = new [] { typeof(string) })]
        string ScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the workflow.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Current scenario details of the protected entity.
    internal partial interface ICurrentScenarioDetailsInternal

    {
        /// <summary>ARM Id of the job being executed.</summary>
        string JobId { get; set; }
        /// <summary>Scenario name.</summary>
        string ScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}