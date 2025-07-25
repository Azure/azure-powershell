### Example 1: How to relink a database after a regional outage
```powershell
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName "MyCache" -ResourceGroupName "MyResourceGroup" -DatabaseName "default" -GroupNickname "MyExistingGroup" -LinkedDatabase @(@{ResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Cache/RedisEnterprise/mycache/databases/default"},@{ResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Cache/RedisEnterprise/mycache/databases/MyLinkedDatabase2"})
```

Forcibly recreates the database given, and rejoins it to an existing replication group.


