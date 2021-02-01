namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Migration item properties.</summary>
    public partial class MigrationItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedOperation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] _allowedOperation;

        /// <summary>
        /// The allowed operations on the migration item, based on the current migration state of the item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] AllowedOperation { get => this._allowedOperation; }

        /// <summary>Backing field for <see cref="CurrentJob" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails _currentJob;

        /// <summary>The current job details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails CurrentJob { get => (this._currentJob = this._currentJob ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetails()); }

        /// <summary>The ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).JobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).JobId = value ?? null; }

        /// <summary>The job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).JobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).JobName = value ?? null; }

        /// <summary>The start time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentJobStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetailsInternal)CurrentJob).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="EventCorrelationId" /> property.</summary>
        private string _eventCorrelationId;

        /// <summary>The correlation Id for events associated with this migration item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EventCorrelationId { get => this._eventCorrelationId; }

        /// <summary>Backing field for <see cref="Health" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? _health;

        /// <summary>The consolidated health.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Health { get => this._health; }

        /// <summary>Backing field for <see cref="HealthError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthError;

        /// <summary>The list of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => this._healthError; }

        /// <summary>Backing field for <see cref="LastTestMigrationStatus" /> property.</summary>
        private string _lastTestMigrationStatus;

        /// <summary>The status of the last test migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LastTestMigrationStatus { get => this._lastTestMigrationStatus; }

        /// <summary>Backing field for <see cref="LastTestMigrationTime" /> property.</summary>
        private global::System.DateTime? _lastTestMigrationTime;

        /// <summary>The last test migration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastTestMigrationTime { get => this._lastTestMigrationTime; }

        /// <summary>Backing field for <see cref="MachineName" /> property.</summary>
        private string _machineName;

        /// <summary>The on-premise virtual machine name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineName { get => this._machineName; }

        /// <summary>Internal Acessors for AllowedOperation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.AllowedOperation { get => this._allowedOperation; set { {_allowedOperation = value;} } }

        /// <summary>Internal Acessors for CurrentJob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.CurrentJob { get => (this._currentJob = this._currentJob ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentJobDetails()); set { {_currentJob = value;} } }

        /// <summary>Internal Acessors for EventCorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.EventCorrelationId { get => this._eventCorrelationId; set { {_eventCorrelationId = value;} } }

        /// <summary>Internal Acessors for Health</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.Health { get => this._health; set { {_health = value;} } }

        /// <summary>Internal Acessors for HealthError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.HealthError { get => this._healthError; set { {_healthError = value;} } }

        /// <summary>Internal Acessors for LastTestMigrationStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.LastTestMigrationStatus { get => this._lastTestMigrationStatus; set { {_lastTestMigrationStatus = value;} } }

        /// <summary>Internal Acessors for LastTestMigrationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.LastTestMigrationTime { get => this._lastTestMigrationTime; set { {_lastTestMigrationTime = value;} } }

        /// <summary>Internal Acessors for MachineName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.MachineName { get => this._machineName; set { {_machineName = value;} } }

        /// <summary>Internal Acessors for MigrationState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.MigrationState { get => this._migrationState; set { {_migrationState = value;} } }

        /// <summary>Internal Acessors for MigrationStateDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.MigrationStateDescription { get => this._migrationStateDescription; set { {_migrationStateDescription = value;} } }

        /// <summary>Internal Acessors for PolicyFriendlyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.PolicyFriendlyName { get => this._policyFriendlyName; set { {_policyFriendlyName = value;} } }

        /// <summary>Internal Acessors for PolicyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.PolicyId { get => this._policyId; set { {_policyId = value;} } }

        /// <summary>Internal Acessors for TestMigrateState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.TestMigrateState { get => this._testMigrateState; set { {_testMigrateState = value;} } }

        /// <summary>Internal Acessors for TestMigrateStateDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal.TestMigrateStateDescription { get => this._testMigrateStateDescription; set { {_testMigrateStateDescription = value;} } }

        /// <summary>Backing field for <see cref="MigrationState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? _migrationState;

        /// <summary>The migration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? MigrationState { get => this._migrationState; }

        /// <summary>Backing field for <see cref="MigrationStateDescription" /> property.</summary>
        private string _migrationStateDescription;

        /// <summary>The migration state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MigrationStateDescription { get => this._migrationStateDescription; }

        /// <summary>Backing field for <see cref="PolicyFriendlyName" /> property.</summary>
        private string _policyFriendlyName;

        /// <summary>The name of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyFriendlyName { get => this._policyFriendlyName; }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>The ARM Id of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings _providerSpecificDetail;

        /// <summary>The migration provider custom settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationProviderSpecificSettings()); set => this._providerSpecificDetail = value; }

        /// <summary>Backing field for <see cref="TestMigrateState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? _testMigrateState;

        /// <summary>The test migrate state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? TestMigrateState { get => this._testMigrateState; }

        /// <summary>Backing field for <see cref="TestMigrateStateDescription" /> property.</summary>
        private string _testMigrateStateDescription;

        /// <summary>The test migrate state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestMigrateStateDescription { get => this._testMigrateStateDescription; }

        /// <summary>Creates an new <see cref="MigrationItemProperties" /> instance.</summary>
        public MigrationItemProperties()
        {

        }
    }
    /// Migration item properties.
    public partial interface IMigrationItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The allowed operations on the migration item, based on the current migration state of the item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The allowed operations on the migration item, based on the current migration state of the item.",
        SerializedName = @"allowedOperations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] AllowedOperation { get;  }
        /// <summary>The ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM Id of the job being executed.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentJobId { get; set; }
        /// <summary>The job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job name.",
        SerializedName = @"jobName",
        PossibleTypes = new [] { typeof(string) })]
        string CurrentJobName { get; set; }
        /// <summary>The start time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the job.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CurrentJobStartTime { get; set; }
        /// <summary>The correlation Id for events associated with this migration item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The correlation Id for events associated with this migration item.",
        SerializedName = @"eventCorrelationId",
        PossibleTypes = new [] { typeof(string) })]
        string EventCorrelationId { get;  }
        /// <summary>The consolidated health.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The consolidated health.",
        SerializedName = @"health",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Health { get;  }
        /// <summary>The list of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of health errors.",
        SerializedName = @"healthErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get;  }
        /// <summary>The status of the last test migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the last test migration.",
        SerializedName = @"lastTestMigrationStatus",
        PossibleTypes = new [] { typeof(string) })]
        string LastTestMigrationStatus { get;  }
        /// <summary>The last test migration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last test migration time.",
        SerializedName = @"lastTestMigrationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastTestMigrationTime { get;  }
        /// <summary>The on-premise virtual machine name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The on-premise virtual machine name.",
        SerializedName = @"machineName",
        PossibleTypes = new [] { typeof(string) })]
        string MachineName { get;  }
        /// <summary>The migration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The migration status.",
        SerializedName = @"migrationState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? MigrationState { get;  }
        /// <summary>The migration state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The migration state description.",
        SerializedName = @"migrationStateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationStateDescription { get;  }
        /// <summary>The name of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of policy governing this item.",
        SerializedName = @"policyFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyFriendlyName { get;  }
        /// <summary>The ARM Id of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM Id of policy governing this item.",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get;  }
        /// <summary>The migration provider custom settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The migration provider custom settings.",
        SerializedName = @"providerSpecificDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings ProviderSpecificDetail { get; set; }
        /// <summary>The test migrate state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The test migrate state.",
        SerializedName = @"testMigrateState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? TestMigrateState { get;  }
        /// <summary>The test migrate state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The test migrate state description.",
        SerializedName = @"testMigrateStateDescription",
        PossibleTypes = new [] { typeof(string) })]
        string TestMigrateStateDescription { get;  }

    }
    /// Migration item properties.
    internal partial interface IMigrationItemPropertiesInternal

    {
        /// <summary>
        /// The allowed operations on the migration item, based on the current migration state of the item.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] AllowedOperation { get; set; }
        /// <summary>The current job details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails CurrentJob { get; set; }
        /// <summary>The ARM Id of the job being executed.</summary>
        string CurrentJobId { get; set; }
        /// <summary>The job name.</summary>
        string CurrentJobName { get; set; }
        /// <summary>The start time of the job.</summary>
        global::System.DateTime? CurrentJobStartTime { get; set; }
        /// <summary>The correlation Id for events associated with this migration item.</summary>
        string EventCorrelationId { get; set; }
        /// <summary>The consolidated health.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Health { get; set; }
        /// <summary>The list of health errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get; set; }
        /// <summary>The status of the last test migration.</summary>
        string LastTestMigrationStatus { get; set; }
        /// <summary>The last test migration time.</summary>
        global::System.DateTime? LastTestMigrationTime { get; set; }
        /// <summary>The on-premise virtual machine name.</summary>
        string MachineName { get; set; }
        /// <summary>The migration status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? MigrationState { get; set; }
        /// <summary>The migration state description.</summary>
        string MigrationStateDescription { get; set; }
        /// <summary>The name of policy governing this item.</summary>
        string PolicyFriendlyName { get; set; }
        /// <summary>The ARM Id of policy governing this item.</summary>
        string PolicyId { get; set; }
        /// <summary>The migration provider custom settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings ProviderSpecificDetail { get; set; }
        /// <summary>The test migrate state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? TestMigrateState { get; set; }
        /// <summary>The test migrate state description.</summary>
        string TestMigrateStateDescription { get; set; }

    }
}