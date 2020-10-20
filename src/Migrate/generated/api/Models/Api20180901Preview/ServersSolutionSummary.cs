namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the servers solution summary.</summary>
    public partial class ServersSolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersSolutionSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersSolutionSummaryInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary __solutionSummary = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SolutionSummary();

        /// <summary>Backing field for <see cref="AssessedCount" /> property.</summary>
        private int? _assessedCount;

        /// <summary>Gets or sets the count of servers assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? AssessedCount { get => this._assessedCount; set => this._assessedCount = value; }

        /// <summary>Backing field for <see cref="DiscoveredCount" /> property.</summary>
        private int? _discoveredCount;

        /// <summary>Gets or sets the count of servers discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DiscoveredCount { get => this._discoveredCount; set => this._discoveredCount = value; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal)__solutionSummary).InstanceType = value; }

        /// <summary>Backing field for <see cref="MigratedCount" /> property.</summary>
        private int? _migratedCount;

        /// <summary>Gets or sets the count of servers migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MigratedCount { get => this._migratedCount; set => this._migratedCount = value; }

        /// <summary>Backing field for <see cref="ReplicatingCount" /> property.</summary>
        private int? _replicatingCount;

        /// <summary>Gets or sets the count of servers being replicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ReplicatingCount { get => this._replicatingCount; set => this._replicatingCount = value; }

        /// <summary>Backing field for <see cref="TestMigratedCount" /> property.</summary>
        private int? _testMigratedCount;

        /// <summary>Gets or sets the count of servers test migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? TestMigratedCount { get => this._testMigratedCount; set => this._testMigratedCount = value; }

        /// <summary>Creates an new <see cref="ServersSolutionSummary" /> instance.</summary>
        public ServersSolutionSummary()
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
    /// Class representing the servers solution summary.
    public partial interface IServersSolutionSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummary
    {
        /// <summary>Gets or sets the count of servers assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of servers assessed.",
        SerializedName = @"assessedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? AssessedCount { get; set; }
        /// <summary>Gets or sets the count of servers discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of servers discovered.",
        SerializedName = @"discoveredCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DiscoveredCount { get; set; }
        /// <summary>Gets or sets the count of servers migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of servers migrated.",
        SerializedName = @"migratedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MigratedCount { get; set; }
        /// <summary>Gets or sets the count of servers being replicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of servers being replicated.",
        SerializedName = @"replicatingCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicatingCount { get; set; }
        /// <summary>Gets or sets the count of servers test migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of servers test migrated.",
        SerializedName = @"testMigratedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? TestMigratedCount { get; set; }

    }
    /// Class representing the servers solution summary.
    internal partial interface IServersSolutionSummaryInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISolutionSummaryInternal
    {
        /// <summary>Gets or sets the count of servers assessed.</summary>
        int? AssessedCount { get; set; }
        /// <summary>Gets or sets the count of servers discovered.</summary>
        int? DiscoveredCount { get; set; }
        /// <summary>Gets or sets the count of servers migrated.</summary>
        int? MigratedCount { get; set; }
        /// <summary>Gets or sets the count of servers being replicated.</summary>
        int? ReplicatingCount { get; set; }
        /// <summary>Gets or sets the count of servers test migrated.</summary>
        int? TestMigratedCount { get; set; }

    }
}