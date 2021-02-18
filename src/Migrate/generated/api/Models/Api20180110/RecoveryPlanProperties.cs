namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan custom details.</summary>
    public partial class RecoveryPlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedOperation" /> property.</summary>
        private string[] _allowedOperation;

        /// <summary>The list of allowed operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AllowedOperation { get => this._allowedOperation; set => this._allowedOperation = value; }

        /// <summary>Backing field for <see cref="CurrentScenario" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails _currentScenario;

        /// <summary>The current scenario details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails CurrentScenario { get => (this._currentScenario = this._currentScenario ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetails()); set => this._currentScenario = value; }

        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).JobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).JobId = value ?? null; }

        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentScenarioName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).ScenarioName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).ScenarioName = value ?? null; }

        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentScenarioStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetailsInternal)CurrentScenario).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="CurrentScenarioStatus" /> property.</summary>
        private string _currentScenarioStatus;

        /// <summary>The recovery plan status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CurrentScenarioStatus { get => this._currentScenarioStatus; set => this._currentScenarioStatus = value; }

        /// <summary>Backing field for <see cref="CurrentScenarioStatusDescription" /> property.</summary>
        private string _currentScenarioStatusDescription;

        /// <summary>The recovery plan status description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CurrentScenarioStatusDescription { get => this._currentScenarioStatusDescription; set => this._currentScenarioStatusDescription = value; }

        /// <summary>Backing field for <see cref="FailoverDeploymentModel" /> property.</summary>
        private string _failoverDeploymentModel;

        /// <summary>The failover deployment model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FailoverDeploymentModel { get => this._failoverDeploymentModel; set => this._failoverDeploymentModel = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="Group" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] _group;

        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get => this._group; set => this._group = value; }

        /// <summary>Backing field for <see cref="LastPlannedFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastPlannedFailoverTime;

        /// <summary>The start time of the last planned failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastPlannedFailoverTime { get => this._lastPlannedFailoverTime; set => this._lastPlannedFailoverTime = value; }

        /// <summary>Backing field for <see cref="LastTestFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastTestFailoverTime;

        /// <summary>The start time of the last test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastTestFailoverTime { get => this._lastTestFailoverTime; set => this._lastTestFailoverTime = value; }

        /// <summary>Backing field for <see cref="LastUnplannedFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastUnplannedFailoverTime;

        /// <summary>The start time of the last unplanned failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUnplannedFailoverTime { get => this._lastUnplannedFailoverTime; set => this._lastUnplannedFailoverTime = value; }

        /// <summary>Internal Acessors for CurrentScenario</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanPropertiesInternal.CurrentScenario { get => (this._currentScenario = this._currentScenario ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetails()); set { {_currentScenario = value;} } }

        /// <summary>Backing field for <see cref="PrimaryFabricFriendlyName" /> property.</summary>
        private string _primaryFabricFriendlyName;

        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricFriendlyName { get => this._primaryFabricFriendlyName; set => this._primaryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="PrimaryFabricId" /> property.</summary>
        private string _primaryFabricId;

        /// <summary>The primary fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryFabricId { get => this._primaryFabricId; set => this._primaryFabricId = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricFriendlyName" /> property.</summary>
        private string _recoveryFabricFriendlyName;

        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricFriendlyName { get => this._recoveryFabricFriendlyName; set => this._recoveryFabricFriendlyName = value; }

        /// <summary>Backing field for <see cref="RecoveryFabricId" /> property.</summary>
        private string _recoveryFabricId;

        /// <summary>The recovery fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryFabricId { get => this._recoveryFabricId; set => this._recoveryFabricId = value; }

        /// <summary>Backing field for <see cref="ReplicationProvider" /> property.</summary>
        private string[] _replicationProvider;

        /// <summary>The list of replication providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] ReplicationProvider { get => this._replicationProvider; set => this._replicationProvider = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanProperties" /> instance.</summary>
        public RecoveryPlanProperties()
        {

        }
    }
    /// Recovery plan custom details.
    public partial interface IRecoveryPlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The list of allowed operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of allowed operations.",
        SerializedName = @"allowedOperations",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedOperation { get; set; }
        /// <summary>ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM Id of the job being executed.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioJobId { get; set; }
        /// <summary>Scenario name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scenario name.",
        SerializedName = @"scenarioName",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the workflow.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentScenarioStartTime { get; set; }
        /// <summary>The recovery plan status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery plan status.",
        SerializedName = @"currentScenarioStatus",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioStatus { get; set; }
        /// <summary>The recovery plan status description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery plan status description.",
        SerializedName = @"currentScenarioStatusDescription",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentScenarioStatusDescription { get; set; }
        /// <summary>The failover deployment model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The failover deployment model.",
        SerializedName = @"failoverDeploymentModel",
        PossibleTypes = new [] { typeof(string) })]
        string FailoverDeploymentModel { get; set; }
        /// <summary>The friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The recovery plan groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery plan groups.",
        SerializedName = @"groups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>The start time of the last planned failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the last planned failover.",
        SerializedName = @"lastPlannedFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastPlannedFailoverTime { get; set; }
        /// <summary>The start time of the last test failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the last test failover.",
        SerializedName = @"lastTestFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastTestFailoverTime { get; set; }
        /// <summary>The start time of the last unplanned failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the last unplanned failover.",
        SerializedName = @"lastUnplannedFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUnplannedFailoverTime { get; set; }
        /// <summary>The primary fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary fabric friendly name.",
        SerializedName = @"primaryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary fabric Id.",
        SerializedName = @"primaryFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryFabricId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric friendly name.",
        SerializedName = @"recoveryFabricFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery fabric Id.",
        SerializedName = @"recoveryFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryFabricId { get; set; }
        /// <summary>The list of replication providers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of replication providers.",
        SerializedName = @"replicationProviders",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReplicationProvider { get; set; }

    }
    /// Recovery plan custom details.
    internal partial interface IRecoveryPlanPropertiesInternal

    {
        /// <summary>The list of allowed operations.</summary>
        string[] AllowedOperation { get; set; }
        /// <summary>The current scenario details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails CurrentScenario { get; set; }
        /// <summary>ARM Id of the job being executed.</summary>
        string CurrentScenarioJobId { get; set; }
        /// <summary>Scenario name.</summary>
        string CurrentScenarioName { get; set; }
        /// <summary>Start time of the workflow.</summary>
        global::System.DateTime? CurrentScenarioStartTime { get; set; }
        /// <summary>The recovery plan status.</summary>
        string CurrentScenarioStatus { get; set; }
        /// <summary>The recovery plan status description.</summary>
        string CurrentScenarioStatusDescription { get; set; }
        /// <summary>The failover deployment model.</summary>
        string FailoverDeploymentModel { get; set; }
        /// <summary>The friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The recovery plan groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanGroup[] Group { get; set; }
        /// <summary>The start time of the last planned failover.</summary>
        global::System.DateTime? LastPlannedFailoverTime { get; set; }
        /// <summary>The start time of the last test failover.</summary>
        global::System.DateTime? LastTestFailoverTime { get; set; }
        /// <summary>The start time of the last unplanned failover.</summary>
        global::System.DateTime? LastUnplannedFailoverTime { get; set; }
        /// <summary>The primary fabric friendly name.</summary>
        string PrimaryFabricFriendlyName { get; set; }
        /// <summary>The primary fabric Id.</summary>
        string PrimaryFabricId { get; set; }
        /// <summary>The recovery fabric friendly name.</summary>
        string RecoveryFabricFriendlyName { get; set; }
        /// <summary>The recovery fabric Id.</summary>
        string RecoveryFabricId { get; set; }
        /// <summary>The list of replication providers.</summary>
        string[] ReplicationProvider { get; set; }

    }
}