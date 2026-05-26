### Example 1: Remove a Microsoft Entra administrator from a flexible server
```powershell
Remove-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -ObjectId 00000000-0000-0000-0000-000000000000
```

```output
```

Removes a Microsoft Entra administrator from an Azure Database for PostgreSQL flexible server that has Microsoft Entra authentication enabled. If subscription is not passed explicitly, it's taken from default context.
