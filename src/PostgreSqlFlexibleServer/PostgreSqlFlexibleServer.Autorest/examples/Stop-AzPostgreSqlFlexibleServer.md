### Example 1: Stop PostgreSQL database engine in a flexible server
```powershell
Stop-AzPostgreSqlFlexibleServer -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
```

Stops an Azure Database for PostgreSQL flexible server that is in ready state. If subscription is not passed explicitly, it's taken from default context.
