namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the databases solution summary.</summary>
    public partial class DatabasesSolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabasesSolutionSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabasesSolutionSummaryInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary __solutionSummary = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionSummary();

        /// <summary>Backing field for <see cref="DatabaseInstancesAssessedCount" /> property.</summary>
        private int? _databaseInstancesAssessedCount;

        /// <summary>Gets or sets the count of database instances assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DatabaseInstancesAssessedCount { get => this._databaseInstancesAssessedCount; set => this._databaseInstancesAssessedCount = value; }

        /// <summary>Backing field for <see cref="DatabasesAssessedCount" /> property.</summary>
        private int? _databasesAssessedCount;

        /// <summary>Gets or sets the count of databases assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DatabasesAssessedCount { get => this._databasesAssessedCount; set => this._databasesAssessedCount = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType = value; }

        /// <summary>Backing field for <see cref="MigrationReadyCount" /> property.</summary>
        private int? _migrationReadyCount;

        /// <summary>Gets or sets the count of databases ready for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MigrationReadyCount { get => this._migrationReadyCount; set => this._migrationReadyCount = value; }

        /// <summary>Creates an new <see cref="DatabasesSolutionSummary" /> instance.</summary>
        public DatabasesSolutionSummary()
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
            await eventListener.AssertNotNull(nameof(__solutionSummary), __solutionSummary);
            await eventListener.AssertObjectIsValid(nameof(__solutionSummary), __solutionSummary);
        }
    }
    /// Class representing the databases solution summary.
    public partial interface IDatabasesSolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary
    {
        /// <summary>Gets or sets the count of database instances assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of database instances assessed.",
        SerializedName = @"databaseInstancesAssessedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DatabaseInstancesAssessedCount { get; set; }
        /// <summary>Gets or sets the count of databases assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of databases assessed.",
        SerializedName = @"databasesAssessedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DatabasesAssessedCount { get; set; }
        /// <summary>Gets or sets the count of databases ready for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of databases ready for migration.",
        SerializedName = @"migrationReadyCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MigrationReadyCount { get; set; }

    }
    /// Class representing the databases solution summary.
    internal partial interface IDatabasesSolutionSummaryInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal
    {
        /// <summary>Gets or sets the count of database instances assessed.</summary>
        int? DatabaseInstancesAssessedCount { get; set; }
        /// <summary>Gets or sets the count of databases assessed.</summary>
        int? DatabasesAssessedCount { get; set; }
        /// <summary>Gets or sets the count of databases ready for migration.</summary>
        int? MigrationReadyCount { get; set; }

    }
}