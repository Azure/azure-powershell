### Example 1: Create a new flexible server
```powershell
$example-administrator-password = Read-Host "Enter admin password" -AsSecureString
>> New-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -Name example-server -Location example-location -AdministratorLogin example-administrator-login -AdministratorLoginPassword $example-administrator-password -AuthConfigPasswordAuth Enabled -AuthConfigActiveDirectoryAuth Disabled -AvailabilityZone 2 -BackupGeoRedundantBackup Disabled -HighAvailabilityMode Enabled -Version 18 -SkuTier GeneralPurpose -SkuName Standard_D2ads_v5 -StorageSizeGb 32 -CreateMode Create
```

```output
AdministratorLogin                            : example-administrator-login
AdministratorLoginPassword                    : 
AuthConfigActiveDirectoryAuth                 : Disabled
AuthConfigPasswordAuth                        : Enabled
AuthConfigTenantId                            : 
AvailabilityZone                              : 2
BackupEarliestRestoreDate                     : 
BackupGeoRedundantBackup                      : Disabled
BackupRetentionDay                            : 7
Capacity                                      : 6
ClusterDefaultDatabaseName                    : 
ClusterSize                                   : 
CreateMode                                    : 
DataEncryptionGeoBackupEncryptionKeyStatus    : 
DataEncryptionGeoBackupKeyUri                 : 
DataEncryptionGeoBackupUserAssignedIdentityId : 
DataEncryptionPrimaryEncryptionKeyStatus      : 
DataEncryptionPrimaryKeyUri                   : 
DataEncryptionPrimaryUserAssignedIdentityId   : 
DataEncryptionType                            : SystemManaged
FullyQualifiedDomainName                      : example-server.postgres.database.azure.com
HighAvailabilityMode                          : Disabled
HighAvailabilityStandbyAvailabilityZone       : 
HighAvailabilityState                         : NotEnabled
Id                                            : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server
IdentityPrincipalId                           : 
IdentityTenantId                              : 
IdentityType                                  : 
IdentityUserAssignedIdentity                  : {
                                                }
Location                                      : example-location
MaintenanceWindowCustomWindow                 : Disabled
MaintenanceWindowDayOfWeek                    : 0
MaintenanceWindowStartHour                    : 0
MaintenanceWindowStartMinute                  : 0
MinorVersion                                  : 9
Name                                          : example-server
NetworkDelegatedSubnetResourceId              : 
NetworkPrivateDnsZoneArmResourceId            : 
NetworkPublicNetworkAccess                    : Enabled
PointInTimeUtc                                : 
PrivateEndpointConnection                     : {}
ReplicaCapacity                               : 6
ReplicaPromoteMode                            : 
ReplicaPromoteOption                          : 
ReplicaReplicationState                       : 
ReplicaRole                                   : Primary
ReplicationRole                               : Primary
ResourceGroupName                             : example-resource-group
SkuName                                       : Standard_D2ads_v5
SkuTier                                       : GeneralPurpose
SourceServerResourceId                        : 
State                                         : Ready
StorageAutoGrow                               : Disabled
StorageIop                                    : 120
StorageSizeGb                                 : 32
StorageThroughput                             : 
StorageTier                                   : P4
StorageType                                   : 
SystemDataCreatedAt                           : 3/22/2026 11:50:44 AM
SystemDataCreatedBy                           : 
SystemDataCreatedByType                       : 
SystemDataLastModifiedAt                      : 
SystemDataLastModifiedBy                      : 
SystemDataLastModifiedByType                  : 
Tag                                           : {
                                                }
Type                                          : Microsoft.DBforPostgreSQL/flexibleServers
Version                                       : 18
```

Creates a new Azure Database for PostgreSQL flexible server with a specific configuration. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Create a new flexible server elastic cluster
```powershell
$example-administrator-password = Read-Host "Enter admin password" -AsSecureString
>> New-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -Name example-server -Location example-location -AdministratorLogin example-administrator-login -AdministratorLoginPassword $example-administrator-password -AuthConfigPasswordAuth Enabled -AuthConfigActiveDirectoryAuth Disabled -AvailabilityZone 2 -BackupGeoRedundantBackup Disabled -HighAvailabilityMode Enabled -Version 18 -SkuTier GeneralPurpose -SkuName Standard_D2ads_v5 -StorageSizeGb 32 -ClusterSize 2 -ClusterDefaultDatabaseName example-default-database -CreateMode Create
```

