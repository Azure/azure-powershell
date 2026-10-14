// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a server.</summary>
    public partial class ServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdministratorLogin" /> property.</summary>
        private string _administratorLogin;

        /// <summary>
        /// Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be
        /// specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot
        /// be changed for the rest of the life of a server. If you disable password based authentication on a server which had it
        /// enabled, this password based role isn't deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string AdministratorLogin { get => this._administratorLogin; set => this._administratorLogin = value; }

        /// <summary>Backing field for <see cref="AdministratorLoginPassword" /> property.</summary>
        private System.Security.SecureString _administratorLoginPassword;

        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Security.SecureString AdministratorLoginPassword { get => this._administratorLoginPassword; set => this._administratorLoginPassword = value; }

        /// <summary>Backing field for <see cref="AuthConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig _authConfig;

        /// <summary>Authentication configuration properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig AuthConfig { get => (this._authConfig = this._authConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfig()); set => this._authConfig = value; }

        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigActiveDirectoryAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).ActiveDirectoryAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).ActiveDirectoryAuth = value ?? null; }

        /// <summary>Indicates if the server supports password based authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigPasswordAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).PasswordAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).PasswordAuth = value ?? null; }

        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal)AuthConfig).TenantId = value ?? null; }

        /// <summary>Backing field for <see cref="AvailabilityZone" /> property.</summary>
        private string _availabilityZone;

        /// <summary>Availability zone of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string AvailabilityZone { get => this._availabilityZone; set => this._availabilityZone = value; }

        /// <summary>Backing field for <see cref="Backup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup _backup;

        /// <summary>Backup properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup Backup { get => (this._backup = this._backup ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Backup()); set => this._backup = value; }

        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupEarliestRestoreDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).EarliestRestoreDate; }

        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string BackupGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).GeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).GeoRedundantBackup = value ?? null; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? BackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).RetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).RetentionDay = value ?? default(int); }

        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).Capacity; }

        /// <summary>Backing field for <see cref="Cluster" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster _cluster;

        /// <summary>Cluster properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster Cluster { get => (this._cluster = this._cluster ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Cluster()); set => this._cluster = value; }

        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ClusterDefaultDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IClusterInternal)Cluster).DefaultDatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IClusterInternal)Cluster).DefaultDatabaseName = value ?? null; }

        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IClusterInternal)Cluster).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IClusterInternal)Cluster).Size = value ?? default(int); }

        /// <summary>Backing field for <see cref="CreateMode" /> property.</summary>
        private string _createMode;

        /// <summary>Creation mode of a new server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string CreateMode { get => this._createMode; set => this._createMode = value; }

        /// <summary>Backing field for <see cref="DataEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption _dataEncryption;

        /// <summary>Data encryption properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption DataEncryption { get => (this._dataEncryption = this._dataEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryption()); set => this._dataEncryption = value; }

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupEncryptionKeyStatus; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupKeyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupKeyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupKeyUri = value ?? null; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupUserAssignedIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupUserAssignedIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupUserAssignedIdentityId = value ?? null; }

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryEncryptionKeyStatus; }

        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryKeyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryKeyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryKeyUri = value ?? null; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryUserAssignedIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryUserAssignedIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryUserAssignedIdentityId = value ?? null; }

        /// <summary>Data encryption type used by a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).Type = value ?? null; }

        /// <summary>Backing field for <see cref="FullyQualifiedDomainName" /> property.</summary>
        private string _fullyQualifiedDomainName;

        /// <summary>Fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string FullyQualifiedDomainName { get => this._fullyQualifiedDomainName; }

        /// <summary>Backing field for <see cref="HighAvailability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability _highAvailability;

        /// <summary>High availability properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability HighAvailability { get => (this._highAvailability = this._highAvailability ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailability()); set => this._highAvailability = value; }

        /// <summary>High availability mode for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).Mode = value ?? null; }

        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityStandbyAvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).StandbyAvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).StandbyAvailabilityZone = value ?? null; }

        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).State; }

        /// <summary>Backing field for <see cref="MaintenanceWindow" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow _maintenanceWindow;

        /// <summary>Maintenance window properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow MaintenanceWindow { get => (this._maintenanceWindow = this._maintenanceWindow ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindow()); set => this._maintenanceWindow = value; }

        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string MaintenanceWindowCustomWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).CustomWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).CustomWindow = value ?? null; }

        /// <summary>Day of the week to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowDayOfWeek { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).DayOfWeek; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).DayOfWeek = value ?? default(int); }

        /// <summary>Start hour to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).StartHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).StartHour = value ?? default(int); }

        /// <summary>Start minute to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).StartMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal)MaintenanceWindow).StartMinute = value ?? default(int); }

        /// <summary>Internal Acessors for AuthConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.AuthConfig { get => (this._authConfig = this._authConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AuthConfig()); set { {_authConfig = value;} } }

        /// <summary>Internal Acessors for Backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Backup { get => (this._backup = this._backup ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Backup()); set { {_backup = value;} } }

        /// <summary>Internal Acessors for BackupEarliestRestoreDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.BackupEarliestRestoreDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).EarliestRestoreDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupInternal)Backup).EarliestRestoreDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for Capacity</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).Capacity = value ?? default(int); }

        /// <summary>Internal Acessors for Cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Cluster { get => (this._cluster = this._cluster ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Cluster()); set { {_cluster = value;} } }

        /// <summary>Internal Acessors for DataEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.DataEncryption { get => (this._dataEncryption = this._dataEncryption ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DataEncryption()); set { {_dataEncryption = value;} } }

        /// <summary>Internal Acessors for DataEncryptionGeoBackupEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.DataEncryptionGeoBackupEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupEncryptionKeyStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).GeoBackupEncryptionKeyStatus = value ?? null; }

        /// <summary>Internal Acessors for DataEncryptionPrimaryEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.DataEncryptionPrimaryEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryEncryptionKeyStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal)DataEncryption).PrimaryEncryptionKeyStatus = value ?? null; }

        /// <summary>Internal Acessors for FullyQualifiedDomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.FullyQualifiedDomainName { get => this._fullyQualifiedDomainName; set { {_fullyQualifiedDomainName = value;} } }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.HighAvailability { get => (this._highAvailability = this._highAvailability ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.HighAvailability()); set { {_highAvailability = value;} } }

        /// <summary>Internal Acessors for HighAvailabilityState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.HighAvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityInternal)HighAvailability).State = value ?? null; }

        /// <summary>Internal Acessors for MaintenanceWindow</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.MaintenanceWindow { get => (this._maintenanceWindow = this._maintenanceWindow ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MaintenanceWindow()); set { {_maintenanceWindow = value;} } }

        /// <summary>Internal Acessors for MinorVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.MinorVersion { get => this._minorVersion; set { {_minorVersion = value;} } }

        /// <summary>Internal Acessors for Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Network { get => (this._network = this._network ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Network()); set { {_network = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for Replica</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Replica { get => (this._replica = this._replica ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Replica()); set { {_replica = value;} } }

        /// <summary>Internal Acessors for ReplicaCapacity</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.ReplicaCapacity { get => this._replicaCapacity; set { {_replicaCapacity = value;} } }

        /// <summary>Internal Acessors for ReplicaReplicationState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.ReplicaReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).TionState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).TionState = value ?? null; }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Internal Acessors for Storage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesInternal.Storage { get => (this._storage = this._storage ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Storage()); set { {_storage = value;} } }

        /// <summary>Backing field for <see cref="MinorVersion" /> property.</summary>
        private string _minorVersion;

        /// <summary>Minor version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string MinorVersion { get => this._minorVersion; }

        /// <summary>Backing field for <see cref="Network" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork _network;

        /// <summary>
        /// Network properties of a server. Only required if you want your server to be integrated into a virtual network provided
        /// by customer.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork Network { get => (this._network = this._network ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Network()); set => this._network = value; }

        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkDelegatedSubnetResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).DelegatedSubnetResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).DelegatedSubnetResourceId = value ?? null; }

        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkPrivateDnsZoneArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).PrivateDnsZoneArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).PrivateDnsZoneArmResourceId = value ?? null; }

        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkPublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal)Network).PublicNetworkAccess = value ?? null; }

        /// <summary>Backing field for <see cref="PointInTimeUtc" /> property.</summary>
        private global::System.DateTime? _pointInTimeUtc;

        /// <summary>
        /// Creation time (in ISO8601 format) of the backup which you want to restore in the new server. It's required when 'createMode'
        /// is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? PointInTimeUtc { get => this._pointInTimeUtc; set => this._pointInTimeUtc = value; }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection> _privateEndpointConnection;

        /// <summary>List of private endpoint connections associated with the specified server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="Replica" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica _replica;

        /// <summary>
        /// Read replica properties of a server. Required only in case that you want to promote a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica Replica { get => (this._replica = this._replica ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Replica()); set => this._replica = value; }

        /// <summary>Backing field for <see cref="ReplicaCapacity" /> property.</summary>
        private int? _replicaCapacity;

        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? ReplicaCapacity { get => this._replicaCapacity; }

        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaPromoteMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).PromoteMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).PromoteMode = value ?? null; }

        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaPromoteOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).PromoteOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).PromoteOption = value ?? null; }

        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).TionState; }

        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).Role; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplicaInternal)Replica).Role = value ?? null; }

        /// <summary>Backing field for <see cref="ReplicationRole" /> property.</summary>
        private string _replicationRole;

        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string ReplicationRole { get => this._replicationRole; set => this._replicationRole = value; }

        /// <summary>Backing field for <see cref="SourceServerResourceId" /> property.</summary>
        private string _sourceServerResourceId;

        /// <summary>
        /// Identifier of the server to be used as the source of the new server. Required when 'createMode' is 'PointInTimeRestore',
        /// 'GeoRestore', 'Replica', or 'ReviveDropped'. This property is returned only when the target server is a read replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceServerResourceId { get => this._sourceServerResourceId; set => this._sourceServerResourceId = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>Possible states of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Backing field for <see cref="Storage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage _storage;

        /// <summary>Storage properties of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage Storage { get => (this._storage = this._storage ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.Storage()); set => this._storage = value; }

        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageAutoGrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).AutoGrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).AutoGrow = value ?? null; }

        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageIop { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Iop; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Iop = value ?? default(int); }

        /// <summary>Size of storage assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).SizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).SizeGb = value ?? default(int); }

        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageThroughput { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Throughput; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Throughput = value ?? default(int); }

        /// <summary>Storage tier of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Tier = value ?? null; }

        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageInternal)Storage).Type = value ?? null; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ServerProperties" /> instance.</summary>
        public ServerProperties()
        {

        }
    }
    /// Properties of a server.
    public partial interface IServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be
        /// specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot
        /// be changed for the rest of the life of a server. If you disable password based authentication on a server which had it
        /// enabled, this password based role isn't deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot be changed for the rest of the life of a server. If you disable password based authentication on a server which had it enabled, this password based role isn't deleted.",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get; set; }
        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed at any time.",
        SerializedName = @"administratorLoginPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdministratorLoginPassword { get; set; }
        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if the server supports Microsoft Entra authentication.",
        SerializedName = @"activeDirectoryAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AuthConfigActiveDirectoryAuth { get; set; }
        /// <summary>Indicates if the server supports password based authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if the server supports password based authentication.",
        SerializedName = @"passwordAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AuthConfigPasswordAuth { get; set; }
        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the tenant of the delegated resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string AuthConfigTenantId { get; set; }
        /// <summary>Availability zone of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Availability zone of a server.",
        SerializedName = @"availabilityZone",
        PossibleTypes = new [] { typeof(string) })]
        string AvailabilityZone { get; set; }
        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Earliest restore point time (ISO8601 format) for a server.",
        SerializedName = @"earliestRestoreDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? BackupEarliestRestoreDate { get;  }
        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Indicates if the server is configured to create geographically redundant backups.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BackupGeoRedundantBackup { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? BackupRetentionDay { get; set; }
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum number of read replicas allowed for a server.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get;  }
        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Default database name for the elastic cluster.",
        SerializedName = @"defaultDatabaseName",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterDefaultDatabaseName { get; set; }
        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of nodes assigned to the elastic cluster.",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterSize { get; set; }
        /// <summary>Creation mode of a new server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Creation mode of a new server.",
        SerializedName = @"createMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Default", "Create", "Update", "PointInTimeRestore", "GeoRestore", "Replica", "ReviveDropped")]
        string CreateMode { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically redundant storage associated to the server when it is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupEncryptionKeyStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string DataEncryptionGeoBackupEncryptionKeyStatus { get;  }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        string DataEncryptionGeoBackupKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        string DataEncryptionGeoBackupUserAssignedIdentityId { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage associated to the server.",
        SerializedName = @"primaryEncryptionKeyStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string DataEncryptionPrimaryEncryptionKeyStatus { get;  }
        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        string DataEncryptionPrimaryKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        string DataEncryptionPrimaryUserAssignedIdentityId { get; set; }
        /// <summary>Data encryption type used by a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data encryption type used by a server.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("SystemManaged", "AzureKeyVault")]
        string DataEncryptionType { get; set; }
        /// <summary>Fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Fully qualified domain name of a server.",
        SerializedName = @"fullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string FullyQualifiedDomainName { get;  }
        /// <summary>High availability mode for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"High availability mode for a server.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Disabled", "ZoneRedundant", "SameZone")]
        string HighAvailabilityMode { get; set; }
        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.",
        SerializedName = @"standbyAvailabilityZone",
        PossibleTypes = new [] { typeof(string) })]
        string HighAvailabilityStandbyAvailabilityZone { get; set; }
        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("NotEnabled", "CreatingStandby", "ReplicatingData", "FailingOver", "Healthy", "RemovingStandby", "RecreatingStandby", "ComputeUpdatingByFailover")]
        string HighAvailabilityState { get;  }
        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"Indicates whether custom window is enabled or disabled.",
        SerializedName = @"customWindow",
        PossibleTypes = new [] { typeof(string) })]
        string MaintenanceWindowCustomWindow { get; set; }
        /// <summary>Day of the week to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"Day of the week to be used for maintenance window.",
        SerializedName = @"dayOfWeek",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowDayOfWeek { get; set; }
        /// <summary>Start hour to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"Start hour to be used for maintenance window.",
        SerializedName = @"startHour",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowStartHour { get; set; }
        /// <summary>Start minute to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"Start minute to be used for maintenance window.",
        SerializedName = @"startMinute",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowStartMinute { get; set; }
        /// <summary>Minor version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Minor version of PostgreSQL database engine.",
        SerializedName = @"minorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string MinorVersion { get;  }
        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"delegatedSubnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkDelegatedSubnetResourceId { get; set; }
        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"privateDnsZoneArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkPrivateDnsZoneArmResourceId { get; set; }
        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into a virtual network which is owned and provided by customer when server is deployed.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string NetworkPublicNetworkAccess { get; set; }
        /// <summary>
        /// Creation time (in ISO8601 format) of the backup which you want to restore in the new server. It's required when 'createMode'
        /// is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = false,
        Description = @"Creation time (in ISO8601 format) of the backup which you want to restore in the new server. It's required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'.",
        SerializedName = @"pointInTimeUTC",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PointInTimeUtc { get; set; }
        /// <summary>List of private endpoint connections associated with the specified server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of private endpoint connections associated with the specified server.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get;  }
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Maximum number of read replicas allowed for a server.",
        SerializedName = @"replicaCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicaCapacity { get;  }
        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover means that the read replica will roles with the primary server.",
        SerializedName = @"promoteMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Standalone", "Switchover")]
        string ReplicaPromoteMode { get; set; }
        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Data synchronization option to use when processing the operation specified in the promoteMode property. This property is write only.",
        SerializedName = @"promoteOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Planned", "Forced")]
        string ReplicaPromoteOption { get; set; }
        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates the replication state of a read replica. This property is returned only when the target server is a read replica. Possible  values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating",
        SerializedName = @"replicationState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicaReplicationState { get;  }
        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
        Update = true,
        Description = @"Role of the server in a replication set.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string ReplicaRole { get; set; }
        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Role of the server in a replication set.",
        SerializedName = @"replicationRole",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string ReplicationRole { get; set; }
        /// <summary>
        /// Identifier of the server to be used as the source of the new server. Required when 'createMode' is 'PointInTimeRestore',
        /// 'GeoRestore', 'Replica', or 'ReviveDropped'. This property is returned only when the target server is a read replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Identifier of the server to be used as the source of the new server. Required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', 'Replica', or 'ReviveDropped'. This property is returned only when the target server is a read replica.",
        SerializedName = @"sourceServerResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceServerResourceId { get; set; }
        /// <summary>Possible states of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Possible states of a server.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Ready", "Dropping", "Disabled", "Starting", "Stopping", "Stopped", "Updating", "Restarting", "Inaccessible", "Provisioning")]
        string State { get;  }
        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions allow for automatically growing storage size.",
        SerializedName = @"autoGrow",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string StorageAutoGrow { get; set; }
        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"iops",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageIop { get; set; }
        /// <summary>Size of storage assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Size of storage assigned to a server.",
        SerializedName = @"storageSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageSizeGb { get; set; }
        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.",
        SerializedName = @"throughput",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageThroughput { get; set; }
        /// <summary>Storage tier of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Storage tier of a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("P1", "P2", "P3", "P4", "P6", "P10", "P15", "P20", "P30", "P40", "P50", "P60", "P70", "P80")]
        string StorageTier { get; set; }
        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified, it defaults to Premium_LRS.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Premium_LRS", "PremiumV2_LRS", "UltraSSD_LRS")]
        string StorageType { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Major version of PostgreSQL database engine.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("18", "17", "16", "15", "14", "13", "12", "11")]
        string Version { get; set; }

    }
    /// Properties of a server.
    internal partial interface IServerPropertiesInternal

    {
        /// <summary>
        /// Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be
        /// specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot
        /// be changed for the rest of the life of a server. If you disable password based authentication on a server which had it
        /// enabled, this password based role isn't deleted.
        /// </summary>
        string AdministratorLogin { get; set; }
        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        System.Security.SecureString AdministratorLoginPassword { get; set; }
        /// <summary>Authentication configuration properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig AuthConfig { get; set; }
        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AuthConfigActiveDirectoryAuth { get; set; }
        /// <summary>Indicates if the server supports password based authentication.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string AuthConfigPasswordAuth { get; set; }
        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        string AuthConfigTenantId { get; set; }
        /// <summary>Availability zone of a server.</summary>
        string AvailabilityZone { get; set; }
        /// <summary>Backup properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackup Backup { get; set; }
        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        global::System.DateTime? BackupEarliestRestoreDate { get; set; }
        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BackupGeoRedundantBackup { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? BackupRetentionDay { get; set; }
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        int? Capacity { get; set; }
        /// <summary>Cluster properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster Cluster { get; set; }
        /// <summary>Default database name for the elastic cluster.</summary>
        string ClusterDefaultDatabaseName { get; set; }
        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        int? ClusterSize { get; set; }
        /// <summary>Creation mode of a new server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Default", "Create", "Update", "PointInTimeRestore", "GeoRestore", "Replica", "ReviveDropped")]
        string CreateMode { get; set; }
        /// <summary>Data encryption properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption DataEncryption { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string DataEncryptionGeoBackupEncryptionKeyStatus { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        string DataEncryptionGeoBackupKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        string DataEncryptionGeoBackupUserAssignedIdentityId { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string DataEncryptionPrimaryEncryptionKeyStatus { get; set; }
        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        string DataEncryptionPrimaryKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        string DataEncryptionPrimaryUserAssignedIdentityId { get; set; }
        /// <summary>Data encryption type used by a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("SystemManaged", "AzureKeyVault")]
        string DataEncryptionType { get; set; }
        /// <summary>Fully qualified domain name of a server.</summary>
        string FullyQualifiedDomainName { get; set; }
        /// <summary>High availability properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailability HighAvailability { get; set; }
        /// <summary>High availability mode for a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Disabled", "ZoneRedundant", "SameZone")]
        string HighAvailabilityMode { get; set; }
        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        string HighAvailabilityStandbyAvailabilityZone { get; set; }
        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("NotEnabled", "CreatingStandby", "ReplicatingData", "FailingOver", "Healthy", "RemovingStandby", "RecreatingStandby", "ComputeUpdatingByFailover")]
        string HighAvailabilityState { get; set; }
        /// <summary>Maintenance window properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow MaintenanceWindow { get; set; }
        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        string MaintenanceWindowCustomWindow { get; set; }
        /// <summary>Day of the week to be used for maintenance window.</summary>
        int? MaintenanceWindowDayOfWeek { get; set; }
        /// <summary>Start hour to be used for maintenance window.</summary>
        int? MaintenanceWindowStartHour { get; set; }
        /// <summary>Start minute to be used for maintenance window.</summary>
        int? MaintenanceWindowStartMinute { get; set; }
        /// <summary>Minor version of PostgreSQL database engine.</summary>
        string MinorVersion { get; set; }
        /// <summary>
        /// Network properties of a server. Only required if you want your server to be integrated into a virtual network provided
        /// by customer.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork Network { get; set; }
        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        string NetworkDelegatedSubnetResourceId { get; set; }
        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        string NetworkPrivateDnsZoneArmResourceId { get; set; }
        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string NetworkPublicNetworkAccess { get; set; }
        /// <summary>
        /// Creation time (in ISO8601 format) of the backup which you want to restore in the new server. It's required when 'createMode'
        /// is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'.
        /// </summary>
        global::System.DateTime? PointInTimeUtc { get; set; }
        /// <summary>List of private endpoint connections associated with the specified server.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get; set; }
        /// <summary>
        /// Read replica properties of a server. Required only in case that you want to promote a server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica Replica { get; set; }
        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        int? ReplicaCapacity { get; set; }
        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Standalone", "Switchover")]
        string ReplicaPromoteMode { get; set; }
        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Planned", "Forced")]
        string ReplicaPromoteOption { get; set; }
        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicaReplicationState { get; set; }
        /// <summary>Role of the server in a replication set.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string ReplicaRole { get; set; }
        /// <summary>Role of the server in a replication set.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "Primary", "AsyncReplica", "GeoAsyncReplica")]
        string ReplicationRole { get; set; }
        /// <summary>
        /// Identifier of the server to be used as the source of the new server. Required when 'createMode' is 'PointInTimeRestore',
        /// 'GeoRestore', 'Replica', or 'ReviveDropped'. This property is returned only when the target server is a read replica.
        /// </summary>
        string SourceServerResourceId { get; set; }
        /// <summary>Possible states of a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Ready", "Dropping", "Disabled", "Starting", "Stopping", "Stopped", "Updating", "Restarting", "Inaccessible", "Provisioning")]
        string State { get; set; }
        /// <summary>Storage properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage Storage { get; set; }
        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string StorageAutoGrow { get; set; }
        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        int? StorageIop { get; set; }
        /// <summary>Size of storage assigned to a server.</summary>
        int? StorageSizeGb { get; set; }
        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        int? StorageThroughput { get; set; }
        /// <summary>Storage tier of a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("P1", "P2", "P3", "P4", "P6", "P10", "P15", "P20", "P30", "P40", "P50", "P60", "P70", "P80")]
        string StorageTier { get; set; }
        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Premium_LRS", "PremiumV2_LRS", "UltraSSD_LRS")]
        string StorageType { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("18", "17", "16", "15", "14", "13", "12", "11")]
        string Version { get; set; }

    }
}