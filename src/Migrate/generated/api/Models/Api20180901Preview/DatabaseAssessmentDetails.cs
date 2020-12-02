namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Assessment properties that can be shared by various publishers.</summary>
    public partial class DatabaseAssessmentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsInternal
    {

        /// <summary>Backing field for <see cref="AssessmentId" /> property.</summary>
        private string _assessmentId;

        /// <summary>Gets or sets the database assessment scope/Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AssessmentId { get => this._assessmentId; set => this._assessmentId = value; }

        /// <summary>Backing field for <see cref="AssessmentTargetType" /> property.</summary>
        private string _assessmentTargetType;

        /// <summary>Gets or sets the assessed target database type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AssessmentTargetType { get => this._assessmentTargetType; set => this._assessmentTargetType = value; }

        /// <summary>Backing field for <see cref="BreakingChangesCount" /> property.</summary>
        private int? _breakingChangesCount;

        /// <summary>Gets or sets the number of breaking changes found.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? BreakingChangesCount { get => this._breakingChangesCount; set => this._breakingChangesCount = value; }

        /// <summary>Backing field for <see cref="CompatibilityLevel" /> property.</summary>
        private string _compatibilityLevel;

        /// <summary>Gets or sets the compatibility level of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CompatibilityLevel { get => this._compatibilityLevel; set => this._compatibilityLevel = value; }

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>Gets or sets the database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; set => this._databaseName = value; }

        /// <summary>Backing field for <see cref="DatabaseSizeInMb" /> property.</summary>
        private string _databaseSizeInMb;

        /// <summary>Gets or sets the database size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatabaseSizeInMb { get => this._databaseSizeInMb; set => this._databaseSizeInMb = value; }

        /// <summary>Backing field for <see cref="EnqueueTime" /> property.</summary>
        private string _enqueueTime;

        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnqueueTime { get => this._enqueueTime; set => this._enqueueTime = value; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo _extendedInfo;

        /// <summary>Gets or sets the extended properties of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseAssessmentDetailsExtendedInfo()); set => this._extendedInfo = value; }

        /// <summary>Backing field for <see cref="InstanceId" /> property.</summary>
        private string _instanceId;

        /// <summary>Gets or sets the database server instance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceId { get => this._instanceId; set => this._instanceId = value; }

        /// <summary>Backing field for <see cref="IsReadyForMigration" /> property.</summary>
        private bool? _isReadyForMigration;

        /// <summary>Gets or sets a value indicating whether the database is ready for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsReadyForMigration { get => this._isReadyForMigration; set => this._isReadyForMigration = value; }

        /// <summary>Backing field for <see cref="LastAssessedTime" /> property.</summary>
        private global::System.DateTime? _lastAssessedTime;

        /// <summary>Gets or sets the time when the database was last assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastAssessedTime { get => this._lastAssessedTime; set => this._lastAssessedTime = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>Gets or sets the time of the last modification of the database details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="MigrationBlockersCount" /> property.</summary>
        private int? _migrationBlockersCount;

        /// <summary>Gets or sets the number of blocking changes found.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MigrationBlockersCount { get => this._migrationBlockersCount; set => this._migrationBlockersCount = value; }

        /// <summary>Backing field for <see cref="SolutionName" /> property.</summary>
        private string _solutionName;

        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SolutionName { get => this._solutionName; set => this._solutionName = value; }

        /// <summary>Creates an new <see cref="DatabaseAssessmentDetails" /> instance.</summary>
        public DatabaseAssessmentDetails()
        {

        }
    }
    /// Assessment properties that can be shared by various publishers.
    public partial interface IDatabaseAssessmentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the database assessment scope/Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database assessment scope/Id.",
        SerializedName = @"assessmentId",
        PossibleTypes = new [] { typeof(string) })]
        string AssessmentId { get; set; }
        /// <summary>Gets or sets the assessed target database type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the assessed target database type.",
        SerializedName = @"assessmentTargetType",
        PossibleTypes = new [] { typeof(string) })]
        string AssessmentTargetType { get; set; }
        /// <summary>Gets or sets the number of breaking changes found.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the number of breaking changes found.",
        SerializedName = @"breakingChangesCount",
        PossibleTypes = new [] { typeof(int) })]
        int? BreakingChangesCount { get; set; }
        /// <summary>Gets or sets the compatibility level of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the compatibility level of the database.",
        SerializedName = @"compatibilityLevel",
        PossibleTypes = new [] { typeof(string) })]
        string CompatibilityLevel { get; set; }
        /// <summary>Gets or sets the database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database name.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>Gets or sets the database size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database size.",
        SerializedName = @"databaseSizeInMB",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseSizeInMb { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time the message was enqueued.",
        SerializedName = @"enqueueTime",
        PossibleTypes = new [] { typeof(string) })]
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the extended properties of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the extended properties of the database.",
        SerializedName = @"extendedInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the database server instance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database server instance Id.",
        SerializedName = @"instanceId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceId { get; set; }
        /// <summary>Gets or sets a value indicating whether the database is ready for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether the database is ready for migration.",
        SerializedName = @"isReadyForMigration",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsReadyForMigration { get; set; }
        /// <summary>Gets or sets the time when the database was last assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time when the database was last assessed.",
        SerializedName = @"lastAssessedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastAssessedTime { get; set; }
        /// <summary>Gets or sets the time of the last modification of the database details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the database details.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the number of blocking changes found.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the number of blocking changes found.",
        SerializedName = @"migrationBlockersCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MigrationBlockersCount { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the solution that sent the data.",
        SerializedName = @"solutionName",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionName { get; set; }

    }
    /// Assessment properties that can be shared by various publishers.
    internal partial interface IDatabaseAssessmentDetailsInternal

    {
        /// <summary>Gets or sets the database assessment scope/Id.</summary>
        string AssessmentId { get; set; }
        /// <summary>Gets or sets the assessed target database type.</summary>
        string AssessmentTargetType { get; set; }
        /// <summary>Gets or sets the number of breaking changes found.</summary>
        int? BreakingChangesCount { get; set; }
        /// <summary>Gets or sets the compatibility level of the database.</summary>
        string CompatibilityLevel { get; set; }
        /// <summary>Gets or sets the database name.</summary>
        string DatabaseName { get; set; }
        /// <summary>Gets or sets the database size.</summary>
        string DatabaseSizeInMb { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the extended properties of the database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseAssessmentDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the database server instance Id.</summary>
        string InstanceId { get; set; }
        /// <summary>Gets or sets a value indicating whether the database is ready for migration.</summary>
        bool? IsReadyForMigration { get; set; }
        /// <summary>Gets or sets the time when the database was last assessed.</summary>
        global::System.DateTime? LastAssessedTime { get; set; }
        /// <summary>Gets or sets the time of the last modification of the database details.</summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the number of blocking changes found.</summary>
        int? MigrationBlockersCount { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        string SolutionName { get; set; }

    }
}