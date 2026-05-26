### Example 1: Change the administrator login password in a flexible server
```powershell
$exampleAdministratorPassword = Read-Host "Enter admin password" -AsSecureString
<<<<<<< HEAD
New-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -Name example-server -Location example-location -AdministratorLoginPassword $exampleAdministratorPassword -CreateMode Update
=======
New-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -Name example-server -Location example-location -AdministratorLoginPassword $exampleAdministratorPassword -CreateMode Update
>>>>>>> 15f018d78f3a5ebd1cabcfc830b54ee117a67146
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

Changes the administrator login password in an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
