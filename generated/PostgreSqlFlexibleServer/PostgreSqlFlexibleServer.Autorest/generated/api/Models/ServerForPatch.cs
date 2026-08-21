// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Represents a server to be updated.</summary>
    public partial class ServerForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal
    {

        /// <summary>
        /// Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be
        /// specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot
        /// be changed for the rest of the life of a server. If you disable password based authentication on a server which had it
        /// enabled, this password based role isn't deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AdministratorLogin { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AdministratorLogin; }

        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdministratorLoginPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AdministratorLoginPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AdministratorLoginPassword = value ?? null; }

        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigActiveDirectoryAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigActiveDirectoryAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigActiveDirectoryAuth = value ?? null; }

        /// <summary>Indicates if the server supports password based authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigPasswordAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigPasswordAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigPasswordAuth = value ?? null; }

        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AuthConfigTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfigTenantId = value ?? null; }

        /// <summary>Availability zone of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AvailabilityZone = value ?? null; }

        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupEarliestRestoreDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupEarliestRestoreDate; }

        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string BackupGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupGeoRedundantBackup; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? BackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupRetentionDay = value ?? default(int); }

        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ClusterDefaultDatabaseName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ClusterDefaultDatabaseName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ClusterDefaultDatabaseName = value ?? null; }

        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ClusterSize = value ?? default(int); }

        /// <summary>Update mode of an existing server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).CreateMode = value ?? null; }

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupEncryptionKeyStatus; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupKeyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupKeyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupKeyUri = value ?? null; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionGeoBackupUserAssignedIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupUserAssignedIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupUserAssignedIdentityId = value ?? null; }

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryEncryptionKeyStatus; }

        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryKeyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryKeyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryKeyUri = value ?? null; }

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionPrimaryUserAssignedIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryUserAssignedIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryUserAssignedIdentityId = value ?? null; }

        /// <summary>Data encryption type used by a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataEncryptionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionType = value ?? null; }

        /// <summary>High availability mode for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityMode = value ?? null; }

        /// <summary>
        /// Availability zone associated to the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityStandbyAvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityStandbyAvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityStandbyAvailabilityZone = value ?? null; }

        /// <summary>
        /// Possible states of the standby server created when high availability is set to SameZone or ZoneRedundant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string HighAvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityState; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity _identity;

        /// <summary>Describes the identity of the application.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentity()); set => this._identity = value; }

        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>Identifier of the tenant of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).TenantId; }

        /// <summary>Types of identities associated with a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>Map of user assigned managed identities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).UserAssignedIdentities; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).UserAssignedIdentities = value ?? null /* model class */; }

        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string MaintenanceWindowCustomWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowCustomWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowCustomWindow = value ?? null; }

        /// <summary>Day of the week to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowDayOfWeek { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowDayOfWeek; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowDayOfWeek = value ?? default(int); }

        /// <summary>Start hour to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowStartHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowStartHour = value ?? default(int); }

        /// <summary>Start minute to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowStartMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindowStartMinute = value ?? default(int); }

        /// <summary>Internal Acessors for AdministratorLogin</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.AdministratorLogin { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AdministratorLogin; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AdministratorLogin = value ?? null; }

        /// <summary>Internal Acessors for AuthConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.AuthConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).AuthConfig = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Backup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Backup; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Backup = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BackupEarliestRestoreDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.BackupEarliestRestoreDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupEarliestRestoreDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupEarliestRestoreDate = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for BackupGeoRedundantBackup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.BackupGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupGeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).BackupGeoRedundantBackup = value ?? null; }

        /// <summary>Internal Acessors for Cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Cluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Cluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Cluster = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DataEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.DataEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DataEncryptionGeoBackupEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.DataEncryptionGeoBackupEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupEncryptionKeyStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionGeoBackupEncryptionKeyStatus = value ?? null; }

        /// <summary>Internal Acessors for DataEncryptionPrimaryEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.DataEncryptionPrimaryEncryptionKeyStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryEncryptionKeyStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).DataEncryptionPrimaryEncryptionKeyStatus = value ?? null; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.HighAvailability { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailability; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailability = value ?? null /* model class */; }

        /// <summary>Internal Acessors for HighAvailabilityState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.HighAvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).HighAvailabilityState = value ?? null; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.UserAssignedIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityInternal)Identity).TenantId = value ?? null; }

        /// <summary>Internal Acessors for MaintenanceWindow</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.MaintenanceWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).MaintenanceWindow = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Network</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Network { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Network; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Network = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesForPatch()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Replica</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IReplica Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Replica { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Replica; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Replica = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ReplicaCapacity</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.ReplicaCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaCapacity = value ?? default(int); }

        /// <summary>Internal Acessors for ReplicaReplicationState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.ReplicaReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaReplicationState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaReplicationState = value ?? null; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuForPatch()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Storage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorage Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchInternal.Storage { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Storage; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Storage = value ?? null /* model class */; }

        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkDelegatedSubnetResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkDelegatedSubnetResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkDelegatedSubnetResourceId = value ?? null; }

        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkPrivateDnsZoneArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkPrivateDnsZoneArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkPrivateDnsZoneArmResourceId = value ?? null; }

        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string NetworkPublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkPublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).NetworkPublicNetworkAccess = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch _property;

        /// <summary>Properties of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerPropertiesForPatch()); set => this._property = value; }

        /// <summary>Maximum number of read replicas allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? ReplicaCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaCapacity; }

        /// <summary>
        /// Type of operation to apply on the read replica. This property is write only. Standalone means that the read replica will
        /// be promoted to a standalone server, and will become a completely independent entity from the replication set. Switchover
        /// means that the read replica will roles with the primary server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaPromoteMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaPromoteMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaPromoteMode = value ?? null; }

        /// <summary>
        /// Data synchronization option to use when processing the operation specified in the promoteMode property. This property
        /// is write only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaPromoteOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaPromoteOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaPromoteOption = value ?? null; }

        /// <summary>
        /// Indicates the replication state of a read replica. This property is returned only when the target server is a read replica.
        /// Possible values are Active, Broken, Catchup, Provisioning, Reconfiguring, and Updating
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaReplicationState; }

        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicaRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicaRole = value ?? null; }

        /// <summary>Role of the server in a replication set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ReplicationRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicationRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).ReplicationRole = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch _sku;

        /// <summary>Compute tier and size of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SkuForPatch()); set => this._sku = value; }

        /// <summary>Name by which is known a given compute size assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatchInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatchInternal)Sku).Name = value ?? null; }

        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatchInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatchInternal)Sku).Tier = value ?? null; }

        /// <summary>
        /// Flag to enable or disable the automatic growth of storage size of a server when available space is nearing zero and conditions
        /// allow for automatically growing storage size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageAutoGrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageAutoGrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageAutoGrow = value ?? null; }

        /// <summary>
        /// Maximum IOPS supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageIop { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageIop; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageIop = value ?? default(int); }

        /// <summary>Size of storage assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageSizeGb = value ?? default(int); }

        /// <summary>
        /// Maximum throughput supported for storage. Required when type of storage is PremiumV2_LRS or UltraSSD_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int? StorageThroughput { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageThroughput; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageThroughput = value ?? default(int); }

        /// <summary>Storage tier of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageTier = value ?? null; }

        /// <summary>
        /// Type of storage assigned to a server. Allowed values are Premium_LRS, PremiumV2_LRS, or UltraSSD_LRS. If not specified,
        /// it defaults to Premium_LRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string StorageType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).StorageType = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags _tag;

        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerForPatchTags()); set => this._tag = value; }

        /// <summary>Major version of PostgreSQL database engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatchInternal)Property).Version = value ?? null; }

        /// <summary>Creates an new <see cref="ServerForPatch" /> instance.</summary>
        public ServerForPatch()
        {

        }
    }
    /// Represents a server to be updated.
    public partial interface IServerForPatch :
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot be changed for the rest of the life of a server. If you disable password based authentication on a server which had it enabled, this password based role isn't deleted.",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get;  }
        /// <summary>
        /// Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed
        /// at any time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
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
        Update = true,
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
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if the server is configured to create geographically redundant backups.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BackupGeoRedundantBackup { get;  }
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
        /// <summary>Default database name for the elastic cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = false,
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
        Create = false,
        Update = true,
        Description = @"Number of nodes assigned to the elastic cluster.",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterSize { get; set; }
        /// <summary>Update mode of an existing server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Update mode of an existing server.",
        SerializedName = @"createMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Default", "Update")]
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
        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the object of the service principal associated to the user assigned managed identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get; set; }
        /// <summary>Identifier of the tenant of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifier of the tenant of a server.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>Types of identities associated with a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Types of identities associated with a server.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "UserAssigned", "SystemAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>Map of user assigned managed identities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Map of user assigned managed identities.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>Name by which is known a given compute size assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name by which is known a given compute size assigned to a server.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Tier of the compute assigned to a server.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SkuTier { get; set; }
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Application-specific metadata in the form of key-value pairs.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags Tag { get; set; }
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
    /// Represents a server to be updated.
    internal partial interface IServerForPatchInternal

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
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigForPatch AuthConfig { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatch Backup { get; set; }
        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        global::System.DateTime? BackupEarliestRestoreDate { get; set; }
        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string BackupGeoRedundantBackup { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? BackupRetentionDay { get; set; }
        /// <summary>Cluster properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICluster Cluster { get; set; }
        /// <summary>Default database name for the elastic cluster.</summary>
        string ClusterDefaultDatabaseName { get; set; }
        /// <summary>Number of nodes assigned to the elastic cluster.</summary>
        int? ClusterSize { get; set; }
        /// <summary>Update mode of an existing server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Default", "Update")]
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
        /// <summary>High availability properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IHighAvailabilityForPatch HighAvailability { get; set; }
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
        /// <summary>Describes the identity of the application.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentity Identity { get; set; }
        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>Identifier of the tenant of a server.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>Types of identities associated with a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("None", "UserAssigned", "SystemAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>Map of user assigned managed identities.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserAssignedIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Maintenance window properties of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowForPatch MaintenanceWindow { get; set; }
        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        string MaintenanceWindowCustomWindow { get; set; }
        /// <summary>Day of the week to be used for maintenance window.</summary>
        int? MaintenanceWindowDayOfWeek { get; set; }
        /// <summary>Start hour to be used for maintenance window.</summary>
        int? MaintenanceWindowStartHour { get; set; }
        /// <summary>Start minute to be used for maintenance window.</summary>
        int? MaintenanceWindowStartMinute { get; set; }
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
        /// <summary>Properties of the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerPropertiesForPatch Property { get; set; }
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
        /// <summary>Compute tier and size of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISkuForPatch Sku { get; set; }
        /// <summary>Name by which is known a given compute size assigned to a server.</summary>
        string SkuName { get; set; }
        /// <summary>Tier of the compute assigned to a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Burstable", "GeneralPurpose", "MemoryOptimized")]
        string SkuTier { get; set; }
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerForPatchTags Tag { get; set; }
        /// <summary>Major version of PostgreSQL database engine.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("18", "17", "16", "15", "14", "13", "12", "11")]
        string Version { get; set; }

    }
}