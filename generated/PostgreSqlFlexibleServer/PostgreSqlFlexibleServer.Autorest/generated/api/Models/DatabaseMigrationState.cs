// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration state of a database.</summary>
    public partial class DatabaseMigrationState :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal
    {

        /// <summary>Backing field for <see cref="AppliedChange" /> property.</summary>
        private int? _appliedChange;

        /// <summary>Change Data Capture applied changes counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? AppliedChange { get => this._appliedChange; set => this._appliedChange = value; }

        /// <summary>Backing field for <see cref="CdcDeleteCounter" /> property.</summary>
        private int? _cdcDeleteCounter;

        /// <summary>Change Data Capture delete counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? CdcDeleteCounter { get => this._cdcDeleteCounter; set => this._cdcDeleteCounter = value; }

        /// <summary>Backing field for <see cref="CdcInsertCounter" /> property.</summary>
        private int? _cdcInsertCounter;

        /// <summary>Change Data Capture insert counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? CdcInsertCounter { get => this._cdcInsertCounter; set => this._cdcInsertCounter = value; }

        /// <summary>Backing field for <see cref="CdcUpdateCounter" /> property.</summary>
        private int? _cdcUpdateCounter;

        /// <summary>Change Data Capture update counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? CdcUpdateCounter { get => this._cdcUpdateCounter; set => this._cdcUpdateCounter = value; }

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>Name of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; set => this._databaseName = value; }

        /// <summary>Backing field for <see cref="EndedOn" /> property.</summary>
        private global::System.DateTime? _endedOn;

        /// <summary>End time of a migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? EndedOn { get => this._endedOn; set => this._endedOn = value; }

        /// <summary>Backing field for <see cref="FullLoadCompletedTable" /> property.</summary>
        private int? _fullLoadCompletedTable;

        /// <summary>Number of tables loaded during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? FullLoadCompletedTable { get => this._fullLoadCompletedTable; set => this._fullLoadCompletedTable = value; }

        /// <summary>Backing field for <see cref="FullLoadErroredTable" /> property.</summary>
        private int? _fullLoadErroredTable;

        /// <summary>Number of tables encountering errors during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? FullLoadErroredTable { get => this._fullLoadErroredTable; set => this._fullLoadErroredTable = value; }

        /// <summary>Backing field for <see cref="FullLoadLoadingTable" /> property.</summary>
        private int? _fullLoadLoadingTable;

        /// <summary>Number of tables loading during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? FullLoadLoadingTable { get => this._fullLoadLoadingTable; set => this._fullLoadLoadingTable = value; }

        /// <summary>Backing field for <see cref="FullLoadQueuedTable" /> property.</summary>
        private int? _fullLoadQueuedTable;

        /// <summary>Number of tables queued for the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? FullLoadQueuedTable { get => this._fullLoadQueuedTable; set => this._fullLoadQueuedTable = value; }

        /// <summary>Backing field for <see cref="IncomingChange" /> property.</summary>
        private int? _incomingChange;

        /// <summary>Change Data Capture incoming changes counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? IncomingChange { get => this._incomingChange; set => this._incomingChange = value; }

        /// <summary>Backing field for <see cref="Latency" /> property.</summary>
        private int? _latency;

        /// <summary>Lag in seconds between source and target during online phase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? Latency { get => this._latency; set => this._latency = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="MigrationOperation" /> property.</summary>
        private string _migrationOperation;

        /// <summary>Migration operation of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationOperation { get => this._migrationOperation; set => this._migrationOperation = value; }

        /// <summary>Backing field for <see cref="MigrationState" /> property.</summary>
        private string _migrationState;

        /// <summary>Migration state of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationState { get => this._migrationState; set => this._migrationState = value; }

        /// <summary>Backing field for <see cref="StartedOn" /> property.</summary>
        private global::System.DateTime? _startedOn;

        /// <summary>Start time of a migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? StartedOn { get => this._startedOn; set => this._startedOn = value; }

        /// <summary>Creates an new <see cref="DatabaseMigrationState" /> instance.</summary>
        public DatabaseMigrationState()
        {

        }
    }
    /// Migration state of a database.
    public partial interface IDatabaseMigrationState :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Change Data Capture applied changes counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Change Data Capture applied changes counter.",
        SerializedName = @"appliedChanges",
        PossibleTypes = new [] { typeof(int) })]
        int? AppliedChange { get; set; }
        /// <summary>Change Data Capture delete counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Change Data Capture delete counter.",
        SerializedName = @"cdcDeleteCounter",
        PossibleTypes = new [] { typeof(int) })]
        int? CdcDeleteCounter { get; set; }
        /// <summary>Change Data Capture insert counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Change Data Capture insert counter.",
        SerializedName = @"cdcInsertCounter",
        PossibleTypes = new [] { typeof(int) })]
        int? CdcInsertCounter { get; set; }
        /// <summary>Change Data Capture update counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Change Data Capture update counter.",
        SerializedName = @"cdcUpdateCounter",
        PossibleTypes = new [] { typeof(int) })]
        int? CdcUpdateCounter { get; set; }
        /// <summary>Name of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of database.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>End time of a migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time of a migration state.",
        SerializedName = @"endedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndedOn { get; set; }
        /// <summary>Number of tables loaded during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of tables loaded during the migration of a database.",
        SerializedName = @"fullLoadCompletedTables",
        PossibleTypes = new [] { typeof(int) })]
        int? FullLoadCompletedTable { get; set; }
        /// <summary>Number of tables encountering errors during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of tables encountering errors during the migration of a database.",
        SerializedName = @"fullLoadErroredTables",
        PossibleTypes = new [] { typeof(int) })]
        int? FullLoadErroredTable { get; set; }
        /// <summary>Number of tables loading during the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of tables loading during the migration of a database.",
        SerializedName = @"fullLoadLoadingTables",
        PossibleTypes = new [] { typeof(int) })]
        int? FullLoadLoadingTable { get; set; }
        /// <summary>Number of tables queued for the migration of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of tables queued for the migration of a database.",
        SerializedName = @"fullLoadQueuedTables",
        PossibleTypes = new [] { typeof(int) })]
        int? FullLoadQueuedTable { get; set; }
        /// <summary>Change Data Capture incoming changes counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Change Data Capture incoming changes counter.",
        SerializedName = @"incomingChanges",
        PossibleTypes = new [] { typeof(int) })]
        int? IncomingChange { get; set; }
        /// <summary>Lag in seconds between source and target during online phase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Lag in seconds between source and target during online phase.",
        SerializedName = @"latency",
        PossibleTypes = new [] { typeof(int) })]
        int? Latency { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Error message, if any, for the migration state.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Migration operation of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Migration operation of a database.",
        SerializedName = @"migrationOperation",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationOperation { get; set; }
        /// <summary>Migration state of a database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Migration state of a database.",
        SerializedName = @"migrationState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForCutoverTrigger", "Failed", "Canceled", "Succeeded", "Canceling")]
        string MigrationState { get; set; }
        /// <summary>Start time of a migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time of a migration state.",
        SerializedName = @"startedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartedOn { get; set; }

    }
    /// Migration state of a database.
    internal partial interface IDatabaseMigrationStateInternal

    {
        /// <summary>Change Data Capture applied changes counter.</summary>
        int? AppliedChange { get; set; }
        /// <summary>Change Data Capture delete counter.</summary>
        int? CdcDeleteCounter { get; set; }
        /// <summary>Change Data Capture insert counter.</summary>
        int? CdcInsertCounter { get; set; }
        /// <summary>Change Data Capture update counter.</summary>
        int? CdcUpdateCounter { get; set; }
        /// <summary>Name of database.</summary>
        string DatabaseName { get; set; }
        /// <summary>End time of a migration state.</summary>
        global::System.DateTime? EndedOn { get; set; }
        /// <summary>Number of tables loaded during the migration of a database.</summary>
        int? FullLoadCompletedTable { get; set; }
        /// <summary>Number of tables encountering errors during the migration of a database.</summary>
        int? FullLoadErroredTable { get; set; }
        /// <summary>Number of tables loading during the migration of a database.</summary>
        int? FullLoadLoadingTable { get; set; }
        /// <summary>Number of tables queued for the migration of a database.</summary>
        int? FullLoadQueuedTable { get; set; }
        /// <summary>Change Data Capture incoming changes counter.</summary>
        int? IncomingChange { get; set; }
        /// <summary>Lag in seconds between source and target during online phase.</summary>
        int? Latency { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        string Message { get; set; }
        /// <summary>Migration operation of a database.</summary>
        string MigrationOperation { get; set; }
        /// <summary>Migration state of a database.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForCutoverTrigger", "Failed", "Canceled", "Succeeded", "Canceling")]
        string MigrationState { get; set; }
        /// <summary>Start time of a migration state.</summary>
        global::System.DateTime? StartedOn { get; set; }

    }
}