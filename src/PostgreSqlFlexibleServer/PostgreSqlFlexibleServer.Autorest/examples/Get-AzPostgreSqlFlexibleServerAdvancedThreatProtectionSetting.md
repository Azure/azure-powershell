### Example 1: Get the advanced threat protection setting in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerAdvancedThreatProtectionSetting -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name       State      CreationTime
----       -----      ------------
Default    Enabled    3/22/2026 3:10:50 AM
```

Gets the advanced protection setting in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
