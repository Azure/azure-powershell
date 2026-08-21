// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration properties.</summary>
    public partial class MigrationPropertiesForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal
    {

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentialsSourceServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentialsSourceServerPassword = value ?? null; }

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentialsTargetServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentialsTargetServerPassword = value ?? null; }

        /// <summary>Backing field for <see cref="Cancel" /> property.</summary>
        private string _cancel;

        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Cancel { get => this._cancel; set => this._cancel = value; }

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

        /// <summary>Internal Acessors for SecretParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal.SecretParameter { get => (this._secretParameter = this._secretParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersForPatch()); set { {_secretParameter = value;} } }

        /// <summary>Internal Acessors for SecretParameterAdminCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal.SecretParameterAdminCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).AdminCredentials = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="MigrateRole" /> property.</summary>
        private string _migrateRole;

        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrateRole { get => this._migrateRole; set => this._migrateRole = value; }

        /// <summary>Backing field for <see cref="MigrationMode" /> property.</summary>
        private string _migrationMode;

        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MigrationMode { get => this._migrationMode; set => this._migrationMode = value; }

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
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch _secretParameter;

        /// <summary>Migration secret parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch SecretParameter { get => (this._secretParameter = this._secretParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersForPatch()); set => this._secretParameter = value; }

        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterSourceServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).SourceServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).SourceServerUsername = value ?? null; }

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterTargetServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).TargetServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatchInternal)SecretParameter).TargetServerUsername = value ?? null; }

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

        /// <summary>Backing field for <see cref="SourceDbServerResourceId" /> property.</summary>
        private string _sourceDbServerResourceId;

        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceDbServerResourceId { get => this._sourceDbServerResourceId; set => this._sourceDbServerResourceId = value; }

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

        /// <summary>Backing field for <see cref="TriggerCutover" /> property.</summary>
        private string _triggerCutover;

        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TriggerCutover { get => this._triggerCutover; set => this._triggerCutover = value; }

        /// <summary>Creates an new <see cref="MigrationPropertiesForPatch" /> instance.</summary>
        public MigrationPropertiesForPatch()
        {

        }
    }
    /// Migration properties.
    public partial interface IMigrationPropertiesForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
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
        Create = false,
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
        Create = false,
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
        Create = false,
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

    }
    /// Migration properties.
    internal partial interface IMigrationPropertiesForPatchInternal

    {
        /// <summary>Password for the user of the source server.</summary>
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string Cancel { get; set; }
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
        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Offline", "Online")]
        string MigrationMode { get; set; }
        /// <summary>Start time (UTC) for migration window.</summary>
        global::System.DateTime? MigrationWindowStartTimeInUtc { get; set; }
        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string OverwriteDbsInTarget { get; set; }
        /// <summary>Migration secret parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch SecretParameter { get; set; }
        /// <summary>Credentials of administrator users for source and target servers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch SecretParameterAdminCredentials { get; set; }
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
        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        string SourceDbServerResourceId { get; set; }
        /// <summary>Indicates if data migration must start right away.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string StartDataMigration { get; set; }
        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        string TargetDbServerFullyQualifiedDomainName { get; set; }
        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("True", "False")]
        string TriggerCutover { get; set; }

    }
}