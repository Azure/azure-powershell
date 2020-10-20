namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the database instance summary object.</summary>
    public partial class DatabaseInstanceSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceSummaryInternal
    {

        /// <summary>Backing field for <see cref="DatabasesAssessedCount" /> property.</summary>
        private int? _databasesAssessedCount;

        /// <summary>Gets or sets the count of databases assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DatabasesAssessedCount { get => this._databasesAssessedCount; set => this._databasesAssessedCount = value; }

        /// <summary>Backing field for <see cref="MigrationReadyCount" /> property.</summary>
        private int? _migrationReadyCount;

        /// <summary>Gets or sets the count of databases ready for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MigrationReadyCount { get => this._migrationReadyCount; set => this._migrationReadyCount = value; }

        /// <summary>Creates an new <see cref="DatabaseInstanceSummary" /> instance.</summary>
        public DatabaseInstanceSummary()
        {

        }
    }
    /// Class representing the database instance summary object.
    public partial interface IDatabaseInstanceSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
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
    /// Class representing the database instance summary object.
    internal partial interface IDatabaseInstanceSummaryInternal

    {
        /// <summary>Gets or sets the count of databases assessed.</summary>
        int? DatabasesAssessedCount { get; set; }
        /// <summary>Gets or sets the count of databases ready for migration.</summary>
        int? MigrationReadyCount { get; set; }

    }
}