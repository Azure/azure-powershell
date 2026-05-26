### Example 1: Remove one one demmand backup in a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServerBackupsAutomaticAndOnDemand -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server --Name example-on-demand-backup
```

```output
```

Removes one on demand backup in an Azure Database for PostgreSQL flexible server with backup name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
