// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration.</summary>
    public partial class MigrationResourceForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal
    {

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).AdminCredentialsSourceServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).AdminCredentialsSourceServerPassword = value ?? null; }

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).AdminCredentialsTargetServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).AdminCredentialsTargetServerPassword = value ?? null; }

        /// <summary>Indicates if cancel must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Cancel { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).Cancel; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).Cancel = value ?? null; }

        /// <summary>
        /// When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DbsToCancelMigrationOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToCancelMigrationOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToCancelMigrationOn = value ?? null /* arrayOf */; }

        /// <summary>Names of databases to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DbsToMigrate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToMigrate; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToMigrate = value ?? null /* arrayOf */; }

        /// <summary>
        /// When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases
        /// in this array.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DbsToTriggerCutoverOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToTriggerCutoverOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).DbsToTriggerCutoverOn = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesForPatch()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SecretParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal.SecretParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameter = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SecretParameterAdminCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchInternal.SecretParameterAdminCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterAdminCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterAdminCredentials = value ?? null /* model class */; }

        /// <summary>Indicates if roles and permissions must be migrated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string MigrateRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrateRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrateRole = value ?? null; }

        /// <summary>Mode used to perform the migration: Online or Offline.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string MigrationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrationMode = value ?? null; }

        /// <summary>Start time (UTC) for migration window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? MigrationWindowStartTimeInUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrationWindowStartTimeInUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).MigrationWindowStartTimeInUtc = value ?? default(global::System.DateTime); }

        /// <summary>
        /// Indicates if databases on the target server can be overwritten when already present. If set to 'False', when the migration
        /// workflow detects that the database already exists on the target server, it will wait for a confirmation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string OverwriteDbsInTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).OverwriteDbsInTarget; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).OverwriteDbsInTarget = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch _property;

        /// <summary>Migration properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationPropertiesForPatch()); set => this._property = value; }

        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterSourceServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterSourceServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterSourceServerUsername = value ?? null; }

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SecretParameterTargetServerUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterTargetServerUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SecretParameterTargetServerUsername = value ?? null; }

        /// <summary>Indicates whether to setup logical replication on source server, if needed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SetupLogicalReplicationOnSourceDbIfNeeded { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SetupLogicalReplicationOnSourceDbIfNeeded; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SetupLogicalReplicationOnSourceDbIfNeeded = value ?? null; }

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the source server. This property is optional. When provided, the migration
        /// service will always use it to connect to the source server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerFullyQualifiedDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SourceDbServerFullyQualifiedDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SourceDbServerFullyQualifiedDomainName = value ?? null; }

        /// <summary>
        /// Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'. For other source types
        /// this must be set to ipaddress:port@username or hostname:port@username.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SourceDbServerResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SourceDbServerResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).SourceDbServerResourceId = value ?? null; }

        /// <summary>Indicates if data migration must start right away.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StartDataMigration { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).StartDataMigration; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).StartDataMigration = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags _tag;

        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationResourceForPatchTags()); set => this._tag = value; }

        /// <summary>
        /// Fully qualified domain name (FQDN) or IP address of the target server. This property is optional. When provided, the migration
        /// service will always use it to connect to the target server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TargetDbServerFullyQualifiedDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).TargetDbServerFullyQualifiedDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).TargetDbServerFullyQualifiedDomainName = value ?? null; }

        /// <summary>Indicates if cutover must be triggered for the entire migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TriggerCutover { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).TriggerCutover; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatchInternal)Property).TriggerCutover = value ?? null; }

        /// <summary>Creates an new <see cref="MigrationResourceForPatch" /> instance.</summary>
        public MigrationResourceForPatch()
        {

        }
    }
    /// Migration.
    public partial interface IMigrationResourceForPatch :
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Application-specific metadata in the form of key-value pairs.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags Tag { get; set; }
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
    /// Migration.
    internal partial interface IMigrationResourceForPatchInternal

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
        /// <summary>Migration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch Property { get; set; }
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationResourceForPatchTags Tag { get; set; }
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