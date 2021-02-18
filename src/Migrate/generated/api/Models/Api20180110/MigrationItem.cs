namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Migration item.</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotFormat]
    public partial class MigrationItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>
        /// The allowed operations on the migration item, based on the current migration state of the item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] AllowedOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).AllowedOperation; }

        /// <summary>The ARM Id of the job being executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobId = value ?? null; }

        /// <summary>The job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CurrentJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobName = value ?? null; }

        /// <summary>The start time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? CurrentJobStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJobStartTime = value ?? default(global::System.DateTime); }

        /// <summary>The correlation Id for events associated with this migration item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string EventCorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).EventCorrelationId; }

        /// <summary>The consolidated health.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Health { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).Health; }

        /// <summary>The list of health errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).HealthError; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>The status of the last test migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string LastTestMigrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationStatus; }

        /// <summary>The last test migration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastTestMigrationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationTime; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value; }

        /// <summary>The on-premise virtual machine name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string MachineName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MachineName; }

        /// <summary>Internal Acessors for AllowedOperation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationItemOperation[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.AllowedOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).AllowedOperation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).AllowedOperation = value; }

        /// <summary>Internal Acessors for CurrentJob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentJobDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.CurrentJob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).CurrentJob = value; }

        /// <summary>Internal Acessors for EventCorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.EventCorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).EventCorrelationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).EventCorrelationId = value; }

        /// <summary>Internal Acessors for Health</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProtectionHealth? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.Health { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).Health; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).Health = value; }

        /// <summary>Internal Acessors for HealthError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.HealthError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).HealthError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).HealthError = value; }

        /// <summary>Internal Acessors for LastTestMigrationStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.LastTestMigrationStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationStatus = value; }

        /// <summary>Internal Acessors for LastTestMigrationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.LastTestMigrationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).LastTestMigrationTime = value; }

        /// <summary>Internal Acessors for MachineName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.MachineName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MachineName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MachineName = value; }

        /// <summary>Internal Acessors for MigrationState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.MigrationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationState = value; }

        /// <summary>Internal Acessors for MigrationStateDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.MigrationStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationStateDescription = value; }

        /// <summary>Internal Acessors for PolicyFriendlyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.PolicyFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyFriendlyName = value; }

        /// <summary>Internal Acessors for PolicyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for TestMigrateState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.TestMigrateState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateState = value; }

        /// <summary>Internal Acessors for TestMigrateStateDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemInternal.TestMigrateStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateStateDescription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateStateDescription = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>The migration status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MigrationState? MigrationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationState; }

        /// <summary>The migration state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string MigrationStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).MigrationStateDescription; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>The name of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyFriendlyName; }

        /// <summary>The ARM Id of policy governing this item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).PolicyId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties _property;

        /// <summary>The migration item properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MigrationItemProperties()); set => this._property = value; }

        /// <summary>The migration provider custom settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings ProviderSpecificDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).ProviderSpecificDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).ProviderSpecificDetail = value ?? null /* model class */; }

        /// <summary>The test migrate state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? TestMigrateState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateState; }

        /// <summary>The test migrate state description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TestMigrateStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemPropertiesInternal)Property).TestMigrateStateDescription; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="MigrationItem" /> instance.</summary>
        public MigrationItem()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Migration item.
    public partial interface IMigrationItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
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
    /// Migration item.
    internal partial interface IMigrationItemInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
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
        /// <summary>The migration item properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationItemProperties Property { get; set; }
        /// <summary>The migration provider custom settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationProviderSpecificSettings ProviderSpecificDetail { get; set; }
        /// <summary>The test migrate state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.TestMigrationState? TestMigrateState { get; set; }
        /// <summary>The test migrate state description.</summary>
        string TestMigrateStateDescription { get; set; }

    }
}