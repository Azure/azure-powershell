### Example 1: Cancel an active migration in a flexible server
```powershell
Stop-AzPostgreSqlFlexibleServerMigration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName server-name -Name example-migration
```

```output
AdminCredentialsSourceServerPassword        : 
AdminCredentialsTargetServerPassword        : 
Cancel                                      : 
CurrentStatusError                          : 
CurrentStatusState                          : InProgress
CurrentSubStateDetailCurrentSubState        : PerformingPreRequisiteSteps
CurrentSubStateDetailDbDetail               : {
                                              }
DbsToCancelMigrationOn                      : 
DbsToMigrate                                : {example-database}
DbsToTriggerCutoverOn                       : 
Id                                          : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/migrations/example-migration
InstanceResourceId                          : 
Location                                    : Canada Central
MigrateRole                                 : False
MigrationId                                 : 00000000-0000-0000-0000-000000000000
Mode                                        : Offline
Name                                        : example-migration
Option                                      : ValidateAndMigrate
OverwriteDbsInTarget                        : True
ResourceGroupName                           : example-resource-group
SecretParameterSourceServerUsername         : 
SecretParameterTargetServerUsername         : 
SetupLogicalReplicationOnSourceDbIfNeeded   : True
SourceDbServerFullyQualifiedDomainName      : 
SourceDbServerMetadataLocation              : 
SourceDbServerMetadataSkuName               : 
SourceDbServerMetadataSkuTier               : 
SourceDbServerMetadataStorageMb             : 
SourceDbServerMetadataVersion               : 
SourceDbServerResourceId                    : example-server.postgres.database.azure.com:5432@example-administrator-login
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
TargetDbServerMetadataLocation              : example-location
TargetDbServerMetadataSkuName               : Standard_D4ads_v5
TargetDbServerMetadataSkuTier               : GeneralPurpose
TargetDbServerMetadataStorageMb             : 131072
TargetDbServerMetadataVersion               : 18
TargetDbServerResourceId                    : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-migration
TriggerCutover                              : True
Type                                        : Microsoft.DBforPostgreSQL/flexibleServers/migrations
ValidationDetailDbLevelValidationDetail     : 
ValidationDetailServerLevelValidationDetail : 
ValidationDetailStatus                      : 
ValidationDetailValidationEndTimeInUtc      : 
ValidationDetailValidationStartTimeInUtc    : 
WindowEndTimeInUtc                          : 
WindowStartTimeInUtc                        : 3/22/2026 6:16:56 PM
```

Cancels an active migration in an Azure Database for PostgreSQL flexible server with migration name, server name, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
