### Example 1: Create a migration from a PostgreSQL server to a flexible server
```powershell
New-AzPostgreSqlFlexibleServerMigration -ResourceGroupName example-resource-group -ServerName example-target-server -Name example-migration -DbsToMigrate example-database-01,example-database-02 -Location example-location -MigrationMode Offline -MigrationOption Validate -SourceDbServerResourceId example-source-server-fully-qualified-domain-name:example-port@example-user -SourceType OnPremises
```

```output
AdminCredentialsSourceServerPassword        : 
AdminCredentialsTargetServerPassword        : 
Cancel                                      : 
CurrentStatusError                          : 
CurrentStatusState                          : InProgress
CurrentSubStateDetailCurrentSubState        : 
CurrentSubStateDetailDbDetail               : {
                                              }
DbsToCancelMigrationOn                      : 
DbsToMigrate                                : {daadsdasd, postgres}
DbsToTriggerCutoverOn                       : 
Id                                          : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-target-server/migrations/example-migration
InstanceResourceId                          : 
Location                                    : example-location
MigrateRole                                 : 
MigrationId                                 : 00000000-0000-0000-0000-000000000000
Mode                                        : Offline
Name                                        : example-migration
Option                                      : Validate
OverwriteDbsInTarget                        : True
ResourceGroupName                           : example-resource-group
SecretParameterSourceServerUsername         : 
SecretParameterTargetServerUsername         : 
SetupLogicalReplicationOnSourceDbIfNeeded   : 
SourceDbServerFullyQualifiedDomainName      : 
SourceDbServerMetadataLocation              : 
SourceDbServerMetadataSkuName               : 
SourceDbServerMetadataSkuTier               : 
SourceDbServerMetadataStorageMb             : 
SourceDbServerMetadataVersion               : 
SourceDbServerResourceId                    : example-source-server-fully-qualified-domain-name:example-port@example-user
SourceType                                  : OnPremises
SslMode                                     : Prefer
StartDataMigration                          : 
SystemDataCreatedAt                         : 
SystemDataCreatedBy                         : 
SystemDataCreatedByType                     : 
SystemDataLastModifiedAt                    : 
SystemDataLastModifiedBy                    : 
SystemDataLastModifiedByType                : 
Tag                                         : {
                                              }
TargetDbServerFullyQualifiedDomainName      : 
TargetDbServerMetadataLocation              : 
TargetDbServerMetadataSkuName               : 
TargetDbServerMetadataSkuTier               : 
TargetDbServerMetadataStorageMb             : 
TargetDbServerMetadataVersion               : 
TargetDbServerResourceId                    : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-target-server
TriggerCutover                              : True
Type                                        : Microsoft.DBforPostgreSQL/flexibleServers/migrations
ValidationDetailDbLevelValidationDetail     : 
ValidationDetailServerLevelValidationDetail : 
ValidationDetailStatus                      : 
ValidationDetailValidationEndTimeInUtc      : 
ValidationDetailValidationStartTimeInUtc    : 
WindowEndTimeInUtc                          : 
WindowStartTimeInUtc                        : 5/22/2026 9:45:51 AM
```

Creates a migration from a PostgreSQL server to an Azure Database for PostgreSQL flexible server.
