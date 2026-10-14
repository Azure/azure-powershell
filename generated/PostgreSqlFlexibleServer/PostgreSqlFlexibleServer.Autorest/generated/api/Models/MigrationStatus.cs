// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>State of migration.</summary>
    public partial class MigrationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal
    {

        /// <summary>Backing field for <see cref="CurrentSubStateDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails _currentSubStateDetail;

        /// <summary>Current migration sub state details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails CurrentSubStateDetail { get => (this._currentSubStateDetail = this._currentSubStateDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetails()); }

        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).CurrentSubState; }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).DbDetail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private string _error;

        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Error { get => this._error; }

        /// <summary>Internal Acessors for CurrentSubStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.CurrentSubStateDetail { get => (this._currentSubStateDetail = this._currentSubStateDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetails()); set { {_currentSubStateDetail = value;} } }

        /// <summary>Internal Acessors for CurrentSubStateDetailCurrentSubState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).CurrentSubState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).CurrentSubState = value ?? null; }

        /// <summary>Internal Acessors for CurrentSubStateDetailDbDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).DbDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).DbDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentSubStateDetailValidationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.CurrentSubStateDetailValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Error</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Internal Acessors for ValidationDetailDbLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailDbLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailDbLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailServerLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailServerLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailServerLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailStatus = value ?? null; }

        /// <summary>Internal Acessors for ValidationDetailValidationEndTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationEndTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationEndTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ValidationDetailValidationStartTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal.ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>State of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailDbLevelValidationDetail; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailServerLevelValidationDetail; }

        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailStatus; }

        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationEndTimeInUtc; }

        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal)CurrentSubStateDetail).ValidationDetailValidationStartTimeInUtc; }

        /// <summary>Creates an new <see cref="MigrationStatus" /> instance.</summary>
        public MigrationStatus()
        {

        }
    }
    /// State of migration.
    public partial interface IMigrationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Substate of migration.",
        SerializedName = @"currentSubState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubStateDetailCurrentSubState { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"dbDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get;  }
        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error message, if any, for the migration state.",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(string) })]
        string Error { get;  }
        /// <summary>State of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"State of migration.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForUserAction", "Canceled", "Failed", "Succeeded", "ValidationFailed", "CleaningUp")]
        string State { get;  }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of server level validations.",
        SerializedName = @"dbLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get;  }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of server level validations.",
        SerializedName = @"serverLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get;  }
        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Validation status for migration.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string ValidationDetailStatus { get;  }
        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"End time (UTC) for validation.",
        SerializedName = @"validationEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get;  }
        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Start time (UTC) for validation.",
        SerializedName = @"validationStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get;  }

    }
    /// State of migration.
    internal partial interface IMigrationStatusInternal

    {
        /// <summary>Current migration sub state details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails CurrentSubStateDetail { get; set; }
        /// <summary>Substate of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubStateDetailCurrentSubState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get; set; }
        /// <summary>Details for the validation for migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails CurrentSubStateDetailValidationDetail { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        string Error { get; set; }
        /// <summary>State of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForUserAction", "Canceled", "Failed", "Succeeded", "ValidationFailed", "CleaningUp")]
        string State { get; set; }
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get; set; }
        /// <summary>Validation status for migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string ValidationDetailStatus { get; set; }
        /// <summary>End time (UTC) for validation.</summary>
        global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for validation.</summary>
        global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get; set; }

    }
}