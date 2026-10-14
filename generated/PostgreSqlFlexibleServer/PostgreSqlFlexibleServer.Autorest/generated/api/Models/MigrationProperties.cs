// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration.</summary>
    public partial class MigrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal
    {

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentialsSourceServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentialsSourceServerPassword = value ?? null; }

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentialsTargetServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentialsTargetServerPassword = value ?? null; }

        /// <summary>Backing field for <see cref="Cancel" /> property.</summary>
        private string _cancel;

        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Cancel { get => this._cancel; set => this._cancel = value; }

        /// <summary>Backing field for <see cref="CurrentStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus _currentStatus;

        /// <summary>Current status of a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus CurrentStatus { get => (this._currentStatus = this._currentStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatus()); }

        /// <summary>Error message, if any, for the migration state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string CurrentStatusError { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).Error; }

        /// <summary>State of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string CurrentStatusState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).State; }

        /// <summary>Substate of migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailCurrentSubState; }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailDbDetail; }

        /// <summary>Backing field for <see cref="DbsToCancelMigrationOn" /> property.</summary>
        private System.Collections.Generic.List<string> _dbsToCancelMigrationOn;

        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DbsToCancelMigrationOn { get => this._dbsToCancelMigrationOn; set => this._dbsToCancelMigrationOn = value; }

        /// <summary>Backing field for <see cref="DbsToMigrate" /> property.</summary>
        private System.Collections.Generic.List<string> _dbsToMigrate;

        /// <summary>Names of databases to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DbsToMigrate { get => this._dbsToMigrate; set => this._dbsToMigrate = value; }

        /// <summary>Backing field for <see cref="DbsToTriggerCutoverOn" /> property.</summary>
        private System.Collections.Generic.List<string> _dbsToTriggerCutoverOn;

        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get => this._dbsToTriggerCutoverOn; set => this._dbsToTriggerCutoverOn = value; }

        /// <summary>Internal Acessors for CurrentStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentStatus { get => (this._currentStatus = this._currentStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatus()); set { {_currentStatus = value;} } }

        /// <summary>Internal Acessors for CurrentStatusCurrentSubStateDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentStatusCurrentSubStateDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentStatusError</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentStatusError { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).Error = value ?? null; }

        /// <summary>Internal Acessors for CurrentStatusState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentStatusState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).State = value ?? null; }

        /// <summary>Internal Acessors for CurrentSubStateDetailCurrentSubState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentSubStateDetailCurrentSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailCurrentSubState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailCurrentSubState = value ?? null; }

        /// <summary>Internal Acessors for CurrentSubStateDetailDbDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentSubStateDetailDbDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailDbDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailDbDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentSubStateDetailValidationDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.CurrentSubStateDetailValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).CurrentSubStateDetailValidationDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for MigrationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.MigrationId { get => this._migrationId; set { {_migrationId = value;} } }

        /// <summary>Internal Acessors for SecretParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SecretParameter { get => (this._secretParameter = this._secretParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParameters()); set { {_secretParameter = value;} } }

        /// <summary>Internal Acessors for SecretParameterAdminCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SecretParameterAdminCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).AdminCredentials = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceDbServerMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadata { get => (this._sourceDbServerMetadata = this._sourceDbServerMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata()); set { {_sourceDbServerMetadata = value;} } }

        /// <summary>Internal Acessors for SourceDbServerMetadataLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Location = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Sku = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuName = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataSkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuTier = value ?? null; }

        /// <summary>Internal Acessors for SourceDbServerMetadataStorageMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).StorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).StorageMb = value ?? default(int); }

        /// <summary>Internal Acessors for SourceDbServerMetadataVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.SourceDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Version = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadata { get => (this._targetDbServerMetadata = this._targetDbServerMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata()); set { {_targetDbServerMetadata = value;} } }

        /// <summary>Internal Acessors for TargetDbServerMetadataLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Location = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Sku = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuName = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataSkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuTier = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerMetadataStorageMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).StorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).StorageMb = value ?? default(int); }

        /// <summary>Internal Acessors for TargetDbServerMetadataVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Version = value ?? null; }

        /// <summary>Internal Acessors for TargetDbServerResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.TargetDbServerResourceId { get => this._targetDbServerResourceId; set { {_targetDbServerResourceId = value;} } }

        /// <summary>Internal Acessors for ValidationDetailDbLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailDbLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailDbLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailServerLevelValidationDetail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailServerLevelValidationDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailServerLevelValidationDetail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ValidationDetailStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailStatus = value ?? null; }

        /// <summary>Internal Acessors for ValidationDetailValidationEndTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationEndTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationEndTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ValidationDetailValidationStartTimeInUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesInternal.ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="MigrateRole" /> property.</summary>
        private string _migrateRole;

        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrateRole { get => this._migrateRole; set => this._migrateRole = value; }

        /// <summary>Backing field for <see cref="MigrationId" /> property.</summary>
        private string _migrationId;

        /// <summary>Identifier of a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationId { get => this._migrationId; }

        /// <summary>Backing field for <see cref="MigrationInstanceResourceId" /> property.</summary>
        private string _migrationInstanceResourceId;

        /// <summary>Identifier of the private endpoint migration instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationInstanceResourceId { get => this._migrationInstanceResourceId; set => this._migrationInstanceResourceId = value; }

        /// <summary>Backing field for <see cref="MigrationMode" /> property.</summary>
        private string _migrationMode;

        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationMode { get => this._migrationMode; set => this._migrationMode = value; }

        /// <summary>Backing field for <see cref="MigrationOption" /> property.</summary>
        private string _migrationOption;

        /// <summary>Supported option for a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationOption { get => this._migrationOption; set => this._migrationOption = value; }

        /// <summary>Backing field for <see cref="MigrationWindowEndTimeInUtc" /> property.</summary>
        private global::System.DateTime? _migrationWindowEndTimeInUtc;

        /// <summary>End time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? MigrationWindowEndTimeInUtc { get => this._migrationWindowEndTimeInUtc; set => this._migrationWindowEndTimeInUtc = value; }

        /// <summary>Backing field for <see cref="MigrationWindowStartTimeInUtc" /> property.</summary>
        private global::System.DateTime? _migrationWindowStartTimeInUtc;

        /// <summary>Start time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? MigrationWindowStartTimeInUtc { get => this._migrationWindowStartTimeInUtc; set => this._migrationWindowStartTimeInUtc = value; }

        /// <summary>Backing field for <see cref="OverwriteDbsInTarget" /> property.</summary>
        private string _overwriteDbsInTarget;

        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string OverwriteDbsInTarget { get => this._overwriteDbsInTarget; set => this._overwriteDbsInTarget = value; }

        /// <summary>Backing field for <see cref="SecretParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters _secretParameter;

        /// <summary>Migration secret parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters SecretParameter { get => (this._secretParameter = this._secretParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParameters()); set => this._secretParameter = value; }

        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterSourceServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).SourceServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).SourceServerUsername = value ?? null; }

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterTargetServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).TargetServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal)SecretParameter).TargetServerUsername = value ?? null; }

        /// <summary>
        /// Backing field for <see cref="SetupLogicalReplicationOnSourceDbIfNeeded" /> property.
        /// </summary>
        private string _setupLogicalReplicationOnSourceDbIfNeeded;

        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SetupLogicalReplicationOnSourceDbIfNeeded { get => this._setupLogicalReplicationOnSourceDbIfNeeded; set => this._setupLogicalReplicationOnSourceDbIfNeeded = value; }

        /// <summary>
        /// Backing field for <see cref="SourceDbServerFullyQualifiedDomainName" /> property.
        /// </summary>
        private string _sourceDbServerFullyQualifiedDomainName;

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceDbServerFullyQualifiedDomainName { get => this._sourceDbServerFullyQualifiedDomainName; set => this._sourceDbServerFullyQualifiedDomainName = value; }

        /// <summary>Backing field for <see cref="SourceDbServerMetadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata _sourceDbServerMetadata;

        /// <summary>Metadata of source database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata SourceDbServerMetadata { get => (this._sourceDbServerMetadata = this._sourceDbServerMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata()); }

        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Location; }

        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuName; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).SkuTier; }

        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? SourceDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).StorageMb; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)SourceDbServerMetadata).Version; }

        /// <summary>Backing field for <see cref="SourceDbServerResourceId" /> property.</summary>
        private string _sourceDbServerResourceId;

        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceDbServerResourceId { get => this._sourceDbServerResourceId; set => this._sourceDbServerResourceId = value; }

        /// <summary>Backing field for <see cref="SourceType" /> property.</summary>
        private string _sourceType;

        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceType { get => this._sourceType; set => this._sourceType = value; }

        /// <summary>Backing field for <see cref="SslMode" /> property.</summary>
        private string _sslMode;

        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SslMode { get => this._sslMode; set => this._sslMode = value; }

        /// <summary>Backing field for <see cref="StartDataMigration" /> property.</summary>
        private string _startDataMigration;

        /// <summary>Indicates if data migration must start right away.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string StartDataMigration { get => this._startDataMigration; set => this._startDataMigration = value; }

        /// <summary>
        /// Backing field for <see cref="TargetDbServerFullyQualifiedDomainName" /> property.
        /// </summary>
        private string _targetDbServerFullyQualifiedDomainName;

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TargetDbServerFullyQualifiedDomainName { get => this._targetDbServerFullyQualifiedDomainName; set => this._targetDbServerFullyQualifiedDomainName = value; }

        /// <summary>Backing field for <see cref="TargetDbServerMetadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata _targetDbServerMetadata;

        /// <summary>Metadata of target database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata TargetDbServerMetadata { get => (this._targetDbServerMetadata = this._targetDbServerMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata()); }

        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TargetDbServerMetadataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Location; }

        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TargetDbServerMetadataSkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuName; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TargetDbServerMetadataSkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).SkuTier; }

        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? TargetDbServerMetadataStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).StorageMb; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TargetDbServerMetadataVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadataInternal)TargetDbServerMetadata).Version; }

        /// <summary>Backing field for <see cref="TargetDbServerResourceId" /> property.</summary>
        private string _targetDbServerResourceId;

        /// <summary>Identifier of the target database server resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TargetDbServerResourceId { get => this._targetDbServerResourceId; }

        /// <summary>Backing field for <see cref="TriggerCutover" /> property.</summary>
        private string _triggerCutover;

        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TriggerCutover { get => this._triggerCutover; set => this._triggerCutover = value; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> ValidationDetailDbLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailDbLevelValidationDetail; }

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ValidationDetailServerLevelValidationDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailServerLevelValidationDetail; }

        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ValidationDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailStatus; }

        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationEndTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationEndTimeInUtc; }

        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? ValidationDetailValidationStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatusInternal)CurrentStatus).ValidationDetailValidationStartTimeInUtc; }

        /// <summary>Creates an new <see cref="MigrationProperties" /> instance.</summary>
        public MigrationProperties()
        {

        }
    }
    /// Migration.
    public partial interface IMigrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the source server.",
        SerializedName = @"sourceServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the target server.",
        SerializedName = @"targetServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if cancel must be triggered for the entire migration.",
        SerializedName = @"cancel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string Cancel { get; set; }
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
        string CurrentStatusError { get;  }
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
        string CurrentStatusState { get;  }
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
        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToCancelMigrationOn",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToCancelMigrationOn { get; set; }
        /// <summary>Names of databases to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Names of databases to migrate.",
        SerializedName = @"dbsToMigrate",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToMigrate { get; set; }
        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.",
        SerializedName = @"dbsToTriggerCutoverOn",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get; set; }
        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if roles and permissions must be migrated.",
        SerializedName = @"migrateRoles",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string MigrateRole { get; set; }
        /// <summary>Identifier of a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifier of a migration.",
        SerializedName = @"migrationId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationId { get;  }
        /// <summary>Identifier of the private endpoint migration instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the private endpoint migration instance.",
        SerializedName = @"migrationInstanceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationInstanceResourceId { get; set; }
        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Mode used to perform the migration: Online or Offline.",
        SerializedName = @"migrationMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        string MigrationMode { get; set; }
        /// <summary>Supported option for a migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Supported option for a migration.",
        SerializedName = @"migrationOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Validate", "Migrate", "ValidateAndMigrate")]
        string MigrationOption { get; set; }
        /// <summary>End time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time (UTC) for migration window.",
        SerializedName = @"migrationWindowEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? MigrationWindowEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time (UTC) for migration window.",
        SerializedName = @"migrationWindowStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? MigrationWindowStartTimeInUtc { get; set; }
        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration workflow detects that the database already exists on the target server, it will wait for a confirmation.",
        SerializedName = @"overwriteDbsInTarget",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string OverwriteDbsInTarget { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.",
        SerializedName = @"sourceServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string SecretParameterSourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.",
        SerializedName = @"targetServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string SecretParameterTargetServerUsername { get; set; }
        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether to setup logical replication on source server, if needed.",
        SerializedName = @"setupLogicalReplicationOnSourceDbIfNeeded",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration service will always use it to connect to the source server.",
        SerializedName = @"sourceDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Location of database server.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataLocation { get;  }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataSkuName { get;  }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SourceDbServerMetadataSkuTier { get;  }
        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage size (in MB) for database server.",
        SerializedName = @"storageMb",
        PossibleTypes = new [] { typeof(int) })]
        int? SourceDbServerMetadataStorageMb { get;  }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerMetadataVersion { get;  }
        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types this must be set to ipaddress:port@username or hostname:port@username.",
        SerializedName = @"sourceDbServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDbServerResourceId { get; set; }
        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL, Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL, GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer, PostgreSQLSingleServer, or Supabase_PostgreSQL",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("OnPremises", "AWS", "GCP", "AzureVM", "PostgreSQLSingleServer", "AWS_RDS", "AWS_AURORA", "AWS_EC2", "GCP_CloudSQL", "GCP_AlloyDB", "GCP_Compute", "EDB", "EDB_Oracle_Server", "EDB_PostgreSQL", "PostgreSQLFlexibleServer", "PostgreSQLCosmosDB", "Huawei_RDS", "Huawei_Compute", "Heroku_PostgreSQL", "Crunchy_PostgreSQL", "ApsaraDB_RDS", "Digital_Ocean_Droplets", "Digital_Ocean_PostgreSQL", "Supabase_PostgreSQL")]
        string SourceType { get; set; }
        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other source types is 'Prefer'.",
        SerializedName = @"sslMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Prefer", "Require", "VerifyCA", "VerifyFull")]
        string SslMode { get; set; }
        /// <summary>Indicates if data migration must start right away.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if data migration must start right away.",
        SerializedName = @"startDataMigration",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string StartDataMigration { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration service will always use it to connect to the target server.",
        SerializedName = @"targetDbServerFullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Location of database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Location of database server.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataLocation { get;  }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataSkuName { get;  }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string TargetDbServerMetadataSkuTier { get;  }
        /// <summary>Storage size (in MB) for database server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage size (in MB) for database server.",
        SerializedName = @"storageMb",
        PossibleTypes = new [] { typeof(int) })]
        int? TargetDbServerMetadataStorageMb { get;  }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerMetadataVersion { get;  }
        /// <summary>Identifier of the target database server resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifier of the target database server resource.",
        SerializedName = @"targetDbServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDbServerResourceId { get;  }
        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if cutover must be triggered for the entire migration.",
        SerializedName = @"triggerCutover",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string TriggerCutover { get; set; }
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
    /// Migration.
    internal partial interface IMigrationPropertiesInternal

    {
        /// <summary>Password for the user of the source server.</summary>
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string Cancel { get; set; }
        /// <summary>Current status of a migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationStatus CurrentStatus { get; set; }
        /// <summary>Current migration sub state details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetails CurrentStatusCurrentSubStateDetail { get; set; }
        /// <summary>Error message, if any, for the migration state.</summary>
        string CurrentStatusError { get; set; }
        /// <summary>State of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("InProgress", "WaitingForUserAction", "Canceled", "Failed", "Succeeded", "ValidationFailed", "CleaningUp")]
        string CurrentStatusState { get; set; }
        /// <summary>Substate of migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("PerformingPreRequisiteSteps", "WaitingForLogicalReplicationSetupRequestOnSourceDB", "WaitingForDBsToMigrateSpecification", "WaitingForTargetDBOverwriteConfirmation", "WaitingForDataMigrationScheduling", "WaitingForDataMigrationWindow", "MigratingData", "WaitingForCutoverTrigger", "CompletingMigration", "Completed", "CancelingRequestedDBMigrations", "ValidationInProgress")]
        string CurrentSubStateDetailCurrentSubState { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSubstateDetailsDbDetails CurrentSubStateDetailDbDetail { get; set; }
        /// <summary>Details for the validation for migration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails CurrentSubStateDetailValidationDetail { get; set; }
        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        System.Collections.Generic.List<string> DbsToCancelMigrationOn { get; set; }
        /// <summary>Names of databases to migrate.</summary>
        System.Collections.Generic.List<string> DbsToMigrate { get; set; }
        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get; set; }
        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string MigrateRole { get; set; }
        /// <summary>Identifier of a migration.</summary>
        string MigrationId { get; set; }
        /// <summary>Identifier of the private endpoint migration instance.</summary>
        string MigrationInstanceResourceId { get; set; }
        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        string MigrationMode { get; set; }
        /// <summary>Supported option for a migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Validate", "Migrate", "ValidateAndMigrate")]
        string MigrationOption { get; set; }
        /// <summary>End time (UTC) for migration window.</summary>
        global::System.DateTime? MigrationWindowEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for migration window.</summary>
        global::System.DateTime? MigrationWindowStartTimeInUtc { get; set; }
        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string OverwriteDbsInTarget { get; set; }
        /// <summary>Migration secret parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters SecretParameter { get; set; }
        /// <summary>Credentials of administrator users for source and target servers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials SecretParameterAdminCredentials { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        string SecretParameterSourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        string SecretParameterTargetServerUsername { get; set; }
        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        string SourceDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Metadata of source database server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata SourceDbServerMetadata { get; set; }
        /// <summary>Location of database server.</summary>
        string SourceDbServerMetadataLocation { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku SourceDbServerMetadataSku { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        string SourceDbServerMetadataSkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SourceDbServerMetadataSkuTier { get; set; }
        /// <summary>Storage size (in MB) for database server.</summary>
        int? SourceDbServerMetadataStorageMb { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        string SourceDbServerMetadataVersion { get; set; }
        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        string SourceDbServerResourceId { get; set; }
        /// <summary>
        /// Source server type used for the migration: ApsaraDB_RDS, AWS, AWS_AURORA, AWS_EC2, AWS_RDS, AzureVM, Crunchy_PostgreSQL,
        /// Digital_Ocean_Droplets, Digital_Ocean_PostgreSQL, EDB, EDB_Oracle_Server, EDB_PostgreSQL, GCP, GCP_AlloyDB, GCP_CloudSQL,
        /// GCP_Compute, Heroku_PostgreSQL, Huawei_Compute, Huawei_RDS, OnPremises, PostgreSQLCosmosDB, PostgreSQLFlexibleServer,
        /// PostgreSQLSingleServer, or Supabase_PostgreSQL
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("OnPremises", "AWS", "GCP", "AzureVM", "PostgreSQLSingleServer", "AWS_RDS", "AWS_AURORA", "AWS_EC2", "GCP_CloudSQL", "GCP_AlloyDB", "GCP_Compute", "EDB", "EDB_Oracle_Server", "EDB_PostgreSQL", "PostgreSQLFlexibleServer", "PostgreSQLCosmosDB", "Huawei_RDS", "Huawei_Compute", "Heroku_PostgreSQL", "Crunchy_PostgreSQL", "ApsaraDB_RDS", "Digital_Ocean_Droplets", "Digital_Ocean_PostgreSQL", "Supabase_PostgreSQL")]
        string SourceType { get; set; }
        /// <summary>
        /// SSL mode used by a migration. Default SSL mode for 'PostgreSQLSingleServer' is 'VerifyFull'. Default SSL mode for other
        /// source types is 'Prefer'.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Prefer", "Require", "VerifyCA", "VerifyFull")]
        string SslMode { get; set; }
        /// <summary>Indicates if data migration must start right away.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string StartDataMigration { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        string TargetDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Metadata of target database server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbServerMetadata TargetDbServerMetadata { get; set; }
        /// <summary>Location of database server.</summary>
        string TargetDbServerMetadataLocation { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSku TargetDbServerMetadataSku { get; set; }
        /// <summary>
        /// Compute tier and size of the database server. This object is empty for an Azure Database for PostgreSQL single server.
        /// </summary>
        string TargetDbServerMetadataSkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string TargetDbServerMetadataSkuTier { get; set; }
        /// <summary>Storage size (in MB) for database server.</summary>
        int? TargetDbServerMetadataStorageMb { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        string TargetDbServerMetadataVersion { get; set; }
        /// <summary>Identifier of the target database server resource.</summary>
        string TargetDbServerResourceId { get; set; }
        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string TriggerCutover { get; set; }
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