### Example 1: Unlink database
```powershell
PS C:\> Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink -ResourceGroupName "MyGroup" -ClusterName "MyCache3" -Id @("<database-id>")
```

Forcibly removes the link to the database resource whose id is given, from the georeplication group the specified cache belongs to