```output
AdministratorLogin                            : example-administrator-login
AdministratorLoginPassword                    : 
AuthConfigActiveDirectoryAuth                 : Disabled
AuthConfigPasswordAuth                        : Enabled
AuthConfigTenantId                            : 
AvailabilityZone                              : 2
BackupEarliestRestoreDate                     : 
BackupGeoRedundantBackup                      : Disabled
BackupRetentionDay                            : 7
Capacity                                      : 6
ClusterDefaultDatabaseName                    : example-default-database
ClusterSize                                   : 2
CreateMode                                    : 
DataEncryptionGeoBackupEncryptionKeyStatus    : 
DataEncryptionGeoBackupKeyUri                 : 
DataEncryptionGeoBackupUserAssignedIdentityId : 
DataEncryptionPrimaryEncryptionKeyStatus      : 
DataEncryptionPrimaryKeyUri                   : 
DataEncryptionPrimaryUserAssignedIdentityId   : 
DataEncryptionType                            : SystemManaged
FullyQualifiedDomainName                      : example-server.postgres.database.azure.com
HighAvailabilityMode                          : Disabled
HighAvailabilityStandbyAvailabilityZone       : 
HighAvailabilityState                         : NotEnabled
Id                                            : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server
IdentityPrincipalId                           : 
IdentityTenantId                              : 
IdentityType                                  : 
IdentityUserAssignedIdentity                  : {
                                                }
Location                                      : example-location
MaintenanceWindowCustomWindow                 : Disabled
MaintenanceWindowDayOfWeek                    : 0
MaintenanceWindowStartHour                    : 0
MaintenanceWindowStartMinute                  : 0
MinorVersion                                  : 9
Name                                          : example-server
NetworkDelegatedSubnetResourceId              : 
NetworkPrivateDnsZoneArmResourceId            : 
NetworkPublicNetworkAccess                    : Enabled
PointInTimeUtc                                : 
PrivateEndpointConnection                     : {}
ReplicaCapacity                               : 6
ReplicaPromoteMode                            : 
ReplicaPromoteOption                          : 
ReplicaReplicationState                       : 
ReplicaRole                                   : Primary
ReplicationRole                               : Primary
ResourceGroupName                             : example-resource-group
SkuName                                       : Standard_D2ads_v5
SkuTier                                       : GeneralPurpose
SourceServerResourceId                        : 
State                                         : Ready
StorageAutoGrow                               : Disabled
StorageIop                                    : 120
StorageSizeGb                                 : 32
StorageThroughput                             : 
StorageTier                                   : P4
StorageType                                   : 
SystemDataCreatedAt                           : 3/22/2026 11:50:44 AM
SystemDataCreatedBy                           : 
SystemDataCreatedByType                       : 
SystemDataLastModifiedAt                      : 
SystemDataLastModifiedBy                      : 
SystemDataLastModifiedByType                  : 
Tag                                           : {
                                                }
Type                                          : Microsoft.DBforPostgreSQL/flexibleServers
Version                                       : 18
```

Creates a new Azure Database for PostgreSQL flexible server elastic cluster with a specific configuration. If subscription is not passed explicitly, it's taken from default context.

### Example 3: Restore a backup of an existing flexible server onto a new flexible server
```powershell
$example-administrator-password = Read-Host "Enter admin password" -AsSecureString
>> New-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -Name example-server -Location example-location -AdministratorLogin example-administrator-login -AdministratorLoginPassword $example-administrator-password -AuthConfigPasswordAuth Enabled -AuthConfigActiveDirectoryAuth Disabled -AvailabilityZone 2 -BackupGeoRedundantBackup Disabled -HighAvailabilityMode Enabled -Version 18 -SkuTier GeneralPurpose -SkuName Standard_D2ads_v5 -StorageSizeGb 32 -PointInTimeUtc 2026-05-23T00:00:00.000Z -SourceServerResourceId /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-restore-server -CreateMode PointInTimeRestore
```

```output
AdministratorLogin                            : example-administrator-login
AdministratorLoginPassword                    : 
AuthConfigActiveDirectoryAuth                 : Disabled
AuthConfigPasswordAuth                        : Enabled
AuthConfigTenantId                            : 
AvailabilityZone                              : 2
BackupEarliestRestoreDate                     : 
BackupGeoRedundantBackup                      : Disabled
BackupRetentionDay                            : 7
Capacity                                      : 6
ClusterDefaultDatabaseName                    : 
ClusterSize                                   : 
CreateMode                                    : 
DataEncryptionGeoBackupEncryptionKeyStatus    : 
DataEncryptionGeoBackupKeyUri                 : 
DataEncryptionGeoBackupUserAssignedIdentityId : 
DataEncryptionPrimaryEncryptionKeyStatus      : 
DataEncryptionPrimaryKeyUri                   : 
DataEncryptionPrimaryUserAssignedIdentityId   : 
DataEncryptionType                            : SystemManaged
FullyQualifiedDomainName                      : example-restore-server.postgres.database.azure.com
HighAvailabilityMode                          : Disabled
HighAvailabilityStandbyAvailabilityZone       : 
HighAvailabilityState                         : NotEnabled
Id                                            : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-restore-server
IdentityPrincipalId                           : 
IdentityTenantId                              : 
IdentityType                                  : 
IdentityUserAssignedIdentity                  : {
                                                }
Location                                      : example-location
MaintenanceWindowCustomWindow                 : Disabled
MaintenanceWindowDayOfWeek                    : 0
MaintenanceWindowStartHour                    : 0
MaintenanceWindowStartMinute                  : 0
MinorVersion                                  : 9
Name                                          : example-restore-server
NetworkDelegatedSubnetResourceId              : 
NetworkPrivateDnsZoneArmResourceId            : 
NetworkPublicNetworkAccess                    : Enabled
PointInTimeUtc                                : 
PrivateEndpointConnection                     : {}
ReplicaCapacity                               : 6
ReplicaPromoteMode                            : 
ReplicaPromoteOption                          : 
ReplicaReplicationState                       : 
ReplicaRole                                   : Primary
ReplicationRole                               : Primary
ResourceGroupName                             : example-resource-group
SkuName                                       : Standard_D2ads_v5
SkuTier                                       : GeneralPurpose
SourceServerResourceId                        : 
State                                         : Ready
StorageAutoGrow                               : Disabled
StorageIop                                    : 120
StorageSizeGb                                 : 32
StorageThroughput                             : 
StorageTier                                   : P4
StorageType                                   : 
SystemDataCreatedAt                           : 3/22/2026 11:50:44 AM
SystemDataCreatedBy                           : 
SystemDataCreatedByType                       : 
SystemDataLastModifiedAt                      : 
SystemDataLastModifiedBy                      : 
SystemDataLastModifiedByType                  : 
Tag                                           : {
                                                }
Type                                          : Microsoft.DBforPostgreSQL/flexibleServers
Version                                       : 18
```

Restores a backup of an existing Azure Database for PostgreSQL flexible server onto a new server with its own specific configuration. If subscription is not passed explicitly, it's taken from default context.
