### Example 1: Get database access keys
```powershell
PS C:\> Get-AzRedisEnterpriseCacheKey -Name "MyCache" -ResourceGroupName "MyGroup"

PrimaryKey                                   SecondaryKey
----------                                   ------------
primary-key                                  secondary-key

```

This command gets the secret access keys used for authenticating connections to the database of the Redis Enterprise cache named MyCache.
