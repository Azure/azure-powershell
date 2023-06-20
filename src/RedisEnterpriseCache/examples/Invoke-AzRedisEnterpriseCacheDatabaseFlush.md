### Example 1: Flush Cache
```powershell
Invoke-AzRedisEnterpriseCacheDatabaseFlush -ClusterName "MyCache" -ResourceGroupName "MyResourceGroup" -Id @("Mydatabase1") , @("MyLinkedDatabase1")
```

## DESCRIPTION
Flushes all the keys in this database and also from its linked databases.
