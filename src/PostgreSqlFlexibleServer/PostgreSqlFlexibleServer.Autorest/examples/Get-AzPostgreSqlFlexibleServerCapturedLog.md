### Example 1: List all captured logs in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerCapturedLog -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                                     PropertiesType  SizeInKb   Url
----                                     --------------  --------   ---
postgresql_2026_03_22_10_00_00.log       ServerLogs      253        https://d8df7342e197sa.blob.core.windows.net/54d8e1fb40ba40…
postgresql_2026_03_22_11_00_00.log       ServerLogs      466        https://d8df7342e197sa.blob.core.windows.net/54d8e1fb40ba40…
postgresql_2026_03_22_12_00_00.log       ServerLogs      459        https://d8df7342e197sa.blob.core.windows.net/54d8e1fb40ba40…
```

Lists all captured logs in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
