### Example 1: Starts a stopped flexible server
```powershell
Start-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
```

Starts an Azure Database for PostgreSQL flexible server that is in stopped state. If subscription is not passed explicitly, it's taken from default context.
