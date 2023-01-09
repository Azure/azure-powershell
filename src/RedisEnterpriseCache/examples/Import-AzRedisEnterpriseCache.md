### Example 1: Import database from file
```powershell
Import-AzRedisEnterpriseCache -ClusterName "MyCache1" -ResourceGroupName "MyGroup" -SasUri @("<sas-uri>")
```

This command imports data from a database file into the database of the Redis Enterprise cache named MyCache.

