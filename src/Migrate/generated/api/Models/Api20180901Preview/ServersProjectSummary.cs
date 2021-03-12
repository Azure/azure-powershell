namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the servers project summary.</summary>
    public partial class ServersProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary __projectSummary = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ProjectSummary();

        /// <summary>Backing field for <see cref="AssessedCount" /> property.</summary>
        private int? _assessedCount;

        /// <summary>Gets or sets the count of entities assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? AssessedCount { get => this._assessedCount; set => this._assessedCount = value; }

        /// <summary>Backing field for <see cref="DiscoveredCount" /> property.</summary>
        private int? _discoveredCount;

        /// <summary>Gets or sets the count of entities discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? DiscoveredCount { get => this._discoveredCount; set => this._discoveredCount = value; }

        /// <summary>Gets or sets the extended summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary ExtendedSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).ExtendedSummary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).ExtendedSummary = value ?? null /* model class */; }

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType; }

        /// <summary>Gets or sets the time when summary was last refreshed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public global::System.DateTime? LastSummaryRefreshedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).LastSummaryRefreshedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).LastSummaryRefreshedTime = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).InstanceType = value; }

        /// <summary>Backing field for <see cref="MigratedCount" /> property.</summary>
        private int? _migratedCount;

        /// <summary>Gets or sets the count of entities migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MigratedCount { get => this._migratedCount; set => this._migratedCount = value; }

        /// <summary>Gets or sets the state of refresh summary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string RefreshSummaryState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).RefreshSummaryState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)__projectSummary).RefreshSummaryState = value ?? null; }

        /// <summary>Backing field for <see cref="ReplicatingCount" /> property.</summary>
        private int? _replicatingCount;

        /// <summary>Gets or sets the count of entities being replicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ReplicatingCount { get => this._replicatingCount; set => this._replicatingCount = value; }

        /// <summary>Backing field for <see cref="TestMigratedCount" /> property.</summary>
        private int? _testMigratedCount;

        /// <summary>Gets or sets the count of entities test migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? TestMigratedCount { get => this._testMigratedCount; set => this._testMigratedCount = value; }

        /// <summary>Creates an new <see cref="ServersProjectSummary" /> instance.</summary>
        public ServersProjectSummary()
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
            await eventListener.AssertNotNull(nameof(__projectSummary), __projectSummary);
            await eventListener.AssertObjectIsValid(nameof(__projectSummary), __projectSummary);
        }
    }
    /// Class representing the servers project summary.
    public partial interface IServersProjectSummary :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummary
    {
        /// <summary>Gets or sets the count of entities assessed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of entities assessed.",
        SerializedName = @"assessedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? AssessedCount { get; set; }
        /// <summary>Gets or sets the count of entities discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of entities discovered.",
        SerializedName = @"discoveredCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DiscoveredCount { get; set; }
        /// <summary>Gets or sets the count of entities migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of entities migrated.",
        SerializedName = @"migratedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MigratedCount { get; set; }
        /// <summary>Gets or sets the count of entities being replicated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of entities being replicated.",
        SerializedName = @"replicatingCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicatingCount { get; set; }
        /// <summary>Gets or sets the count of entities test migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the count of entities test migrated.",
        SerializedName = @"testMigratedCount",
        PossibleTypes = new [] { typeof(int) })]
        int? TestMigratedCount { get; set; }

    }
    /// Class representing the servers project summary.
    internal partial interface IServersProjectSummaryInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal
    {
        /// <summary>Gets or sets the count of entities assessed.</summary>
        int? AssessedCount { get; set; }
        /// <summary>Gets or sets the count of entities discovered.</summary>
        int? DiscoveredCount { get; set; }
        /// <summary>Gets or sets the count of entities migrated.</summary>
        int? MigratedCount { get; set; }
        /// <summary>Gets or sets the count of entities being replicated.</summary>
        int? ReplicatingCount { get; set; }
        /// <summary>Gets or sets the count of entities test migrated.</summary>
        int? TestMigratedCount { get; set; }

    }
}