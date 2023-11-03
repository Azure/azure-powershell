### Example 1: Export database to file
```powershell
Export-AzRedisEnterpriseCache -Name "MyCache" -ResourceGroupName "MyGroup" -SasUri "https://mystorageaccount.blob.core.windows.net/mycontainer?sp=signedPermissions&se=signedExpiry&sv=signedVersion&sr=signedResource&sig=signature;mystoragekey"
```

This command exports the database of the Redis Enterprise cache named MyCache to a database file.

