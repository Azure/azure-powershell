### Example 1: Get one database in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-database
```

```output
Name                                Charset         Collation
----                                -------         ---------
example-database                    UTF8            en_US.utf8
```

Gets one database in an Azure Database for PostgreSQL flexible server with database name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: List all databases in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerDatabase -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                                Charset         Collation
----                                -------         ---------
postgres                            UTF8            en_US.utf8
azure_maintenance                   UTF8            en_US.utf8
azure_sys                           UTF8            en_US.utf8
example-database                    UTF8            en_US.utf8
```

Lists all databases in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
