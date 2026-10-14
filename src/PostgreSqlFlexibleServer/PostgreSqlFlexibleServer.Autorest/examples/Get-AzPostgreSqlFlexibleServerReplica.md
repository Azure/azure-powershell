### Example 1: List direct read replicas of a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerReplica -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                                     ResourceGroupName                        Location             SkuName              SkuTier         AdministratorLogin        StorageSizeGb
----                                     -----------------                        --------             -------              -------         ------------------        -------------
example-direct-read-replica-01           example-resource-group                   example-location                                                                    0
example-direct-read-replica-02           example-resource-group                   example-location                                                                    0
```

Lists Azure Database for PostgreSQL flexible servers which are direct read replicas of the flexible server with name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
