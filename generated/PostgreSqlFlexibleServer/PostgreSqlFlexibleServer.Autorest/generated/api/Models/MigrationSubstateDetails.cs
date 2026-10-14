// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Details of migration substate.</summary>
    public partial class MigrationSubstateDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal
    {

        /// <summary>Backing field for <see cref="CurrentSubState" /> property.</summary>
        private string _currentSubState;

        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string CurrentSubState { get => this._currentSubState; }

        /// <summary>Backing field for <see cref="DbDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails _dbDetail;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails DbDetail { get => (this._dbDetail = this._dbDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSubstateDetailsDbDetails()); set => this._dbDetail = value; }

        /// <summary>Internal Acessors for CurrentSubState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal.CurrentSubState { get => this._currentSubState; set { {_currentSubState = value;} } }

        /// <summary>Internal Acessors for ValidationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsInternal.ValidationDetail { get => (this._validationDetail = this._validationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetails()); set { {_validationDetail = value;} } }

        /// <summary>Backing field for <see cref="ValidationDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails _validationDetail;

        /// <summary>Details for the validation for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails ValidationDetail { get => (this._validationDetail = this._validationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ValidationDetails()); set => this._validationDetail = value; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).DbLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).DbLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ServerLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ServerLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).Status = value ?? null; }

        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ValidationEndTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ValidationEndTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ValidationStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal)ValidationDetail).ValidationStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="MigrationSubstateDetails" /> instance.</summary>
        public MigrationSubstateDetails()
        {

        }
    }
    /// Details of migration substate.
    public partial interface IMigrationSubstateDetails :
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
        string CurrentSubState { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"dbDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails DbDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Details of server level validations.",
        SerializedName = @"dbLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Details of server level validations.",
        SerializedName = @"serverLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get; set; }
        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Validation status for migration.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string ValidationDetailStatus { get; set; }
        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time (UTC) for validation.",
        SerializedName = @"validationEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time (UTC) for validation.",
        SerializedName = @"validationStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get; set; }

    }
    /// Details of migration substate.
    internal partial interface IMigrationSubstateDetailsInternal

    {
        /// <summary>Substate of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails DbDetail { get; set; }
        /// <summary>Details for the validation for migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails ValidationDetail { get; set; }
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