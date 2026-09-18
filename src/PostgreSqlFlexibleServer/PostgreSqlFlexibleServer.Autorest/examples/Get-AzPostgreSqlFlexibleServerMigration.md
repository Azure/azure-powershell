### Example 1: List all migrations in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerMigration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -MigrationListFilter All
```

```output
Name                 CurrentStatusState CurrentStatusError   Option               MigrateRole SourceType TriggerCutover SourceDbServerResourceId  DbsToMigrate              OverwriteDbsInTarget      Mode
----                 ------------------ ------------------   ------               ----------- ---------- -------------- ------------------------  ------------              --------------------      ----
example-migration-01 ValidationFailed   An unexpected error… ValidateAndMigrate   False       OnPremises True           example-source-server.po… {database-01, postgres}   True                      Offline
example-migration-02 InProgress                              ValidateAndMigrate   False       OnPremises True           example-source-server.po… {database-01, postgres}   True                      Offline
```

Lists all migrations in an Azure Database for PostgreSQL flexible server with filter configured to retrieve active and inactive migrations, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context. If the migration filter is not passed, it defaults to active migration only.

### Example 1: List only active migration in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerMigration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -MigrationListFilter Active
```

```output
Name                 CurrentStatusState CurrentStatusError   Option               MigrateRole SourceType TriggerCutover SourceDbServerResourceId  DbsToMigrate              OverwriteDbsInTarget      Mode
----                 ------------------ ------------------   ------               ----------- ---------- -------------- ------------------------  ------------              --------------------      ----
example-migration-01 ValidationFailed   An unexpected error… ValidateAndMigrate   False       OnPremises True           example-source-server.po… {database-01, postgres}   True                      Offline
example-migration-02 InProgress                              ValidateAndMigrate   False       OnPremises True           example-source-server.po… {database-01, postgres}   True                      Offline
```

Lists only active migration in an Azure Database for PostgreSQL flexible server with filter configured to retrieve active migration only, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context. If the migration filter is not passed, it defaults to active migration only.
